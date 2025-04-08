<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.SaveAndSearch.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Aceoffix Document Search and Edit</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <script src="../js/jquery-3.6.0.min.js"></script>
    <!-- The aceoffix.js must be referenced -->
    <script type="text/javascript" src="../aceoffix.js"></script>

    <script type="text/javascript">
        function copyKeyToInput(key) {
            $("#Input_KeyWord").val(key);
        }

        $(document).ready(function () {
            $('#Input_KeyWord').val("<%=strKey%>");

            $('#Input_KeyWord').focus(function () {
                if ($(this).val() === "Enter keyword") {
                    $(this).val("");
                }
            });

            $('#Input_KeyWord').blur(function () {
                if ($(this).val().trim().length <= 0) {
                    $(this).val("Enter keyword");
                }
            });

            $('#searchButton').click(function () {
                var keyword = $('#Input_KeyWord').val();
                $('#searchForm').submit();
            });
        });
    </script>
</head>
<body>
    <div class="search-container">
        <h2>Aceoffix for Online Editing, Saving, and Full-text Keyword Search in Word Documents</h2>
       <form id="searchForm" method="post" action="Default">
            <label for="Input_KeyWord">Search documents by keywords in their content</label>
            <br/>
            <input name="Input_KeyWord" id="Input_KeyWord" type="text" onfocus="getFocus()" onblur="lostFocus()"
                class="search-box" placeholder="Enter keyword" />
            <div class="popular-searches">
                  Popular Searches:
            <a href="#" onclick="copyKeyToInput('License');">License</a>&nbsp;
            <a href="#" onclick="copyKeyToInput('Word');">Word</a>&nbsp;
            <a href="#" onclick="copyKeyToInput('Trial');">Trial</a>&nbsp;
            </div>
            <button id="searchButton" type="button" class="button" >Search Documents</button>
        </form>
    </div>
    <div>
        <h2 style="text-align: center;">Document List</h2>
        <table id="docTable">
            <thead>
                <tr>
                    <th>Document Name</th>
                    <th style="text-align: center;">Operations</th>
                </tr>
            </thead>
            <tbody>
                <%=strHtml %>
            </tbody>
        </table>
    </div>
</body>
</html>
