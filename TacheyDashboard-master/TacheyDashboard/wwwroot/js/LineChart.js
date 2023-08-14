function lineChart(url, text, ctxx, label) {
    $.ajax({
        url: url,
        method: "POST",
        success: function (data) {
            var id = [];
            var amount = [];

            for (var i in data) {
                id.push(data[i].date);
                amount.push(data[i].count);
            }

            var chart = new Chart(ctxx, {
                type: 'line',
                data: {
                    labels: id,
                    datasets: [{
                        //label: label,
                        data: amount,
                        fill: false,
                        backgroundColor: 'rgba(255,165,0,0.3)',
                        borderColor: 'rgb(255,165,0)',
                        pointStyle: "circle",
                        pointBackgroundColor: 'rgb(0,255,0)',
                        pointRadius: 5,
                        pointHoverRadius: 10
                    }]
                },
                options: {
                    responsive: true,
                    //title: {
                    //    display: true,
                    //    fontSize: 26,
                    //    text: text
                    //},
                    tooltips: {
                        mode: 'point',
                        intersect: true,
                    },
                    hover: {
                        mode: 'nearest',
                        intersect: true
                    },
                    scales: {
                        xAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: '',
                                fontSize: 20
                            },
                            ticks: {
                                fontSize: 10
                            }
                        }],
                        yAxes: [{
                            display: true,
                            //scaleLabel: {
                            //    display: true,
                            //    labelString: '數量',
                            //    fontSize: 20
                            //},
                            ticks: {
                                fontSize: 12,
                                beginAtZero: true,
                                steps: 10,
                                stepValue: 5,
                            }
                        }],
                        maintainAspectRatio: false,
                    },
                    animation: {
                        duration: 3000
                    },
                    legend: {
                        display: false //This will do the task
                    }
                }
            });
        },
        error: function (data) {
        }
    });
}