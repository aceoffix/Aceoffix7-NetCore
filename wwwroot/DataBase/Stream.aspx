<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stream.cs" Inherits="Aceoffix7_Net.DataBase.Stream" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open a file saved in the DataBase</title>

    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveFilePage = "/DataBase/SaveFile?id=1";
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
