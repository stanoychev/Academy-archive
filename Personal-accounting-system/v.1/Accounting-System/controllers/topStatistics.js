const refreshTopStatisticsFunc = function (database) {
    function execute() {
        const knownExpArray = database.expenses[0];
        const expensesArray = database.expenses

        function createTopStatistics() {
            $("#account-info-wrap").attr("class", "row");

            let empty = `<div id="account-infoLeft" class="col-xs-4 panel-group"></div>`;
            $("#account-info-wrap").append(empty);

            empty = `<div id="account-infoMiddle" class="col-xs-4 panel-group"></div>`;
            $("#account-info-wrap").append(empty);

            empty = `<div id="account-infoRight" class="col-xs-4 panel-group"></div>`;
            $("#account-info-wrap").append(empty);

            let totalExp = 0;
            for (let i = 0; i <= knownExpArray.length - 1; i++) {
                totalExp += knownExpArray[i].amount
            }
            for (let i = 1; i <= expensesArray.length - 1; i++) {
                totalExp += expensesArray[i].amount
            }

            let panelHeading = `<div class="panel-heading ">Salary:</div>`
            let salaryToDysplay = database.budget.salary
            let panelBody = `<div class="panel-body" id="salaryDisplay">${parseFloat(salaryToDysplay).toFixed(2)}</div>`
            let panelWrapper = [`<div class="panel panel-default">`, panelHeading, panelBody, `</div>`]
            let containerArray = [panelWrapper.join(``)]

            panelHeading = `<div class="panel-heading ">Total Expenses:</div>`
            panelBody = `<div class="panel-body" id="totalExp">${parseFloat(totalExp).toFixed(2)}</div>`
            panelWrapper = [`<div class="panel panel-default">`, panelHeading, panelBody, `</div>`]
            containerArray.push(panelWrapper.join(``))

            $(`#account-infoLeft`).append(containerArray)
            containerArray = null

            let maxSpending = 0;
            let maxCategory;
            for (let i = 0; i <= knownExpArray.length - 1; i++) {
                if (knownExpArray[i].amount >= maxSpending) {
                    maxSpending = knownExpArray[i].amount;
                    maxCategory = knownExpArray[i].category;
                }
            }

            for (let i = 1; i <= expensesArray.length - 1; i++) {
                if (expensesArray[i].amount >= maxSpending) {
                    maxSpending = expensesArray[i].amount;
                    maxCategory = expensesArray[i].category;
                }
            }

            panelHeading = `<div class="panel-heading ">Most spent on:</div>`
            panelBody = `<div class="panel-body" id="maxCategory">${maxCategory}</div>`
            maxCategory = null
            panelWrapper = [`<div class="panel panel-default">`, panelHeading, panelBody, `</div>`]
            containerArray = [panelWrapper.join(``)]

            panelHeading = `<div class="panel-heading ">Biggest Expense:</div>`
            panelBody = `<div class="panel-body" id="maxSpending">${parseFloat(maxSpending).toFixed(2)}</div>`
            maxSpending = null
            panelWrapper = [`<div class="panel panel-default">`, panelHeading, panelBody, `</div>`]
            containerArray.push(panelWrapper.join(``))

            $(`#account-infoMiddle`).append(containerArray)
            containerArray = null

            for (let i = 0; i <= database.budget.savingGoals.length - 1; i++) {
                let saveGoalValue = database.budget.savingGoals[i].amount
                panelHeading = `<div class="panel-heading ">Save goal #${i + 1} for ${parseFloat(saveGoalValue).toFixed(2)}</div>`
                panelBody = `<div class="panel-body">${database.budget.savingGoals[i].note}</div>`
                panelWrapper = [`<div class="panel panel-primary">`, panelHeading, panelBody, `</div>`]
                containerArray = [panelWrapper.join(``)]

                $(`#account-infoRight`).append(containerArray)
                containerArray = null
            }
        }

        function refreshTopStatistics() {
            let salaryDisplay = database.budget.salary
            $("#salaryDisplay").text(parseFloat(salaryDisplay).toFixed(2));

            let totalExp = 0;
            for (let i = 0; i <= knownExpArray.length - 1; i++) {
                totalExp += knownExpArray[i].amount;
            }

            for (let i = 1; i <= expensesArray.length - 1; i++) {
                totalExp += expensesArray[i].amount;
            }
            $("#totalExp").text(parseFloat(totalExp).toFixed(2));

            let maxSpending = 0;
            let maxCategory;

            for (let i = 0; i <= knownExpArray.length - 1; i++) {
                if (knownExpArray[i].amount >= maxSpending) {
                    maxSpending = knownExpArray[i].amount;
                    maxCategory = knownExpArray[i].category;
                }
            }

            for (let i = 1; i <= expensesArray.length - 1; i++) {
                if (expensesArray[i].amount >= maxSpending) {
                    maxSpending = expensesArray[i].amount;
                    maxCategory = expensesArray[i].category;
                }
            }
            console.log(maxCategory)
            $("#maxCategory").text(maxCategory);
            $("#maxSpending").text(parseFloat(maxSpending).toFixed(2));
        }

        if ($("#account-info-wrap").attr("class") !== "row") {
            createTopStatistics();
            console.log("creating top statistics")
        } else {
            refreshTopStatistics();
            console.log("refresh top statistics")
        }
    }

    return execute
};