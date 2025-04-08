using System.Threading.Tasks;
using AceoffixNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Aceoffix7_NetCore.Controllers.SaveReturnValue
{
    public class SaveReturnValueController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SaveReturnValueController(IWebHostEnvironment webHostEnvironment)
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


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SaveReturnValue/doc/" + fs.FileName);
            fs.CustomSaveResult = "ok";
            return fs.Close();
            
        }
    }
}