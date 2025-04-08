using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.WordDataTag2
{
    public partial class DataTag : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WordDocumentWriter wd = new WordDocumentWriter();
            DataTagWriter dataTag1 = wd.OpenDataTag("{name}");
            dataTag1.Value = "Tom";
            DataTagWriter dataTag2 = wd.OpenDataTag("{Number}");
            dataTag2.Value = "201501";
            DataTagWriter dataTag3 = wd.OpenDataTag("{Department}");
            dataTag3.Value = "Development";
            DataTagWriter dataTag4 = wd.OpenDataTag("{Manager}");
            dataTag4.Value = "John Scott";
            DataTagWriter dataTag5 = wd.OpenDataTag("{Salary}");
            dataTag5.Value = "$5000";

            aceCtrl.SetWriter(wd);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");
        }
    }
}