using Aceoffix;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ConcurrencyCtrl
{
    public partial class Word2 : System.Web.UI.Page
    {
        public String subject = "";
        public string id = "";
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();

        protected void Page_Load(object sender, EventArgs e)
        {
            String fileName = "";
            id = Request.QueryString["id"].ToString().Trim();
            string user = Request.QueryString["user"].ToString().Trim();
            String userName = WebUtility.UrlDecode(user);
            Console.WriteLine(userName);


            string connectionString = "Data Source=" + Server.MapPath("/App_Data/ConcurrencyCtrl.db");
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string strSqll = "select * from doc where id=" + id;
                        using (SQLiteCommand cmd = new SQLiteCommand(conn))
                        {
                            cmd.CommandText = strSqll;
                            using (SQLiteDataReader Reader = cmd.ExecuteReader())
                            {
                                if (Reader.Read())
                                {
                                    fileName = (String)Reader[1];
                                    subject = (String)Reader[2];
                                }
                            }
                        }
                        string strSql2 = "Update doc set Editor='" + userName + "' where id=" + id;

                        using (SQLiteCommand updateCmd = new SQLiteCommand(strSql2, conn))
                        {
                            updateCmd.CommandText = strSql2;
                            updateCmd.ExecuteNonQuery();
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

            aceCtrl.Caption = "Current User: " + userName + " | Mode: ReadOnly View | Document Name: " + subject;
            aceCtrl.WebOpen("doc/" + fileName, OpenModeType.docReadOnly, userName);
        }
    }
}