$(document).ready(function () {

    //Gender
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

    //Role
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

    //Salary
    var chartRole = new ApexCharts(document.querySelector("#chartRole"), optionsRole);
    chartRole.render();

    var labelSalary = [];
    var jumlahSalary = [];
    $.ajax({
        url: "https://localhost:44364/API/employees/GetSalary",
        success: function (result) {
            var data = result.result.length;
            for (var i = 0; i < data; i++) {
                jumlahSalary.push(result.result[i].jumlah);
                labelSalary.push(result.result[i].label);
            }
        }
    })

    var optionsSalary = {
        series: [{
            data: jumlahSalary
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: true,
            }
        },
        dataLabels: {
            enabled: false
        },
        xaxis: {
            categories: labelSalary
        }
    };

    var chartSalary = new ApexCharts(document.querySelector("#chartSalary"), optionsSalary);
    chartSalary.render();

    var options = {
        series: [{
            name: "Salary",
            data: jumlahSalary
        }],
        chart: {
            height: 350,
            type: 'line',
            zoom: {
                enabled: false
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'straight'
        },
        title: {
            text: 'Product Trends by Month',
            align: 'left'
        },
        grid: {
            row: {
                colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.5
            },
        },
        xaxis: {
            categories: labelSalary,
        },
        theme: {
            palette: 'palette8' // upto palette10
        }
    };

    var chart = new ApexCharts(document.querySelector("#chartLine"), options);
    chart.render();
});