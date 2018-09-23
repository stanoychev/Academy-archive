const navbarControllerFunc = function (database, modelFactory) {

    let incomeOn = true;
    let expenseOn = true;

    $('#reloadPage').click(function () {
        location.reload();
    });

    function showIncomeBar() {
        if (incomeOn && expenseOn === false) {
            $("#addIncome").hide(100);
            incomeOn = false;
        } else if (incomeOn === false || expenseOn) {
            $("#addExpense").hide(100);
            expenseOn = false;
            $("#addIncome").show(200);
            incomeOn = true;
        }
    }

    function showExpensesBar() {
        if (expenseOn && incomeOn === false) {
            $("#addExpense").hide(100);
            expenseOn = false;
        } else if (expenseOn === false || incomeOn) {
            $("#addIncome").hide(100);
            incomeOn = false;
            $("#addExpense").show(200);
            expenseOn = true;
        }
    }

    return {
        showIncomeBar,
        showExpensesBar
    }
}
