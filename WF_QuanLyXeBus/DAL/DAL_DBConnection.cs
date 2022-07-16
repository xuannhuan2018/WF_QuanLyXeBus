using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DAL
{
    public class DAL_DBConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        public DAL_DBConnection()
        {
            conn = new SqlConnection(@"Data Source=HIEU\SQLEXPRESS;Initial Catalog=QL_TuyenXeBus;Integrated Security=True");
        }

        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public DataTable executeSelectQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            myAdapter = new SqlDataAdapter();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameters);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {

            }
            return dataTable;
        }
        public int executeFunctionQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand myCommand = new SqlCommand();
            int check = 0;
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameters);
                var result = myCommand.ExecuteReader();
                result.Read();
                check = result.GetInt32(0);
            }
            catch (SqlException e)
            {
                return check;
            }
            finally
            {
                conn.Close();
            }
            return check;
        }

        public bool executeInsertQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameters);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                
            }
            return true;
        }

        public bool executeUpdateQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameters);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
    }
    //public sqlconnection con = new sqlconnection(@"data source=hieu\sqlexpress;initial catalog=ql_tuyenxebus;integrated security=true");
    //    public sqlconnection getcon()
    //    {
    //        if (con.state == connectionstate.closed)
    //        {
    //            con.open();
    //        }
    //        return con;
    //    }

    //    public int exenonquery(sqlcommand cmd)
    //    {
    //        cmd.connection = getcon();
    //        int rowsaffected = -1;
    //        rowsaffected = cmd.executenonquery();
    //        con.close();
    //        return rowsaffected;
    //    }
    //    public object exescalar(sqlcommand cmd)
    //    {
    //        cmd.connection = getcon();
    //        object obj = -1;
    //        obj = cmd.executescalar();
    //        con.close();
    //        return obj;
    //    }

    //    public datatable exereader(sqlcommand cmd)
    //    {
    //        cmd.connection = getcon();
    //        sqldatareader sdr;
    //        datatable dt = new datatable();

    //        sdr = cmd.executereader();
    //        dt.load(sdr);
    //        con.close();
    //        return dt;
    //    }
    //}
}
