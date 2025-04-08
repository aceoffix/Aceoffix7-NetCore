<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.SetDrByUserWord2.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveDataPage = "/SetDrByUserWord2/SaveData?userName=<%=userName%>";
            aceoffixctrl.WebSave();
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
</head>
<body>
    <span style="width: 100px;"></span><strong>Current User:</strong>
    <span style="color: Red;"><%=userName%></span>
    <div style="width: auto; height: 800px;">
        <%=aceCtrl.GetHtml()%>
    </div>
</body>
</html>
