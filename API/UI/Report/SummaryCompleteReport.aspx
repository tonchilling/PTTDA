﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SummaryCompleteReport.aspx.cs" Inherits="UI_Report_SummaryCompleteReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="<%= ResolveUrl("~/Css/stickytable/jquery.stickytable.min.css") %>">
 <script src="<%=ResolveUrl("~/Js/stickytable/jquery.stickytable.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/js/chart/Chart.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ExportToCSVFile.js") %>" type="text/javascript"></script>
   
     <script language="javascript">

         var currentURL = "<%= ResolveUrl("~/ASHX/Report/ReportMHandler.ashx") %>"; 
            var exportPlan= "<%= ResolveUrl("~/UI/Report/MReport.aspx?v=223") %>"; 
     var chart=null;

       var regionID = '', pipelineID = '', assetOwnerID = '', routeCodeID = '';

    $(document).ready(function () {
    // MergeRow2($('.tblSummary'));
    //  MergeRow2($('.tbl2'));

     LoadDropDownList($('.ddlYear'), "M_Year", currentYear);
    LoadDropDownList($('.ddlQuarter'), "M_Quarter");
     
      LoadDropDownList($('.ddlDIGFrom'), "M_DIGFrom");
    

      LoadRegionDropDownList($(".ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
         LoadRouteCodeDropDownList($(".ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);

    LoadTypeOfPipelineDropDownList($(".ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
   LoadAssetOwnerDropDownList($(".ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);


              $('.btnExport').on("click",function(e){


                     ExportFile("1");


                           //    exportTableToCSV($('.dataTable'), 'SummaryCompleteReport.csv');

                });



});



    $(document).on('click', '.btnViewTab1', function (e) {

  
   ViewSummaryReport();
  // ViewChart();
  
});


  $(document).on('change', '.ddlRegion', function (e) {

            AssignDropDownToData();
            regionID = $(this).val();
            LoadTypeOfPipelineDropDownList($(".ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($(".ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($(".ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);

        });


          $(document).on('change', '.ddlRouteCode', function (e) {

           
            AssignDropDownToData();
            routeCodeID = $(this).val();

            LoadRegionDropDownList($(".ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadTypeOfPipelineDropDownList($(".ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($(".ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
        });



        $(document).on('change', '.ddlAssertOwner', function (e) {

            AssignDropDownToData();
            assetOwnerID = $(this).val();
            LoadRegionDropDownList($(".ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadTypeOfPipelineDropDownList($(".ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($(".ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);
        });



        $(document).on('change', '.ddlPipeline', function (e) {

         

            AssignDropDownToData();

            pipelineID = $(this).val();

            LoadRegionDropDownList($(".ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($(".ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($(".ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);

           
        });


        function ExportFile(reportNo) {
            
            var param = "";
            var formData = new FormData();

            formData.append("Action", "ExportSummaryPlan");

            formData.append("AssetOwnerID", $('.ddlAssertOwner').val());
            formData.append("RegionID", $('.ddlRegion').val());
            formData.append("RouteCodeID", $('.ddlRouteCode').val());
            formData.append("Year", $('.ddlYear').val());


            waitingDialog.show('Exporting -  Summary Complete Report', { dialogSize: 'lg', progressType: 'light' });



            param = param + "&AssetOwnerID=" + $('.ddlAssertOwner').val();
            param = param + "&RegionID=" + $('.ddlRegion').val();
            param = param + "&RouteCodeID=" + $('.ddlRouteCode').val();
            param = param + "&Year=" + $('.ddlYear').val();

            setTimeout(function () {

                waitingDialog.hide();
            }, 3000);

            window.open(exportPlan + "&RPTType=report1_summarycomplete" + param, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=5,height=5");


        }



function ExportFileAsCSV(reportNo)
  {
  


   var html = '';
    var formData = new FormData();

   var exportType="";
   var fileName="";

 exportType="temp";
    fileName="SummaryCompleteReport";


    waitingDialog.show('EXPORTING', {dialogSize: 'lg', progressType: 'primary'});

     /*  exportCSVFile(fileName, reportObject, fileName); */

    

    exportTableToCSV($('.divSummaryPlan>table'), fileName);


                    setTimeout(function () { waitingDialog.hide(); }, 1000);

    }


  function AssignDropDownToData(tregionID, tassetOwnerID, tpipelineID, trouteCodeID) {
            regionID = (tregionID != null ? tregionID : $(".ddlRegion").val());
            assetOwnerID = (tassetOwnerID != null ? tassetOwnerID : $(".ddlAssertOwner").val());
          //  pipelineID = (tpipelineID != null ? tpipelineID : $(".ddlPipeline").val());
            routeCodeID = (trouteCodeID != null ? trouteCodeID : $(".ddlRouteCode").val());
        }



function ViewChart()
  {
  
 

          var html = '';
 var formData = new FormData();
 formData.append("Action", "SumCompletelyReport");
 formData.append("AssetOwnerID", $('.ddlAssertOwner').val());
 formData.append("Quarter", $('.ddlQuarter').val());
 formData.append("RouteCodeID", $('.ddlRouteCode').val());
      
     formData.append("Year", $('.ddlYear').val());

  

   


    

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
         var obj = JSON.parse(result)

        
        LoadChart(obj.GraphReport);
        
       
        }
        });
}



 function ViewSummaryReport()
  {
      
 var formData = new FormData();
   
 formData.append("Action", "SumCompletelyReport");

 formData.append("AssetOwnerID", $('.ddlAssertOwner').val());
      formData.append("RegionID", $('.ddlRegion').val());
        formData.append("DIGFromID", $('.ddlDIGFrom').val());
         formData.append("PipelineLengthID", $('.ddlPipeline').val());
           formData.append("RouteID", $('.ddlRouteCode').val());
     formData.append("Year", $('.ddlYear').val());
  

     waitingDialog.show('LOADING -  Summary  Report', {dialogSize: 'lg', progressType: 'light'});

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

         var obj = JSON.parse(result)

         if(obj!=null && obj.GraphReport!=null)
         {
       LoadChart(obj.GraphReport);
       }
        if(obj!=null && obj.TableReport!=null)
         {

         reportObject=obj.TableReport;
         LoadTable(obj.SumaryCompletelyByRegionTable)
       }
         setTimeout(function () { waitingDialog.hide(); }, 1000);
        },
         error: function(data) {
          alert("error");
        }

});

  
  }


  function LoadTable(objList)
  {
   var html = '';
     $('.divSummaryPlan').empty();

       html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
         html+= '<thead>';

            html+= '<tr class="bg-primary">';
          
            html += '<th>Region</th>';
            html += '<th> PM<br> Transmission</th>';
            html += '<th>Estimate<br>this year</th>';
            html += '<th> Postpone to <br>this year</th>';
              html+= '<th>Q1</th>';
              html += '<th > Q2</th>';
              html+= '<th>Q3</th>';
                html+= '<th> Q4</th>';
              html+= '</tr>';
             html+= '</thead>';

             html += '<tbody>';

           
              $.each(objList, function( index, item ) {

                  html += '<tr >';


                
                  html+= '<td  class="bg-success">'+item.RegionName+'</td>';
                  html += '<td>' + (IsNull(item.Actual) == '' ? '' : IsNull(item.Actual)+'%') + '</td>';
                  html += '<td>' + (IsNull(item.Plan) == '' ? '' : IsNull(item.Plan)+'%')  + '</td>';
                  html += '<td>' + (IsNull(item.PostPone) == '' ? '' : IsNull(item.PostPone)+'%') + '</td>';
                  html += '<td>'  + (IsNull(item.Q1) == '' ? '' : IsNull(item.Q1)+'%')  + '</td>';
                  html += '<td>' + (IsNull(item.Q2) == '' ? '' : IsNull(item.Q2)+'%')  + '</td>';
                  html += '<td>'+ (IsNull(item.Q3) == '' ? '' : IsNull(item.Q3)+'%')  + '</td>';
                  html += '<td>' + (IsNull(item.Q4) == '' ? '' : IsNull(item.Q4)+'%')   + '</td>';
     
                     html+= '</tr>';
              });
                  html += '</tbody>';
                html+= '</table>';

                 $('.divSummaryPlan').append(html);

                 $('.divSummaryPlan table').DataTable({

             
                searching: false

            });


  }



  
function compareDataPointX(dataPoint1, dataPoint2) {
    return dataPoint1.x - dataPoint2.x;
}

function LoadChart(sumaryPlanlist) {



    //alert('LoadChart')
    CanvasJS.addColorSet("greenShades",
                [//colorSet Array
                "#28a745",
                  
              "#007bff",
          "#ffc107",
            "#dc3545",
            "#000"
                ]);




    //Better to construct options first and then pass it as a parameter
    var options = {
        animationEnabled: true,
     colorSet: "greenShades",
        width: 1200, //in pixels
        height: 450, //in pixels
        title: {
            text: ""
        },

        axisY: {

            interval: 10,
              minimum: 10,
            maximum: 100,
            suffix: "%"

        },
        axisX:{
         minimum: 10,
        },

       
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
chart.options.data[0].dataPoints.sort(compareDataPointX);

chart.render();



}



   </script>



<style type="text/css">
.sticky-table table td.sticky-cell, .sticky-table table th.sticky-cell
    {
    	background-color: #ffffff;
    	outline: 1px solid #ddd;position: relative;z-index: 10;}
    	
    	
    	    	.tblSummary tr.collapse
    	{
    		background-color: #ffffff;
    
    		
    		}
    		
 
    		
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->
<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" ></i>  Summary Plan Report </div>
     <div class="card-body">

   

    <div class="row">
      <div class="col-sm-12">
     <div class="login-signup">
      <div class="row">
        <div class="col-sm-12 nav-tab-holder">
        <ul class="nav nav-tabs row" role="tablist">
          <li role="presentation" class=" col-sm-2"><a  href="<%= ResolveUrl("~/UI/Report/SummaryOverAllProgressReport.aspx") %>">Overall progress</a></li>
          <li role="presentation" class="active col-sm-2"><a  href="#CreatingPlan" aria-controls="home" role="tab" data-toggle="tab">ความครบถ้วนของการดำเนินงาน </a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Report/SummaryRiskReport.aspx") %>"  >ผลการประเมินความเสี่ยง</a></li>
          
        </ul>
      </div>

      </div>


         <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
     <div class="row">
          <div class="col-sm-12">
          
          <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-search " ></i> ตัวกรองข้อมูล 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
           
           </div>
           </div>
          </div>
        <div class="card-body card-body2">

         <div class="row">
          <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Year :</span>
                            <select class="form-control ddlYear" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div> 
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span6">Asset Owner:</span>
                            <select class="form-control ddlAssertOwner" data-val="true" data-val-number="The field Asset Owner must be a number." data-val-required="The Asset Owner field is required." id="ddlAssertOwner" name="ddlAssertOwner">

</select>
   

</div>
          </div>
             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span4">Region :</span>
   <select name="ddlRegion" class="form-control ddlRegion" id="Select1" data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
<option value="1">Region1</option>
<option value="2">Region2</option>
<option value="3">Region3</option>
<option value="4">Region4</option>
<option value="5">Region5</option>
<option value="6">Region6</option>
<option value="7">Region7</option>
<option value="8">Region8</option>
<option value="9">Region9</option>
<option value="10">Region10</option>
<option value="11">Region11</option>
</select>


</div>
          </div>
           <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab1" >VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExport">EXPORT</button>
          </div>

        </div>


      
          <div class="row" style="padding-top:10px;">


            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span1">Route Code :</span>
        <select class="form-control routecode-list ddlRouteCode" id="ddlRouteCode" name="ddlRouteCode"><option value="0">ทั้งหมด</option>
<option value="RC0200">RC0200</option>
<option value="RC0200101">RC0200101</option>
<option value="RC020100">RC020100</option>
<option value="RC0210">RC0210</option>
<option value="RC0250">RC0250</option>
<option value="RC0260">RC0260</option>
<option value="RC032010">RC032010</option>
<option value="RC033000">RC033000</option>
<option value="RC03301">RC03301</option>
<option value="RC033010">RC033010</option>


</select>



</div>
          </div>

     <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span22">License :</span>
        <select class="form-control ddlLicense" id="ddlLicense" name="ddlLicense">


</select>



</div>
          </div>
         
             
          

         
          </div>

      




       </div>
        </div>
        </div>
          </div>
    <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa fa-bar-chart " ></i> Graph View 
          </div>
          <div class="col-sm-1">
         
           </div>
         
           </div>
          </div>
        <div class="card-body card-body2">
       
             <div class="row" style="padding-top:10px;">
          <div class="col-sm-12">
          
           <div class="row ">

                <div class="col-sm-12 my-auto">
                  

                     <div class="card-body table-responsive" style="height: 480px;">
           <div class="row">

                <div class="col-sm-12">
                  

                  <div id="myBarChart" style="height: 370px; width: 100%;"></div>
                </div>
             </div>
             
             </div>
                </div>
             </div>
          
          </div>
          </div>

           <div class="row" style="padding-top:10px;">
          <div class="col-sm-12">
              <div class="divSummaryPlan table-responsive">
               <table  id="tblummaryPlan" class="table table-bordered tblummaryPlan">
              </table>
        </div>

          </div>
          </div>

          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
          </div>

</div>
   </div>

   </div>
   </div>
   </div>
   </div>
   </div>
   


<!--- Content --->


        </div>
  </div>
  </div>
  </div>
  </div>
  </div>

    <script src="<%= ResolveUrl("~/Js/chartNew/Chart.Canvas.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ui/Report/SummaryCompleteReport.js") %>"></script>
</asp:Content>

