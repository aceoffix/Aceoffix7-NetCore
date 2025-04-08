<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.cs" Inherits="Aceoffix7_Net.FileMakerPrintFiles.Preview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false;
        }
    </script>
    <div style="width: auto; height: 98vh;">
        <%=aceCtrl.GetHtml() %>
    </div>
</body>
</html>
