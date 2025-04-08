using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.FormToDataRegions
{
    public class FormToDataRegionsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FormToDataRegionsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter worddoc = new WordDocumentWriter();
            worddoc.OpenDataRegion("ACE_purchaser").Editing = true;
            worddoc.OpenDataRegion("ACE_supplier").Editing = true;
            worddoc.OpenDataRegion("ACE_project_number").Editing = true;
            worddoc.OpenDataRegion("ACE_buyer_company").Editing = true;
            worddoc.OpenDataRegion("ACE_table").Editing = true;
            worddoc.OpenDataRegion("ACE_totalPrice").Editing = true;

            aceCtrl.SetWriter(worddoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FormToDataRegions/doc/" + fs.FileName);
            return   fs.Close();
            
        }
    }
}