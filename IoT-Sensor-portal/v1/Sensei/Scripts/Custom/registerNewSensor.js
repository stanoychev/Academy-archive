$(document).ready(function () {
    (function () {
        //Sensor_OperatingRange Sensor_MeasurementType not in use anymore
        //let textBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`, `Sensor_OperatingRange`,
        //    `Sensor_MinValue`, `Sensor_MaxValue`, `Sensor_MeasurementType`,
        //    `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];

        let textBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`,
            `Sensor_MinValue`, `Sensor_MaxValue`,
            `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];

        let checkBoxes = [`Sensor_IsPublic`];

        textBoxes.forEach(hideTextBox);
        checkBoxes.forEach(hideCheckbox);
    }())

    $("#Tag").on("change", function () {

        let selected = `#` + $(`#Tag`).val();

        //let baseUrl = `http://telerikacademy.icb.bg/api/sensor/`;
        let sensorId = $(selected).find(".sensorId").text();
        
        let sensorDescription = $(selected).find(".sensorDescription").text();
        let descriptionAsArray = sensorDescription.split(` `);
        //let measurementType = $(selected).find(".measurementType").text();

        //let minPollingInterval = $(selected).find(".minPollingInterval").text(); not in use but important

        //Sensor_OperatingRange Sensor_MeasurementType not in use anymore
        //let textBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`, `Sensor_OperatingRange`,
        //    `Sensor_MinValue`, `Sensor_MaxValue`, `Sensor_MeasurementType`,
        //    `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];
        
        let textBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`,
            `Sensor_MinValue`, `Sensor_MaxValue`,
            `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];

        let checkBoxes = [`Sensor_IsPublic`];

        if (selected === '#' || sensorId === '') {
            textBoxes.forEach(hideTextBox);
            checkBoxes.forEach(hideCheckbox);
        }
        else {
            //Sensor_OperatingRange Sensor_MeasurementType not in use anymore
            //let limitedTextBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`,
            //    `Sensor_OperatingRange`, `Sensor_MeasurementType`,
            //    `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];

            let limitedTextBoxes = [`Sensor_Name`, `Sensor_LastValue_SensorIdICB`,
                `Sensor_DescriptionGivenByTheUser`, `Sensor_LastValue_PollingInterval`];

            limitedTextBoxes.forEach(showElement);
            checkBoxes.forEach(showElement);

            if ($.inArray(`between`, descriptionAsArray) > -1) {
                showElement(`Sensor_MinValue`);
                showElement(`Sensor_MaxValue`);
                let minVal = descriptionAsArray[descriptionAsArray.length - 3]
                $(`#Sensor_MinValue`).val(minVal);
                let maxVal = descriptionAsArray[descriptionAsArray.length - 1]
                $(`#Sensor_MaxValue`).val(maxVal);
            }
            else {
                hideTextBox(`Sensor_MinValue`);
                hideTextBox(`Sensor_MaxValue`);
            }

            $(`#Sensor_LastValue_SensorIdICB`).val(sensorId);
            //$(`#Sensor_OperatingRange`).val(sensorDescription); not in use anymore
            //$(`#Sensor_MeasurementType`).val(measurementType);
        }
    });

    function hideTextBox(item) {
        $(`#` + item).hide();
        if (item === `Sensor_MinValue` || item === `Sensor_MaxValue`) {
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