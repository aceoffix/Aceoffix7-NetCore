using Aceoffix;
using System;


namespace Aceoffix7_Net.FIleMakerToPDF
{
    public partial class FileMakerToPDF : System.Web.UI.Page
    {
        public FileMakerCtrl fmCtrl = new FileMakerCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            fmCtrl.FillDocumentAsPDF("doc/template.docx", DocumentOpenType.Word, "certificate.pdf");
        }
    }
}