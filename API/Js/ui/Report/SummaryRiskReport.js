

window.onload = function () {

  //  LoadChart();
  //  LoadTable();



}

function compareDataPointX(dataPoint1, dataPoint2) {
    return dataPoint1.x - dataPoint2.x;
}

function LoadChart(sumaryPlanlist) {



    CanvasJS.addColorSet("greenShades",
            [//colorSet Array
            "#66b3ff",
          "#ffc107",
      "#dc3545"
            ]);

    //Better to construct options first and then pass it as a parameter
    var options = {
        animationEnabled: true,
        colorSet: "greenShades",
        exportEnabled: true,
        exportFileName: "SummaryRiskReport",
      //  width: 1200, //in pixels
       // height: 450, //in pixels
        title: {
            text: ""
        },

    axisY: {
		title: "จำนวนลูก",
		prefix: " "
	}
    ,
       
        legend: {
           /* reversed: true,
            interval: 10,*/
            verticalAlign: "bottom",
            horizontalAlign: "bottom"
        },
        toolTip: {
            shared: true,
            reversed: true
        },
        data: sumaryPlanlist
    };

chart = new CanvasJS.Chart("myBarChart", options);
//chart.options.data[0].dataPoints.sort(compareDataPointX);

chart.render();



}