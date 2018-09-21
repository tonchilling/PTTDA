<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SummaryRepairReport.aspx.cs" Inherits="UI_Master_SummaryRepairReport" %>

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

              //  exportTableToCSV($('.tblSummary'), 'SummaryRepairReport.csv');

                      ExportFile("1");

                });



    });


    function ExportFile(reportNo) {
        var param = "";
        waitingDialog.show('Exporting to Excel', { dialogSize: 'lg', progressType: 'light' });
        
        param = param + "&AssertOwnerID=" + $('.ddlAssertOwner').val();
        param = param + "&RegionID=" + $('.ddlRegion').val();
        param = param + "&RouteID=" + $('.ddlRouteCode').val();
        param = param + "&Year=" + $('.ddlYear').val();
        param = param + "&DIGFromID=" + $('.ddlDIGFrom').val();
        param = param + "&PipelineLengthID=" + $('.ddlPipeline').val();

        setTimeout(function () {

            waitingDialog.hide();
        }, 3000);

        window.open(exportPlan + "&RPTType=report2_summaryrepaire" + param, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=5,height=5");

    }



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



  function AssignDropDownToData(tregionID, tassetOwnerID, tpipelineID, trouteCodeID) {
            regionID = (tregionID != null ? tregionID : $(".ddlRegion").val());
            assetOwnerID = (tassetOwnerID != null ? tassetOwnerID : $(".ddlAssertOwner").val());
          //  pipelineID = (tpipelineID != null ? tpipelineID : $(".ddlPipeline").val());
            routeCodeID = (trouteCodeID != null ? trouteCodeID : $(".ddlRouteCode").val());
        }



    $(document).on('click', '.btnViewTab1', function (e) {

  
   ViewSummaryRepairReport();
  // ViewChart();
  
});




function ViewChart()
  {
  
 

          var html = '';
 var formData = new FormData();
    formData.append("Action", "SUMRReport");
    formData.append("AssertID", $('.ddlAssertOwner').val());
      formData.append("Quarter", $('.ddlQuarter').val());

     formData.append("Year", $('.ddlYear').val());

  

   

    var html='';

    

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
         var obj = JSON.parse(result)
        LoadChart(obj);
       
        }
        });
}



 function ViewSummaryRepairReport()
  {
       var html = '';
 var formData = new FormData();
    formData.append("Action", "SRReport");

    /*@RegionID nvarchar(50)='',
     @RouteID nvarchar(50)='',
     @Year nvarchar(4)='',
      @PipelineLengthID nvarchar(50)='',
      @AssertID nvarchar(50)='',
     @DIGFromID nvarchar(50)=''*/

     formData.append("AssertOwnerID", $('.ddlAssertOwner').val());
      formData.append("RegionID", $('.ddlRegion').val());
        formData.append("DIGFromID", $('.ddlDIGFrom').val());
         formData.append("PipelineLengthID", $('.ddlPipeline').val());
           formData.append("RouteID", $('.ddlRouteCode').val());
     formData.append("Year", $('.ddlYear').val());
  

     waitingDialog.show('LOADING -  Summary Repaire Report', {dialogSize: 'lg', progressType: 'light'});

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

        var pipelineAll = [];
         var assertOwnerAll = [];


         var searchPipeline="PipelineType";
          var searchAssertOwner="AssertOwner";


           var objAll = JSON.parse(result)

           var obj=objAll.Table;
           var objChart=objAll.Graph;
            $('.divSRR,.tbDetail').empty();
           // $('.divSRR').empty();
           LoadChart(objChart);
          var searchVal="";
          for (var i=0 ; i < obj.length ; i++)
             {
                
                if(searchVal=="")
                {
                 pipelineAll.push(obj[i][searchPipeline]);
                  searchVal=obj[i][searchPipeline];
                }
                else if (obj[i][searchPipeline] != searchVal) {
                   pipelineAll.push(obj[i][searchPipeline]);
                   searchVal=obj[i][searchPipeline];
              }
            }



        html+= '<table class="table table-bordered tblSummary"';
         html+= '<thead>';
           html+= '<tr class="sticky-row bg-primary">';
          html+= '<th class=" text-center "  colspan="8"></th>';
           html+= '<th class="text-center"  colspan="3">Coating Inspection Result</th>';
            html+= '<th class="text-center"  colspan="2">Pipeline Inspection Result</th>';
            html+= '<th></th>';
            html+= '</tr>';
            html+= '<tr class="sticky-row bg-primary">';
             html+= '<th class="sticky-cell text-center "> No.</th>';
              html+= '<th class=" text-center ">Region</th>';
               html+= '<th class=" text-center ">RC</th>';
               html+= '<th class=" text-center ">Pipeline Section</th>';
              html+= '<th class=" text-center ">KP</th>';
              html+= '<th class=" text-center ">Repair <br /> Length (m)</th>';
                html+= '<th class=" text-center ">Dig from</th>';
              html+= '<th class=" text-center ">Risk level</th>';
                html+= '<th class=" text-center ">type</th>';
                html+= '<th class=" text-center ">dmg type</th>';
                html+= '<th class=" text-center ">จำนวนจุด</th>';
               html+= '<th class=" text-center ">Damage type</th>';
               html+= '<th class=" text-center ">จำนวนจุด</th>';
             html+= '<th class=" text-center ">Note</th>';
              html+= '</tr>';
             html+= '</thead>';

             $.each(pipelineAll, function( index, pipelineType ) {
                 
                 var resultByPipelineList = $.grep(obj, function(e){ return e.PipelineType == pipelineType; });


              /*    dto.No,
            dto.Region,
            dto.RC,
            dto.PipelineSection,
            dto.KP,
            dto.RepairLength,
            dto.Digfrom,
            dto.RiskLevel,
            dto.CoatingType,
            dto.CoatingDMGType,
            dto.CoatingPoint,
            dto.PipelineDMGType,
            dto.PipelinePoint*/
            if(resultByPipelineList!=null)
            {

              html+= '<tr class="bg-success  accordion-toggle">';
              // html+= '<td colspan="14"><a class="detail-icon text-white" href="javascript:"><i class="glyphicon glyphicon-wrench fa-1x" aria-hidden="true"></i>&nbsp;'+pipelineType+'</a></td>'
               html+= '<td colspan="14"><a class="detail-icon text-white" href="javascript:">'+pipelineType+'</a></td>'
               html+= '</tr>';


               assertOwnerAll = [];
               searchVal="";
                for (var i=0 ; i < resultByPipelineList.length ; i++)
             {
                
                if(searchVal=="")
                {
                 assertOwnerAll.push(obj[i][searchAssertOwner]);
                  searchVal=obj[i][searchAssertOwner];
                }
                else if (obj[i][searchAssertOwner] != searchVal) {
                   assertOwnerAll.push(obj[i][searchAssertOwner]);
                   searchVal=obj[i][searchAssertOwner];
              }
            }

             $.each(assertOwnerAll, function( index, assertOwnerName ) {

             var resultByAssertOwnerList = $.grep(resultByPipelineList, function(e){ return e.AssertOwner == assertOwnerName; });


            
              if(resultByAssertOwnerList!=null)
            {
               html+= '<tr class="bgSubSuccess  accordion-toggle" data-toggle="collapse" data-target=".'+resultByPipelineList[0].PipelineID.replace('-','')+assertOwnerName.replace(' ','')+'" >';
              // html+= '<td colspan="14"><a class="detail-icon text-white" href="javascript:"><i class="glyphicon glyphicon-wrench fa-1x" aria-hidden="true"></i>&nbsp;'+pipelineType+'</a></td>'
               html+= '<td colspan="14"><a class="detail-icon text-white" href="javascript:">'+assertOwnerName+'</a></td>'
               html+= '</tr>';



               
              $.each(resultByAssertOwnerList, function( index, item ) {
                 html+= '<tr  class="collapse '+resultByPipelineList[0].PipelineID.replace('-','')+assertOwnerName.replace(' ','')+'">';
                   html+= '<td class="sticky-cell">'+item.No+'</td>';
                     html+= '<td>'+item.Region+'</td>';
                     html+= '<td>'+item.RC+'</td>';
                     html+= '<td>'+item.PipelineSection+'</td>';
                     html+= '<td>'+item.KP+'</td>';
                     html+= '<td>'+item.RepairLength+'</td>';
                     html+= '<td>'+item.Digfrom+'</td>';
                     html+= '<td>'+item.RiskLevel+'</td>';
                     html+= '<td>'+item.CoatingType+'</td>';
                     html+= '<td>'+item.CoatingDMGType+'</td>';
                     html+= '<td>'+item.CoatingPoint+'</td>';
                     html+= '<td>'+item.PipelineDMGType+'</td>';
                     html+= '<td>'+item.PipelinePoint+'</td>';
                     html+= '<td></td>';
                     html+= '</tr>';
                      });
                  }
                });
             }

               });


              html+= '</table>';

                 $('.divSRR').append(html);

               

                 MergeRow2($('.divSRR table'));

                    setTimeout(function () { waitingDialog.hide(); }, 1000);

         // alert(result);
        },
         error: function(data) {
          alert("error");
        }

});

  
  }



   function MergeCommonRows(table) {

 
    var firstColumnBrakes = [];
    // iterate through the columns instead of passing each column as function parameter:
    alert(table.find('th').length)
    for(var i=1; i<=table.find('th').length; i++){
        var previous = null, cellToExtend = null, rowspan = 1;
        table.find("td:nth-child(" + i + ")").each(function(index, e){
            var jthis = $(this), content = jthis.text();
            // check if current row "break" exist in the array. If not, then extend rowspan:
          
            if (previous == content && content !== "" && $.inArray(index, firstColumnBrakes) === -1) {
                // hide the row instead of remove(), so the DOM index won't "move" inside loop.
                jthis.addClass('hidden');
                
                cellToExtend.attr("rowspan", (rowspan = rowspan+1));
            }else{
                // store row breaks only for the first column:
                if(i === 1) firstColumnBrakes.push(index);
                rowspan = 1;
                previous = content;
                cellToExtend = jthis;
            }
        });
    }
    // now remove hidden td's (or leave them hidden if you wish):
    $('td.hidden').remove();
}


  
function MergeRow2(table)
{

var i = 0;
var $trs =table.find("tr");
$trs.each(function() {
    var $tds = $(this).find('td');
    var width = $tds.length;
    var num = 2;
    for(i = width - 2; i >= 0; i--) {
        if($($tds[i]).html() == $($tds[i + 1]).html() && $($tds[i]).html() != ""){
          //  $($tds[i]).attr('colspan', num);
            num++;
          //  $($tds[i + 1]).remove();
        } else {
            num = 2;
        }
    }
    $tds = $(this).find('td');
    width = $tds.length;
    $($tds[0]).attr('seq', 0);
    for(i = 1; i < width; i++) {
        $($tds[i]).attr('seq', parseInt($($tds[i - 1]).attr('seq')) + $($tds[i - 1]).prop('colspan'));
    }
});

var height = $trs.length;
var j = 0;

for(i = height - 2; i >= 0; i--){
    $($trs[i]).find('td').each(function() {
        var seq = parseInt($(this).attr('seq'));
        var $tdUnder = $($trs[i + 1]).find('td[seq="' + seq + '"]');
        if($tdUnder.length && ($tdUnder.html() != "") && ($tdUnder.html() == $(this).html()) && ($tdUnder.prop('colspan') == $(this).prop('colspan'))) {
            $(this).prop('rowspan', $tdUnder.prop('rowspan') + 1);
            $tdUnder.remove();
        }
    });
}

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
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" ></i>  Summary Repair Report </div>
     <div class="card-body">

   
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
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span20">Region :</span>
   <select name="ddlRegion" class="form-control ddlRegion" id="ddlRegion" data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
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
  <span class="input-group-addon" id="Span2">Year :</span>
                            <select class="form-control ddlYear" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>
           <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab1" ><i class="fa fa-spinner fa-spin"></i>VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExport">EXPORT</button>
          </div>

        </div>
          <div class="row" style="padding-top:10px;">


            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span15">Type Of line:</span>
                            <select class="form-control ddlPipeline" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="ddlPipeline" ><option selected="selected" value="0">ทั้งหมด</option>

</select>
   

</div>
          </div>

     <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span22">Asset Owner :</span>
        <select class="form-control ddlAssertOwner" id="Select15" name="AssertOwner">


</select>



</div>
          </div>
         
             
             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span19">Dig From</span>
       <select class="form-control ddlDIGFrom" data-val="true"  data-val-number="The field ToMonth must be a number." id="ddlDIGFrom" name="ddlDIGFrom">
       <option selected="selected" value="0">ทั้งหมด</option>
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
          <i class="fa fa-file " ></i> Table View 
          </div>
          <div class="col-sm-1">
         
           </div>
         
           </div>
          </div>
        <div class="card-body card-body2">
       
             <div class="row" style="padding-top:10px;">
          <div class="col-sm-12">
          
           <div class="sticky-table sticky-headers sticky-ltr-cells divSRR">
           <div class="tbDetail table-responsive">
        <table  id="tblSummary" class="table table-bordered tblSummary">
            <thead>
             <tr class="sticky-row bg-primary">
                    <th class=" text-center "  colspan="8"></th>
                    <th class="text-center"  colspan="3">Coating Inspection Result</th>
                       <th class="text-center"  colspan="2">Pipeline Inspection Result</th>
                       <th></th>
                    </tr>
                <tr class="sticky-row bg-primary">
                    
                   <th class="sticky-cell text-center "> No.</th>
                   	 <th class=" text-center ">Region</th>
                    <th class=" text-center ">RC</th>
                    <th class=" text-center ">Pipeline Section</th>
                    <th class=" text-center ">KP</th>
                    <th class=" text-center ">Repair
                      <br /> Length (m)</th>
                     <th class=" text-center ">Dig from</th>
                     <th class=" text-center ">Risk level</th>
                      <th class=" text-center ">type</th>
                      <th class=" text-center ">dmg type</th>
                      <th class=" text-center ">จำนวนจุด</th>
                      <th class=" text-center ">Damage type</th>
                      	<th class=" text-center ">จำนวนจุด</th>
                        <th class=" text-center ">Note</th>


                </tr>

            </thead>
          
        </table>
        </div>
      
    </div>
          </div>
          </div>

           <div class="row" style="padding-left:10px;">
             <div class="col-sm-12">
          <p class="text-sm-left"> Note 1* - ขุดผิวท่อและ Coating ยังคงอยู่ในสภาพดี %IR เกิดจาก ซิ้งค์ของสาธารณูปโภคอื่น</p>
        
          <p class="text-sm-left">Note 2* - จุดขุดเป็นบริเวณถนนที่มีการจราจรหนาแน่น ทำให้ต้องมีการประสานงานหลายหน่วยงาน และ เตรียมมาตราการเพื่อให้เกิดผลกระทบต่อชุมชนน้อยที่สุด </p>
          </div>
          </div>
          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
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

        

          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
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
    <script src="<%= ResolveUrl("~/Js/ui/Report/SummaryRepaireChart.js") %>"></script>
</asp:Content>

