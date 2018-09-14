

window.onload = function () {

  //  LoadChart();
  //  LoadTable();



}

function compareDataPointX(dataPoint1, dataPoint2) {
    return dataPoint1.x - dataPoint2.x;
}

function LoadOverAllChart(dataList) {

    var options = {
        animationEnabled: true,
        exportEnabled: true,
        exportFileName:"OverAllChart",
	title:{
		text: "ความครบถ้วนการดำเนินงาน",
		horizontalAlign: "left"

	},
       
        data: dataList
    };

    summaryChart = new CanvasJS.Chart("graphOverAllChart", options);

    summaryChart.render();



}



function LoadRiskBeforeChart(dataList) {

    var options = {

        animationEnabled: true,
        exportEnabled: true,
        exportFileName: "BeforRiskChart",
	title:{
		text: "ผลการประเมินความเสี่ยง",
		horizontalAlign: "left"

	},
      
        data: dataList
    };

    risk1Chart = new CanvasJS.Chart("graphRiskBeforeChart", options);

    risk1Chart.render();

  

}

function LoadCoatingTypeChart(dataList) {

    var options = {

        animationEnabled: true,
        exportEnabled: true,
        exportFileName: "CoatingDefectChart",
        title: {
            text: "Coating Defect Type",
            horizontalAlign: "left"

        },

        data: dataList
    };

    coatingTypeChart = new CanvasJS.Chart("graphCoatingTypeChart", options);

    coatingTypeChart.render();

  


}


function LoadRiskAfterChart(dataList) {

    var options = {

        animationEnabled: true,
        exportFileName: "AfterRiskChart",
        exportEnabled: true,
        title: {
            text: "ผลการประเมินความเสี่ยง",
            horizontalAlign: "left"

        },

        data: dataList
    };

    risk2Chart = new CanvasJS.Chart("graphRiskAfterChart", options);

    risk2Chart.render();

  

}


function LoadPipelineTypeChart(dataList) {

    var options = {

        animationEnabled: true,
        exportEnabled: true,
        exportFileName: "PipelineDefectChart",
        title: {
            text: "Pipeline Defect Type",
            horizontalAlign: "left"

        },

        data: dataList
    };

    piplineTypeChart = new CanvasJS.Chart("graphPipelineTypeChart", options);

    piplineTypeChart.render();

  


}
