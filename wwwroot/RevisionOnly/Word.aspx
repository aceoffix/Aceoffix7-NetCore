<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.RevisionOnly.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RevisionOnly</title>
</head>
<body>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveFilePage = "/RevisionOnly/SaveFile";
            aceoffixctrl.WebSave();
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
            aceoffixctrl.AddCustomToolButton("Hide Revisions", "hideRevision()", 0);
            aceoffixctrl.AddCustomToolButton("Show Revisions", "showRevision()", 0);
        }

        function showRevision() {
            aceoffixctrl.ShowRevisions = true;
        }

        function hideRevision() {
            aceoffixctrl.ShowRevisions = false;
        }
    </script>
    <div id="main">
        <div style="width:auto;height:850px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </div>
</body>
</html>
