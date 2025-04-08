using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordResExcel
{
    public class WordResExcelController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter worddoc = new WordDocumentWriter();

            DataRegionWriter img1 = worddoc.OpenDataRegion("ACE_Image");
            img1.Value = "[image]doc/image1.png[/image]";

            DataRegionWriter excel1 = worddoc.OpenDataRegion("ACE_Excel");
            excel1.Value = "[excel]doc/test.xlsx[/excel]";

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