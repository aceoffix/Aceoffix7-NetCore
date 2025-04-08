using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.SetDrByUserWord
{
    public class SetDrByUserWordController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SetDrByUserWordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Word(string userName)
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = doc.OpenDataRegion("ACE_Paragraph1");
            DataRegionWriter dataRegion2 = doc.OpenDataRegion("ACE_Paragraph2");

            if (userName.Equals("Tom"))
            {
                dataRegion1.Editing = true;
                dataRegion2.Editing = false;

            }

            else
            {
                dataRegion1.Editing = false;
                dataRegion2.Editing = true;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, userName);
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            ViewBag.user = userName;
            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SetDrByUserWord/doc/" + fs.FileName);
            return fs.Close();
            
        }
    }
}