using Aceoffix.Word;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.WordSalaryBill
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();
            DataRegionReader dr = doc.OpenDataRegion("ACE_table");
            WordTableReader table = dr.OpenTable(1);

            string id = Request.QueryString["id"];
            if (id != null && id.Length > 0)
            {
                string strConn = "Data Source=" + Server.MapPath("/App_Data/WordSalaryBill.db");

                string userName = "", deptName = "", salTotoal = "0", salDeduct = "0", salCount = "0", dateTime = "";


                userName = table.OpenCellRC(2, 2).Value;
                deptName = table.OpenCellRC(2, 3).Value;
                salTotoal = table.OpenCellRC(2, 4).Value;
                salDeduct = table.OpenCellRC(2, 5).Value;
                salCount = table.OpenCellRC(2, 6).Value;
                dateTime = table.OpenCellRC(2, 7).Value;

                string sql = "UPDATE Salary SET UserName='" + userName
                    + "',DeptName='" + deptName + "',SalTotal='" + salTotoal
                    + "',SalDeduct='" + salDeduct + "',SalCount='" + salCount
                    + "',DataTime='" + dateTime + "' WHERE ID=" + id;

                SQLiteConnection conn = new SQLiteConnection(strConn);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();

                doc.CustomSaveResult = "ok";
                doc.Close();
            }
            else
            {
                Response.Write("The ID of the file has not been obtained, and the saving failed.");
            }
        }
    }
}