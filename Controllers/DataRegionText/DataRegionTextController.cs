﻿using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.DataRegionText
{
    public class DataRegionTextController : Controller
    {

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            DataRegionWriter paragraph1 = doc.OpenDataRegion("ACE_p1");
            paragraph1.Font.Color = Color.Blue;//Font Color
            paragraph1.Font.Name = "Arial Rounded MT Bold";// Font Style
            paragraph1.Font.Size = 16;
            paragraph1.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;//Alignment

            DataRegionWriter paragraph2 = doc.OpenDataRegion("ACE_p2");
            paragraph2.Font.Color = Color.Orange;//Font Color
            paragraph2.Font.Name = "Algerian";// Font Style
            paragraph2.Font.Size = 14;
            paragraph2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;//Alignment

            DataRegionWriter paragraph3 = doc.OpenDataRegion("ACE_p3");
            paragraph3.Font.Color = Color.Magenta;//Font Color
            paragraph3.Font.Name = "Blackadder ITC";// Font Style
            paragraph3.Font.Size = 12;
            paragraph3.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;//Alignment

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

       

    }
}