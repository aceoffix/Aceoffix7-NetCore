using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.FileMakerToPDF
{
    public class FileMakerToPDFController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerToPDFController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            string url = "";
            url = _webHostEnvironment.WebRootPath;
            ViewBag.url = url + "\\FileMakerToPDF\\doc";
            return View();
        }
 
        public void FileMakerToPDF()
        {
            FileMakerCtrl fileMakerCtrl = new FileMakerCtrl(Request);
            fileMakerCtrl.FillDocumentAsPDF("doc/template.docx", DocumentOpenType.Word, "certificate.pdf");
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fileMakerCtrl.GetHtml()));
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FileMakerToPDF/doc/" + fs.FileName);
            /// Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in the form of a JSON string.
            fs.CustomSaveResult = "ok";
            return fs.Close();
           
        }        

    }
}