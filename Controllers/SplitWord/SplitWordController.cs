using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;
using Microsoft.AspNetCore.Hosting.Server;

namespace Aceoffix7_NetCore.Controllers.SplitWord
{
    public class SplitWordController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SplitWordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);


            WordDocumentWriter wordDoc = new WordDocumentWriter();

            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_paragraph1");
            dataRegion1.SubmitAsFile = true;

            DataRegionWriter dataRegion2 = wordDoc.OpenDataRegion("ACE_paragraph2");
            dataRegion2.SubmitAsFile = true;
            dataRegion2.Editing = true;

            DataRegionWriter dataRegion3 = wordDoc.OpenDataRegion("ACE_paragraph3");
            dataRegion3.SubmitAsFile = true;

            aceCtrl.SetWriter(wordDoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveData()
        {
            WordDocumentReader doc = new WordDocumentReader(Request, Response);
            await doc.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            Byte[] bWord;

            DataRegionReader dr1 = doc.OpenDataRegion("ACE_paragraph1");
            bWord = dr1.FileBytes;
            Stream s1 = new FileStream(webRootPath + "/SplitWord/doc/paragraph1.docx", FileMode.Create);
            s1.Write(bWord, 0, bWord.Length);
            s1.Close();


            DataRegionReader dr2 = doc.OpenDataRegion("ACE_paragraph2");
            bWord = dr2.FileBytes;
            Stream s2 = new FileStream(webRootPath + "/SplitWord/doc/paragraph2.docx", FileMode.Create);
            s2.Write(bWord, 0, bWord.Length);
            s2.Close();

            DataRegionReader dr3 = doc.OpenDataRegion("ACE_paragraph3");
            bWord = dr3.FileBytes;
            Stream s3 = new FileStream(webRootPath + "/SplitWord/doc/paragraph3.docx", FileMode.Create);
            s3.Write(bWord, 0, bWord.Length);
            s3.Close();

            return doc.Close();
            
        }
    }
}