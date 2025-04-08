using System;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.ConcurrencyCtrl
{
    public class ConcurrencyCtrlController : Controller
    {
		private string connString;
		private readonly IWebHostEnvironment _webHostEnvironment;
        public ConcurrencyCtrlController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
			string rootPath = _webHostEnvironment.WebRootPath.Replace("/", "\\");
			string dataPath = rootPath.Substring(0, rootPath.Length - 7) + "App_Data\\" + "ConcurrencyCtrl.db";
            connString = "Data Source=" + dataPath;
		}
		public IActionResult Default()
		{

			StringBuilder strHtml = new ();

			string sql= "select * from doc order by id desc";

			using SQLiteConnection conn = new (connString);
			conn.Open();

			using SQLiteCommand cmd = new (sql, conn);
			cmd.CommandText = sql;
			using SQLiteDataReader dr = cmd.ExecuteReader();
			bool flag = false;
			while (dr.Read())			{			
				strHtml.Append("<tr>\n");
				strHtml.Append("<td>" + "<img src='../images/office-1.png' />" + "</td>\n");
				strHtml.Append("<td>" + dr["Subject"].ToString() + "</td>\n");
				strHtml.Append("<td ><a class='button-edit' href='javascript:editFile(" + dr["ID"] + ");' >Edit</a>&nbsp;&nbsp;");
				strHtml.Append("<a href='javascript:viewFile(" + dr["ID"] + ");' >View</a></td>\n");
				strHtml.Append(" </tr>\n");

				flag = true;
			}
			if (!flag)
			{
				strHtml.Append("<tr>\r\n");
				strHtml.Append("<td colspan='2' style='width:100%; text-align:center;'>No Data.\r\n");
				strHtml.Append("</td></tr>\r\n");

			}
			ViewBag.strHtml = strHtml.ToString();
			return View();
		}
		public void detectCurrentEditor()
		{
			string id = Request.Query["id"].ToString().Trim();
			string sql = "select * from doc where id=" + id;
			using SQLiteConnection conn = new (connString);
			conn.Open();
			using SQLiteCommand cmd = new (sql, conn);
			using SQLiteDataReader dr = cmd.ExecuteReader();			
			if (dr.Read())
			{				
				Response.WriteAsync("{\"editor\":\"" + dr["Editor"] + "\"}");
			}
		}
		public IActionResult Word()
		{
			string id = Request.Query["id"].ToString().Trim();
			string user = Request.Query["user"].ToString();
			user = System.Web.HttpUtility.UrlDecode(user);

			String fileName = "";
			String subject = "";

			using SQLiteConnection conn = new (connString);
			conn.Open();

			string sql = "select * from doc where id=" + id;
			using SQLiteCommand cmd = new(sql, conn);				
			using SQLiteDataReader dr = cmd.ExecuteReader();					
			if (dr.Read())
			{
				fileName = (String)dr["FileName"];
				subject = (String)dr["Subject"];
			}
			
			string sql2 = "update doc set Editor='" + user + "' where id=" + id;
			using SQLiteCommand cmd2 = new(sql2, conn);
			cmd2.ExecuteNonQuery();

			AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
			aceCtrl.Caption= "Current User:" + user + "Mode: Revision Editing | Document Name:" + subject;
			
			aceCtrl.WebOpen("doc/"+ fileName, OpenModeType.docRevisionOnly, user);
            ViewBag.aceCtrl = aceCtrl.GetHtml();
			ViewBag.subject = subject;
			ViewBag.id = id;
			return View();
        }
		public void clearCurrentEditor()
		{
			string id = Request.Query["id"].ToString().Trim();
			using SQLiteConnection conn = new(connString);
			conn.Open();

			string sql = "update doc set Editor='' where id=" + id;
			using SQLiteCommand cmd = new SQLiteCommand(sql, conn);
			cmd.ExecuteNonQuery();
			Response.WriteAsync("{\"msg\":\"ok\"}");
		}
		public IActionResult Word2()
		{
			string id = Request.Query["id"].ToString().Trim();
			string user = Request.Query["user"].ToString();
			user = System.Web.HttpUtility.UrlDecode(user);

			String fileName = "";
			String subject = "";

			using SQLiteConnection conn = new(connString);
			conn.Open();

			string sql = "select * from doc where id=" + id;
			using SQLiteCommand cmd = new(sql, conn);
			using SQLiteDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				fileName = (String)dr["FileName"];
				subject = (String)dr["Subject"];
			}


			AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
			aceCtrl.Caption= "Current User: " + user + " | Mode: ReadOnly View | Document Name: " + subject;

			aceCtrl.WebOpen("doc/" + fileName, OpenModeType.docReadOnly, "tom");
			ViewBag.aceCtrl = aceCtrl.GetHtml();
			ViewBag.subject = subject;
			ViewBag.id = id;
			return View();
		}
		public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/ConcurrencyCtrl/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}