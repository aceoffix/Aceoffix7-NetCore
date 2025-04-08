<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.SetDrByUserWord.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <!-- The js must be referenced -->
    <script type="text/javascript" src="../aceoffix.js"></script>
    <script type="text/javascript">
        function OpenFile() {
            let userName = document.getElementById('userName').value;
            AceBrowser.openWindow('Word?userName=' + userName, 'width=1200px;height=900px;');
        }
    </script>
</head>
<body>
    <form id="form1" method="post"> 
        <div style="text-align: center;">
            <div>Please select a user to log in:</div><br />
            <select name="userName" id="userName">
                <option selected="selected" value="Tom">Tom</option>
                <option value="Jack">Jack</option>
            </select><br /><br />
            <input type="button" onclick="OpenFile();" value="Open File" /><br /><br />
            <div style="color: red;">Different users can edit different regions in the document after logging in.</div>
        </div>
    </form>
</body>
</html>
