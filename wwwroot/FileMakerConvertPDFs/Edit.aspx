<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.cs" Inherits="Aceoffix7_Net.FileMakerConvertPDFs.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <script type="text/javascript">
          function SaveDoc() {
              aceoffixctrl.SaveFilePage = "/FileMakerConvertPDFs/SaveMaker";
              aceoffixctrl.WebSave();
          }
          function OnAceoffixCtrlInit() {
              aceoffixctrl.AddCustomToolButton("Save", "SaveDoc()", 1);
          }
      </script>
	<div style="width:auto;height:98vh;">
           <%=aceCtrl.GetHtml() %>
    </div>
</body>
</html>
