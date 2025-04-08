using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.FileMakerPDF
{
    public class FileMakerPDFController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerPDFController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            string url = "";
            url = _webHostEnvironment.WebRootPath;
            ViewBag.url = url + "\\FileMakerPDF\\doc";
            return View();
        }
 
        public void FileMakerPDF()
        {
            FileMakerCtrl fmCtrl = new FileMakerCtrl(Request);

            WordDocumentWriter wb = new WordDocumentWriter();
            wb.OpenDataRegion("ACE_UnitName").Value = "Jack Jons";

            fmCtrl.SetWriter(wb);
            fmCtrl.FillDocumentAsPDF("doc/template.docx", DocumentOpenType.Word, "certificate.pdf");
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fmCtrl.GetHtml()));
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FileMakerPDF/doc/" + fs.FileName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in the form of a JSON string.
            fs.CustomSaveResult = "ok";
            return fs.Close();
           
        }        

    }
}