using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordSetTable
{
    public class WordSetTableController : Controller
    {

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);


            WordDocumentWriter wd = new WordDocumentWriter();
            DataRegionWriter dataRegion = wd.OpenDataRegion("ACE_Table");
            WordTableWriter table = dataRegion.OpenTable(1);

            table.OpenCellRC(3, 1).Value = "Tom";
            table.OpenCellRC(3, 2).Value = "201501";
            table.OpenCellRC(3, 3).Value = "Development";
            table.OpenCellRC(3, 4).Value = "John Scott";
            table.OpenCellRC(3, 5).Value = "$5000";

            table.InsertRowAfter(table.OpenCellRC(3, 5));

            table.OpenCellRC(4, 1).Value = "Jack";
            table.OpenCellRC(4, 2).Value = "201502";
            table.OpenCellRC(4, 3).Value = "Sales";
            table.OpenCellRC(4, 4).Value = "Anna";
            table.OpenCellRC(4, 5).Value = "$5500";

            aceCtrl.SetWriter(wd);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


    }
}