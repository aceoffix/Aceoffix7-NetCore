using Microsoft.AspNetCore.Mvc;
using System.Text;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.SwitchFile
{
    public class SwitchFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void Word(string fileName)
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            // Open the file
            aceCtrl.WebOpen("doc/" + fileName, OpenModeType.docReadOnly, "Tom");
            Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(aceCtrl.GetHtml()));
            
        }
    }
}