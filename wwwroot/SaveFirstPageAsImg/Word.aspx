<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.SaveFirstPageAsImg.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Save Word First Page as Image</title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveFilePage = "/SaveFirstPageAsImg/SaveFile";
            aceoffixctrl.WebSave();
        }

        function SaveFirstAsImg() {
            aceoffixctrl.SaveFilePage = "/SaveFirstPageAsImg/SaveFile";
            aceoffixctrl.WebSaveAsImage();
            alert('The image has been saved to the "SaveFirstPageAsImg/doc/" directory.');
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save()", 1);
            aceoffixctrl.AddCustomToolButton("Save First Page as Image", "SaveFirstAsImg()", 1);
        }
    </script>
</head>
<body>
        <div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
</body>
</html>
