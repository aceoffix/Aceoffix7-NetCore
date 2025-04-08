using Aceoffix.Word;
using Aceoffix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FileMakerSingle
{
    public partial class FileMakerSingle : System.Web.UI.Page
    {
        public FileMakerCtrl fmCtrl = new FileMakerCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wb = new WordDocumentWriter();
            wb.OpenDataRegion("ACE_UnitName").Value = "Jack Jons";

            fmCtrl.SetWriter(wb);
            fmCtrl.FillDocument(Server.MapPath("doc/template.docx"), DocumentOpenType.Word);
        }
    }
}