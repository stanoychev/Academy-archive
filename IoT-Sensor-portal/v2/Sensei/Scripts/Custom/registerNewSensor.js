$(document).ready(function () {
    (function () {
        let textBoxes = [`UserDefinedSensorName`, `SensorIdICB`,
            `UserDefinedMinValue`, `UserDefinedMaxValue`,
            `UserDefinedDescription`, `PollingInterval`];

        let checkBoxes = [`IsPublic`];

        textBoxes.forEach(hideTextBox);
        checkBoxes.forEach(hideCheckbox);
    }())

    $("#Tag").on("change", function () {

        let selected = `#` + $(`#Tag`).val();

        //let baseUrl = `http://telerikacademy.icb.bg/api/sensor/`;
        let sensorId = $(selected).find(".sensorId").text();

        let sensorDescription = $(selected).find(".sensorDescription").text();
        let descriptionAsArray = sensorDescription.split(` `);

        let textBoxes = [`UserDefinedSensorName`, `SensorIdICB`,
            `UserDefinedMinValue`, `UserDefinedMaxValue`,
            `UserDefinedDescription`, `PollingInterval`];

        let checkBoxes = [`IsPublic`];

        if (selected === '#' || sensorId === '') {
            textBoxes.forEach(hideTextBox);
            checkBoxes.forEach(hideCheckbox);
        }
        else {
            let limitedTextBoxes = [`UserDefinedSensorName`, `SensorIdICB`,
                `UserDefinedDescription`, `PollingInterval`];

            limitedTextBoxes.forEach(showElement);
            checkBoxes.forEach(showElement);

            if ($.inArray(`between`, descriptionAsArray) > -1) {
                showElement(`UserDefinedMinValue`);
                showElement(`UserDefinedMaxValue`);
                let minVal = descriptionAsArray[descriptionAsArray.length - 3]
                $(`#UserDefinedMinValue`).val(minVal);
                let maxVal = descriptionAsArray[descriptionAsArray.length - 1]
                $(`#UserDefinedMaxValue`).val(maxVal);
            }
            else {
                hideTextBox(`UserDefinedMinValue`);
                hideTextBox(`UserDefinedMaxValue`);
            }

            $(`#SensorIdICB`).val(sensorId);
        }
    });

    function hideTextBox(item) {
        $(`#` + item).hide();
        if (item === `UserDefinedMinValue` || item === `UserDefinedMaxValue`) {
            $(`#` + item).val('0');
        }
        else {
            $(`#` + item).val('');
        }
        $(`label[for="` + item + `"]`).hide();
    }

    function hideCheckbox(item) {
        $(`#` + item).hide();
        $(`label[for="` + item + `"]`).hide();
    }

    function showElement(item) {
        $(`#` + item).show();
        $(`label[for="` + item + `"]`).show();
    }

});