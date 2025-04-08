<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compare.cs" Inherits="Aceoffix7_Net.WordCompare.Compare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Word Document Comparison</title>
    <script language="javascript" type="text/javascript">

        function ShowFile1View() {
            aceoffixctrl.word.ShowCompareView(1);
        }

        function ShowFile2View() {
            aceoffixctrl.word.ShowCompareView(2);
        }

        function ShowCompareView() {
            aceoffixctrl.word.ShowCompareView(0);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Show Document A", "ShowFile1View()", 0);
            aceoffixctrl.AddCustomToolButton("Show Document B", "ShowFile2View()", 0);
            aceoffixctrl.AddCustomToolButton("Show Comparison Result", "ShowCompareView()", 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:auto; height:900px;">
       <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
