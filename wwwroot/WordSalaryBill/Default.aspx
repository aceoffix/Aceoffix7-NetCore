<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.WordSalaryBill.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dynamic Salary Slip Generation</title>
    <style>
    .content {
        width: 60%;
        margin-left: 20%;
        margin-top: 20px;
        position: relative;
    }
    .instructions p {
        color: red;
        font-size: 14px;
        text-align: left;
        margin: 0 0 10px;
    }
    table {
        width: 100%;
        border: 1px solid #a2c5d9;
        font-size: 12px;
        margin-top: 10px;
    }
    .generate-btn {
        text-align: center;
        padding: 10px;
        font-size: 12px;
        margin-top: 10px;
    }
</style>
    <!-- The aceoffix.js file must be referenced -->
    <script type="text/javascript" src="../aceoffix.js"></script>
    <script type="text/javascript">
        // Function to get the IDs of selected records and open the Compose page
        function getID() {
            var ids = "";
            for (var i = 1; i < 11; i++) {
                if (document.getElementById("check" + i.toString()).checked) {
                    ids += i.toString() + ",";
                }
            }
            if (ids == "") {
                alert("Please select the records you want to generate salary slips for first.");
            } else {
               AceBrowser.openWindow('Compose?ids=' + ids.substr(0, ids.length - 1), 'width=1200px;height=800px;');
            }
        }
    </script>
</head>
<body>
   <div class="content">
    <div class="instructions">
        <p>1. You can click "Edit" in the "Operations" column to edit individual employee's salary slip</p>
        <p>2. You can click "View" in the "Operations" column to view individual employee's salary slip</p>
        <p>3. You can select multiple salary records and click the "Generate Salary Slips" button to generate the salary slips</p>
    </div>
    <table>
        <%=strHtml.ToString() %>
    </table>
    <div class="generate-btn">
        <input type="button" value="Generate Salary Slips" onclick="getID()" />
    </div>
</div>
</body>
</html>
