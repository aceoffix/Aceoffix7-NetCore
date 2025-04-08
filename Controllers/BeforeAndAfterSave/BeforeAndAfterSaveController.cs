using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.BeforeAndAfterSave
{
    public class BeforeAndAfterSaveController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BeforeAndAfterSaveController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            // Save the file to the specified path on the server
            fs.SaveToFile(webRootPath + "/BeforeAndAfterSave/doc/" + fs.FileName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in JSON string format.
            fs.CustomSaveResult = "ok";
            // Close the FileSaver object
            return fs.Close();
            
        }
    }
}