<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.WordAddBKMK.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function addBookMark() {
            var bkName = document.getElementById("txtBkName").value;
            var bkText = document.getElementById("txtBkText").value;
            aceoffixctrl.word.AddDataRegion(bkName, bkText);
        }
        function delBookMark() {
            var bkName = document.getElementById("txtBkName").value;
            aceoffixctrl.word.DeleteDataRegion(bkName);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Add BookMark", "addBookMark()", 5);
            aceoffixctrl.AddCustomToolButton("Delete BookMark", "delBookMark()", 5);
        }
    </script>
</head>
<body>
   <form id="form1" runat="server">
       <div style="color:red">Note:When inserting a bookmark, please enter the name and text of the bookmark you want to insert first. When deleting a bookmark, please enter the corresponding bookmark name first and when inserting a bookmark, the bookmark name cannot be repeated.</div>
        <label for="txtBkName">BookMark Name:</label>
        <input type="text" id="txtBkName" name="txtBkName" value="test"/><br/>
        
        <label for="txtBkText">BookMark Value:</label>
        <input type="text" id="txtBkText" name="txtBkText"  value="[test]"/><br/><br/>

        <button type="button" onclick="addBookMark()">Add Bookmark</button>
        
        <button type="button" onclick="delBookMark()">Delete Bookmark</button>

        <div style="width: auto; height: 850px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
