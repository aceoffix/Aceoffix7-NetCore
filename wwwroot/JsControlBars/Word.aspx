<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.JsControlBars.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">      
        // Hide/Show the title bar
        function Button1_onclick() {
            var bVisible = aceoffixctrl.Titlebar;
            aceoffixctrl.Titlebar = !bVisible;
        }
        

        // Hide/Show the custom toolbar
        function Button3_onclick() {
            var bVisible = aceoffixctrl.CustomToolbar;
            aceoffixctrl.CustomToolbar = !bVisible;
        }

        // Hide/Show the Office toolbar
        function Button4_onclick() {
            var bVisible = aceoffixctrl.OfficeToolbars;
            aceoffixctrl.OfficeToolbars = !bVisible;
        }

        function OnAceoffixCtrlInit() {
            // Hide the custom toolbar
            aceoffixctrl.CustomToolbar = false; 
        }
    </script>
    <form id="form1" runat="server">
    <input id="Button1" type="button" value="Hide/Show Title Bar"  onclick="return Button1_onclick()" />
    <input id="Button3" type="button" value="Hide/Show Custom Toolbar"  onclick="return Button3_onclick()" />
    <input id="Button4" type="button" value="Hide/Show Office Toolbar"  onclick="return Button4_onclick()" />
    <br /><br />
    <div style=" width:auto; height:900px;">
         <%=aceCtrl.GetHtml()%>
    </div>
    </form>
</body>
</html>