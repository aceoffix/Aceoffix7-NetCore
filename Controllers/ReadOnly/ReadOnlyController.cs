using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.ReadOnly
{
    public class ReadOnlyController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.AllowCopy = false;
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docReadOnly, "Tom");

            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}