using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ConcurrencyCtrl
{
    public partial class Default : System.Web.UI.Page
    {
        protected string strHtmls = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSql = "select * from doc order by id desc";
            string connectionString = "Data Source=" + Server.MapPath("/App_Data/ConcurrencyCtrl.db");
            StringBuilder strHtml = new StringBuilder();
            DataSet ds = new DataSet();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteDataAdapter command = new SQLiteDataAdapter(strSql, connection);
                    command.Fill(ds, "ds");
                    connection.Close();
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td>" + "<img src='../images/office-1.png' />" + "</td>\n");
                    strHtml.Append("<td>" + dt.Rows[i]["Subject"] + "</td>\n");
                    strHtml.Append("<td ><a class='button-edit' href='javascript:editFile(" + dt.Rows[i]["ID"] + ");' >Edit</a>&nbsp;&nbsp;");
                    strHtml.Append("<a href='javascript:viewFile(" + dt.Rows[i]["ID"] + ");' >View</a></td>");
                    strHtml.Append("</tr>");
                }
            }
            else
            {
                strHtml.Append("<tr>\r\n");
                strHtml.Append("<td colspan='2' style='width:100%; text-align:center;'>No Data.\r\n");
                strHtml.Append("</td></tr>\r\n");
            }
            strHtmls = strHtml.ToString();
        }
    }
}