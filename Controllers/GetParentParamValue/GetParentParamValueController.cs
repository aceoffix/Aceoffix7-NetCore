﻿using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.GetParentParamValue
{
    public class GetParentParamValueController : Controller
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