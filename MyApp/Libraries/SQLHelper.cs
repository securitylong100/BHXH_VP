using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML130.EasyUtils;

namespace XML130.Libraries
{
    public class SQLHelper
    {
        private const int CMD_TIMEOUT = 200;
        private static string strConn;

        public static string Connectionstring
        {
            get => SQLHelper.strConn;
            set => SQLHelper.strConn = value;
        }

        public static DataTable ExecuteDataTable(string commandText) => SQLHelper.ExecuteDataTable(SQLHelper.strConn, CommandType.Text, commandText, (SqlParameter[])null);

        public static DataTable ExecuteDataTable(string connection, string commandText) => SQLHelper.ExecuteDataTable(connection, CommandType.Text, commandText, (SqlParameter[])null);

        public static DataTable ExecuteDataTable(string spName, params SqlParameter[] commandParameters) => SQLHelper.ExecuteDataTable(SQLHelper.strConn, CommandType.StoredProcedure, spName, commandParameters);

        public static DataTable ExecuteDataTable(
          string connection,
          string spName,
          params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteDataTable(connection, CommandType.StoredProcedure, spName, commandParameters);
        }

        public static DataTable ExecuteDataTable(
          string connection,
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            SqlCommand selectCommand = new SqlCommand(commandText, new SqlConnection(connection));
            selectCommand.CommandType = commandType;
            selectCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    selectCommand.Parameters.Add(commandParameters[index]);
            }
            selectCommand.Connection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    selectCommand.Parameters.Clear();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("expects parameter"))
                    {
                        int num = (int)EasyDialog.ShowWarningDialog("Khai báo tham số câu truy vấn không hợp lệ");
                    }
                    return (DataTable)null;
                }
                finally
                {
                    selectCommand.Connection.Close();
                }
            }
        }

        public static DataSet ExecuteDataset(string commandText) => SQLHelper.ExecuteDataset(SQLHelper.strConn, CommandType.Text, commandText, (SqlParameter[])null);

        public static DataSet ExecuteDataset(string connection, string commandText) => SQLHelper.ExecuteDataset(connection, CommandType.Text, commandText, (SqlParameter[])null);

        public static DataSet ExecuteDataset(string spName, params SqlParameter[] commandParameters) => SQLHelper.ExecuteDataset(SQLHelper.strConn, CommandType.StoredProcedure, spName, commandParameters);

        public static DataSet ExecuteDataset(
          string connection,
          string spName,
          params SqlParameter[] commandParameters)
        {
            return SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
        }

        public static DataSet ExecuteDataset(
          string connection,
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            SqlCommand selectCommand = new SqlCommand(commandText, new SqlConnection(connection));
            selectCommand.CommandType = commandType;
            selectCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    selectCommand.Parameters.Add(commandParameters[index]);
            }
            selectCommand.Connection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    selectCommand.Parameters.Clear();
                    return dataSet;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("expects parameter"))
                    {
                        int num = (int)EasyDialog.ShowWarningDialog("Khai báo tham số câu truy vấn không hợp lệ");
                    }
                    return (DataSet)null;
                }
                finally
                {
                    selectCommand.Connection.Close();
                }
            }
        }

        public static int ExecuteNonQuery(string commandText) => SQLHelper.ExecuteNonQuery(SQLHelper.strConn, CommandType.Text, commandText, (SqlParameter[])null);

        public static int ExecuteNonQuery(string connection, string commandText) => SQLHelper.ExecuteNonQuery(connection, CommandType.Text, commandText, (SqlParameter[])null);


        // thủ tục
        public static int ExecuteNonQuery(string spName, params SqlParameter[] commandParameters) => SQLHelper.ExecuteNonQuery(SQLHelper.strConn, CommandType.StoredProcedure, spName, commandParameters);

        public static int ExecuteNonQuery(
          string connection,
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            SqlCommand sqlCommand = new SqlCommand(commandText, new SqlConnection(connection));
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    sqlCommand.Parameters.Add(commandParameters[index]);
            }
            sqlCommand.Connection.Open();
            int num;
            try
            {
                num = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                num = -1;
            }
            sqlCommand.Connection.Close();
            return num;
        }

        public static void FillDataset(string commandText, DataSet dataSet, string[] tableNames) => SQLHelper.FillDataset(SQLHelper.strConn, CommandType.Text, commandText, dataSet, tableNames, (SqlParameter[])null);

        public static void FillDataset(
          string connection,
          string commandText,
          DataSet dataSet,
          string[] tableNames)
        {
            SQLHelper.FillDataset(connection, CommandType.Text, commandText, dataSet, tableNames, (SqlParameter[])null);
        }

        public static void FillDataset(
          string spName,
          DataSet dataSet,
          string[] tableNames,
          params SqlParameter[] commandParameters)
        {
            SQLHelper.FillDataset(SQLHelper.strConn, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
        }

        public static void FillDataset(
          string connection,
          string spName,
          DataSet dataSet,
          string[] tableNames,
          params SqlParameter[] commandParameters)
        {
            SQLHelper.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
        }

        public static void FillDataset(
          string connection,
          CommandType commandType,
          string commandText,
          DataSet dataSet,
          string[] tableNames,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            if (dataSet == null)
                throw new ArgumentNullException(nameof(dataSet));
            SqlCommand selectCommand = new SqlCommand(commandText, new SqlConnection(connection));
            selectCommand.CommandType = commandType;
            selectCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    selectCommand.Parameters.Add(commandParameters[index]);
            }
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                if (tableNames != null && tableNames.Length > 0)
                {
                    string sourceTable = "Table";
                    for (int index = 0; index < tableNames.Length; ++index)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0)
                            throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", nameof(tableNames));
                        sqlDataAdapter.TableMappings.Add(sourceTable, tableNames[index]);
                        sourceTable += (index + 1).ToString();
                    }
                }
                try
                {
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                selectCommand.Parameters.Clear();
            }
        }

        public static object ExecuteScalar(string spName, params SqlParameter[] commandParameters) => SQLHelper.ExecuteScalar(SQLHelper.strConn, CommandType.StoredProcedure, spName, commandParameters);

        public static object ExecuteScalar(
          string connection,
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            SqlCommand sqlCommand = new SqlCommand(commandText, new SqlConnection(connection));
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    sqlCommand.Parameters.Add(commandParameters[index]);
            }
            sqlCommand.Connection.Open();
            object obj = sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            return obj;
        }

        public static T ExecuteScalar<T>(string cmdText) => SQLHelper.ExecuteScalar<T>(SQLHelper.strConn, CommandType.Text, cmdText, (SqlParameter[])null);

        public static T ExecuteScalar<T>(string spName, params SqlParameter[] commandParameters) => SQLHelper.ExecuteScalar<T>(SQLHelper.strConn, CommandType.StoredProcedure, spName, commandParameters);

        public static T ExecuteScalar<T>(
          string connection,
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = SQLHelper.strConn;
            SqlCommand sqlCommand = new SqlCommand(commandText, new SqlConnection(connection));
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandTimeout = 200;
            if (commandParameters != null)
            {
                for (int index = 0; index < commandParameters.Length; ++index)
                    sqlCommand.Parameters.Add(commandParameters[index]);
            }
            sqlCommand.Connection.Open();
            object obj = sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            sqlCommand.Dispose();
            return obj == DBNull.Value || obj == null ? default(T) : (T)Convert.ChangeType(obj, typeof(T));
        }

        public static object ExecuteScalar(string commandText) => SQLHelper.ExecuteScalar(SQLHelper.strConn, CommandType.Text, commandText, (SqlParameter[])null);

        public static bool ExecuteSqlFromFile(string sqlFile)
        {
            using (SqlConnection sqlConnection = new SqlConnection(SQLHelper.Connectionstring))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    int num = (int)EasyDialog.ShowErrorDialog("Không kết nối được cơ sở dữ liệu");
                    SQLHelper.WriteLogText(ex.Message);
                    return false;
                }
                string input = string.Empty;
                using (FileStream fileStream = File.OpenRead(sqlFile))
                    input = new StreamReader((Stream)fileStream).ReadToEnd();
                string[] strArray = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline).Split(input);
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.Connection = sqlConnection;
                    command.Transaction = sqlTransaction;
                    foreach (string str in strArray)
                    {
                        if (str.Length > 0)
                        {
                            command.CommandText = str;
                            command.CommandType = CommandType.Text;
                            try
                            {
                                command.ExecuteNonQuery();
                                SQLHelper.WriteLogText(string.Format("DONE\n{0}", (object)str));
                            }
                            catch (SqlException ex)
                            {
                                SQLHelper.WriteLogText(string.Format("ERROR\n{0}", (object)str));
                                SQLHelper.WriteLogText(ex.Message);
                                sqlTransaction.Rollback();
                                return false;
                            }
                        }
                    }
                }
                sqlTransaction.Commit();
                sqlConnection.Close();
                return true;
            }
        }

        private static void WriteLogText(string description)
        {
            using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\updateLog.txt", true, Encoding.Unicode))
            {
                string str = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}\t:\t{1}", (object)DateTime.Now, (object)description);
                streamWriter.WriteLine(str);
            }
        }
    }
}
