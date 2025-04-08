<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFill4.cs" Inherits="Aceoffix7_Net.DefinedNameTable.ExcelFill4" %>

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
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
   Display effect after OpenTable fills in the data
		<div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
</body>
</html>

