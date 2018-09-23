let incomesBarChartLoadFunc = function (database) {
    google.charts.load('current', {'packages': ['corechart']});
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        let january = 1200,
            february = 1600,
            march = 2000,
            april = 1050,
            may = 1200,
            june = 2150,
            july = 2250,
            august = 3000,
            september = 3100,
            october = 2600,
            november = 3120,
            december = 2750;


        let incomeData = google.visualization.arrayToDataTable([
            ['Category', 'Income'],
            ['January', january],
            ['February', february],
            ['March', march],
            ['April', april],
            ['May', may],
            ['June', june],
            ['July', july],
            ['August', august],
            ['September', september],
            ['October', october],
            ['November', november],
            ['December', december]
        ]);

        let options = {'title': 'Income for 2017'};

        let chart = new google.visualization.BarChart(document.getElementById('barchart'));
        chart.draw(incomeData, options);
    }
    return drawChart
}