<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.InsertPageBreak2.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert a Page Break into the Current Word Document Using Server-Side Methods</title>
</head>
<body>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveFilePage = "/InsertPageBreak2/SaveFile";
            aceoffixctrl.WebSave();
            if (aceoffixctrl.CustomSaveResult == "ok") {
                alert("Saved successfully!\nPlease check the merged document \"test3.docx\" in the InsertPageBreak2/doc directory.");
            }
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
    <form id="form1" runat="server">
        <div style="width: auto; height: 98vh;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
