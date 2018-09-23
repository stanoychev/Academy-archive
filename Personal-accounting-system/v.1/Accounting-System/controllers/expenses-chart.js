const expenseChartLoadFunc = function (database) {
    google.charts.load('current', {'packages': ['corechart']});
    google.charts.setOnLoadCallback(drawChart);

    let taxes = 0
    let insurance = 0
    let savings = 0
    let investments = 0
    let housing = 0
    let debtRepayment = 0
    let medicalDental = 0
    let food = 0
    let entertainmentAndRecreation = 0
    let miscellaneous = 100
    let automobile = 0
    let clothing = 0
    let schoolChildcare = 0;

    function drawChart() {

        let category = $("#addExpense input[name=optradio]:checked").val()
        let amount = +$('#subtractMoney').val()

        switch (category) {
            case 'Taxes':
                taxes = +amount
                break
            case 'Housing':
                housing += amount
                break
            case 'Food':
                food += amount
                break
            case 'Automobile':
                automobile += amount
                break
            case 'Insurance':
                insurance += amount
                break
            case 'Debt Repayment':
                debtRepayment += amount
                break
            case 'Entertainment and Recreation':
                entertainmentAndRecreation += amount
                break
            case 'Clothing':
                clothing += amount
                break
            case 'Savings':
                savings += amount
                break
            case 'Medical/Dental':
                medicalDental += amount
                break
            case 'Miscellaneous':
                miscellaneous += amount
                break
            case 'School/Childcare':
                schoolChildcare += amount
                break
            case 'Investments':
                investments += amount
                break
        }

        let data = google.visualization.arrayToDataTable([
            ['Category', 'amount'],
            ['Taxes', taxes],
            ['Housing', housing],
            ['Food', food],
            ['Automobile', automobile],
            ['Insurance', insurance],
            ['Debt Repayment', debtRepayment],
            ['Entertainment and Recreation', entertainmentAndRecreation],
            ['Clothing', clothing],
            ['Savings', savings],
            ['Medical/Dental', medicalDental],
            ['Miscellaneous', miscellaneous],
            ['School/Childcare', schoolChildcare],
            ['Investments', investments]
        ]);
        let options = {
            title: 'Expenses'
        };
        let chart = new google.visualization.PieChart(document.getElementById('piechart'));
        chart.draw(data, options);
    }

    return {
        drawChart
    }
}