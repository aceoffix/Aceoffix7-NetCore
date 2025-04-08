using System;
using System.Data.SQLite;
using System.Data;
using System.Text;


namespace Aceoffix7_Net.SaveAndSearch
{
    public partial class Default : System.Web.UI.Page
    {
        public  string strHtml = "";
        public string strKey = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=" + Server.MapPath("/App_Data/SaveAndSearch.db");
            StringBuilder stringBuilder = new StringBuilder();
            string strSql = "";
            strKey = Request.Form["Input_KeyWord"]?.ToString().Trim();
            if (strKey == ""|| strHtml==null)
            {

                 strSql = "select * from word  where Content order by ID desc";
            }
            else {
                strSql = "select * from word  where Content like '%" + strKey + "%' order by ID desc";
            }
   
            DataSet ds = new DataSet();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteDataAdapter command = new SQLiteDataAdapter(strSql, connection))
                    {
                        command.Fill(ds, "ds");
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>" + dt.Rows[i]["FileName"] + "</td>");
                    stringBuilder.Append("<td><a href='javascript:AceBrowser.openWindow(\"Edit?ID=" + dt.Rows[i]["ID"] + "\",\"width=1200px;height=800px;\",\"" + strKey+ "," + dt.Rows[i]["ID"] + "\");' >Edit</a></td>");
                    stringBuilder.Append(" </tr>");
                }
            }
            else
            {
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<td colspan=\"2\" style=\"text-align:center; vertical-align:middle;\">No Data</td>");
                stringBuilder.Append("</tr>");
            }
            strHtml = stringBuilder.ToString();
        }
    }
}