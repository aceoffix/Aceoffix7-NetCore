<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.CommandCtrl.Word" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>Disable "Save", "Save As", "Print", and "Open". Ctrl+S is also disabled.</p>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            // Hide the custom toolbar
            aceoffixctrl.CustomToolbar = false;
        }
        function AfterDocumentOpened() {
            // Disable saving
            aceoffixctrl.DisableSave = true;
            // Disable saving as
            aceoffixctrl.DisableSaveAs = true;
            // Disable printing
            aceoffixctrl.DisablePrint = true;
            // Disable opening
            aceoffixctrl.DisableOpen = true;
        }
    </script>
    <div style=" width:auto; height:95vh;">
            <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
