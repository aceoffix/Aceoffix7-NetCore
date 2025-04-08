using Aceoffix;
using System;

namespace Aceoffix7_Net.BeforeAndAfterSave
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            // Save the file to the specified path on the server
            fs.SaveToFile(Server.MapPath("doc/") + fs.FileName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in JSON string format.
            fs.CustomSaveResult = "ok";
            // Close the FileSaver object
            fs.Close();
        }
    }
}