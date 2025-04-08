<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.DataRegionTable.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Submit a Table in a Data Region</title>
</head>
<body> 
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveDataPage = "/DataRegionTable/SaveData";
            aceoffixctrl.WebSave();
            alert(aceoffixctrl.CustomSaveResult);
        }
        function IsFullScreen() {
            aceoffixctrl.FullScreen =
                !aceoffixctrl.FullScreen;
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
            aceoffixctrl.AddCustomToolButton("Full Screen/Restore", "IsFullScreen", 4);
        }
    </script> 
    <div style="width: auto; height: 850px;">
         <%=aceCtrl.GetHtml()%> 
    </div>
</body>
</html>
