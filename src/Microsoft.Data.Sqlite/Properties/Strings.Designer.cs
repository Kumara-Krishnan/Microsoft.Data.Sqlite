// <auto-generated />
namespace Microsoft.Data.Sqlite
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Strings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.Data.Sqlite.Strings", typeof(Strings).GetTypeInfo().Assembly);

        /// <summary>
        /// {methodName} can only be called when the connection is open.
        /// </summary>
        internal static string CallRequiresOpenConnection
        {
            get { return GetString("CallRequiresOpenConnection"); }
        }

        /// <summary>
        /// {methodName} can only be called when the connection is open.
        /// </summary>
        internal static string FormatCallRequiresOpenConnection(object methodName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CallRequiresOpenConnection", "methodName"), methodName);
        }

        /// <summary>
        /// CommandText must be set before {methodName} can be called.
        /// </summary>
        internal static string CallRequiresSetCommandText
        {
            get { return GetString("CallRequiresSetCommandText"); }
        }

        /// <summary>
        /// CommandText must be set before {methodName} can be called.
        /// </summary>
        internal static string FormatCallRequiresSetCommandText(object methodName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CallRequiresSetCommandText", "methodName"), methodName);
        }

        /// <summary>
        /// ConnectionString cannot be set when the connection is open.
        /// </summary>
        internal static string ConnectionStringRequiresClosedConnection
        {
            get { return GetString("ConnectionStringRequiresClosedConnection"); }
        }

        /// <summary>
        /// ConnectionString cannot be set when the connection is open.
        /// </summary>
        internal static string FormatConnectionStringRequiresClosedConnection()
        {
            return GetString("ConnectionStringRequiresClosedConnection");
        }

        /// <summary>
        /// Invalid attempt to call {operation} when reader is closed.
        /// </summary>
        internal static string DataReaderClosed
        {
            get { return GetString("DataReaderClosed"); }
        }

        /// <summary>
        /// Invalid attempt to call {operation} when reader is closed.
        /// </summary>
        internal static string FormatDataReaderClosed(object operation)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DataReaderClosed", "operation"), operation);
        }

        /// <summary>
        /// The CommandBehavior '{behavior}' is invalid.
        /// </summary>
        internal static string InvalidCommandBehavior
        {
            get { return GetString("InvalidCommandBehavior"); }
        }

        /// <summary>
        /// The CommandBehavior '{behavior}' is invalid.
        /// </summary>
        internal static string FormatInvalidCommandBehavior(object behavior)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidCommandBehavior", "behavior"), behavior);
        }

        /// <summary>
        /// The CommandType '{commandType}' is invalid.
        /// </summary>
        internal static string InvalidCommandType
        {
            get { return GetString("InvalidCommandType"); }
        }

        /// <summary>
        /// The CommandType '{commandType}' is invalid.
        /// </summary>
        internal static string FormatInvalidCommandType(object commandType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidCommandType", "commandType"), commandType);
        }

        /// <summary>
        /// The IsolationLevel '{isolationLevel}' is invalid.
        /// </summary>
        internal static string InvalidIsolationLevel
        {
            get { return GetString("InvalidIsolationLevel"); }
        }

        /// <summary>
        /// The IsolationLevel '{isolationLevel}' is invalid.
        /// </summary>
        internal static string FormatInvalidIsolationLevel(object isolationLevel)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidIsolationLevel", "isolationLevel"), isolationLevel);
        }

        /// <summary>
        /// The ParameterDirection '{direction}' is invalid.
        /// </summary>
        internal static string InvalidParameterDirection
        {
            get { return GetString("InvalidParameterDirection"); }
        }

        /// <summary>
        /// The ParameterDirection '{direction}' is invalid.
        /// </summary>
        internal static string FormatInvalidParameterDirection(object direction)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidParameterDirection", "direction"), direction);
        }

        /// <summary>
        /// Keyword not supported: '{keyword}'.
        /// </summary>
        internal static string KeywordNotSupported
        {
            get { return GetString("KeywordNotSupported"); }
        }

        /// <summary>
        /// Keyword not supported: '{keyword}'.
        /// </summary>
        internal static string FormatKeywordNotSupported(object keyword)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("KeywordNotSupported", "keyword"), keyword);
        }

        /// <summary>
        /// Must add values for the following parameters: {parameters}
        /// </summary>
        internal static string MissingParameters
        {
            get { return GetString("MissingParameters"); }
        }

        /// <summary>
        /// Must add values for the following parameters: {parameters}
        /// </summary>
        internal static string FormatMissingParameters(object parameters)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MissingParameters", "parameters"), parameters);
        }

        /// <summary>
        /// No data exists for the row/column.
        /// </summary>
        internal static string NoData
        {
            get { return GetString("NoData"); }
        }

        /// <summary>
        /// No data exists for the row/column.
        /// </summary>
        internal static string FormatNoData()
        {
            return GetString("NoData");
        }

        /// <summary>
        /// ConnectionString must be set before Open can be called.
        /// </summary>
        internal static string OpenRequiresSetConnectionString
        {
            get { return GetString("OpenRequiresSetConnectionString"); }
        }

        /// <summary>
        /// ConnectionString must be set before Open can be called.
        /// </summary>
        internal static string FormatOpenRequiresSetConnectionString()
        {
            return GetString("OpenRequiresSetConnectionString");
        }

        /// <summary>
        /// SqliteConnection does not support nested transactions.
        /// </summary>
        internal static string ParallelTransactionsNotSupported
        {
            get { return GetString("ParallelTransactionsNotSupported"); }
        }

        /// <summary>
        /// SqliteConnection does not support nested transactions.
        /// </summary>
        internal static string FormatParallelTransactionsNotSupported()
        {
            return GetString("ParallelTransactionsNotSupported");
        }

        /// <summary>
        /// A SqliteParameter with ParameterName '{parameterName}' is not contained by this SqliteParameterCollection.
        /// </summary>
        internal static string ParameterNotFound
        {
            get { return GetString("ParameterNotFound"); }
        }

        /// <summary>
        /// A SqliteParameter with ParameterName '{parameterName}' is not contained by this SqliteParameterCollection.
        /// </summary>
        internal static string FormatParameterNotFound(object parameterName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ParameterNotFound", "parameterName"), parameterName);
        }

        /// <summary>
        /// {propertyName} must be set.
        /// </summary>
        internal static string RequiresSet
        {
            get { return GetString("RequiresSet"); }
        }

        /// <summary>
        /// {propertyName} must be set.
        /// </summary>
        internal static string FormatRequiresSet(object propertyName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RequiresSet", "propertyName"), propertyName);
        }

        /// <summary>
        /// This SqliteTransaction has completed; it is no longer usable.
        /// </summary>
        internal static string TransactionCompleted
        {
            get { return GetString("TransactionCompleted"); }
        }

        /// <summary>
        /// This SqliteTransaction has completed; it is no longer usable.
        /// </summary>
        internal static string FormatTransactionCompleted()
        {
            return GetString("TransactionCompleted");
        }

        /// <summary>
        /// The transaction object is not associated with the connection object.
        /// </summary>
        internal static string TransactionConnectionMismatch
        {
            get { return GetString("TransactionConnectionMismatch"); }
        }

        /// <summary>
        /// The transaction object is not associated with the connection object.
        /// </summary>
        internal static string FormatTransactionConnectionMismatch()
        {
            return GetString("TransactionConnectionMismatch");
        }

        /// <summary>
        /// Execute requires the command to have a transaction object when the connection assigned to the command is in a pending local transaction.  The Transaction property of the command has not been initialized.
        /// </summary>
        internal static string TransactionRequired
        {
            get { return GetString("TransactionRequired"); }
        }

        /// <summary>
        /// Execute requires the command to have a transaction object when the connection assigned to the command is in a pending local transaction.  The Transaction property of the command has not been initialized.
        /// </summary>
        internal static string FormatTransactionRequired()
        {
            return GetString("TransactionRequired");
        }

        /// <summary>
        /// No mapping exists from object type {typeName} to a known managed provider native type.
        /// </summary>
        internal static string UnknownDataType
        {
            get { return GetString("UnknownDataType"); }
        }

        /// <summary>
        /// No mapping exists from object type {typeName} to a known managed provider native type.
        /// </summary>
        internal static string FormatUnknownDataType(object typeName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnknownDataType", "typeName"), typeName);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}