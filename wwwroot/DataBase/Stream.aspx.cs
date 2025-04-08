using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.DataBase
{
    public partial class Stream : System.Web.UI.Page
    {
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            aceCtrl.WebOpen("Openstream?id=1", Aceoffix.OpenModeType.docRevisionOnly, "Tom");
        }
    }
}