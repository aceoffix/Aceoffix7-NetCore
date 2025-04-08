using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordTable
{
    public class WordTableController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter doc = new WordDocumentWriter();
            WordTableWriter table1 = doc.OpenDataRegion("ACE_T001").OpenTable(1);
            table1.OpenCellRC(1, 1).Value = "Aceoffix Component";
            int oldRowCount = 3; // The original number of rows in the table.
            int dataRowCount = 5; // The number of rows to be filled with data.

            // Expand the table.
            for (int j = 0; j < dataRowCount - oldRowCount; j++)
            {
                // Insert a new row after the last cell in the second row.
                table1.InsertRowAfter(table1.OpenCellRC(2, 5));
            }

            int i = 1;
            while (i <= dataRowCount)
            {
                table1.OpenCellRC(i, 2).Value = "AA" + i.ToString();
                table1.OpenCellRC(i, 3).Value = "BB" + i.ToString();
                table1.OpenCellRC(i, 4).Value = "CC" + i.ToString();
                table1.OpenCellRC(i, 5).Value = "DD" + i.ToString();
                i++;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test_table.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}