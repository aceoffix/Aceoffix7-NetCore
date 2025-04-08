using System;
using System.Data.SQLite;

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordSalaryBill
{
    public class WordSalaryBillController : Controller
    {

        private String connString;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WordSalaryBillController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            string rootPath = _webHostEnvironment.WebRootPath.Replace("/", "\\");
            string dataPath = rootPath.Substring(0, rootPath.Length - 7) + "App_Data\\" + "WordSalaryBill.db";
            connString = "Data Source=" + dataPath;

        }

        public IActionResult Index()
        {

            string sql = "select * from Salary   order by ID ";
            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SQLiteDataReader dr = cmd.ExecuteReader();
            StringBuilder strHtml = new StringBuilder();


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

            while (dr.Read())
            {
                flg = true;
                DateTime date = DateTime.Now;
                string pID = dr["ID"].ToString().Trim();
                strHtml.Append("<tr  style='height:40px; text-indent:10px; padding:0; border-right:1px solid #a2c5d9; border-bottom:1px solid #a2c5d9; color:#666;'>");
                strHtml.Append("<td style=' text-align:center;'><input id='check" + pID + "'  type='checkbox' /></td>");
                strHtml.Append("<td style=' text-align:left;'>" + pID + "</td>");
                strHtml.Append("<td style=' text-align:left;'>" + dr["UserName"].ToString() + "</td>");
                strHtml.Append("<td style=' text-align:left;'>" + dr["DeptName"].ToString() + "</td>");
                if (dr["SalTotal"] != null && dr["SalTotal"].ToString() != "")
                {
                    strHtml.Append("<td style=' text-align:left;'>" + dr["SalTotal"].ToString() + "</td>");
                }
                else
                {
                    strHtml.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["SalDeduct"] != null && dr["SalDeduct"].ToString() != "")
                {
                    strHtml.Append("<td style=' text-align:left;'>" + dr["SalDeduct"].ToString() + "</td>");
                }
                else
                {
                    strHtml.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["SalCount"] != null && dr["SalCount"].ToString() != "")
                {
                    strHtml.Append("<td style=' text-align:left;'>" + dr["SalCount"].ToString() + "</td>");
                }
                else
                {
                    strHtml.Append("<td style=' text-align:left;'>￥0.00</td>");
                }

                if (dr["DataTime"] != null && dr["DataTime"].ToString() != "")
                {
                    strHtml.Append("<td style=' text-align:center;'>" + dr["DataTime"].ToString() + "</td>");
                }
                else
                {
                    strHtml.Append("<td style=' text-align:left;'>" + DateTime.Now.ToString("yyyy-MM-dd") + "</td>");
                }
                strHtml.Append("<td style=' text-align:center;'><a href='javascript:AceBrowser.openWindow(\"ViewWord?id=" + pID + "\" ,\"width=1200px;height=800px;\");' >View</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:AceBrowser.openWindow(\"Openfile?id=" + pID + "\" ,\"width=1200px;height=800px;\", "+ pID + ");'>Edit</a></td>");
                strHtml.Append("</tr>");
            }
            if (!flg)
            {
                strHtml.Append("<tr>\r\n");
                strHtml.Append("<td width='100%' height='100' align='center'>Sorry, there is no data available for operation.\r\n");
                strHtml.Append("</td></tr>\r\n");
            }
            ViewBag.strHtml = strHtml.ToString();
            dr.Close();
            conn.Close();
            return View();
        }

        public IActionResult ViewWord(string id)
        {
            String err = "";
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            if (id != null && id.Length > 0)
            {
                string sql = "select * from Salary where id =" + id + " order by ID"; ;
                SQLiteConnection conn = new SQLiteConnection(connString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                SQLiteDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DateTime date = DateTime.Now;

                    WordDocumentWriter doc = new WordDocumentWriter();
                    DataRegionWriter datareg = doc.OpenDataRegion("ACE_table");
                    WordTableWriter table = datareg.OpenTable(1);

                    table.OpenCellRC(2, 1).Value = dr["ID"].ToString();
                    table.OpenCellRC(2, 2).Value = dr["UserName"].ToString();
                    table.OpenCellRC(2, 3).Value = dr["DeptName"].ToString();

                    if (dr["SalTotal"] != null && dr["SalTotal"].ToString() != "")
                    {
                        table.OpenCellRC(2, 4).Value = dr["SalTotal"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 4).Value = "￥0.00";
                    }

                    if (dr["SalDeduct"] != null && dr["SalDeduct"].ToString() != "")
                    {
                        table.OpenCellRC(2, 5).Value = dr["SalDeduct"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 5).Value = "￥0.00";
                    }

                    if (dr["SalCount"] != null && dr["SalCount"].ToString() != "")
                    {
                        table.OpenCellRC(2, 6).Value = dr["SalCount"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 6).Value = "￥0.00";
                    }

                    if (dr["DataTime"] != null && dr["SalTotal"].ToString() != "")
                    {
                        table.OpenCellRC(2, 7).Value = dr["DataTime"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 7).Value = "";
                    }

                    aceCtrl.SetWriter(doc);
                }
                else
                {
                    err = "<script>alert('No salary information found for this employee!');</script>";
                }
                dr.Close();
                conn.Close();

            }
            else
            {
                err = "<script>alert('Employee ID not obtained!');</script>";
            }

            aceCtrl.WebOpen("doc/template.docx", OpenModeType.docReadOnly, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            ViewBag.err = err;
            return View();
        }



        public IActionResult Compose()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            string idlist = Request.Query["ids"];
            string sql = "select * from Salary where ID in(" + idlist + ") order by ID";

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SQLiteDataReader dr = cmd.ExecuteReader();

            WordDocumentWriter doc = new WordDocumentWriter();

            DataRegionWriter data = null;
            WordTableWriter table = null;
            int i = 0;
            while (dr.Read())
            {
                data = doc.CreateDataRegion("reg" + i.ToString(), DataRegionInsertType.Before, "[End]");
                data.Value = "[word]/WordSalaryBill/doc/template.docx[/word]";
                table = data.OpenTable(1);

                table.OpenCellRC(2, 1).Value = dr["ID"].ToString();
                table.OpenCellRC(2, 2).Value = dr["UserName"].ToString();
                table.OpenCellRC(2, 3).Value = dr["DeptName"].ToString();

                if (dr["SalTotal"] != null && dr["SalTotal"].ToString() != "")
                {
                    table.OpenCellRC(2, 4).Value = dr["SalTotal"].ToString();
                }
                else
                {
                    table.OpenCellRC(2, 4).Value = "￥0.00";
                }

                if (dr["SalDeduct"] != null && dr["SalDeduct"].ToString() != "")
                {
                    table.OpenCellRC(2, 5).Value = dr["SalDeduct"].ToString();
                }
                else
                {
                    table.OpenCellRC(2, 5).Value = "￥0.00";
                }

                if (dr["SalCount"] != null && dr["SalCount"].ToString() != "")
                {
                    table.OpenCellRC(2, 6).Value = dr["SalCount"].ToString();
                }
                else
                {
                    table.OpenCellRC(2, 6).Value = "￥0.00";
                }

                if (dr["DataTime"] != null && dr["SalTotal"].ToString() != "")
                {
                    table.OpenCellRC(2, 7).Value = dr["DataTime"].ToString();
                }
                else
                {
                    table.OpenCellRC(2, 7).Value = "";
                }
                i++;
            }

            dr.Close();
            conn.Close();

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docReadOnly, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }



        public IActionResult Openfile(string id)
        {
            String err = "";
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);


            if (id != null && id.Length > 0)
            {
                string sql = "select * from Salary where id =" + id + " order by ID"; ;
                SQLiteConnection conn = new SQLiteConnection(connString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                SQLiteDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DateTime date = DateTime.Now;

                    WordDocumentWriter doc = new WordDocumentWriter();
                    DataRegionWriter dataRegion = doc.OpenDataRegion("ACE_table");
                    WordTableWriter table = dataRegion.OpenTable(1);

                    doc.EnableAllDataRegionsEditing = true;

                    table.OpenCellRC(2, 1).Value = dr["ID"].ToString();
                    table.OpenCellRC(2, 2).Value = dr["UserName"].ToString();
                    table.OpenCellRC(2, 3).Value = dr["DeptName"].ToString();

                    if (dr["SalTotal"] != null && dr["SalTotal"].ToString() != "")
                    {
                        table.OpenCellRC(2, 4).Value = dr["SalTotal"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 4).Value = "￥0.00";
                    }

                    if (dr["SalDeduct"] != null && dr["SalDeduct"].ToString() != "")
                    {
                        table.OpenCellRC(2, 5).Value = dr["SalDeduct"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 5).Value = "￥0.00";
                    }

                    if (dr["SalCount"] != null && dr["SalCount"].ToString() != "")
                    {
                        table.OpenCellRC(2, 6).Value = dr["SalCount"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 6).Value = "￥0.00";
                    }

                    if (dr["DataTime"] != null && dr["SalTotal"].ToString() != "")
                    {
                        table.OpenCellRC(2, 7).Value = dr["DataTime"].ToString();
                    }
                    else
                    {
                        table.OpenCellRC(2, 7).Value = "";
                    }


                    aceCtrl.SetWriter(doc);
                }
                else
                {
                    err = "< script > alert('No salary information is available for this employee！');</ script > ";
                }
                dr.Close();
                conn.Close();


            }
            else
            {
                err = "<script>alert('The ID for which the salary information has not been obtained！');</script>";
            }

            aceCtrl.WebOpen("doc/template.docx", OpenModeType.docSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            ViewBag.err = err;
            ViewBag.id = id;
            return View();
        }

        public async Task<ActionResult> SaveData(string id)
        {

            WordDocumentReader doc = new WordDocumentReader(Request, Response);
            await doc.LoadAsync();
            DataRegionReader dr = doc.OpenDataRegion("ACE_table");
            WordTableReader table = dr.OpenTable(1);

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

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            doc.CustomSaveResult = "ok";
            return doc.Close();
            
        }

    }
}