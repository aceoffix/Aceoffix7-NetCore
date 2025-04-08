<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aspx.cs" Inherits="Aceoffix7_Net.CommentOnly.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CommentOnly</title>
</head>
<body>
    <script type="text/javascript">
        function Save() {   
           aceoffixctrl.SaveFilePage = "/CommentOnly/SaveFile";
           aceoffixctrl.WebSave();
        }

        function newComment() {
           aceoffixctrl.InsertComment();
        }

        function OnAceoffixCtrlInit() {
           aceoffixctrl.AddCustomToolButton("Save", "Save()", 1);
           aceoffixctrl.AddCustomToolButton("Insert Comment", "newComment()", 0);
        }
    </script>
    <form id="form1" runat="server">
        <div style=" width:auto; height:900px;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>
