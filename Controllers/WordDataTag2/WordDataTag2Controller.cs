using System;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordDataTag2
{
    public class WordDataTag2Controller : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter wd = new WordDocumentWriter();
            DataTagWriter dataTag1 = wd.OpenDataTag("{name}");
            dataTag1.Value = "Tom";
            DataTagWriter dataTag2 = wd.OpenDataTag("{Number}");
            dataTag2.Value = "201501";
            DataTagWriter dataTag3 = wd.OpenDataTag("{Department}");
            dataTag3.Value = "Development";
            DataTagWriter dataTag4 = wd.OpenDataTag("{Manager}");
            dataTag4.Value = "John Scott";
            DataTagWriter dataTag5 = wd.OpenDataTag("{Salary}");
            dataTag5.Value = "$5000";

            aceCtrl.SetWriter(wd);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}