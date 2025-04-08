<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word2.cs" Inherits="Aceoffix7_Net.ConcurrencyCtrl.Word2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnBeforeBrowserClosed() {
            aceoffixctrl.CloseWindow(true);// Must be called to close the window with "true" param.
        }
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false;
        }
    </script>
</head>
<body>
	<div style=" width:auto; height:900px;">
          <%=aceCtrl.GetHtml()%> 
    </div>
</body>
</html>