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
    public partial class Compose : System.Web.UI.Page
    {
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ids"] == null || Request.QueryString["ids"] == "")
            {
                return;
            }
            string idlist = Request.QueryString["ids"].Trim();

            string strConn = "Data Source=" + Server.MapPath("/App_Data/WordSalaryBill.db");
            string strSql = "select * from Salary where ID in(" + idlist + ") order by ID";
            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteDataAdapter cmd = new SQLiteDataAdapter(strSql, conn);
            DataSet ds = new DataSet();
            conn.Open();
            cmd.Fill(ds, "ds");

            WordDocumentWriter doc = new WordDocumentWriter();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRegionWriter[] data = new DataRegionWriter[ds.Tables[0].Rows.Count];
                WordTableWriter[] table = new WordTableWriter[ds.Tables[0].Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data[i] = doc.CreateDataRegion("reg" + i.ToString(), DataRegionInsertType.Before, "[End]");
                    data[i].Value = "[word]/WordSalaryBill/doc/template.docx[/word]";

                    table[i] = data[i].OpenTable(1);
                    table[i].OpenCellRC(2, 1).Value = dt.Rows[i]["ID"].ToString();
                    table[i].OpenCellRC(2, 2).Value = dt.Rows[i]["UserName"].ToString();
                    table[i].OpenCellRC(2, 3).Value = dt.Rows[i]["DeptName"].ToString();
                    table[i].OpenCellRC(2, 4).Value = dt.Rows[i]["SalTotal"].ToString();
                    table[i].OpenCellRC(2, 5).Value = dt.Rows[i]["SalDeduct"].ToString();
                    table[i].OpenCellRC(2, 6).Value = dt.Rows[i]["SalCount"].ToString();
                    table[i].OpenCellRC(2, 7).Value = dt.Rows[i]["DataTime"].ToString();

                }
            }
            conn.Close();

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", Aceoffix.OpenModeType.docReadOnly, "Tom");
        }
    }
}