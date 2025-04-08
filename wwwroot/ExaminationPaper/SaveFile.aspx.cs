using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ExaminationPaper
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            string id = Request.QueryString["id"];
            if (id != null && id.Length > 0)
            {
                string strConn = "Data Source=" + Server.MapPath("/App_Data/ExaminationPaper.db");
                SQLiteConnection conn = new SQLiteConnection(strConn);
                byte[] aa = fs.FileBytes;
                SQLiteCommand cm = new SQLiteCommand();
                cm.Connection = conn;
                cm.CommandType = CommandType.Text;
                if (conn.State == 0) conn.Open();
                cm.CommandText = "UPDATE  Stream SET Word=@file WHERE ID=" + id;
                SQLiteParameter spFile = new SQLiteParameter("@file", DbType.Binary);
                spFile.Value = aa;
                cm.Parameters.Add(spFile);
                cm.ExecuteNonQuery();
                conn.Close();

                fs.CustomSaveResult = "ok";
            }
            else
            {
                Response.Write("<script>alert('The ID of the file was not obtained, and the saving failed!');location.href='Default'</script>");
            }
            fs.Close();
        }
    }
}