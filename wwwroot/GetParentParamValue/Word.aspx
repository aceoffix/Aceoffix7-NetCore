<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.GetParentParamValue.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Pass parameters from the parent page to the child page</title>
    <script type="text/javascript">
        function AfterDocumentOpened() {
            var userName =aceoffixctrl.WindowParams;
            document.getElementById("userName").value = userName;
        }
        function OnAceoffixCtrlInit() {
            // Hide the custom toolbar
           aceoffixctrl.CustomToolbar = false; 
        }
    </script>
</head>
<body>
    <div>
        <font color="red">Parameters passed from the parent page:</font><input type="text" id="userName" name="userName"/>
    </div>
    <form id="form1" runat="server">
        <div style=" width:auto; height:850px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
