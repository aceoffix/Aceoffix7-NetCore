using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordResWord
{
    public class WordResWordController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter worddoc = new WordDocumentWriter();
            // First, manually insert bookmarks at the positions where you want to insert Word files. The bookmarks must start with "ACE_".
            // Assign values to the DataRegion. The value should be in the format: "[word]Path to the Word file[/word]"
            DataRegionWriter data1 = worddoc.OpenDataRegion("ACE_paragraph1");
            data1.Value = "[word]doc/paragraph1.docx[/word]";
            DataRegionWriter data2 = worddoc.OpenDataRegion("ACE_paragraph2");
            data2.Value = "[word]doc/paragraph2.docx[/word]";
            DataRegionWriter data3 = worddoc.OpenDataRegion("ACE_paragraph3");
            data3.Value = "[word]doc/paragraph3.docx[/word]";

            aceCtrl.SetWriter(worddoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}