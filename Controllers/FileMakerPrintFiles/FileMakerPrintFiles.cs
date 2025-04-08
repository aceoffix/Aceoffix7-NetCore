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
    public class FileMakerPrintFiles : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileMakerPrintFiles(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string url = "";
            url = _webHostEnvironment.WebRootPath;
            ViewBag.url = url + "\\FileMakerPrintFiles\\doc";
            return View();
        }


        public void FileMaker(string id)
        {           
            Console.WriteLine(id);
            FileMakerCtrl fmCtrl = new FileMakerCtrl(Request);

            string filePath = "";
            string url = "";
            url = _webHostEnvironment.WebRootPath;

            if ("1".Equals(id))
            {
                filePath = url+ "\\FileMakerPrintFiles\\doc\\Aceoffix Product Overview.docx";
            }
            if ("2".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Aceoffix Trial Limits.docx";
            }
            if ("3".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Aceoffix License Policy.docx";
            }
            if ("4".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Introduction to Aceoffix.docx";
            }

            fmCtrl.FillDocument(filePath, DocumentOpenType.Word);
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(fmCtrl.GetHtml()));
        }

		public IActionResult Preview(string id)
		{
            string filePath = "";
            string url = "";
            url = _webHostEnvironment.WebRootPath;

            if ("1".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Aceoffix Product Overview.docx";
            }
            if ("2".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Aceoffix Trial Limits.docx";
            }
            if ("3".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Aceoffix License Policy.docx";
            }
            if ("4".Equals(id))
            {
                filePath = url + "\\FileMakerPrintFiles\\doc\\Introduction to Aceoffix.docx";
            }

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
			aceCtrl.WebOpen(filePath, OpenModeType.docReadOnly, "tom");
			ViewBag.aceCtrl = aceCtrl.GetHtml();
			return View();
		}

	}
}