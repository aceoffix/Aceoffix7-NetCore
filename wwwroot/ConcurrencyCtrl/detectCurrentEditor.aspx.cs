using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ConcurrencyCtrl
{
    public partial class detectCurrentEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString().Trim();
            string strSql = "select * from doc where id=" + id;
            string connectionString = "Data Source=" + Server.MapPath("/App_Data/ConcurrencyCtrl.db");
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(conn))
                        {
                            cmd.CommandText = strSql;
                            using (SQLiteDataReader Reader = cmd.ExecuteReader())
                            {
                                if (Reader.Read())
                                {
                                    string editor = (string)Reader[3];
                                    editor = "{\"editor\":\"" + editor + "\"}";
                                    Response.Write(editor);
                                }
                            }
                        }
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
