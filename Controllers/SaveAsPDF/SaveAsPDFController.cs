using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.SaveAsPDF
{
    public class SaveAsPDFController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected string pdfName = "";
        public SaveAsPDFController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult WordToPDF()
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
            fs.SaveToFile(webRootPath + "/SaveAsPDF/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}