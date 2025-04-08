using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.InsertPageBreak2
{
    public class InsertPageBreak2Controller : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InsertPageBreak2Controller(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter wordDocument = new WordDocumentWriter();

            // Insert a page break at the end of the document and create a new data region to insert another document on the new page.
            DataRegionWriter mydr1 = wordDocument.CreateDataRegion("ACE_first", DataRegionInsertType.After, "[end]");
            mydr1.SelectEnd();
            wordDocument.InsertPageBreak(); // Insert a page break

            DataRegionWriter mydr2 = wordDocument.CreateDataRegion("ACE_second", DataRegionInsertType.After, "[end]");
            mydr2.Value = "[word]/InsertPageBreak2/doc/test2.docx[/word]";

            aceCtrl.SetWriter(wordDocument);

            aceCtrl.WebOpen("doc/test1.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/InsertPageBreak2/doc/" + "test3.doc");
            fs.CustomSaveResult = "ok";
            return  fs.Close();
            
        }
    }
}