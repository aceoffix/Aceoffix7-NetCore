using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.DataRegionEdit
{
    public class DataRegionEditController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataRegionEditController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            doc.Template.DefineDataRegion("ACE_contract_number", "[contract number]");
            doc.Template.DefineDataRegion("ACE_purchasers_name", "[Purchasers full name]");
            doc.Template.DefineDataRegion("ACE_purchasers_email", "[Purchasers email]");
            doc.Template.DefineDataRegion("ACE_purchasers_address", "[Purchasers address]");
            doc.Template.DefineDataRegion("ACE_suppliers_name", "[Suppliers full name]");
            doc.Template.DefineDataRegion("ACE_suppliers_email", "[Suppliers email]");
            doc.Template.DefineDataRegion("ACE_suppliers_address", "[Suppliers address]");

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
            fs.SaveToFile(webRootPath + "/DataRegionEdit/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}