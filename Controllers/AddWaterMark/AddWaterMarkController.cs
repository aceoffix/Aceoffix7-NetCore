using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.AddWaterMark
{
    public class AddWaterMarkController : Controller
    {
        public IActionResult AddWaterMark()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            WordDocumentWriter doc = new WordDocumentWriter();
            doc.WaterMark.Text = "Aceoffix";
            aceCtrl.SetWriter(doc);// Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}