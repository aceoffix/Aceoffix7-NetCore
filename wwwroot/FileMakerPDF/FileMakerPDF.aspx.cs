
using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.FileMakerPDF
{
    public partial class FileMakerPDF : System.Web.UI.Page
    {
        public FileMakerCtrl fmCtrl = new FileMakerCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wb= new WordDocumentWriter();
            wb.OpenDataRegion("ACE_UnitName").Value = "Jack Jons";

            fmCtrl.SetWriter(wb);
            fmCtrl.FillDocumentAsPDF(Server.MapPath("doc/template.docx"), DocumentOpenType.Word, "certificate.pdf");
        }
    }
}