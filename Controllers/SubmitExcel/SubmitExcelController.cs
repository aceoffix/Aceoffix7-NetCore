using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AceoffixNetCore;
using AceoffixNetCore.Excel;
using Newtonsoft.Json;

namespace Aceoffix7_NetCore.Controllers.SubmitExcel
{
    public class SubmitExcelController : Controller
    {

        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet1 = wb.OpenSheet("Purchase Order");

            System.Random rd = new Random(System.DateTime.Now.Millisecond);
            sheet1.OpenCell("D8").Value = "XYZ-11-" + (10001 + rd.Next(10000)).ToString();
            sheet1.OpenCell("D8").ReadOnly = true;

            ExcelCellWriter cellDate = sheet1.OpenCell("I6");
            string dt = DateTime.Now.ToString();
            cellDate.Value = dt;
            sheet1.OpenCell("J31").Value = dt;

            sheet1.OpenCell("D15").ReadOnly = false; // Enabled edit

            ExcelTableWriter table1 = sheet1.OpenTable("B18:J23");
            table1.ReadOnly = false; // Enabled edit

            sheet1.OpenCell("J24").ReadOnly = true;
            sheet1.OpenCell("J26").ReadOnly = true;
            sheet1.OpenCell("J28").ReadOnly = true;

            sheet1.OpenCell("G31").Value = "John Scott";

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsSubmitForm, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


        public async Task<ActionResult> SaveData()
        {
            // This page is used to receive the data submitted by AceoffixCtrl.
            WorkbookReader wb = new WorkbookReader(Request,Response);
            await wb.LoadAsync();
            SheetReader sheet1 = wb.OpenSheet("Purchase Order");
            ExcelTableReader table1 = sheet1.OpenTable("B18:J23");
            List<JObject> objectList = new List<JObject>();
            while (!table1.EOF)
            {
                if (!table1.DataFields.IsEmpty)
                {
                    JObject jsonObject = new JObject();
                    jsonObject["QTY"] = table1.DataFields[0].Text;
                    jsonObject["DESCRIPTION"] = table1.DataFields[1].Text;
                    jsonObject["UNIT PRICE"] = table1.DataFields[7].Text;
                    jsonObject["AMOUNT"] = table1.DataFields[8].Text;
                    objectList.Add(jsonObject);
                }
                table1.NextRow();
            }
            table1.Close();
            wb.CustomSaveResult = JsonConvert.SerializeObject(objectList);
            return wb.Close(); ;
        }
    }
}