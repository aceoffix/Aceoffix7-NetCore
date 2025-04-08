<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordToPDF.cs" Inherits="Aceoffix7_Net.SaveAsPDF.WordToPDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Convert Word File to PDF Format</title>
    <script type="text/javascript">
        // Save the file
        function Save() {
            aceoffixctrl.SaveFilePage = "/SaveAsPDF/SaveFile";
            aceoffixctrl.WebSave();
        }

        // Save as a PDF file
        function SaveAsPDF() {
            aceoffixctrl.SaveFilePage = "/SaveAsPDF/SaveFile";
            aceoffixctrl.WebSaveAsPDF();
            alert("The PDF file has been saved to the 'SaveAsPDF/doc/' directory of the project.");
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save()", 1);
            aceoffixctrl.AddCustomToolButton("SaveAsPDF", "SaveAsPDF()", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:auto;height:850px;">
         <%=aceCtrl.GetHtml()%>
    </div>
    </form>
</body>
</html>
