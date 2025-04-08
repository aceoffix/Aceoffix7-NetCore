using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.InsertImageSetSize
{
    public class InsertImageSetSizeController : Controller
    {
        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter worddoc = new WordDocumentWriter();
            // First, manually insert bookmarks at the positions where you want to insert Word files. The bookmarks must start with "ACE_".
            // Assign values to the DataRegion. The value should be in the format: "[image]Path to the image[/image]"
            DataRegionWriter img1 = worddoc.OpenDataRegion("ACE_Image1");

            //The units for the width and height attributes in an [image] tag are: inches.
            img1.Value = "[image width=100.2 height=50]doc/image1.png[/image]";
            DataRegionWriter img2 = worddoc.OpenDataRegion("ACE_Image2");
            img2.Value = "[image width=200.2 height=200]doc/image2.png[/image]";
            aceCtrl.SetWriter(worddoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}