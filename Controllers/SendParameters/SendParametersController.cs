using System.Threading.Tasks;
using System.Web;
using AceoffixNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;

namespace Aceoffix7_NetCore.Controllers.SendParameters
{
    public class SendParametersController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SendParametersController(IWebHostEnvironment webHostEnvironment)
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


        public async Task<ActionResult> SaveDoc(int id, string userName, string age)
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SendParameters/doc/" + fs.FileName);

            if (userName != null && userName.Trim().Length > 0)
            {
                userName = fs.GetFormField("userName");
                userName = HttpUtility.UrlDecode(userName);
            }

            if (age != null && age.Trim().Length > 0)
            {
                age = fs.GetFormField("selSex");
                age = HttpUtility.UrlDecode(age);

            }


            var data = new
            {
                userName = userName,
                age = age,
                id = id
            };
            // Return a JSON - formatted result to the aceoffix control page
            fs.CustomSaveResult = data.ToString();
            //await Response.Body.WriteAsync(Encoding.GetEncoding("gbk").GetBytes(content));
            return fs.Close();
        }
    }
}