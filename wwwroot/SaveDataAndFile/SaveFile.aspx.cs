using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.SaveDataAndFile
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            fs.SaveToFile(Server.MapPath("doc/") + fs.FileName);
            // Set the custom save result to be returned to the front-end page. The parameter of CustomSaveResult can also be in JSON string format.
            // Set the save result of the file
            fs.CustomSaveResult = "ok2";
            fs.Close();
        }
    }
}