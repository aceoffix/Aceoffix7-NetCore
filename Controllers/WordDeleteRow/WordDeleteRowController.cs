using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordDeleteRow
{
    public class WordDeleteRowController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WordDeleteRowController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Word()
        {
            ViewBag.FilePath = _webHostEnvironment.WebRootPath + "\\WordDeleteRow\\doc\\test_table.doc"; 

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            WordTableWriter table1 = doc.OpenDataRegion("ACE_table").OpenTable(1);
            WordCellWriter cell = table1.OpenCellRC(2, 1);
            table1.RemoveRowAt(cell);// Delete the row where the cell at coordinates (2, 1) is located.

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test_table.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}