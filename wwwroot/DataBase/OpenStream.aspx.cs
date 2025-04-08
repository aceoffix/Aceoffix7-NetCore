using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.DataBase
{
    public partial class OpenStream : System.Web.UI.Page
    {
        public string docID="";
        protected void Page_Load(object sender, EventArgs e)
        {
            docID = Request.QueryString["id"];
            string connstring = "Data Source=" + Server.MapPath("/App_Data/DataBase.db");
            SQLiteConnection conn = new SQLiteConnection(connstring);
            conn.Open();
            string sql = "select Word,ID from stream where ID=" + docID;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.CommandType = CommandType.Text;
            SQLiteDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                long num = reader.GetBytes(0, 0, null, 0, Int32.MaxValue);
                Byte[] b = new Byte[num];
                reader.GetBytes(0, 0, b, 0, b.Length);
                Response.ContentType = "Application/msword"; // application/x-excel, application/ms-powerpoint, application/pdf 
                Response.AddHeader("Content-Disposition", "attachment; filename=down.docx");
                Response.AddHeader("Content-Length", num.ToString());
                this.Response.Clear();
                System.IO.Stream fs = this.Response.OutputStream;
                fs.Write(b, 0, b.Length);
                fs.Close();

            }
            reader.Close();
            conn.Close();
            Response.Flush();
            Response.End();
        }
    }
}