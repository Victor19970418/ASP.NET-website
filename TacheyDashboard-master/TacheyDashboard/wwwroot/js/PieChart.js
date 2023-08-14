function pieChart(url, text, ctx, type='pie') {
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

            var pieChart = new Chart(ctx, {
                type: type,
                data: {
                    labels: id,
                    datasets: [{
                        data: amount,
                        backgroundColor: [
                            window.chartColors.red,
                            window.chartColors.blue,
                            window.chartColors.orange,
                            window.chartColors.yellow,
                            window.chartColors.green,
                            window.chartColors.purple,
                            window.chartColors.hotPink,
                            window.chartColors.lightGreen,
                            window.chartColors.darkOrchid4,
                            window.chartColors.peachPuff2,
                            window.chartColors.mistyRose,
                            window.chartColors.lightGoldenrod1
                        ]
                    }],
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
                    legend: {
                        position: 'top',
                        labels: {
                            fontColor: 'black',
                        }
                    },
                    Radius: 500
                }
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
}