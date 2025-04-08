using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.SubmitWord
{
    public class SubmitWordController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SubmitWordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            // Get the data region object and then assign a value
            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_Name");
            dataRegion1.Editing = true;
            dataRegion1.Value = " ";
            // You can also assign a value directly
            DataRegionWriter dataRegion2 = wordDoc.OpenDataRegion("ACE_department");
            dataRegion2.Editing = true;
            dataRegion2.Value = " ";

            aceCtrl.SetWriter(wordDoc); // Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Luna");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveData()
        {
            WordDocumentReader doc = new WordDocumentReader(Request, Response);
            await doc.LoadAsync();

            DataRegionReader dataUserName = doc.OpenDataRegion("ACE_Name");
            DataRegionReader dataDeptName = doc.OpenDataRegion("ACE_Department");

            JObject jsonObject = new JObject();
            jsonObject["userName"] = dataUserName.Value;
            jsonObject["department"] = dataDeptName.Value;
            jsonObject["companyName"] = doc.GetFormField("companyName");
            // Convert the JObject to a JSON string
            string jsonString = jsonObject.ToString();
            // Return a JSON - formatted result to the aceoffix control page
            doc.CustomSaveResult = jsonString;
            return doc.Close(); ;
        }
    }
}