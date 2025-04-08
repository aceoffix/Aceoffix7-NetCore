using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.SimplePPT
{
    public class SimplePPTController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SimplePPTController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult PPT()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.pptx", OpenModeType.pptNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SimplePPT/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}