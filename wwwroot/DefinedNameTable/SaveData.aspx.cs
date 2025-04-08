using Aceoffix.Excel;
using System;
using System.Text;


namespace Aceoffix7_Net.DefinedNameTable
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookReader workBook = new WorkbookReader();
            SheetReader sheet = workBook.OpenSheet("Sheet1");

            ExcelTableReader table = sheet.OpenTableByDefinedName("report");

            int result = 0;
            StringBuilder content = new StringBuilder();
            while (!table.EOF)
            {

                if (!table.DataFields.IsEmpty)
                {
                    content.Append("Month:" + table.DataFields[0].Text+"\r\n");
                    content.Append("Plan:" + table.DataFields[1].Text + "\r\n");
                    content.Append("Reality:" + table.DataFields[2].Text + "\r\n");
                    content.Append("Accumulative:" + table.DataFields[3].Text + "\r\n");
 

                    if (string.IsNullOrEmpty(table.DataFields[2].Text) || !int.TryParse(table.DataFields[2].Text, out result) ||
                        !int.TryParse(table.DataFields[1].Text, out result))
                    {
                        content.Append("Order Fill Rate:0%");
                    }
                    else
                    {
                        float f = int.Parse(table.DataFields[2].Text);
                        f = f / int.Parse(table.DataFields[1].Text);

                        content.Append("Order Fill Rate:" + string.Format("{0:P}", f));
                    }
                }

                table.NextRow();
            }
            table.Close();
            workBook.CustomSaveResult=content.ToString();
            workBook.Close();

        }
    }
}