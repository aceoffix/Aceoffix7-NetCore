using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.SaveAndSearch
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim().Length > 0)
            {
                string id = Request.QueryString["id"].ToString().Trim();
                string content = fs.DocumentText;
                string strConn = "Data Source=" + Server.MapPath("/App_Data/SaveAndSearch.db");
                string sql = " update word set Content = '" + content + "' where id= " + id;
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                }
                fs.SaveToFile(Server.MapPath("doc/") + fs.FileName);
            }

            fs.Close();

        }
    }
}