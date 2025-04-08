using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers
{
    public class DataRegionFillController : Controller
    {

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            // Get the data region object and then assign a value
            DataRegionWriter dataRegion1 = doc.OpenDataRegion("ACE_Name");
            dataRegion1.Value = "John";
            // You can also assign a value directly
            DataRegionWriter dataRegion2 = doc.OpenDataRegion("ACE_department");
            dataRegion2.Value = "Sales Department";

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}