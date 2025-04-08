<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.WordGetSelection.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>Demo: Retrieve Selected Text Content</title>
    <script type="text/javascript">
        // Function to retrieve the selected text from the Word document.
        function getSelectionText(){
            if (aceoffixctrl.word.GetTextFromSelection() != "") {
                alert(aceoffixctrl.word.GetTextFromSelection());
            } else {
                alert("You have not selected any text.");
            }     
        }

        // Event handler for when the Aceoffix control is initialized.
        function OnAceoffixCtrlInit() {
            // Adds a custom toolbar button that triggers the 'getSelectionText' function when clicked.
           aceoffixctrl.AddCustomToolButton("Retrieve Selected Text Content", "getSelectionText()", 5);
        }
    </script>
</head>
<body>
    <div style="font-size: 12px; line-height: 20px; border-bottom: dotted 1px #ccc; border-top: dotted 1px #ccc; padding: 5px;">
        <!-- Instructions on how to use the demo functionality -->
        <span style="color: red;">Instructions:</span> Select a portion of text in the Word file, then click the "Retrieve Selected Text Content" button.<br />
        <!-- Guidance on where to find the key JavaScript function -->
        Key Code: Right-click and select "View Source" to see the JS function <span style="background-color: Yellow;">getSelectionText()</span>
    </div>
    <!-- Button to trigger the getSelectionText function -->
    <input id="Button1" type="button" onclick="getSelectionText();" value="Retrieve Selected Text Content" /><br />
    <form id="form1" runat="server" style="height: 100%;">
        <div  style="height:850px;width:auto;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>
