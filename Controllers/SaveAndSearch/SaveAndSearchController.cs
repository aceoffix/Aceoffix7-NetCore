using System.Data;
using System.Data.SQLite;

using System.Text;
using System.Threading.Tasks;
using AceoffixNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Aceoffix7_NetCore.Controllers.SaveAndSearch
{
    public class SaveAndSearchController : Controller
    {
        private string connString ;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SaveAndSearchController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            string rootPath = _webHostEnvironment.WebRootPath.Replace("/", "\\");
            string dataPath = rootPath.Substring(0, rootPath.Length - 7) + "App_Data\\" + "SaveAndSearch.db";
            connString = "Data Source=" + dataPath;
        }
        public IActionResult Index()
        {

            StringBuilder strHtml = new StringBuilder();

            string key = Request.Query["Input_KeyWord"].ToString();

            key = Request.Query["Input_KeyWord"].ToString();
            key = System.Web.HttpUtility.UrlDecode(key, System.Text.Encoding.UTF8);
            ViewBag.key = key;
            string sql;

            if (key != null && key.Length > 0)
            {
                sql = "select * from word  where Content like '%" + key + "%' order by ID desc";
            }
            else
            {
                sql = "select * from word order by ID desc ";
            }

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SQLiteDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            while (dr.Read())
            {
                //string param = "{key:" + key + ",id:" + dr["ID"] + "}";
                strHtml.Append("<tr>");
                strHtml.Append("<td>" + dr["FileName"].ToString() + "</td>");
                strHtml.Append("<td><a style=' color:#00217d;' href='javascript:AceBrowser.openWindow(\"Word?ID=" + dr["ID"].ToString() + "\",\"width=1200px;height=800px;\",\""
                    + key + "," + dr["ID"] + "\");' >Edit</a></td>");
                strHtml.Append(" </tr>");

                flag = true;
            }
            if (!flag)
            {
                strHtml.Append("<tr>\r\n");
                strHtml.Append("<td colspan='2' style='width:100%; text-align:center;'>No Data\r\n");
                strHtml.Append("</td></tr>\r\n");

            }
            ViewBag.strHtml = strHtml.ToString();
            return View();
        }

        public IActionResult Word()
        {
            string id = Request.Query["id"].ToString().Trim();
            string sql = "select * from word where id=" + id;
            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = sql;
            SQLiteDataReader dr = cmd.ExecuteReader();

            string fileName = "";
            if (dr.Read())
            {
                if (dr["FileName"] != null && dr["FileName"].ToString().Length > 0)
                {
                    fileName = dr["FileName"].ToString().Trim() + ".docx";
                }
            }
            dr.Close();
            conn.Close();

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            string webRootPath = _webHostEnvironment.WebRootPath;
            //Console.WriteLine(webRootPath + "\\SaveAndSearch\\doc\\" + fileName);
            aceCtrl.WebOpen(webRootPath + "\\SaveAndSearch\\doc\\" + fileName, OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> SaveDoc(int ID)
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();

            string id = ID.ToString().Trim();
            string content = fs.DocumentText;

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            string sql = "update word set Content='" + content + "' where id=" + id;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SaveAndSearch/doc/" + fs.FileName);
            fs.CustomSaveResult = "ok";
            return fs.Close();
            
        }


    }
}