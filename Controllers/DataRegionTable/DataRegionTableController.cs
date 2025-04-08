using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.DataRegionTable
{
    public class DataRegionTableController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataRegionTableController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter doc = new WordDocumentWriter();
            // Open the data region
            DataRegionWriter dTable = doc.OpenDataRegion("ACE_table");
            // Set the editability of the data region
            dTable.Editing = true;
            // Open the table in the data region. The 'index' in the OpenTable(index) method is the sub - index of the table in the Word document, starting from 1.
            WordTableWriter table1 = doc.OpenDataRegion("ACE_table").OpenTable(1);
            // Assign values to the header cells of the table
            table1.OpenCellRC(1, 2).Value = "Product 1";
            table1.OpenCellRC(1, 3).Value = "Product 2";
            table1.OpenCellRC(2, 1).Value = "Department A";
            table1.OpenCellRC(3, 1).Value = "Department B";
            aceCtrl.SetWriter(doc);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> SaveData()

        {
            WordDocumentReader doc = new WordDocumentReader(Request, Response);

            await doc.LoadAsync();
            // Open the data region with the specified name
            DataRegionReader dataReg = doc.OpenDataRegion("ACE_table");

            // Open the first table in the data region
            WordTableReader table = dataReg.OpenTable(1);

            List<JObject> objectList = new List<JObject>();
            for (int i = 1; i <= table.RowsCount; i++)
            {
                JObject jobject = new JObject();
                for (int j = 1; j <= table.ColumnsCount; j++)
                {
                    jobject.Add("The value of cell (" + i + "," + j + ") is: ", table.OpenCellRC(i, j).Value);
                }
                objectList.Add(jobject);
            }

            // await Response.Body.WriteAsync(Encoding.GetEncoding("GB2312").GetBytes(dataStr.ToString()));
            /**
              * In actual development, generally, after obtaining the value of the data region, it is used to interact with the database.
              * For example, new records can be added, existing records can be updated, or records can be deleted in the database based on the obtained data.
              * Here, in order to show the obtained data content to the user, the value of the obtained data region is returned to the front - end page through setCustomSaveResult for the user to check the execution result.
              * If you only want to return a save result, you can use something like: setCustomSaveResult("ok"). The front - end can perform the next logical processing based on this save result.
              */
            string data = string.Join(Environment.NewLine, objectList);
            // Return data to the front - end page through CustomSaveResult
            doc.CustomSaveResult = data;
            // This is necessary and should be placed on the last line
            return doc.Close();
        }
    }
}