﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.ApplicationForm.Word" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tax Form Application</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <script src="../js/jquery-3.6.0.min.js"></script>
</head>
<body>
<%--    <div class="button-container">
        <button class="main-btn" id="openTaxForm">Tax Form</button>
        <button class="main-btn" id="openApplicationForm">Application Form</button>
    </div>--%>

    <div class="modal-overlay" id="taxModal">
        <div class="modal-center">
            <form id="taxForm">
                <div class="form-group">
                    <label>Full Name:</label>
                    <input type="text" id="name" placeholder="Enter your full name">
                </div>

                <div class="form-group">
                    <label>Gender:</label>
                    <div class="gender-container">
                        <div class="gender-item">
                            <label>Male:</label>
                            <input type="radio" name="gender" value="male">
                        </div>
                        <div class="gender-item">
                            <label>Female:</label>
                            <input type="radio" name="gender" value="female">
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label>ID Number:</label>
                    <input type="text" id="idNumber" placeholder="Enter your ID number">
                </div>

                <div class="form-group">
                    <label>Date:</label>
                    <input type="text" id="date" placeholder="YYYY-MM-DD">
                </div>

                <div class="form-group">
                    <label>Position:</label>
                    <input type="text" id="position" placeholder="Enter your position">
                </div>

                <div class="form-group">
                    <label>Monthly Salary (USD):</label>
                    <input type="number" id="salary" placeholder="Enter monthly amount">
                </div>

                <div class="form-actions">
                    <button type="submit" class="confirm-btn">Confirm</button>
                    <button type="button" class="clear-btn">Clear</button>
                </div>
            </form>
        </div>
    </div>

    <div class="modal-overlay" id="applicationModal">
        <div class="modal-center">
            <form id="applicationForm">
                <div class="form-group">
                    <label>Full Name:</label>
                    <input type="text" id="applicantName" placeholder="Enter your full name">
                </div>

                <div class="form-group">
                    <label>Age:</label>
                    <input type="number" id="age" placeholder="Enter your age">
                </div>

                <div class="form-group">
                    <label>Gender:</label>
                    <div class="gender-container">
                        <div class="gender-item">
                            <label>Male:</label>
                            <input type="radio" name="applicantGender" value="1">
                        </div>
                        <div class="gender-item">
                            <label>Female:</label>
                            <input type="radio" name="applicantGender" value="2">
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label>Nationality:</label>
                    <input type="text" id="nationality" placeholder="Enter nationality">
                </div>

                <div class="form-group">
                    <label>ID Type:</label>
                    <input type="text" id="idType" placeholder="Enter ID type (e.g. Passport)">
                </div>

                <div class="form-group">
                    <label>ID Number:</label>
                    <input type="text" id="applicantId" placeholder="Enter ID number">
                </div>

                <div class="form-group">
                    <label>Application Reason:</label>
                    <textarea id="reason" rows="4" placeholder="State your application reason"></textarea>
                </div>

                <div class="form-actions">
                    <button type="submit" class="confirm-btn">Confirm</button>
                    <button type="button" class="clear-btn">Clear</button>
                </div>
            </form>
        </div>
    </div>
    <div style="width: auto; height: 95vh;">
        <%=aceCtrl.GetHtml()%>
    </div>
    <script>
        $(document).ready(function () {
            // Tax Form Handling
            //$('#openTaxForm').click(function () {
            //    $('#taxModal').fadeIn(300);
            //});

            $('#taxForm').submit(function (e) {
                e.preventDefault();
                $('#taxModal').fadeOut(300);

                aceoffixctrl.Enabled = true;

                aceoffixctrl.word.SetValueToDataRegion('ACE_name', $('#name').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_gender', $('input[name="gender"]:checked').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_ID', $('#idNumber').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_date', $('#date').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_position', $('#position').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_monthly_income', $('#salary').val());

                return false;
            });

            //// Application Form Handling
            //$('#openApplicationForm').click(function () {
            //    $('#applicationModal').fadeIn(300);
            //});

            $('#applicationForm').submit(function (e) {
                e.preventDefault();
                $('#applicationModal').fadeOut(300);
                aceoffixctrl.Enabled = true;

                aceoffixctrl.word.SetValueToDataRegion('ACE_taxpayer_name', $('#applicantName').val());

                if ('1' == $('input[name="applicantGender"]:checked').val()) {
                    aceoffixctrl.word.SetValueToDataRegion('ACE_taxpayer_gender', '☑Male □Female');
                } else {
                    aceoffixctrl.word.SetValueToDataRegion('ACE_taxpayer_gender', '□Male ☑Female');
                }
                aceoffixctrl.word.SetValueToDataRegion('ACE_age', $('#age').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_nationality', $('#nationality').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_identification', $('#idType').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_identification_nubmer', $('#applicantId').val());
                aceoffixctrl.word.SetValueToDataRegion('ACE_reason', $('#reason').val());
            });

            // Common Handlers
            $('.clear-btn').click(function () {
                $(this).closest('form')[0].reset();
            });

            $('.modal-overlay').click(function (e) {
                if ($(e.target).hasClass('modal-overlay')) {
                    $(this).fadeOut(300);
                }
            });
        });
        function OnAceoffixCtrlInit() {
            // Callback function for Aceoffix initialization event. You can add custom buttons here.
            aceoffixctrl.AddCustomToolButton("Fill Certificate", "ShowModalDlg()", 3);
            aceoffixctrl.AddCustomToolButton("Fill Application Form", "ShowModalDlg2()", 3);
        }

        function ShowModalDlg() {
            aceoffixctrl.word.LocateDataRegion("ACE_certificate");
            aceoffixctrl.Enabled = false;
            $('#taxModal').fadeIn(300);
        }

        function ShowModalDlg2() {
            aceoffixctrl.word.LocateDataRegion("ACE_application_form");
            aceoffixctrl.Enabled = false;
            $('#applicationModal').fadeIn(300);
        }
    </script>
</body>
</html>
