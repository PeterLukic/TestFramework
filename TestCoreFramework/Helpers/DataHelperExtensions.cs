using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TestCoreFramework.Helpers
{ 
    public static class DataHelperExtensions
    {
        //Open the connection
        public static SqlConnection DbConnect(this SqlConnection sqlConnection, string connectionString)
        {

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                //LogHelpers.Write("ERROR :: " + e.Message);
            }

            return null;
        }

        //Closing the connection 
        public static void DbClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                //LogHelpers.Write("ERROR :: " + e.Message);
            }
        }
        
        //Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {

            DataSet dataset;
            try
            {
                //Checking the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                //LogHelpers.Write("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }
        }
        public static DataTable ExecuteProcWithParamsDt(this SqlConnection conn, string procName, Hashtable parameters)
        {
            DataSet dataSet;
            try
            {
                var dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(procName, conn);
                dataAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (DictionaryEntry de in parameters)
                    {
                        var sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());
                        dataAdaptor.SelectCommand.Parameters.Add(sp);
                    }

                dataSet = new DataSet();
                dataAdaptor.Fill(dataSet, "table");
                conn.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception e)
            {
                dataSet = null;
                conn.Close();
                Console.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                conn.Close();
                dataSet = null;
            }
        }
    }
}
