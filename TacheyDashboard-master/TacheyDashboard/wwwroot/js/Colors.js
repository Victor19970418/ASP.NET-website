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


var colors = [];
colors[0] = 'red';
colors[1] = 'LightPink';
colors[2] = 'yellow';
colors[3] = 'green';
colors[4] = 'blue';
colors[5] = 'purple';
colors[6] = 'Aqua';
colors[7] = 'DarkTurquoise';
colors[8] = 'Gold';
colors[9] = 'LightCoral';
colors[10] = 'MediumAquaMarine';
colors[11] = 'MintCream';
colors[12] = 'orange';
colors[13] = 'cornsilk';
colors[14] = 'mistyRose';
colors[15] = 'paleGreen1';
colors[16] = 'cornflowerBlue';
colors[17] = 'lightGoldenrod1';
colors[18] = 'hotPink';
colors[19] = 'slateGray1';
colors[20] = 'lightGreen';
colors[21] = 'darkOrchid4';
colors[22] = 'peachPuff2';


function getRandomColor() {
    var index = Math.floor(Math.random() * 13);

    return colors[index];
}