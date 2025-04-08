<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileMakerPDF.cs" Inherits="Aceoffix7_Net.FileMakerPDF.FileMakerPDF" %>

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
