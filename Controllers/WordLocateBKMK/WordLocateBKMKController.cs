﻿using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.WordLocateBKMK
{
    public class WordLocateBKMKController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}