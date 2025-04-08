<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.ConcurrencyCtrl.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ConcurrenControl</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <script src="../js/jquery-3.6.0.min.js"></script>
    <!-- Include aceoffix's JavaScript -->
    <script src="../aceoffix.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Highlight the table row on mouse over.
            $('tr').hover(function () {
                $(this).css('background-color', 'lightyellow');
            }, function () {
                $(this).css('background-color', '');
         });
        });
            // Edit file functionality.
            function editFile(id) {
                var user = $('#slt_user').val();
                $.ajax({
                    url: 'detectCurrentEditor?id=' + id,
                    type: 'GET',
                    dataType: 'json',
                    success: function (data) {
                        if (data.editor == user || data.editor == '') {
                            AceBrowser.openWindow('Word?id=' + id + '&user=' + user, 'width=1200px;height=800px;');
                        } else {
                            alert('User "' + data.editor + '" is currently editing this document. Please try again later or click "View" to open it read-only.');
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error('Request failed:', error);
                    }
                });
            }

            // View file functionality.
            function viewFile(id) {
                var user = $('#slt_user').val();
                AceBrowser.openWindow('Word2?id=' + id + '&user=' + user, 'width=1200px;height=800px;');
            }

        // User selection functionality.
        $('#selectUser').click(function () {
            var user = $('#slt_user').val();
            if ('' === user) {
                alert('Please select a user first.');
                return;
            }
            $('#div_login').hide();
            $('#div_table').show();
            $('#span_user').html("Current User: " + user);
        });
     

    </script>
</head>
<body>

    <div class="description">
        <div class="demo mc">
            <h2 class="fs-18">File Concurrency Control Feature</h2>
            <h3 class="fs-14" style="color: black;">Demo Instructions:</h3>
            <p>This example demonstrates how to develop a file concurrency control feature that prevents two users from opening and editing the same file simultaneously, thereby avoiding content overwriting when saving.</p>
            <p>(If your online edited files are handled by a single user at a time, there is no need to implement or use the concurrency control feature. Only consider this functionality if multiple users need to edit the same file concurrently within a process node.)</p>
            <h3 class="fs-14" style="color: black;">Steps:</h3>
            <p>1. Select a user, such as "<span style="color: black; font-weight: bold;">Jack</span>", log in, and click the "Edit" button to open a file from the list, for instance, "<span style="color: black; font-weight: bold;">Product Introduction</span>";</p>
            <p>2. Open a new browser window to simulate another user "<span style="color: black; font-weight: bold;">Lisa</span>" logging in and attempting to edit the same file, "<span style="color: black; font-weight: bold;">Product Introduction</span>", to observe the effect of the concurrency control (a prompt indicating the document is being used by another user).</p>
        </div>
    </div>

    <div class="container">
        <div class="content">
            <div id="div_login" style="display: block;">
                <form action="/login" method="post">
                    <label class="header">Login</label>
                    <div class="form-group">
                        <label for="username">Username:</label>
                        <select id="slt_user" name="username">
                            <option value="" disabled="disabled">Select User</option>
                            <option value="Jack">Jack</option>
                            <option value="Lisa">Lisa</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" id="password" disabled="disabled" name="password" value="123456" placeholder="Enter password" />
                    </div>
                    <button type="button" id="selectUser">Log In</button>
                </form>
            </div>

            <div id="div_table" style="display: none; margin-top: 30px;">
                <div style="display: flex; justify-content: space-between; align-items: center;">
                    <div class="fs-18">Share File List</div>
                    <div class="fs-18" id="currentUserName"></div>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Document Name</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%=strHtmls %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script>
        // jQuery for controlling form display logic
        $(document).ready(function () {
            $('#selectUser').click(function () {
                $('#div_login').hide();
                $('#div_table').show();
                var selectedUser = $('#slt_user').val();
                if (selectedUser) {
                    $('#currentUserName').text('Current Login User: ' + selectedUser);
                }
            });
        });

    </script>
</body>
</html>
