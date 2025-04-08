<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFill5.cs" Inherits="Aceoffix7_Net.DefinedNameTable.ExcelFill5" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            var saveUrl = "/DefinedNameTable/SaveData";
            aceoffixctrl.SaveDataPage = saveUrl;
            aceoffixctrl.WebSave();
            alert(aceoffixctrl.CustomSaveResult);
        }
        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Assign values to the table with a defined name in the Excel document.";
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
The display effect after filling data through the OpenTableByDefinedName method.
		<div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
</body>
</html>