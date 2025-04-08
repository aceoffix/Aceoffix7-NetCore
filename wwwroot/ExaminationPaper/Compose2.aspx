<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compose2.cs" Inherits="Aceoffix7_Net.ExaminationPaper.Compose2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Generate Test Papers";
            aceoffixctrl.CustomToolbar = false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
