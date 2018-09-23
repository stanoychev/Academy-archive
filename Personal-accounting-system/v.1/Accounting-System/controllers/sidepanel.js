const sidePanelControllerFunc = function (database) {
    function visualizeCalendar() {
        (function callendarOperator() {
            let today = new Date();
            (function setMonthAndYear() {
                let monthNames = ["January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December"];
                let currentMonth = monthNames[today.getUTCMonth()];
                let currentYear = today.getUTCFullYear();
                $("#displayCallendarMonthYear").text(function () {
                    return currentMonth + ` ` + currentYear;
                });
            })();

            (function setCallendarDates() {
                let callendarCells = $(".callendar td");
                let currentDate = today.getUTCDate();
                let numberOfDaysToRevert = currentDate - 1;
                let callendarStartDate = new Date();
                callendarStartDate.setDate(today.getDate() - numberOfDaysToRevert);
                let firstAsDayOfWeek = callendarStartDate.getUTCDay();
                if (firstAsDayOfWeek === 0) {
                    firstAsDayOfWeek = 7;
                }
                callendarStartDate.setDate(callendarStartDate.getDate() - (firstAsDayOfWeek - 1));
                let date = callendarStartDate;

                for (let i = 0; i <= callendarCells.length - 1; i++) {
                    if ((date.getDate() === today.getDate()) && (date.getUTCMonth() === today.getUTCMonth())) {

                        $(callendarCells[i]).attr("id", "today");
                        let elem = document.createElement("strong");
                        let txt = document.createTextNode(date.getDate());
                        elem.appendChild(txt);
                        $(callendarCells[i]).append(elem);

                    } else if (date.getUTCMonth() !== today.getUTCMonth()) {
                        $(callendarCells[i]).addClass("mutedDays");
                        $(callendarCells[i]).text(date.getDate());

                    } else {
                        $(callendarCells[i]).text(date.getDate());
                    }
                    date.setDate(date.getDate() + 1);
                }
            })();
        })();
    }

    $(document).ready(function () {
        $('.dropdown-submenu a.submenuSwitch').click(function (e) {
            let toggleSwitch = true;

            $(this).next('ul').toggle(100);

            if (toggleSwitch) {
                $(this).css("font-weight", 700);
                $(this).css("color", "#797979");
                $(this).next('ul').css("background-color", "#808080");
                toggleSwitch = false;
            } else {
                $(this).css("font-weight", 400);
                $(this).css("color", "rgb(51, 51, 51)");
                $(this).next('ul').css("background-color", "white");
                toggleSwitch = true;
            }

            e.stopPropagation();
            e.preventDefault();
        })
    })

    $(document).ready(function () {
        let customColor = "#1F1C1C";
        let originalBackgroundColor = $(".dropdown-menu li a").css("background-color");
        let originalTextColor = $(".dropdown-menu li a").css("color");

        $(".dropdown-menu li a")
            .hover(
                function () {


                    $(this).css(`background-color`, customColor);
                    $(this).css("color", "#797979");
                },

                function () {

                    $(this).css(`background-color`, originalBackgroundColor);
                    $(this).css("color", originalTextColor);
                }
            )
    })


    return {
        visualizeCalendar,
    }
}

