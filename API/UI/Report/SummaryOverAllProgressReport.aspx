<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
 CodeFile="SummaryOverAllProgressReport.aspx.cs" Inherits="UI_Report_SummaryOverAllProgressReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="<%= ResolveUrl("~/Css/stickytable/jquery.stickytable.min.css") %>">
 <script src="<%=ResolveUrl("~/Js/stickytable/jquery.stickytable.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/js/chart/Chart.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ExportToCSVFile.js") %>" type="text/javascript"></script>
   
     <script language="javascript">

           var exportPlan= "<%= ResolveUrl("~/UI/Report/MReport.aspx?v=223") %>"; 
  var currentURL= "<%= ResolveUrl("~/ASHX/Report/ReportMHandler.ashx") %>"; 
     var chart=null;

     var summaryChart,risk1Chart,risk2Chart,coatingTypeChart,piplineTypeChart;
      var regionID = '', pipelineID = '', assetOwnerID = '', routeCodeID = '';

      var reportObject;
    $(document).ready(function () {
    // MergeRow2($('.tblSummary'));
    //  MergeRow2($('.tbl2'));

     LoadDropDownList($('.ddlYear'), "M_Year", currentYear);
     
     LoadAssetOwnerDropDownList($(".ddlAssetOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);

              $('.btnExport').on("click",function(e){


                  ExportFile("1");
               //  exportTableToCSV($('.dataTable'), 'OverallProgressReport.csv');
                   //   ExportFile("1");

                });



});



    $(document).on('click', '.btnViewTab1', function (e) {

  
   ViewSummaryReport();
  // ViewChart();
  
});





function ExportFile(reportNo)
  {
  

    var param = "";
    var formData = new FormData();

    formData.append("Action", "ExportSummaryPlan");

    formData.append("AssetOwnerID", $('.ddlAssetOwner').val());
    formData.append("STMonth", $('.ddlFrom').val());
    formData.append("ENMonth", $('.ddlTo').val());
    formData.append("Year", $('.ddlYear').val());


   waitingDialog.show('Exporting -  Over All Report', { dialogSize: 'lg', progressType: 'light' });



    param = param + "&AssetOwnerID=" + $('.ddlAssetOwner').val();
    param = param + "&STMonth=" + $('.ddlFrom').val();
    param = param + "&ENMonth=" + $('.ddlTo').val();
    param = param + "&Year=" + $('.ddlYear').val();

    setTimeout(function () {
      
        waitingDialog.hide();
    }, 3000);

    window.open(exportPlan + "&RPTType=report1_overallprogress" + param, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=5,height=5");
 
   
   
     
  }




 function ViewSummaryReport()
  {
      
 var formData = new FormData();
   
     formData.append("Action", "SumOverAllReport");

     formData.append("AssetOwnerID", $('.ddlAssetOwner').val());
      formData.append("STMonth", $('.ddlFrom').val());
        formData.append("ENMonth", $('.ddlTo').val());
     formData.append("Year", $('.ddlYear').val());
  

     waitingDialog.show('Exporting to Excel', { dialogSize: 'lg', progressType: 'light' });

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

         var obj = JSON.parse(result)

         if(obj!=null && obj.DonutGraphRiskBeforeReport!=null)
         {
       LoadOverAllChart(obj.DonutGraphReport);
       LoadRiskBeforeChart(obj.DonutGraphRiskBeforeReport);
         LoadCoatingTypeChart(obj.DonutGraphCoatingTypeReport);
         LoadRiskAfterChart(obj.DonutGraphRiskAfterReport);
             LoadPipelineTypeChart(obj.DonutGraphPipelineTypeReport);
       }
        if(obj!=null && obj.OverAllTableReport!=null)
         {

         reportObject=obj.OverAllTableReport;
       LoadTable(obj.OverAllTableReport)
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

     /* public string PID { get; set; }
      public string AssetOwner { get; set; }
      public string InspectionDate { get; set; }
      public string RouteCode { get; set; }
      public string RouteCodeName { get; set; }
      public string Section { get; set; }
      public string KP { get; set; }
      public string RegionCode { get; set; }
      public string RegionName { get; set; }
      public string DigFrom { get; set; }
      public string PlanDate { get; set; }
      public string CoatingDefectType { get; set; }
      public string CoatingServerity { get; set; }
      public string PipelineDefectType { get; set; }
      public string PipelineServerity { get; set; }
      							Coating Inspection Result		Pipeline Inspection Result		
Customer type	Inspection date	Route code	Section	KP.	Region	Dig form	Defect type	 severity	Defect type	Pipeline severity	Status

      */
   var html = '';
     $('.divSummaryPlan').empty();

       html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
         html+= '<thead>';
         html += '<tr class="bg-primary">';
         html += '<th colspan="7"></th>';
         html += '<th colspan="2" class="text-center">Coating Inspection Result</th>';
         html += '<th colspan="2" class="text-center">Pipeline Inspection Result</th>';
         html += '<th colspan="1"></th>';
         html += '</tr>';
            html+= '<tr class="bg-primary">';
               html+= '<th>AssetOwner</th>';
            html+= '<th>Inspection Date</th>';
             html+= '<th>Route Code</th>';
              html+= '<th>Section</th>';
                html+= '<th>KP</th>';
                html += '<th>Region</th>';
                html += '<th>Dig From</th>';
                html += '<th>Defect Type</th>';
                html += '<th>Serverity</th>';
                html += '<th>Defect Type</th>';
                html += '<th>Serverity</th>';
                html += '<th>Status</th>';
              html+= '</tr>';
             html+= '</thead>';

              html += '<tbody>';
              $.each(objList, function( index, item ) {


    
               html+= '<tr >';
               html += '<td>' + item.AssetOwner + '</td>';
               html += '<td>' + item.InspectionDate + '</td>';
               html += '<td>' + item.RouteCodeName + '</td>';
               html += '<td>' + item.Section + '</td>';
               html += '<td>' + item.KP + '</td>';
               html += '<td>' + item.RegionName + '</td>';
               html += '<td>' + item.DigFrom + '</td>';
               html += '<td>' + item.CoatingDefectType + '</td>';
               html += '<td>' + item.CoatingServerity + '</td>';
               html += '<td>' + item.PipelineDefectType + '</td>';
               html += '<td>' + item.PipelineServerity + '</td>';
               html += '<td>' + item.Status + '</td>';
                     html+= '</tr>';
              });
                  html += '</tbody>';
                html+= '</table>';

                 $('.divSummaryPlan').append(html);

                 $('.divSummaryPlan table').DataTable({
                  "order": [[ 1, "asc" ]],
             
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
          <li role="presentation" class="active col-sm-2"><a aria-controls="home" role="tab" data-toggle="tab" >Overall progress</a></li>
          <li role="presentation" class=" col-sm-2"><a  href="<%= ResolveUrl("~/UI/Report/SummaryCompleteReport.aspx") %>" >ความครบถ้วนของการดำเนินงาน </a></li>
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
  <span class="input-group-addon" id="Span2">Year :</span>
                            <select class="form-control ddlYear" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>
               <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Month :</span>
     <select class="form-control ddlFrom" data-val="true" data-val-number="The field FromMonth must be a number." data-val-required="The FromMonth field is required." id="FromMonth" name="FromMonth"><option selected="selected" value="1">ม.ค.</option>
<option value="2">ก.พ.</option>
<option value="3">มี.ค.</option>
<option value="4">เม.ย.</option>
<option value="5">พ.ค.</option>
<option value="6">มิ.ย.</option>
<option value="7">ก.ค.</option>
<option value="8">ส.ค.</option>
<option value="9">ก.ย.</option>
<option value="10">ต.ค.</option>
<option value="11">พ.ย.</option>
<option value="12">ธ.ค.</option>
</select>


</div>
          </div>
               <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span4">To :</span>
       <select class="form-control ddlTo" data-val="true" data-val-number="The field ToMonth must be a number." data-val-required="The ToMonth field is required." id="ToMonth" name="ToMonth"><option value="1">ม.ค.</option>
<option value="2">ก.พ.</option>
<option value="3">มี.ค.</option>
<option value="4">เม.ย.</option>
<option value="5">พ.ค.</option>
<option value="6">มิ.ย.</option>
<option value="7">ก.ค.</option>
<option value="8">ส.ค.</option>
<option value="9">ก.ย.</option>
<option value="10">ต.ค.</option>
<option value="11">พ.ย.</option>
<option selected="selected" value="12">ธ.ค.</option>
</select>


</div>
          </div>
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span1">Asset Owner :</span>
                            <select class="form-control ddlAssetOwner" data-val="true" data-val-number="The field AssetOwner must be a number." data-val-required="The AssetOwner field is required." id="ddlAssetOwner" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>
<option value="37">PTT</option>
<option value="38">NGR</option>
<option value="39">NGV</option>
<option value="40">TREASURY DEPT.</option>
<option value="41">-</option>
</select>
   

</div>
          </div>
           <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab1" >VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExport">EXPORT</button>
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
                  

                     <div class="card-body table-responsive" >
           <div class="row"  style="padding-top:20px;">
             <div class="col-sm-3"></div>
                <div class="col-sm-6">
                  

                  <div id="graphOverAllChart"  class="card" style="height: 370px; width: 100%;"></div>
                </div>
             
             </div>
             <div class="row" style="padding-top:20px;">
                <div class="col-sm-6">
                  

                  <div id="graphRiskBeforeChart" class="card"  style="height: 370px; width: 100%;"></div>
                </div>

                  <div class="col-sm-6">
                  

                  <div id="graphCoatingTypeChart" class="card"  style="height: 370px; width: 100%;"></div>
                </div>
             </div>
             <div class="row" style="padding-top:20px;">
                <div class="col-sm-6">
                  

                  <div id="graphRiskAfterChart" class="card"  style="height: 370px; width: 100%;"></div>
                </div>

                  <div class="col-sm-6">
                  

                  <div id="graphPipelineTypeChart" class="card"  style="height: 370px; width: 100%;"></div>
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
    <script src="<%= ResolveUrl("~/Js/ui/Report/SummaryOverAllProgressReport.js") %>"></script>
</asp:Content>

