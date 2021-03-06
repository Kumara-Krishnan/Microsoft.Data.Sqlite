// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SQLitePCL;
using Xunit;


namespace Microsoft.Data.Sqlite
{
    public class SqliteConcurrencyTest : IDisposable
    {
        private const string FileName = "concurrency.db";

        public SqliteConcurrencyTest()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS a (b);
INSERT INTO a VALUES (1);
INSERT INTO a VALUES (2);";
                command.ExecuteNonQuery();
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Multi_threaded_access_avoids_locking_and_busy(bool sharedCache)
        {
            var list = new List<Action>();
            for (var i = 0; i < 50; i++)
            {
                var copy_i = i;
                list.Add(() =>
                    {
                        using (var connection = CreateConnection(shared: sharedCache))
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandTimeout = 300;
                            if (copy_i % 2 == 0)
                            {
                                command.CommandText = "SELECT * FROM a;";
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                    }
                                }
                            }
                            else
                            {
                                command.CommandText = "INSERT INTO a VALUES (1);";
                                Assert.Equal(1, command.ExecuteNonQuery());
                            }
                        }
                    });
            }
            var tasks = list.Select(execute => Task.Factory.StartNew(execute)).ToArray();
            Task.WaitAll(tasks);
        }

        [Fact]
        public void It_throws_drop_table_deadlock()
        {
            using (var connection = CreateConnection())
            {
                var selectCommand = connection.CreateCommand();
                connection.Open();
                selectCommand.CommandText = "SELECT * FROM a;";

                var dropCommand = connection.CreateCommand();
                dropCommand.CommandTimeout = 1;
                dropCommand.CommandText = "DROP TABLE a;";

                using (var reader = selectCommand.ExecuteReader())
                {
                    reader.Read();
                    var ex = Assert.Throws<SqliteException>(() => dropCommand.ExecuteNonQuery());

                    Assert.Equal(raw.SQLITE_LOCKED, ex.SqliteErrorCode);
                    var message = raw.sqlite3_errmsg(connection.Handle);
                    Assert.Equal(Strings.SqliteNativeError(raw.SQLITE_LOCKED, message), ex.Message);
                }

                dropCommand.ExecuteNonQuery();
                Assert.Throws<SqliteException>(() => dropCommand.ExecuteNonQuery());
            }
        }

        [Fact]
        public void It_throws_sqlite_busy_on_deadlock()
        {
            using (var connection = CreateConnection())
            {
                var selectCommand = connection.CreateCommand();
                connection.Open();
                selectCommand.CommandText = "SELECT * FROM a;";
                using (var connection2 = CreateConnection())
                {
                    var dropCommand = connection2.CreateCommand();
                    dropCommand.CommandTimeout = 1;
                    connection2.Open();
                    dropCommand.CommandText = "DROP TABLE a;";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        reader.Read();
                        var ex = Assert.Throws<SqliteException>(() => dropCommand.ExecuteNonQuery());

                        Assert.Equal(raw.SQLITE_BUSY, ex.SqliteErrorCode);

                        var message = raw.sqlite3_errstr(raw.SQLITE_BUSY);
                        Assert.Equal(Strings.SqliteNativeError(raw.SQLITE_BUSY, message), ex.Message);
                    }

                    dropCommand.ExecuteNonQuery();
                    Assert.Throws<SqliteException>(() => dropCommand.ExecuteNonQuery());
                }
            }
        }

        [Fact]
        public void Prevents_timeout_exception()
        {
            using (var connection1 = CreateConnection())
            {
                using (var connection2 = CreateConnection())
                {
                    connection1.Open();
                    connection2.Open();

                    var selectCommand = connection1.CreateCommand();
                    selectCommand.CommandTimeout = 30;
                    selectCommand.CommandText = "SELECT * FROM a;";

                    var insertCommand = connection2.CreateCommand();
                    insertCommand.CommandTimeout = 10;
                    insertCommand.CommandText = "INSERT INTO a VALUES ( 1);";

                    var startRead = new ManualResetEventSlim(false);

                    var t1 = Task.Factory.StartNew(() =>
                        {
                            using (var reader = selectCommand.ExecuteReader())
                            {
                                startRead.Set();
                                Thread.Sleep(insertCommand.CommandTimeout * 1000 / 2); // delay task 2, but not beyond its timeout
                            }
                        });
                    var t2 = Task.Factory.StartNew(() =>
                    {
                        startRead.Wait();
                        insertCommand.ExecuteNonQuery();
                    });
                    Task.WaitAll(t1, t2);
                }
            }
        }

        [Fact]
        public void Command_times_out()
        {
            using (var connection1 = CreateConnection())
            {
                using (var connection2 = CreateConnection())
                {
                    connection1.Open();
                    connection2.Open();

                    var selectCommand = connection1.CreateCommand();
                    selectCommand.CommandText = "SELECT * FROM a;";

                    var insertCommand = connection2.CreateCommand();
                    insertCommand.CommandTimeout = 1;
                    insertCommand.CommandText = "INSERT INTO a VALUES ( 1);";

                    var waitHandle = new Semaphore(0, 1);
                    var beginRead = new Semaphore(0, 1);
                    var t1 = new Thread(() =>
                        {
                            using (var reader = selectCommand.ExecuteReader())
                            {
                                beginRead.Release();
                                waitHandle.WaitOne();
                            }
                        });
                    var t2 = new Thread(() =>
                        {
                            beginRead.WaitOne();
                            var ex = Assert.Throws<SqliteException>(() => insertCommand.ExecuteNonQuery());
                            waitHandle.Release();

                            Assert.Equal(raw.SQLITE_BUSY, ex.SqliteErrorCode);

                            var message = raw.sqlite3_errstr(raw.SQLITE_BUSY);
                            Assert.Equal(Strings.SqliteNativeError(raw.SQLITE_BUSY, message), ex.Message);
                        });

                    t1.Start();
                    t2.Start();
                    t1.Join();
                    t2.Join();
                }
            }
        }

        private SqliteConnection CreateConnection(bool shared = false)
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = FileName,
                Cache = shared
                    ? SqliteCacheMode.Shared
                    : SqliteCacheMode.Private
            };

            return new SqliteConnection(builder.ToString());
        }

        public void Dispose()
        {
            File.Delete(FileName);
        }
    }
}
