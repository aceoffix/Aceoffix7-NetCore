using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.DataTagEdit
{
    public class DataTagEditController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataTagEditController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            doc.Template.DefineDataTag("{contract number}");
            doc.Template.DefineDataTag("{Purchasers full name}");
            doc.Template.DefineDataTag("{Purchasers email}");
            doc.Template.DefineDataTag("{Purchasers address}");
            doc.Template.DefineDataTag("{Suppliers full name}");
            doc.Template.DefineDataTag("{Suppliers email}");
            doc.Template.DefineDataTag("{Suppliers address}");

            aceCtrl.SetWriter(doc);         
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

       
        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/DataTagEdit/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}