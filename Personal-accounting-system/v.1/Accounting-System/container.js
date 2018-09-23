const container = (function () {
    const database2 = database()
    const modelFactory2 = modelFactory()

    const formController = formControllerFunc(database2, modelFactory2)
    const expensesController = expensesControllerFunc(database2, modelFactory2)
    const incomeController = incomeControllerFunc(database2, modelFactory2)
    const navbarController = navbarControllerFunc(database2, modelFactory2)
    const sidepanelController = sidePanelControllerFunc(database2)

    const expenseChartLoad = expenseChartLoadFunc(database2)
    const incomesBarChartLoad = incomesBarChartLoadFunc(database2)

    const historyTableLoad = historyTableLoadFunc(database2)

    const ajaxProvider = ajaxModule()
    const currencyHandler = currencyHandlerFunc(database2)

    const refreshTopStatistics = refreshTopStatisticsFunc(database2)

    return {
        formController,
        expensesController,
        incomeController,
        navbarController,
        sidepanelController,
        expenseChartLoad,
        incomesBarChartLoad,
        ajaxProvider,
        currencyHandler,
        refreshTopStatistics,
        historyTableLoad
    }
}())