var regionID1 = '', pipelineID1 = '',assetOwnerID1 = '';
   
   $(document).ready(function () {

     

    LoadChart();
    LoadTable();


    LoadEvent();

    LoadRegionDropDownList($("#ddlRegion1"), '', '', '', '');
    LoadTypeOfPipelineDropDownList($("#ddlPipeline1"), '', '', '', '');
    LoadAssetOwnerDropDownList($("#ddlAssertOwner1"), '', '', '', '');

});




$(document).on('change', '#ddlRegion1', function (e) {


    regionID1 = $(this).val();
    LoadTypeOfPipelineDropDownList($("#ddlPipeline1"), regionID1, pipelineID1, assetOwnerID1, '');
    LoadAssetOwnerDropDownList($("#ddlAssertOwner1"), regionID1, pipelineID1, assetOwnerID1, '');

});


$(document).on('change', '#ddlPipeline1', function (e) {





    pipelineID1 = $(this).val();

    LoadRegionDropDownList($("#ddlRegion1"), regionID1, pipelineID1, assetOwnerID1, '');
    LoadAssetOwnerDropDownList($("#ddlAssertOwner1"), regionID1, pipelineID1, assetOwnerID1, '');

});

$(document).on('change', '#ddlAssertOwner1', function (e) {





    assetOwnerID1 = $(this).val();

    LoadRegionDropDownList($("#ddlRegion1"), regionID1, pipelineID1, assetOwnerID1, '');
    LoadTypeOfPipelineDropDownList($("#ddlPipeline1"), regionID1, pipelineID1, assetOwnerID1, '');

});




function LoadEvent() {




    $('.multiselect-ui').multiselect({
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        includeSelectAllOption: true,
        includeSelectAllDivider: true,
        maxHeight: 400,
        numberDisplayed: 1,
        onSelectAll: function () {
            console.log("select-all-nonreq");
        },
        onDeselectAll: function () {
            console.log("deselect-all-nonreq");
        }

    });


    



    $('[data-toggle="tooltip"]').tooltip({ html: true });


    $(".multiselect-ui").multiselect('selectAll', false);
    $(".multiselect-ui").multiselect('updateButtonText');

  
    

}


$(document).on('click', '.btnSearchGraph', function (e) {

    LoadChart();
});

function LoadChart()
{

   
  //  waitingDialog.show('LOADING', { dialogSize: 'lg', progressType: 'primary' });

   
 var formData = new FormData();
 formData.append("Action", "GetProgressPlan");
 formData.append("Year", $(".ddlYear1").val() == 0 ? currentYear : $(".ddlYear1").val());
  //  formData.append("PID", PID);



    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)



            if (obj != null) {



           /*     obj= [{
                    type: "stackedColumn100",
                    name: "รอดำเนินการ",
                    showInLegend: "true",
                    yValueFormatString: "#0'%'",

                    dataPoints: [
			{ y: 20, label: "Region 1" },
			{ y: 10, label: "Region 2" },
		
			{ y: 10, label: "Region 12" }
		]
                },
	{
	    type: "stackedColumn100",
	    name: "เลื่อแผน",
	    showInLegend: "true",
	    yValueFormatString: "#0'%'",
	    dataPoints: [
			{ y: 2, label: "Region 1" },
			{ y: 4, label: "Region 2" }
			
		]
	}
    ,
	{
	    type: "stackedColumn100",
	    name: "เสร็จ",
	    showInLegend: "true",
	    yValueFormatString: "#0'%'",
	    dataPoints: [
        { y: 1, label: "Region 2" },
			{ y: 5, label: "Region 1" },
			
			{ y: 12, label: "Region 3" }

		]
	}
     
    ]*/




                CanvasJS.addColorSet("greenShades",
                [//colorSet Array

              "#3e97f7", // blue
               "#67bb7a", // green
            "#eceb97",
           
            "#dc616d"
                ]);


                //Better to construct options first and then pass it as a parameter
                var options = {
                    animationEnabled: true,
                    colorSet: "greenShades",
                    title: {
                        text: ""
                    },

                    axisY: {

                        interval: 10,
                        maximum: 100,

                        suffix: "%"

                    },
                    legend: {
                        reversed: true,
                        interval: 10,
                        verticalAlign: "bottom",
                        horizontalAlign: "bottom"
                    },
                    toolTip: {
                        shared: true,
                        reversed: true
                    },
                    data: obj
                };

                $("#myBarChart").CanvasJSChart(options);

            }


         

        }
    });

}


