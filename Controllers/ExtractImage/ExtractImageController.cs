using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;
using Microsoft.AspNetCore.Hosting.Server;

namespace Aceoffix7_NetCore.Controllers.ExtractImage
{
    public class ExtractImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExtractImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter wordDoc = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_image");
            dataRegion1.Editing = true;
            aceCtrl.SetWriter(wordDoc);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveData()
        {
            WordDocumentReader wordDoc = new WordDocumentReader(Request, Response);
            
            await wordDoc.LoadAsync();
            DataRegionReader dataRegion1 = wordDoc.OpenDataRegion("ACE_image");

            string webRootPath = _webHostEnvironment.WebRootPath;
            dataRegion1.OpenShape(1).SaveAsJPG(webRootPath + "/ExtractImage/doc/logo.jpg");

            wordDoc.CustomSaveResult = "The save was successful. The image path is:" + webRootPath + "/ExtractImage/doc/logo.jpg";
            return wordDoc.Close();
            
        }
    }
}