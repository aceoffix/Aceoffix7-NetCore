<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.cs" Inherits="Aceoffix7_Net.WordSalaryBill.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveDataPage = "/WordSalaryBill/SaveData?id=<%=id %>";
            aceoffixctrl.WebSave();
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <div style="width: auto; height: 900px;">
        <%=aceCtrl.GetHtml()%>
    </div>
</body>
</html>
