using System;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;


namespace Aceoffix7_NetCore.Controllers.ExaminationPaper
{
    public class ExaminationPaperController : Controller
    {

        private string connString;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExaminationPaperController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            string rootPath= _webHostEnvironment.WebRootPath.Replace("/", "\\");
            string dataPath = rootPath.Substring(0, rootPath.Length - 7) + "App_Data\\" + "ExaminationPaper.db";
            connString = "Data Source=" + dataPath;
        }


        public IActionResult Index()
        {
            string sql = "Select * from stream";
            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SQLiteDataReader dr = cmd.ExecuteReader();

            StringBuilder strHtmls = new StringBuilder();

            strHtmls.Append("<tr style='background-color:#FEE;height:50px;'>");
            strHtmls.Append("<td width='10%'>Select</td>");
            strHtmls.Append("<td width='50%'>Question Bank ID</td>");
            strHtmls.Append("<td width='40%'>Operations</td>");
            strHtmls.Append("</tr>");
           
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string pID = dr["ID"].ToString().Trim();
                    strHtmls.Append("<tr  style='background-color:white;height:40px;'>");
                    strHtmls.Append("<td><input id='check" + pID + "'  type='checkbox' /></td>");
                    strHtmls.Append("<td>Question - " + pID + "</td>");
                    strHtmls.Append("<td><a href='javascript:AceBrowser.openWindow(\"Edit?id=" + pID + "\" ,\"width=1200px;height=800px;\","+pID+ ");'>Edit</a></td>");
                    strHtmls.Append("</tr>");
                }
            }
            else
            {
                strHtmls.Append("<tr>\r\n");
                strHtmls.Append("<td colspan='3' width='100%' height='100' align='center'>Sorry, there is no data available for operation.\r\n");
                strHtmls.Append("</td></tr>\r\n");
            }

            ViewBag.strHtmls = strHtmls.ToString();
            dr.Close();
            conn.Close();
            return View();
        }

        public IActionResult Edit()
        {

            string id = Request.Query["id"];
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);       
            aceCtrl.WebOpen("Openfile?id=" + id, OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public IActionResult Compose2()
        {
            int num = 1;// Question number

            string idlist = Request.Query["ids"];          
            string[] ids = idlist.Split(',');

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            string temp = "ACE_begin";
           
            WordDocumentWriter doc = new WordDocumentWriter();
            for (int i = 0; i < ids.Length; i++)
            {
                DataRegionWriter dataNum = doc.CreateDataRegion("ACE_" + num, DataRegionInsertType.After, temp);
                dataNum.Value = num + ".\t";
                DataRegionWriter dataReg = doc.CreateDataRegion("ACE_begin" + (i + 1), DataRegionInsertType.After, "ACE_" + num);
                dataReg.Value = "[word]OpenFile?id=" + ids[i] + "[/word]";
                num++;
                temp = "ACE_begin" + (i + 1);
            }
          
            aceCtrl.SetWriter(doc);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docReadOnly, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public void Openfile()
        {
            string docID = Request.Query["id"];
            string sql = "select Word from stream where id =" + docID;
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        long num = dr.GetBytes(0, 0, null, 0, Int32.MaxValue);
                        Byte[] b = new Byte[num];
                        dr.GetBytes(0, 0, b, 0, b.Length);
                        Response.ContentType = "Application/msword"; // application/x-excel, application/ms-powerpoint, application/pdf 
                        Response.Headers.Add("Content-Disposition", "attachment; filename=down.doc");
                        Response.Headers.Add("Content-Length", num.ToString());
                        Response.Body.WriteAsync(b);
                    }
                }

            }
            Response.Body.Flush();
            Response.Body.Close();
        }

        public async Task<ActionResult> SaveDoc(int id)
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            //string id = Request.Query["id"];
            string sql = "UPDATE  Stream SET Word=@file  where ID=" + id;
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                byte[] aa = fs.FileBytes;
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    SQLiteParameter parameter = new SQLiteParameter("@file",System.Data.DbType.Binary);
                    parameter.Value = aa;
                    cmd.Parameters.Add(parameter);
                    cmd.ExecuteNonQuery();
                }
            }
            return fs.Close();
            
        }
    }
}