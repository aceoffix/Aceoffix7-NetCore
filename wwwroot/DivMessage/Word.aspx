﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.DivMessage.Word" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dialog Components Demo</title>
    <script src="../js/jquery-3.6.0.min.js"></script>
    <style>
        /* Button container style */
        .button-group {
            display: flex;
            gap: 20px;
            padding: 20px;
            background: #f8f9fa;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
        }

        /* Button style */
        .action-btn {
            padding: 12px 24px;
            border: none;
            border-radius: 8px;
            background: #2196F3;
            color: white;
            font-size: 16px;
            cursor: pointer;
            transition: all 0.3s ease;
            box-shadow: 0 2px 4px rgba(0,0,0,0.2);
        }

        .action-btn:hover {
            background: #1976D2;
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        }

        /* Modal dialog style */
        .modal-overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,0.5);
            justify-content: center;
            align-items: center;
            z-index: 1000; /* Ensure it's on top */
        }

        .modal-box {
            background: white;
            padding: 30px;
            border-radius: 12px;
            width: 400px;
            position: relative;
            /* Removed animation effect */
            top: 50%; /* Centering */
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .modal-close {
            position: absolute;
            top: 15px;
            right: 20px;
            font-size: 28px;
            cursor: pointer;
            transition: transform 0.3s;
            color: #666;
        }

        .modal-close:hover {
            color: #333;
            transform: rotate(90deg);
        }
    </style>
</head>
<body>
    <!-- Action buttons -->
    <div class="button-group">
        <button class="action-btn" id="modalBtn">Modal Dialog</button>
        <button class="action-btn" id="alertBtn">Standard Alert Dialog</button>
        <button class="action-btn" id="confirmBtn">Standard Confirm Dialog</button>
    </div>

    <!-- Custom modal dialog -->
    <div class="modal-overlay" id="modal">
        <div class="modal-box">
            <span class="modal-close" id="closeModal">&times;</span>
            <h2 style="margin-top: 0;">Custom Modal Dialog</h2>
            <p>This is a customizable modal dialog that can only be closed by clicking the close button.</p>
        </div>
    </div>
    <div style="width: auto; height: 85vh;">
        <%=aceCtrl.GetHtml()%>
    </div>
    <script>
        $(document).ready(function () {
            $('#modalBtn').click(function () {
                aceoffixctrl.Enabled = false;
                $('#modal').show();
            });

            $('#closeModal').click(function () {
                $('#modal').hide();
                aceoffixctrl.Enabled = true;
            });

            $('.modal-overlay').click(function (e) {
                e.stopPropagation();
            });

            $('#alertBtn').click(function () {
                alert('This is a standard alert dialog from native JavaScript.');
            });

            $('#confirmBtn').click(function () {
                const result = confirm('Please confirm your action.');
                console.log(result ? 'User confirmed' : 'User canceled');
            });

            $(document).keyup(function (e) {
                if (e.key === "Escape") {
                    e.preventDefault(); // Prevent default behavior
                }
            });
        });

        function OnAceoffixCtrlInit() {
            // Initialization event callback function for Aceoffix where you can add custom buttons
            aceoffixctrl.AddCustomToolButton("Modal Dialog", "ShowModalDlg()", 0);
        }

        function ShowModalDlg() {
            aceoffixctrl.Enabled = false;
            $('#modal').show();
        }
    </script>
</body>
</html>
