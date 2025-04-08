using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ConcurrencyCtrl
{
    public partial class clearCurrentEditor : System.Web.UI.Page
    {
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Request.QueryString["id"].ToString().Trim();
            string connectionString = "Data Source=" + Server.MapPath("/App_Data/ConcurrencyCtrl.db");
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string strSql2 = "Update doc set Editor='' where id=" + id;

                        using (SQLiteCommand updateCmd = new SQLiteCommand(strSql2, conn))
                        {
                            updateCmd.CommandText = strSql2;
                            updateCmd.ExecuteNonQuery();
                            Response.Write("{\"msg\":\"ok\"}");
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}