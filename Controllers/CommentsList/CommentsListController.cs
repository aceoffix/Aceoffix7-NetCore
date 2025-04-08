using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace NetCoreSamples5.Controllers.CommentsList
{
    public class CommentsListController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CommentsListController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docRevisionOnly, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/CommentsList/doc/" + fs.FileName);
            return fs.Close();
        }
    }
}