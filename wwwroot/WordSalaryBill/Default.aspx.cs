using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.WordSalaryBill
{
    public partial class Default : System.Web.UI.Page
    {
        public StringBuilder strHtml = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {

            string strConn = "Data Source=" + Server.MapPath("/App_Data/WordSalaryBill.db");

            string strSql = "select * from Salary order by ID";

            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand cmd = new SQLiteCommand(strSql, conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            SQLiteDataReader reader = cmd.ExecuteReader();

  
            strHtml.Append("<tr style='height:40px;padding:0; border-right:1px solid #a2c5d9; border-bottom:1px solid #a2c5d9; background:#edf8fe; font-weight:bold; color:#666;text-align:center; text-indent:0px;'>");
            strHtml.Append("<td width='5%'>Select</td>");
            strHtml.Append("<td width='10%'>Employee ID</td>");
            strHtml.Append("<td width='10%'>Employee Name</td>");
            strHtml.Append("<td width='15%'>Department</td>");
            strHtml.Append("<td width='10%'>Gross Salary</td>");
            strHtml.Append("<td width='10%'>Deductions</td>");
            strHtml.Append("<td width='10%'>Net Salary</td>");
            strHtml.Append("<td width='10%'>Payment Date</td>");
            strHtml.Append("<td width='20%'>Operations</td>");
            strHtml.Append("</tr>");

            bool flg = false;
            while (reader.Read())
            {
                flg = true;
                string pID = reader["ID"].ToString().Trim();

                strHtml.Append("<tr style='height:40px; text-indent:10px; padding:0; border-right:1px solid #a2c5d9; border-bottom:1px solid #a2c5d9; color:#666;'>");
                strHtml.Append("<td style='text-align:center;'><input id='check" + pID + "' type='checkbox' /></td>");
                strHtml.Append("<td style='text-align:left;'>" + pID + "</td>");
                strHtml.Append("<td style='text-align:left;'>" + reader["UserName"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:left;'>" + reader["DeptName"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:left;'>" + reader["SalTotal"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:left;'>" + reader["SalDeduct"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:left;'>" + reader["SalCount"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:center;'>" + reader["DataTime"].ToString() + "</td>");
                strHtml.Append("<td style='text-align:center;'><a href='javascript:AceBrowser.openWindow(\"View?ID=" + pID + "\", \"width=1200px;height=800px;\");'>View</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:AceBrowser.openWindow(\"Edit?ID=" + pID + "\", \"width=1200px;height=800px;\"," + pID + ");'>Edit</a></td>");
                strHtml.Append("</tr>");
            }


            if (!flg)
            {
                strHtml.Append("<tr>\r\n");
                strHtml.Append("<td width='100%' height='100' align='center'>Sorry, there is no data available for operation.\r\n");
                strHtml.Append("</td></tr>\r\n");
            }

            reader.Close();
            conn.Close();
        }
    }
}