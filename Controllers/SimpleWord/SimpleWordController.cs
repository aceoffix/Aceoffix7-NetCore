using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.SimpleWord
{
    public class SimpleWordController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SimpleWordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public IActionResult Word1()

        {
            string simplePath = "\\SimpleWord\\doc\\test.docx";
            string filePath = _webHostEnvironment.WebRootPath + simplePath;

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            aceCtrl.WebOpen(filePath, OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SimpleWord/doc/" + fs.FileName);
            return   fs.Close();
            
        }
    }
}