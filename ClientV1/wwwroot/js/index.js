$(document).ready(function () {
    var jumlahGender = [];
    var labelGender = [];
    $.ajax({
        url: "https://localhost:44364/API/employees/GetGender",
        success: function (result) {
            var data = result.result.length;
            for (var i = 0; i < data; i++) {
                jumlahGender.push(result.result[i].jumlah);
                labelGender.push(result.result[i].gender);
            }
        }
    })

    var optionsGender = {
        chart: {
            type: 'donut'
        },
        series: jumlahGender,
        labels: labelGender
    }
    var chartGender = new ApexCharts(document.querySelector("#chartGender"), optionsGender);
    chartGender.render();

    var labelRole = [];
    var jumlahRole = [];
    $.ajax({
        url: "https://localhost:44364/API/employees/GetRole",
        success: function (result) {
            var data = result.result.length;
            for (var i = 0; i < data; i++) {
                jumlahRole.push(result.result[i].jumlah);
                labelRole.push(result.result[i].roleName);
            }
        }
    })

    var optionsRole = {
        series: jumlahRole,
        chart: {
            width: 380,
            type: 'pie',
        },
        labels: labelRole,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    var chartRole = new ApexCharts(document.querySelector("#chartRole"), optionsRole);
    chartRole.render();
});