<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.cs" Inherits="Aceoffix7_Net.ExaminationPaper.Edit" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveFilePage = "/ExaminationPaper/SaveFile?id=<%=id%>";
            aceoffixctrl.WebSave();
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
