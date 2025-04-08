using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ExaminationPaper
{
    public partial class OpenFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].Length > 0)
            {
                string id = Request.QueryString["id"];
                string strConn = "Data Source=" + Server.MapPath("/App_Data/ExaminationPaper.db");
                string strSql = "select Word from stream where id =" + id;

                SQLiteConnection conn = new SQLiteConnection(strConn);
                SQLiteCommand cmd = new SQLiteCommand(strSql, conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    long num = reader.GetBytes(0, 0, null, 0, Int32.MaxValue) - 1;
                    Byte[] b = new Byte[num];
                    reader.GetBytes(0, 0, b, 0, b.Length);
                    Response.ContentType = "Application/msword";
                    Response.AddHeader("Content-Disposition", "attachment; filename=new.docx");
                    Response.AddHeader("Content-Length", num.ToString());
                    this.Response.Clear();
                    System.IO.Stream fs = this.Response.OutputStream;
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                }
                else
                {

                    Response.Write("<script>alert('No file information obtained!');location.href='Default'</script>");
                }


                reader.Close();
                conn.Close();
            }
            else
            {
                Response.Write("<script>alert('File ID not obtained!');location.href='Default'</script>");
            }
        }
    }
}