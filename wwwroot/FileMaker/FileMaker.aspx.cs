using Aceoffix.Word;
using Aceoffix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FileMaker
{
    public partial class FileMaker : System.Web.UI.Page
    {
        public FileMakerCtrl fmCtrl = new FileMakerCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            string[] companyArr = { "empty", "Microsoft (China) Co., Ltd.", "IBM (China) Services Co., Ltd.", "Amazon Trade Co., Ltd.",
                                "Facebook Technology Co., Ltd.", "Google Network Co., Ltd.", "NVIDIA Technology Co., Ltd.",
                                "TSMC Technology Co., Ltd.", "Walmart Inc." };

            int id = int.Parse(Request.QueryString["id"]);

            WordDocumentWriter wb = new WordDocumentWriter();
            wb.OpenDataRegion("ACE_Company").Value = companyArr[id];

            fmCtrl.SetWriter(wb);
            fmCtrl.FillDocument(Server.MapPath("doc/template.docx"), DocumentOpenType.Word);
        }
    }
}