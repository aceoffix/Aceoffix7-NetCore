<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.SplitWord.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Word Splitting</title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveDataPage = "/SplitWord/SaveData";
            aceoffixctrl.WebSave();
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
   <div style="font-size:14px; line-height:20px;">Demonstration Description:<br />Click the "Save" button, and Aceoffix will save the content of the three data regions (ACE_paragraph1, ACE_paragraph2, ACE_paragraph3) as three separate sub-files (paragraph1.doc, paragraph2.doc, paragraph3.doc) to the "SplitWord/doc" directory.</div>
   <div style="color: red;font-size:14px; line-height:20px;">The Word splitting feature is only supported in the Enterprise Edition, and the document's open mode must be OpenModeType.docSubmitForm. The property dataRegion1.SubmitAsFile = true must also be set for the data regions.<br /><br /></div>
    <form id="form1" runat="server">
   
   <div style="width:auto; height:900px;">
          <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
