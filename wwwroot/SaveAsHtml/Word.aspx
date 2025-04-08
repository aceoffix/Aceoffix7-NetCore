<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.SaveAsHtml.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Save Word File as HTML</title>
    <script type="text/javascript">

        function Save() {
            aceoffixctrl.SaveFilePage = "/SaveAsHTML/SaveFile";
            aceoffixctrl.WebSave();
        }

        function saveAsHTML() {
            aceoffixctrl.SaveFilePage = "/SaveAsHTML/SaveFile";
            aceoffixctrl.WebSaveAsHTML();
            alert("The HTML file has been saved to the server.");
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
            aceoffixctrl.AddCustomToolButton("Save as HTML", "saveAsHTML()", 1);
        }

        function openHtml() {
            location.href = "doc/test.htm?r=" + Math.random();
        }
    </script>
</head>
<body>
        <div>After performing the "Save as HTML" operation, you can <a href="javascript:openHtml();">view the HTML file</a> to see the effect.</div>
        <div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
</body>
</html>
