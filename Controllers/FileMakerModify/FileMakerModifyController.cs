using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.FileMakerModify
{
    public class FileMakerModifyController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerModifyController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            string url = "";
            url = _webHostEnvironment.WebRootPath + "/FileMakerModify/doc/";
            ViewBag.url = url;
            return View();
        }

        
        public void FileMakerModify()
        {
            FileMakerCtrl fmCtrl = new FileMakerCtrl(Request);
            WordDocumentWriter wb = new WordDocumentWriter();
            wb.OpenDataRegion("ACE_UnitName").Value = "Jack Jons";

            fmCtrl.SetWriter(wb);

            fmCtrl.FillDocument("doc/template.docx", DocumentOpenType.Word);

            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fmCtrl.GetHtml()));

        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FileMakerModify/doc/" + "maker" + fs.FileExtName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in the form of a JSON string.
            fs.CustomSaveResult = "ok";
            return fs.Close();
        }

        
    }
}