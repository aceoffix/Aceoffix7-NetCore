using System;
using System.IO;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.SetDrByUserWord2
{
    public class SetDrByUserWord2Controller : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SetDrByUserWord2Controller(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Word(string userName)
        {

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = doc.OpenDataRegion("ACE_Paragraph1");
            DataRegionWriter dataRegion2 = doc.OpenDataRegion("ACE_Paragraph2");

            dataRegion1.Value = "[word]doc/paragraph1.docx[/word]";
            dataRegion2.Value = "[word]doc/paragraph2.docx[/word]";

            if (userName.Equals("Tom"))
            {
                dataRegion1.Editing = true;
                dataRegion2.Editing = false;
                dataRegion1.SubmitAsFile = true;

            }

            else
            {
                dataRegion1.Editing = false;
                dataRegion2.Editing = true;
                dataRegion2.SubmitAsFile = true;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, userName);
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            ViewBag.userName = userName;
            return View();
        }

        public async Task<ActionResult> SaveData(string userName)
        {
            WordDocumentReader doc = new WordDocumentReader(Request, Response);
            await doc.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (userName != "" && userName.Equals("Tom"))
             {
                saveBytesToFile(doc.OpenDataRegion("ACE_Paragraph1").FileBytes, webRootPath + "/SetDrByUserWord2/doc/paragraph1.docx");
            }
            else
            {
                saveBytesToFile(doc.OpenDataRegion("ACE_Paragraph2").FileBytes, webRootPath + "/SetDrByUserWord2/doc/paragraph2.docx");
            }

            return doc.Close();
            
        }
        private void saveBytesToFile(byte[] bytes, string filePath)
        {
            FileStream fs = new FileStream(filePath, System.IO.FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

    }
}