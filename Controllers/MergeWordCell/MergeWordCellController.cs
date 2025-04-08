using System.Drawing;

using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.MergeWordCell
{
    public class MergeWordCellController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);


            WordDocumentWriter doc = new WordDocumentWriter();
            WordTableWriter table = doc.OpenDataRegion("Table1").OpenTable(1);

            table.OpenCellRC(1, 1).MergeTo(1, 5);
            table.OpenCellRC(1, 1).Value = "Aceoffix";
            table.OpenCellRC(1, 1).Font.Color = Color.Red;
            table.OpenCellRC(1, 1).Font.Size = 24;
            table.OpenCellRC(1, 1).Font.Name = "Andalus";
            table.OpenCellRC(1, 1).ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}