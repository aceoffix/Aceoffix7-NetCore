
using Aceoffix.Word;
using Newtonsoft.Json.Linq;
using System;

namespace Aceoffix7_Net.SubmitWord
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();
            //获取提交的数值
            DataRegionReader dataUserName = doc.OpenDataRegion("ACE_Name");
            DataRegionReader dataDeptName = doc.OpenDataRegion("ACE_Department");

            JObject jsonObject = new JObject();
            jsonObject["userName"] = dataUserName.Value;
            jsonObject["department"] = dataDeptName.Value;
            jsonObject["companyName"] = doc.GetFormField("companyName");
            // Convert the JObject to a JSON string
            string jsonString = jsonObject.ToString();
            // Return a JSON - formatted result to the aceoffix control page
            doc.CustomSaveResult = jsonString;
            doc.Close();
        }
    }
}
