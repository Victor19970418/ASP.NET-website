//Pie Chart圓餅圖
var coursePieChart = document.getElementById('peiChart');
//var ctxGoughnut = document.getElementById('goughnutChart');

//var ctx1 = document.getElementById('verticalBar');

var orderLineChart = document.getElementById('OrderLineChart');
var memberLineChart = document.getElementById('MemberLineChart');

// 定義顏色
window.chartColors = {
    red: 'rgb(255, 99, 132)',
    pink: 'rgb(255,75,50)',
    yellow: 'rgb(255, 205, 86)',
    green: 'rgb(75, 192, 192)',
    blue: 'rgb(54, 162, 235)',
    purple: 'rgb(153, 102, 255)',
    grey: 'rgb(201, 203, 207)',
    orange: 'rgb(255, 159, 64)',
    cornsilk: 'rgb(255, 248, 220)',
    mistyRose: 'rgb(255, 228, 225)',
    paleGreen1: 'rgb(154, 255, 154)',
    cornflowerBlue: 'rgb(100, 149, 237)',
    lightGoldenrod1: 'rgb(255, 236, 139)',
    hotPink: 'rgb(255, 105, 180)',
    slateGray1: 'rgb(198, 226, 255)',
    lightGreen: 'rgb(144, 238, 144)',
    darkOrchid4: 'rgb(104, 34, 139)',
    peachPuff2: 'rgb(238, 203, 173)',
};

//定義Enums列舉
const barDirection = {
    vertial: 'bar',
    horizontal: 'horizontalBar'
};

pieChart('Home/CourseTypesDistribution', '開課種類分布', coursePieChart, 'pie');
//pieChart('Home/ClickPercentage', 'Click', ctxGoughnut, 'doughnut');
lineChart('Home/TotalSales', '訂單銷售統計圖', orderLineChart, '銷售數量');
lineChart('Home/MembersChart', '會員成長分布圖', memberLineChart, '會員數量');


$.ajax({
    url: 'Home/MonthTopFive',
    method: "POST",
    success: function (data) {
        //data[0].id
        //let list = [];
        //data.forEach(function (item, index, array) {
        //    list.push({ item: item.id },);
        //});
        //let test = Newtonsoft.Json.JsonConvert.SerializeObject(data);

        new Vue({
            el: '#app',
            data() {
                return {
                    items: [
                        { '排名': 1, '課程名稱': data[0].id, '銷售數': data[0].count },
                        { '排名': 2, '課程名稱': data[1].id, '銷售數': data[1].count },
                        { '排名': 3, '課程名稱': data[2].id, '銷售數': data[2].count },
                        { '排名': 4, '課程名稱': data[3].id, '銷售數': data[3].count },
                        { '排名': 5, '課程名稱': data[4].id, '銷售數': data[4].count }
                    ]
                }
            }
        })
    },
    error: function (data) {
        console.log(data);
    }
});

