using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace NetCoreSamples5.Controllers.SaveFirstPageAsImg
{
    public class SaveFirstPageAsImgController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SaveFirstPageAsImgController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (fs.FileExtName.Equals(".jpg"))
            {
                fs.SaveToFile(webRootPath + "/SaveFirstPageAsImg/doc/" + fs.FileName);
            }
            else
            {
                fs.SaveToFile(webRootPath + "/SaveFirstPageAsImg/doc/" + fs.FileName);
            }

            return fs.Close();
        }
    }
}