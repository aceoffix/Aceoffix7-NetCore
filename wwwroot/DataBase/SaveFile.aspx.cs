using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.DataBase
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();

            string sID = Request.QueryString["id"];
            string connstring = "Data Source=" + Server.MapPath("/App_Data/DataBase.db");
            byte[] aa = fs.FileBytes;

            string sql = "UPDATE  Stream SET Word=@file WHERE ID=" + sID;

            using (SQLiteConnection conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    SQLiteParameter parameter = new SQLiteParameter("@file", System.Data.DbType.Binary);
                    parameter.Value = aa;
                    cmd.Parameters.Add(parameter);
                    cmd.ExecuteNonQuery();
                }
            }
            fs.Close();
        }
    }
}