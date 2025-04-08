<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.FormToDataRegions.Word1" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contract Management System</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <script src="../js/jquery-3.6.0.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="left-panel">
            <!-- Placeholder for ACE control -->
            <div style="padding: 20px;height:840px;" ><%=aceCtrl.GetHtml()%></div>
        </div>

        <div class="right-panel">
            <h2>Contract Information</h2>

            <form id="contractForm">
                <!-- Purchaser Section -->
                <div class="form-group">
                    <label class="form-label">Purchaser:</label>
                    <input type="text" class="form-control" name="purchaser" placeholder="Enter Purchaser Name">
                </div>

                <!-- Supplier Section -->
                <div class="form-group">
                    <label class="form-label">Supplier:</label>
                    <input type="text" class="form-control" name="supplier" placeholder="Enter Supplier Name">
                </div>

                <!-- Buyer Company -->
                <div class="form-group">
                    <label class="form-label">Buyer's Company:</label>
                    <input type="text" class="form-control" name="buyer_company" placeholder="Enter Company Name">
                </div>

                <!-- Project Number -->
                <div class="form-group">
                    <label class="form-label">Project Number:</label>
                    <input type="text" class="form-control" name="project_number" placeholder="Enter Project Number">
                </div>

                <div class="section-divider"></div>

                <!-- Product Selection -->
                <div class="form-group">
                    <button type="button" class="btn btn-primary btn-disabled" id="addButton" disabled>Add to List</button><br><br>
                    <div id="productOptions">
                        <!-- Single radio button for each product option -->
                        <input type="radio" id="productOption1" name="selectedGood" value='{"id": 1, "name": "Quantum Computer", "specification": "550A", "model": "Entry-level", "unit": "Unit", "quantity": 1, "unit_price": "100USD"}'>
                        <label for="productOption1">Quantum Computer (550A, Entry-level, Unit)</label><br><br>
                        <input type="radio" id="productOption2" name="selectedGood" value='{"id": 2, "name": "Quantum Computer", "specification": "550C", "model": "Flagship", "unit": "Unit", "quantity": 1, "unit_price": "200USD"}'>
                        <label for="productOption1">Quantum Computer (550C, Flagship, Unit)</label><br><br>
                        <input type="radio" id="productOption3" name="selectedGood" value='{"id": 3, "name": "Quantum Computer", "specification": "550W", "model": "Enthusiast", "unit": "Unit", "quantity": 1, "unit_price": "300USD"}'>
                        <label for="productOption1">Quantum Computer (550W, Enthusiast, Unit)</label><br>
                    </div>
                </div>

                <!-- Goods List Table -->
                <h3>Procurement List</h3>
                <table class="goods-table" id="goodsTable">
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th>Specification</th>
                            <th>Model</th>
                            <th>Unit</th>
                            <th>Quantity</th>
                            <th>Unit Price</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>

                <div class="total-price">
                    Total Contract Price: $<span id="totalUSD">0</span>
                </div>

                <!-- Form Actions -->
                <div class="form-group">
                    <button type="reset" class="btn">Reset</button>
                    <button type="submit" class="btn btn-primary">Submit</button>
                </div>
            </form>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            // Enable add button when a product option is selected
            $('input[name="selectedGood"]').on('click', function () {
                if ($(this).is(':checked')) {
                    $('#addButton').prop('disabled', false).removeClass('btn-disabled');
                } else {
                    $('#addButton').prop('disabled', true).addClass('btn-disabled');
                }
            });

            // Add product to table
            $('#addButton').click(function () {
                const productDetails = $('input[name="selectedGood"]:checked').val();
                const product = JSON.parse(productDetails);
                const row = `
                    <tr>
                        <td>${product.name}</td>
                        <td>${product.specification}</td>
                        <td>${product.model}</td>
                        <td>${product.unit}</td>
                        <td>${product.quantity}</td>
                        <td>${product.unit_price}</td>
                    </tr>`;

                $('#goodsTable tbody').append(row);
                updateTotalPrice();
                resetProductSelection();
            });

            // Update total price
            function updateTotalPrice() {
                let total = 0;
                $('#goodsTable tbody tr').each(function () {
                    const price = parseInt($(this).find('td:last').text().replace('USD', ''));
                    total += price;
                });
                $('#totalUSD').text(total);
            }

            // Reset product selection
            function resetProductSelection() {
                $('input[name="selectedGood"]').prop('checked', false);
                $('#addButton').prop('disabled', true).addClass('btn-disabled');
            }

            // Form submission
            $('#contractForm').submit(function (e) {
                e.preventDefault();

                const formData = {
                    purchaser: $('[name="purchaser"]').val(),
                    supplier: $('[name="supplier"]').val(),
                    buyer_company: $('[name="buyer_company"]').val(),
                    project_number: $('[name="project_number"]').val()
                };

                const tableDatas = [];
                $('#goodsTable tbody tr').each(function () {
                    const cells = $(this).find('td');
                    tableDatas.push({
                        name: cells.eq(0).text().trim(),
                        specification: cells.eq(1).text().trim(),
                        model: cells.eq(2).text().trim(),
                        unit: cells.eq(3).text().trim(),
                        quantity: cells.eq(4).text().trim(),
                        unit_price: cells.eq(5).text().trim()
                    });
                });

       
                Object.entries(formData).forEach(([key, value]) => {
                    aceoffixctrl.word.SetValueToDataRegion(`ACE_${key}`, String(value));
                });
                aceoffixctrl.word.SetValueToDataRegion('ACE_totalPrice', $('#totalUSD').text());


                try {      

                    for (let row = 1; row <= tableDatas.length; row++) {
                        aceoffixctrl.word.SelectTableCell("ACE_table", 1, row, 6);
                        aceoffixctrl.word.AppendTableRow();
                    }

                    tableDatas.forEach((row, index) => {
                        for (let col = 1; col <= 6; col++) {
                            aceoffixctrl.word.SelectTableCell("ACE_table", 1, index + 2, col);
                            const valueMap = {
                                1: row.name,
                                2: row.specification,
                                3: row.model,
                                4: row.unit,
                                5: row.quantity,
                                6: row.unit_price
                            };
                            aceoffixctrl.word.SetTextToSelection(String(valueMap[col] || ''));
                        }
                    });

                } catch (error) {
                    console.error('error:', error);
                }
            });
        });
        function OnAceoffixCtrlInit() {
            // Callback function for the initialization event of . You can add custom buttons here.
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }

        function Save() {
            aceoffixctrl.SaveFilePage = "/FormToDataRegions/SaveFile";
            aceoffixctrl.WebSave();
        }
    </script>
</body>
</html>
