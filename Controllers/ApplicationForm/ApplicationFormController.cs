using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.AfterDocOpened
{
    public class ApplicationFormController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}