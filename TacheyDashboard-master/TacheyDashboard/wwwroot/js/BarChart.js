//繪製Bar長條圖
function barChart(url, text, barChartDirection, context) {
    //if (!(barChartDirection == 'bar' || barChartDirection == 'horizontalBar')) {
    //    return;
    //}

    $.ajax({
        url: url,
        method: "POST",
        success: function (data) {
            var id = [];
            var amount = [];

            for (var i in data) {
                id.push(data[i].id);
                amount.push(data[i].amount);
            }

            var myChart = new Chart(context, {
                type: barChartDirection,
                data: {
                    labels: id,
                    datasets: [{
                        label: text,
                        data: amount,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        xAxes: [{
                            ticks: {
                                beginAtZero: true,
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                            }
                        }],
                    }
                }
            });

        },
        error: function (data) {
            console.log(data);
        }
    });


    
}