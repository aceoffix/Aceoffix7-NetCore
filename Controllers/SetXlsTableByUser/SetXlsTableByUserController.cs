using System;

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;
using System.Drawing;

namespace Aceoffix7_NetCore.Controllers.SetXlsTableByUser
{
    public class SetXlsTableByUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SetXlsTableByUserController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Excel(string userName)
        {

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            ExcelTableWriter tableA = sheet.OpenTable("C4:D6");
            ExcelTableWriter tableB = sheet.OpenTable("C7:D9");
            if (userName.Equals("Tom"))
            {
                tableA.ReadOnly = false;
                tableA.BackColor = Color.Yellow;
                tableB.ReadOnly = true;
                tableB.BackColor = Color.White;
            }
            else
            {
                tableB.ReadOnly = false;
                tableB.BackColor = Color.Yellow;
                tableA.ReadOnly = true;
                tableA.BackColor = Color.White;
            }

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsSubmitForm, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            ViewBag.userName = userName;
            return View();
        }

        public async Task<ActionResult> SaveDoc()
        {
            FileSaver fs = new FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/SetXlsTableByUser/doc/" + fs.FileName);
            return fs.Close();
            
        }

       
    }
}