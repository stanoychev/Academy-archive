const historyTableLoadFunc = function (database) {
    function addRow() {


        let date = $("#showCallendarExpense").val();
        let amount = +$('#subtractMoney').val()
        let category = $("input[name=optradio]:checked").val()
        let note = $('#subtractMoneyNote').val()
        let table = document.getElementById("myTableData")

        //let rowCount = table.rows.length;
        let firstRow = 1
        let row = table.insertRow(firstRow);

        row.insertCell(0).innerHTML = date;
        row.insertCell(1).innerHTML = amount;
        row.insertCell(2).innerHTML = category;
        row.insertCell(3).innerHTML = note;
    }

    return {
        addRow
    }
}


