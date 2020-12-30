using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using SQLOperationsClass;

namespace TradeProcess
{
    public partial class MiSReports_TradeProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    try
                    {
                        Funds_DDLFill(ddl_fund);                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        SqlConnection.ClearAllPools();
                    }
                }
                else
                {
                    Response.Redirect("~/Account/login.aspx");
                }
            }



        }


        private void Funds_DDLFill(DropDownList ddl_funds)
        {
            string query = "Select * from FUND";
            DataTable dtfunds = SQLOperations.GetTable(query);
            if (dtfunds.Rows.Count > 0)
            {
                ddl_funds.DataSource = dtfunds;
                ddl_funds.DataTextField = "FUND_NAME";
                ddl_funds.DataValueField = "FUND_ID";
                ddl_funds.DataBind();
            }
        }
    }
}
  /*  public class SQLOperations
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        static SqlConnection conn;
        public SQLOperations()
        {
            // TODO: Add constructor logic here
        }

        /*   public static SqlConnection GetConnection()
           {

               string dbcon = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
               try
               {
                   SqlConnection con = new SqlConnection(dbcon);
                   con.Close();
                   con.Open();
                   return con;

               }
               catch (Exception)
               {
                   throw;
               }
           }


        public static DataTable GetTable(string query)
        {
            //string dbcon = ConfigurationManager.ConnectionStrings["Sebis"].ConnectionString;
            conn = new SqlConnection(connectionString);
            try
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(query, conn);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static void ExecuteQuery(string query)
        {
            //string dbcon = ConfigurationManager.ConnectionStrings["Sebis"].ConnectionString;
            //SqlConnection con = new SqlConnection(dbcon);
            //con.Open();
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 50000000;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }

        /* public static DataTable GetDataTable(string sql, SqlParameter[] parameters)
         {
             try
             {
                 using (DbConnection connection = factory.CreateConnection())
                 {
                     connection.ConnectionString = connectionString;

                     using (DbCommand command = factory.CreateCommand())
                     {
                         command.Connection = connection;
                         command.CommandType = CommandType.Text;
                         command.CommandText = sql;

                         if (parameters != null)
                         {
                             foreach (var parameter in parameters)
                             {
                                 if (parameter != null)
                                     command.Parameters.Add(parameter);
                             }
                         }
                         using (DbDataAdapter adapter = factory.CreateDataAdapter())
                         {
                             adapter.SelectCommand = command;

                             DataTable dt = new DataTable();
                             adapter.Fill(dt);

                             return dt;
                         }
                     }
                 }
             }
             catch (Exception)
             {
                 throw;
             }
         }

    }

}*/