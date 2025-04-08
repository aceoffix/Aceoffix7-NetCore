using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.OpenWord
{
    public class OpenWordController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docReadOnly, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}