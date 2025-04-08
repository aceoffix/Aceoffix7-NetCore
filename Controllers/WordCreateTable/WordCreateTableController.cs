using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordCreateTable
{
    public class WordCreateTableController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();

            // Create a table with 3 rows and 5 columns in the data region "ACE_table1"
            WordTableWriter table1 = doc.OpenDataRegion("ACE_Table1").CreateTable(3, 5, WdAutoFitBehavior.wdAutoFitWindow);

            // Merge cells in the first column from row 1 to row 3
            table1.OpenCellRC(1, 1).MergeTo(3, 1);
            table1.OpenCellRC(1, 1).Value = "Merged Cell";

            // Assign values to the remaining cells in table1
            for (int i = 1; i < 4; i++)
            {
                table1.OpenCellRC(i, 2).Value = "AA" + i.ToString();
                table1.OpenCellRC(i, 3).Value = "BB" + i.ToString();
                table1.OpenCellRC(i, 4).Value = "CC" + i.ToString();
                table1.OpenCellRC(i, 5).Value = "DD" + i.ToString();
            }

            // Dynamically create a new data region "ACE_table2" after "ACE_table1" and create a new table with 5 rows and 5 columns
            DataRegionWriter drTable2 = doc.CreateDataRegion("ACE_Table2", DataRegionInsertType.After, "ACE_table1");
            WordTableWriter table2 = drTable2.CreateTable(5, 5, WdAutoFitBehavior.wdAutoFitWindow);

            // Assign values to the cells in table2
            for (int i = 1; i < 6; i++)
            {
                table2.OpenCellRC(i, 1).Value = "AA" + i.ToString();
                table2.OpenCellRC(i, 2).Value = "BB" + i.ToString();
                table2.OpenCellRC(i, 3).Value = "CC" + i.ToString();
                table2.OpenCellRC(i, 4).Value = "DD" + i.ToString();
                table2.OpenCellRC(i, 5).Value = "EE" + i.ToString();
            }

            // Set the document writer and open the document for editing
            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}