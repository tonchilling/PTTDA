

window.onload = function () {

  //  LoadChart();
  //  LoadTable();



}

function compareDataPointX(dataPoint1, dataPoint2) {
    return dataPoint1.x - dataPoint2.x;
}

function LoadChart(sumaryPlanlist) {





    //Better to construct options first and then pass it as a parameter
    var options = {
        animationEnabled: true,
        exportEnabled: true,
        exportFileName: "SummaryRepaireReport",
      //  width: 1200, //in pixels
       // height: 450, //in pixels
        title: {
            text: "Summary Repair Report",
            horizontalAlign: "left"
        }
    ,

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