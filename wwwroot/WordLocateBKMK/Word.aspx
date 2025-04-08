<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.WordLocateBKMK.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>Demo: Position Cursor to a Specified Bookmark</title>
    <style type="text/css">
        html, body
        {
            height: 100%;
        }
        .main
        {
            height: 100%;
        }
    </style>
    <script type="text/javascript">

        // Function to position cursor to the specified bookmark location.
        function locateBookMark() {
            // Retrieve the bookmark name from the input field.
            var bkName = document.getElementById("txtBkName").value;
            // Position the cursor at the location of the bookmark.
            aceoffixctrl.word.LocateDataRegion(bkName);
        }

        // Event handler for when the Aceoffix control is initialized.
        function OnAceoffixCtrlInit() {
            // Adds a custom toolbar button that triggers the 'locateBookMark' function when clicked.
            aceoffixctrl.AddCustomToolButton("Locate Bookmark", "locateBookMark()", 5);
        }
    </script>
</head>
<body>
    <div style=" font-size:small;">
        <!-- Highlight the key JavaScript function used in this demo -->
        <label>Key Code: Right-click and select "View Source" to see the JS function:</label>
        <label style=" background-color:Yellow;">function locateBookMark()</label>
        <br/>
        <!-- Instructions on how to use the bookmark feature -->
        <label>Position the cursor before the bookmark by entering the desired bookmark name in the text box (you can click on the "Insert" → "Bookmark" in the Office toolbar to view all current bookmarks in the Word document).</label><br />
        <label>Bookmark Name:</label><input id="txtBkName" type="text" value="ACE_test" />
    </div>
    <br />
    <form id="form1" runat="server">
    <div  style="height: 900px; width:auto;">
        <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
