using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.FileMakerConvertPDFs
{
    public class FileMakerConvertPDFsController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerConvertPDFsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public void Convert(String id)
        {
            string filePath = "";
            string pdfName = "";

            //String id = Request.Query["id"];
            //String id = Request.Query["id"];
            string webRootPath = _webHostEnvironment.WebRootPath;
            if ("1".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix Product Overview.docx";
                pdfName = "Aceoffix Product Overview.pdf";
            }
            if ("2".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix Trial Limits.docx";
                pdfName = "Aceoffix Trial Limits.pdf";
            }
            if ("3".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix License Policy.docx";
                pdfName = "Aceoffix License Policy.pdf";
            }
            if ("4".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Introduction to Aceoffix.docx";
                pdfName = "Introduction to Aceoffix.pdf";
            }

            FileMakerCtrl fileMakerCtrl = new FileMakerCtrl(Request);

            fileMakerCtrl.FillDocumentAsPDF(filePath, DocumentOpenType.Word, pdfName);
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fileMakerCtrl.GetHtml()));
        }
       

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/FileMakerConvertPDFs/doc/" + fs.FileName);
            return fs.Close();
        }

        public IActionResult Edit(string id)
        {
            string filePath = "";           

            string webRootPath = _webHostEnvironment.WebRootPath;
            if ("1".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix Product Overview.docx";
            }
            if ("2".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix Trial Limits.docx";
            }
            if ("3".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Aceoffix License Policy.docx";
            }
            if ("4".Equals(id))
            {
                filePath = webRootPath + "\\FileMakerConvertPDFs\\doc\\Introduction to Aceoffix.docx";
            }

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen(filePath, OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

       

	}
}