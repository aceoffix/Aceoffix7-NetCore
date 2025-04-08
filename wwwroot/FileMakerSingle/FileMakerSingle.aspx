<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileMakerSingle.cs" Inherits="Aceoffix7_Net.FileMakerSingle.FileMakerSingle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%=fmCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
