using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.FileMaker
{
    public class FileMakerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            string url = "";
            url = _webHostEnvironment.WebRootPath;
            ViewBag.url = url + "\\FileMaker\\doc";
            return View();
        }
        public void FileMaker(int id)
        {
            string[] companyArr = { "empty", "Microsoft (China) Co., Ltd.", "IBM (China) Services Co., Ltd.", "Amazon Trade Co., Ltd.",
                                "Facebook Technology Co., Ltd.", "Google Network Co., Ltd.", "NVIDIA Technology Co., Ltd.",
                                "TSMC Technology Co., Ltd.", "Walmart Inc." };
            FileMakerCtrl fmCtrl = new FileMakerCtrl(Request);
   
            WordDocumentWriter wb = new WordDocumentWriter();
            wb.OpenDataRegion("ACE_Company").Value = companyArr[id];

            fmCtrl.SetWriter(wb);

            fmCtrl.FillDocument("doc/template.docx", DocumentOpenType.Word);
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fmCtrl.GetHtml()));
        }

        public async Task<ActionResult> SaveDoc(int id)
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            string fileName = "maker" + id + fs.FileExtName; ;
            fs.SaveToFile(webRootPath + "/FileMaker/doc/" + fileName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in the form of a JSON string.
            fs.CustomSaveResult = "ok";
            return fs.Close();
        }
    }
}