const ajaxModule = function () {
    const linkApi = "http://api.fixer.io/latest"

    function changeCurrencry(callback, currency) {
        function firstPromise() {
            let getCurrencyRate = new Promise((resolve, reject) =>
                $.get('http://api.fixer.io/latest', (data) => resolve(data)))

            return getCurrencyRate
        }

        function getcurrency(data) {
            return {
                currency,
                rate: data.rates[currency]
            }
        }

        firstPromise().then(getcurrency).then(callback)
    }

    return {
        changeCurrencry
    }
}

