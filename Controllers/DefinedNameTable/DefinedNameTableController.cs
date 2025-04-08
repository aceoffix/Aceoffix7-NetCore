using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.DefinedNameTable
{
    public class DefinedNameTableController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public DefinedNameTableController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExcelFill()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");

            ExcelTableWriter table = sheet.OpenTableByDefinedName("report", 10, 5, false);
            table.DataFields[0].Value = "Jan";
            table.DataFields[1].Value = "100";
            table.DataFields[2].Value = "120";
            table.DataFields[3].Value = "500";
            table.DataFields[4].Value = "120%";
            table.NextRow();
            table.Close();
            aceCtrl.SetWriter(wb);

            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
        public IActionResult ExcelFill2()
        {

            string tempFileName = Request.Query["temp"];

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");

            ExcelTableWriter table = sheet.OpenTableByDefinedName("report", 10, 5, false);
            table.DataFields[0].Value = "Jan";
            table.DataFields[1].Value = "100";
            table.DataFields[2].Value = "120";
            table.DataFields[3].Value = "500";
            table.DataFields[4].Value = "120%";
            table.NextRow();
            table.Close();

            ExcelCellWriter cellName = sheet.OpenCellByDefinedName("Name");
            cellName.Value = "Tom";

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/" + tempFileName, OpenModeType.xlsSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public IActionResult ExcelFill4()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");

            ExcelTableWriter table = sheet.OpenTable("B4:F11");
            int rowCount = 12;
            for (int i = 1; i <= rowCount; i++)
            {
                table.DataFields[0].Value = i + "Month";
                table.DataFields[1].Value = "100";
                table.DataFields[2].Value = "120";
                table.DataFields[3].Value = "500";
                table.DataFields[4].Value = "120%";
                table.NextRow();

            }

            table.Close();

            ExcelTableWriter table2 = sheet.OpenTable("B13:F16");
            int rowCount2 = 12;
            for (int i = 1; i <= rowCount2; i++)
            {
                table2.DataFields[0].Value = i + "Quarter";
                table2.DataFields[1].Value = "300";
                table2.DataFields[2].Value = "300";
                table2.DataFields[3].Value = "300";
                table2.DataFields[4].Value = "100%";
                table2.NextRow();

            }

            table2.Close();

            aceCtrl.SetWriter(wb);            

            aceCtrl.WebOpen("doc/test4.xlsx", OpenModeType.xlsSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public IActionResult ExcelFill5()
        {

            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            ExcelTableWriter table = sheet.OpenTableByDefinedName("report", 4, 5, true);
            int rowCount = 12; // Assume the actual number of records to be automatically filled is 12.
            for (int i = 1; i <= rowCount; i++)
            {
                table.DataFields[0].Value = i + " month";
                table.DataFields[1].Value = "100";
                table.DataFields[2].Value = "120";
                table.DataFields[3].Value = "500";
                table.DataFields[4].Value = "120%";
                table.NextRow();
            }
            table.Close();

            // Define another table
            ExcelTableWriter table2 = sheet.OpenTableByDefinedName("report2", 4, 5, true);
            int rowCount2 = 4; // Assume the actual number of records to be automatically filled is 4.
            for (int i = 1; i <= rowCount2; i++)
            {
                table2.DataFields[0].Value = i + " quarter";
                table2.DataFields[1].Value = "300";
                table2.DataFields[2].Value = "300";
                table2.DataFields[3].Value = "300";
                table2.DataFields[4].Value = "100%";
                table2.NextRow();
            }
            table2.Close();

            aceCtrl.SetWriter(wb);

            aceCtrl.WebOpen("doc/test4.xlsx", OpenModeType.xlsSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
        public IActionResult ExcelFill6()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
            aceCtrl.WebOpen("doc/test4.xlsx", OpenModeType.xlsNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> SaveData()
        {
            WorkbookReader workBook = new WorkbookReader(Request, Response);

            await workBook.LoadAsync();
            SheetReader sheet = workBook.OpenSheet("Sheet1");

            ExcelTableReader table = sheet.OpenTableByDefinedName("report");
            List< JObject > list = new List< JObject >();
            int result = 0;
            while (!table.EOF)
            {
                if (!table.DataFields.IsEmpty)
                {
                    JObject jobject = new JObject();
                    jobject.Add("Month:", table.DataFields[0].Text);
                    jobject.Add("Plan:", table.DataFields[1].Text);
                    jobject.Add("Reality:", table.DataFields[2].Text);
                    jobject.Add("Accumulative:", table.DataFields[3].Text);

                    if (string.IsNullOrEmpty(table.DataFields[2].Text) || !int.TryParse(table.DataFields[2].Text, out result) ||
                        !int.TryParse(table.DataFields[1].Text, out result))
                    {
                        jobject.Add("Order Fill Rate:", 0);
                    }
                    else
                    {
                        float f = int.Parse(table.DataFields[2].Text);
                        f = f / int.Parse(table.DataFields[1].Text);
                        jobject.Add("Order Fill Rate", string.Format("{0:P}", f));
                    }
                    list.Add(jobject);                  
                }
                table.NextRow();
            }
            table.Close();

            string data = string.Join(Environment.NewLine, list);
            workBook.CustomSaveResult =  data;

            return workBook.Close();
        }
    }
}