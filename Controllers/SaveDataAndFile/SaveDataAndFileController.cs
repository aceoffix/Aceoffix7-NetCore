using System;

using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;


namespace Aceoffix7_NetCore.Controllers.SaveDataAndFile
{
    public class SaveDataAndFileController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SaveDataAndFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter wd = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = wd.OpenDataRegion("ACE_Name");
            dataRegion1.Editing = true;
            dataRegion1.Value = "Tom";
            DataRegionWriter dataRegion3 = wd.OpenDataRegion("ACE_Department");
            dataRegion3.Editing = true;
            dataRegion3.Value = "Development";

            aceCtrl.SetWriter(wd);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SaveDataAndFile/doc/" + fs.FileName);
            // Set the custom save result to be returned to the front-end page. The parameter of CustomSaveResult can also be in JSON string format.
            // Set the save result of the file
            fs.CustomSaveResult = "ok2";
            return fs.Close();
            
        }

        public async Task<ActionResult> SaveData()
        {
            WordDocumentReader doc = new WordDocumentReader(Request, Response);
            await doc.LoadAsync();
            // Get the submitted values
            string dataUserName = doc.OpenDataRegion("ACE_Name").Value;
            string dataDeptName = doc.OpenDataRegion("ACE_Department").Value;
            string companyName = doc.GetFormField("CompanyName");

            /**The retrieved content such as company name, employee name, and department name can be saved to the database. 
             * Here, developers can connect to their own databases, for example, connect to a SQL Server 2008 database.
             * string constr = "server=ACER-PC\\LI;database=db_test;uid=sa;pwd=123";
             * conn = new SqlConnection(constr);  // Database connection
             * conn.Open();
             * SqlCommand cmd = new SqlCommand("update user set userName='" + dataUserName + "',deptName='" + dataDeptName + "',companyName='" + companyName + "' where userId=1", conn);
             * cmd.ExecuteNonQuery();
             * conn.Close();
             */
            doc.CustomSaveResult = "ok1";
            return doc.Close();
            
        }

    }
}