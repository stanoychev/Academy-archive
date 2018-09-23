const currencyHandlerFunc = function (database) {

    function generateCurrencyChangeMenu() {

        // let $listItem = $('<li  id="currency"></li>')
        // let $divDropDown = $('<div class="dropdown"></div>')
        // let $ulDrops = $('<ul id="currency-dropdown" class="dropdown-menu"></ul>')
        //
        // $ulDrops.append('<li><a href="#" class="currency-item EUR">EUR</a></li>')
        // $ulDrops.append('<li><a href="#" class="currency-item BGN">BGN</a></li>')
        // $ulDrops.append('<li ><a href="#" class="currency-item USD">USD</a></li>')
        // $ulDrops.append('<li ><a href="#" class="currency-item GBP">GBP</a></li>')
        //
        // $divDropDown.append('<button class="btn btn-sm btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> Change Currency<span class="caret"></span></button>')
        // $divDropDown.append($ulDrops)
        // $listItem.append($divDropDown)
        //
        // $('#main-nav-ul').append($listItem)

        //$(`.${database.currency}`).attr('class', `currency-item ${database.currency} disabled`)
    }

    function convertToBaseEUR(data) {

        if (database.currency !== 'EUR') {
            database.budget.salary /= data.rate
            database.budget.amount /= data.rate
            database.budget.moneyLeft /= data.rate

            for (let i = 0; i < database.budget.knownExpenses.length; i++) {
                database.budget.knownExpenses[i].amount /= data.rate
            }

            for (let i = 0; i < database.budget.savingGoals.length; i++) {
                database.budget.savingGoals[i].amount /= data.rate
            }

            for (let i = 0; i < database.incomes.length; i++) {
                database.incomes[i].amount /= data.rate
            }

            for (let i = 1; i < database.expenses.length; i++) {
                database.expenses[i].amount /= data.rate
            }
        }

        //console.log(database.budget.amount)
    }

    function getCurrentCurrency() {
        //console.log(database.budget.amount)
        return database.currency
    }

    function updateCurrency(data) {
        if (data.rate !== undefined) {

            database.budget.salary *= data.rate
            database.budget.amount *= data.rate
            database.budget.moneyLeft *= data.rate

            for (let i = 0; i < database.budget.knownExpenses.length; i++) {
                database.budget.knownExpenses[i].amount *= data.rate
            }

            for (let i = 0; i < database.budget.savingGoals.length; i++) {
                database.budget.savingGoals[i].amount *= data.rate
            }

            for (let i = 0; i < database.incomes.length; i++) {
                database.incomes[i].amount *= data.rate
            }

            for (let i = 1; i < database.expenses.length; i++) {
                database.expenses[i].amount *= data.rate
            }

            //console.log(database.budget.amount)
        }
        (function updateDatabase(newCurrency) {
            database.currency = newCurrency
        }(data.currency))

        container.refreshTopStatistics()

    }


    return {
        generateCurrencyChangeMenu,
        convertToBaseEUR,
        getCurrentCurrency,
        updateCurrency,
    }
}

