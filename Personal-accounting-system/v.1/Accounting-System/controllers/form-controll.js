const formControllerFunc = function (database, modelFactory) {
    let salary = 0
    let expenses = []
    let savingGoals = []
    let sumOfExpenses = 0
    let sumOfSavings = 0


    function continueToPartTwo() {
        salary = $('#salary-budget').val()
        let payday = +$('#payday-budget').val()
        database.currency = $('#selectbasic').find(':selected').val()

        $(`.${database.currency}`).attr('class', `currency-item ${database.currency} disabled`)

        console.log(database.currency)

        let regex = new RegExp('[0-9]+')

        let salaryTrimed = +(function trimStart(character, string) {
            let startIndex = 0;

            while (string[startIndex] === character) {
                startIndex++;
            }

            return string.substr(startIndex);
        }(0, salary))

        if (salaryTrimed > 0 && regex.test(salaryTrimed)) {
            let checked = $('#monthEndDateCheckBox').is(':checked')

            if (checked) {
                payday = 30
            }

            if (typeof payday === "number" && payday > 0 && payday < 31) {
                $('#salary-span').text(salaryTrimed)
                updateProgress()

                //console.log('TRIMED: ' + `${typeof salaryTrimed}`)
                salary = undefined
                salary = salaryTrimed
                let budget = modelFactory.createBudget(salaryTrimed, payday, [], {})
                database.budget = budget

                // console.log(database.budget)
                // console.log(database.budget.moneySpent)
                // console.log(typeof database.budget.moneySpent)


                $(".partOne").hide(100);
                $(".partTwo").show()
            }
            else {
                alert('Please enter a valida day of the month')
            }
        }
        else {
            alert('Salary must be a number!')
        }
    }


    function submitExpenseBudget() {
        let expense = (function getExpense() {
            let type = $("input[name = 'knownExpenseType']:checked").val()
            let category = $("input[name='knownExpenseCategory']:checked").val()
            let amount = +$('#subtractMoney-budget').val()
            let note = $('#subtractMoneyNote-budget').val()

            switch (type) {
                case 'week':
                    amount *= 4
                    break
                case 'daily':
                    amount *= 30
                    break
                case 'year':
                    amount /= 12
                    break
            }
            console.log(modelFactory.createKnownExpense(type, category, amount, note))
            return modelFactory.createKnownExpense(type, category, amount, note)
        }())

        console.log(typeof database.budget.salary)


        let validAmount = checkAmountOfSalaryLeft(sumOfSavings + expense.amount, expense)

        if (validAmount) {
            sumOfExpenses += expense.amount
            expenses.push(expense)
            updateProgress()

            updateExpenseInfoVizualisation()
            $('#add-known-expense').hide(300)
        }

        function updateExpenseInfoVizualisation() {
            $('#expenses-span').text(sumOfExpenses)
            $('.counter').text(expenses.length)
            $('#subtractMoney-budget').val('')
            $('#subtractMoneyNote-budget').val('')
        }
    }

    function submitSavings() {
        let saving = (function getSaving() {

            let amount = +$('#savings-form-money').val()
            let note = $('#savings-form-note').val()

            return modelFactory.createSavingGoals(amount, note)
        }())

        let validAmount = checkAmountOfSalaryLeft(sumOfSavings + saving.amount, saving)

        if (validAmount) {
            sumOfSavings += saving.amount
            savingGoals.push(saving)
            updateProgress()

            $('.counter-savings').text(sumOfSavings)
            $('#subtractMoney-budget').val('')
            $('#savings-form-money').val('')
            $('#savings-form-note').val('')
            $('#savings-form').hide(300)
        }
        console.log(savingGoals)
    }


    function checkAmountOfSalaryLeft(newBonus, expenseOrSavingAdded) {
        if (sumOfSavings + sumOfExpenses + newBonus > database.budget.salary) {
            alert('You reached the limit of your expenses!')
            return false
        }
        else {
            return true
        }
    }

    function updateProgress() {
        function getPercentOfProgress() {
            return ((sumOfExpenses + sumOfSavings) / salary) * 100
        }

        $('#expense-progress').attr({
            'style': 'width:' + getPercentOfProgress() + '%'
        })
    }


    function submitBudget() {

        let initialBudget = salary - sumOfExpenses - sumOfSavings

        console.log(initialBudget)
        console.log(typeof initialBudget)

        database.budget.knownExpenses = expenses
        database.expenses.push(expenses)
        database.budget.savingGoals = savingGoals
        database.budget.amount = initialBudget
        database.budget.moneySpent = 0


        $("#navbarBtnRight").removeAttr("hidden");
        $(".wrap-budget-form").hide();
        $("#myNavbar").attr("class", "navbar-collapse collapse").removeAttr("hidden");

        $("#sidepanel").show(200);
        $('#budget-progressbar').show()
        $('.main-content').show()
        generateFooter()
    }

    function generateFooter() {

        $('footer')
            .css('display', 'block')
            .append('<section id="devInfo"> Made by: <br> Nikola Stanoychev, Simeon Darakchiev, Martin Donevski</section>')
    }

    //koleto
    //payday end of the month checkbox
    $("#monthEndDateCheckBox").change(function () {
        let $payDayForm = $("#payday-budget");
        if ($payDayForm.prop("disabled") === true) {
            $payDayForm.prop("disabled", false);
            $payDayForm.attr("placeholder", "Specify date of the month");
        } else {
            $payDayForm.val("");
            $payDayForm.attr("placeholder", "End of the month");
            $payDayForm.prop("disabled", true);
        }
    })

    //add known expense - default radio buttons behaviours sat
    let $setPayType = $('input:radio[name=knownExpenseType]');
    if ($setPayType.is(":checked") === false) {
        $setPayType.filter("[value=month]").prop("checked", true);
    }

    $setPayType.change(function () {
        let payType = ["Month", "Week", "Daily", "Year"];
        for (let i = 0; i <= payType.length - 1; i++) {
            if ($(this).attr("value") === payType[i].toLowerCase()) {
                $("#selectDateExpense-budget-label").text(payType[i]);
                break;
            }
        }
    });

    function textInButtonHandler($setCategory, $btnLabel, $otherField) {
        if ($setCategory.is(":checked") === false) {
            $setCategory.filter("[value=Miscellaneous]").prop("checked", true);
            $btnLabel.text("default: Miscellaneous");
        }

        $setCategory.change(function () {
            $btnLabel.text($(this).attr("value"));

            if ($(this).attr("value") === "Other") {
                $otherField.prop("disabled", false);
            } else {
                $otherField.prop("disabled", true);
            }
        });
    }

    (function () {
        let $setCategory = $('input:radio[name=knownExpenseCategory]');
        let $btnLabel = $("#selectIncome-budget-label")
        let $otherField = $("#otherExpenseCategory-budget")
        textInButtonHandler($setCategory, $btnLabel, $otherField)
    })();

    (function () {
        let $setCategory = $('input:radio[name=income-category-item]');
        let $btnLabel = $("#selectIncome")
        let $otherField = $("#otherIncomeCategory")
        textInButtonHandler($setCategory, $btnLabel, $otherField)
    })();

    (function () {
        let $setCategory = $('input:radio[name=optradio]');
        let $btnLabel = $("#selectExpense")
        let $otherField = $("#otherExpenseCategory")
        textInButtonHandler($setCategory, $btnLabel, $otherField)
    })();

    return {
        continueToPartTwo,
        submitExpenseBudget,
        updateProgress,
        submitSavings,
        submitBudget
    }
}

