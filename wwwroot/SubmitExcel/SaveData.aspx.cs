using Aceoffix.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;


namespace Aceoffix7_Net.SubmitExcel
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page is used to receive the data submitted by AceoffixCtrl.
            WorkbookReader wb = new WorkbookReader();
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
            wb.Close();
        }
    }
}