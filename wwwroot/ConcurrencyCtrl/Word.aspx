﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.ConcurrencyCtrl.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-3.6.0.min.js"></script>
	<script type="text/javascript">
        // This function is called when the PageOffice control is initialized. You can add custom buttons here.
        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1); 
            aceoffixctrl.AddCustomToolButton("Save As", "SaveAs", 5); 
            aceoffixctrl.AddCustomToolButton("Page Setup", "PrintSet", 0); 
            aceoffixctrl.AddCustomToolButton("Print", "PrintFile", 6);
            aceoffixctrl.AddCustomToolButton("Fullscreen/Restore", "IsFullScreen", 4); 
            aceoffixctrl.AddCustomToolButton("Close", "Close", 9); 
        }

        function Save() {
            var saveUrl = "/ConcurrencyCtrl/SaveFile";
            aceoffixctrl.SaveFilePage = saveUrl;
            aceoffixctrl.WebSave();
        }

        function SaveAs() {
            aceoffixctrl.ShowDialog(3);
        }

        function PrintSet() {
            aceoffixctrl.ShowDialog(5);
        }

        function PrintFile() {
            aceoffixctrl.ShowDialog(4);
        }

        function Close() {
            aceoffixctrl.CloseWindow();
        }

        function IsFullScreen() {
            aceoffixctrl.FullScreen = !aceoffixctrl.FullScreen;
        }

        function SendCloseMsg() {
            $.ajax({
                url: 'clearCurrentEditor?id=<%=id%>',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    console.log('Request succeeded:', data.msg);
                },
                error: function (xhr, status, error) {
                    console.error('Request failed:', error);
                }
            });
        }

        // Executes necessary business logic before the browser window is closed.
        function OnBeforeBrowserClosed() {
            if (aceoffixctrl.IsDirty) { 
                if (confirm("Alert: The document has been modified. Do you wish to continue closing without saving?")) {
                    SendCloseMsg();
                    aceoffixctrl.CloseWindow(true); // Must be called to close the window.
                }
            } else {
                SendCloseMsg();
                aceoffixctrl.CloseWindow(true); // Must be called to close the window.
            }
        }
    </script>
</head>
<body>
	<div style=" width:auto; height:900px;">
          <%=aceCtrl.GetHtml()%> 
    </div>
</body>
</html>