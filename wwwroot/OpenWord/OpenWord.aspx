<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenWord.cs" Inherits="Aceoffix7_Net.OpenWord.OpenWord" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>open Word for Readonly</title>
<script type="text/javascript">
    function OnAceoffixCtrlInit() {
        aceoffixctrl.Titlebar = false; // Hide the title bar
        aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar
        aceoffixctrl.OfficeToolbars = false; // Hide the Office toolbar
    }
</script>
</head>
<body>
This shows the effect of hiding the title bar, custom toolbar, and Office toolbar. Each bar can be individually controlled to be hidden or shown.
<form id="form1" runat="server">
<div style="width:auto; height:92vh;">
  <%=aceCtrl.GetHtml()%>
</div>
</form>
</body>
</html>

