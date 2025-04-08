using Aceoffix.Word;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.WordSalaryBill
{
    public partial class Edit : System.Web.UI.Page
    {
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        public string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].Length > 0)
            {
                id = Request.QueryString["ID"].Trim();
                string strConn = "Data Source=" + Server.MapPath("/App_Data/WordSalaryBill.db");
                string strSql = "select * from Salary where id =" + id + " order by ID";

                SQLiteConnection conn = new SQLiteConnection(strConn);
                SQLiteCommand cmd = new SQLiteCommand(strSql, conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime date = DateTime.Now;

                    WordDocumentWriter doc = new WordDocumentWriter();
                    DataRegionWriter dataRegion = doc.OpenDataRegion("ACE_table");
                    WordTableWriter table = dataRegion.OpenTable(1);

                    doc.EnableAllDataRegionsEditing = true;

                    table.OpenCellRC(2, 1).Value = reader["ID"].ToString();
                    table.OpenCellRC(2, 2).Value = reader["UserName"].ToString();
                    table.OpenCellRC(2, 3).Value = reader["DeptName"].ToString();
                    table.OpenCellRC(2, 4).Value = reader["SalTotal"].ToString();
                    table.OpenCellRC(2, 5).Value = reader["SalDeduct"].ToString();
                    table.OpenCellRC(2, 6).Value = reader["SalCount"].ToString();
                    table.OpenCellRC(2, 7).Value = reader["DataTime"].ToString();

                    aceCtrl.SetWriter(doc);
                }
                else
                {
                    Response.Write("<script>alert('No salary information is available for this employee！');</script>");
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                Response.Write("<script>alert('The ID for which the salary information has not been obtained！');</script>");
            }
            aceCtrl.WebOpen("doc/template.docx", Aceoffix.OpenModeType.docSubmitForm, "Tom");
        }
    }
}