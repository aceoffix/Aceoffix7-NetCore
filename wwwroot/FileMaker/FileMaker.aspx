<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileMaker.cs" Inherits="Aceoffix7_Net.FileMaker.FileMaker" %>

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
