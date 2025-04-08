using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Aceoffix7_Net.ExaminationPaper
{
    public partial class Default : System.Web.UI.Page
    {
        public StringBuilder strHtmls = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConn = "Data Source=" + Server.MapPath("/App_Data/ExaminationPaper.db");
            string strSql = "select * from stream";

            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand cmd = new SQLiteCommand(strSql, conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            SQLiteDataReader reader = cmd.ExecuteReader();

            strHtmls.Append("<tr style='background-color:#FEE;height:50px;'>");
            strHtmls.Append("<td width='10%'>Select</td>");
            strHtmls.Append("<td width='50%'>Question Bank ID</td>");
            strHtmls.Append("<td width='40%'>Operations</td>");
            strHtmls.Append("</tr>");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string pID = reader["ID"].ToString().Trim();
                    strHtmls.Append("<tr style='background-color:white;height:40px;'>");
                    strHtmls.Append("<td><input id='check" + pID + "' type='checkbox' /></td>");
                    strHtmls.Append("<td>Question - " + pID + "</td>");
                    strHtmls.Append("<td><a href='javascript:AceBrowser.openWindow(\"Edit?id=" + pID + "\", \"width=1200px;height=800px;\"," + pID + ");'>Edit</a></td>");
                    strHtmls.Append("</tr>");
                }
            }
            else
            {
                strHtmls.Append("<tr>\r\n");
                strHtmls.Append("<td colspan='3' width='100%' height='100' align='center'>Sorry, there is no data available for operation.\r\n");
                strHtmls.Append("</td></tr>\r\n");
            }

            reader.Close();
            conn.Close();
        }
    }
}