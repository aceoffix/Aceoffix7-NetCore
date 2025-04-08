<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFill.cs" Inherits="Aceoffix7_Net.DefinedNameTable.ExcelFill" %>

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
           aceoffixctrl.Caption = "Assign Values to Named Cells in Excel Documents";
           aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
    </head>
    <body>
        The table data is filled using backend programming. Please refer to the code in ExcelFill.
        <div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </body>
</html>
