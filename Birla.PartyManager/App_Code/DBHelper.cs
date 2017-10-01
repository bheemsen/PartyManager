using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


/// <summary>
///ConnectionForm provides methods to Connect And fetch or update database
/// </summary>
public class DBHelper
{
    private SqlConnection connectionDB = new SqlConnection();
    private SqlCommand command = new SqlCommand();
    private SqlDataAdapter dataadapter = new SqlDataAdapter();
    private DataSet data_set=new DataSet();
    private string ExInfo = null;

    public string ExceptionInfo
    {
        set
        {
            ExInfo = value;
        }

        get
        {
            return ExInfo;
        }
    }

    public DBHelper()
	{
        connectionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        command.Connection = connectionDB;
        dataadapter.SelectCommand = command; 
	}

   


    /// <summary>
    /// Method to get multiple records from database according to SQL Query.
    /// </summary>
    /// <param name="Query">SQL Query to execute.</param>
    /// <param name="AliasName">Virtual table name.</param>
    /// <returns>System.Data.DataSet</returns>
    public DataSet GetDataSet(string Query, string AliasName)
    {
        try
        {
            data_set.Clear();
            command.CommandText = Query;
            dataadapter.Fill(data_set, AliasName);
            return data_set;
        }
        catch (Exception ex)
        {           
            ExceptionInfo = ex.Message;
            return null;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

    public DataTable GetTable(string Query )
    {
        try
        {  
            command.CommandText = Query;
            dataadapter.Fill(data_set);
            return data_set.Tables[0];
        }
        catch (Exception ex)
        {
            ExceptionInfo = ex.Message;
            return null;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

    SqlTransaction objTransaction;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Query">SQL Query to execute.</param>
    /// <returns></returns>
    public bool NonQuery(string Query)
    {
        
        try
        {
            if (connectionDB.State == ConnectionState.Closed)
                connectionDB.Open();
            objTransaction = connectionDB.BeginTransaction();
            command.Transaction = objTransaction;
            command.CommandText = Query;
            int Result = command.ExecuteNonQuery();
            if (Result > 0)
            {
                objTransaction.Commit();
                return true;
            }
            else
            {
                objTransaction.Rollback();
                return false;
            }
        }
        catch (Exception ex)
        {
            objTransaction.Rollback();
            ExceptionInfo = ex.Message;
            return false;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }


    public bool ExecuteNonQueryStoredProcedure(string ProcedureName, SqlParameter[] Parameters)
    {
        
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandType = CommandType.StoredProcedure;
            if (connectionDB.State == ConnectionState.Closed)
                connectionDB.Open();
            objTransaction = connectionDB.BeginTransaction();
            cmd.Transaction = objTransaction;
            cmd.CommandText = ProcedureName;
            if (Parameters != null)
            cmd.Parameters.AddRange(Parameters);
            int Result = cmd.ExecuteNonQuery();
            if (Result > 0)
            {
                objTransaction.Commit();
                return true;
            }
            else
            {
                objTransaction.Rollback();
                return false;
            }
        }
        catch (Exception ex)
        {
            objTransaction.Rollback();
            ExceptionInfo = ex.Message;
            return false;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

    public bool ExecuteNonQueryStoredProcedure(string[] ProcedureName, SqlParameter[][] Parameters)
    {

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandType = CommandType.StoredProcedure;
            if (connectionDB.State == ConnectionState.Closed)
                connectionDB.Open();
            objTransaction = connectionDB.BeginTransaction();
            cmd.Transaction = objTransaction;
            int i = 0;
            int flag = 0;
            foreach (string Procedure in ProcedureName)
            {
                cmd.CommandText = Procedure;
                cmd.Parameters.Clear();
                if (Parameters[i] != null)
                    cmd.Parameters.AddRange(Parameters[i]);
                int Result = cmd.ExecuteNonQuery();
                if (Result > 0)
                {
                    flag = 0;                    
                }
                else
                {
                    flag = 1;
                    break;                   
                }
                i++;
            }
            if (flag == 0)
            {
                objTransaction.Commit();
                return true;
            }
            else
            {
                objTransaction.Rollback();
                return false;
            }
        }
        catch (Exception ex)
        {
            objTransaction.Rollback();
            ExceptionInfo = ex.Message;
            return false;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }


    public object GetScaler(string Query)
    {
        try
        {
            if (connectionDB.State == ConnectionState.Closed)
                connectionDB.Open();
            objTransaction = connectionDB.BeginTransaction();
         
          command.Transaction = objTransaction;
            command.CommandText = Query;
            object Result = command.ExecuteScalar();
            if (Result != null)
            {
                objTransaction.Commit();
                return Result;
            }
            else
            {
                objTransaction.Rollback();
                return Result;
            }
        }
        catch (Exception ex)
        {
            objTransaction.Rollback();
            ExceptionInfo = ex.Message;
            return false;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }



    public object GetScaler(string ProcedureName, SqlParameter[] Parameters)
    {
        try
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandType = CommandType.StoredProcedure;
            if (connectionDB.State == ConnectionState.Closed)
                connectionDB.Open();
            objTransaction = connectionDB.BeginTransaction();
            cmd.Transaction = objTransaction;
            cmd.CommandText = ProcedureName;
            if (Parameters != null)
                cmd.Parameters.AddRange(Parameters);
            object Result = cmd.ExecuteScalar();
            if (Result != null)
            {
                objTransaction.Commit();
                return Result;
            }
            else
            {
                objTransaction.Rollback();
                return Result;
            }
        }
        catch (Exception ex)
        {
            objTransaction.Rollback();
            ExceptionInfo = ex.Message;
            return false;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

    public DataSet ExecuteDataSet(string ProcedureName, SqlParameter[] Params_Array, string AliasName)
    {
        try
        {
            data_set.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connectionDB;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcedureName;
        if(Params_Array != null)
        cmd.Parameters.AddRange(Params_Array);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(data_set, AliasName);
        return data_set;
        }
        catch (Exception ex)
        {
            ExceptionInfo = ex.Message;
            return null;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

    public void ClearTable(string TableName)
    {
        if (data_set.Tables.Contains(TableName))
            data_set.Tables[TableName].Clear();
    }

    public DataSet ExecuteDataSet2(string ProcedureName, SqlParameter[] Params_Array, string AliasName)
    {
        try
        {
            //data_set.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcedureName;
            if (Params_Array != null)
                cmd.Parameters.AddRange(Params_Array);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(data_set, AliasName);
            return data_set;
        }
        catch (Exception ex)
        {
            ExceptionInfo = ex.Message;
            return null;
        }
        finally
        {
            if (connectionDB.State == ConnectionState.Open)
                connectionDB.Close();
        }
    }

}
