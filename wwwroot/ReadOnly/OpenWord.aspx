<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenWord.cs" Inherits="Aceoffix7_Net.ReadOnly.OpenWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open a Word file online</title>
</head>
<body>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            // Set the caption of the control to demonstrate online secure file browsing
            aceoffixctrl.Caption = "Demonstration: Online secure browsing of files";
            // Hide the custom toolbar
            aceoffixctrl.CustomToolbar = false;
            // Hide the Office toolbars
            aceoffixctrl.OfficeToolbars = false;
        }

        function AfterDocumentOpened() {
            // Disable the "Save As" function
            aceoffixctrl.DisableSaveAs = true;
            // Disable the printing functio
            aceoffixctrl.DisablePrint = true;
        }
    </script>
    <form id="form1" runat="server">
        <div style="width:auto; height: 850px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
