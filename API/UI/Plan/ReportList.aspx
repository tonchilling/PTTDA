<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ReportList.aspx.cs" Inherits="UI_Plan_ReportList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<link rel="stylesheet" href="<%= ResolveUrl("~/Css/stickytable/jquery.stickytable.min.css") %>">
 <script src="<%=ResolveUrl("~/Js/stickytable/jquery.stickytable.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/js/chart/Chart.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ExportToCSVFile.js") %>" type="text/javascript"></script>
   
    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Report/ReportMHandler.ashx") %>"; 
     var chart=null;
    $(document).ready(function () {
    // MergeRow2($('.tblSummary'));
    //  MergeRow2($('.tbl2'));

      LoadDropDownList($('.ddlAssertOwner'), "M_AssertOwner");
    LoadDropDownList($('.ddlQuarter'), "M_Quarter");
     

   




   $('.btnExport').on("click",function(e){


    ExportFile("1");

});



   $('.btnExportChart').on("click",function(e){


  
  // chart.render();
   chart.exportChart({format: "jpg"});

});

$('.btnExportQuarterReport').on("click",function(e){

    ExportFile("3");

   

});





     $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });

            $('.btnAdd').on("click",function(e){
            
            window.location.href =' <%= ResolveUrl("~/UI/Plan/CreatingPlan.aspx") %>';
            });



            
  });


$(function() { 
    $(".btn").click(function(){
        $(this).button('loading').delay(1000).queue(function() {
            $(this).button('reset');
            $(this).dequeue();
        });        
    });
});  




    $(document).on('click', '.btnViewTab1', function (e) {

  
   ViewSummaryRepairReport();

  
});

     $(document).on('click', '.btnViewTab2', function (e) {

   
   ViewSummaryPlanReport();

  
});

 $(document).on('click', '.btnViewTab3', function (e) {
       
   
   ViewQuarterlyReport();

  
});


  function ExportFile(reportNo)
  {
  


   var html = '';
    var formData = new FormData();

   var exportType="";
   var fileName="";

   if(reportNo=="1")
   {
     exportType="ExportSRR";
    fileName="SummaryReport";
   }
   else if(reportNo=="2")
   {
   
   }

    else if(reportNo=="3")
   {
     exportType="ExportQR";
    fileName="QuaterlyReport";
   }

    formData.append("Action",exportType);

    waitingDialog.show('EXPORTING', {dialogSize: 'lg', progressType: 'primary'});


     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
   var obj = JSON.parse(result)
                 exportCSVFile(fileName, obj, fileName); 
                    setTimeout(function () { waitingDialog.hide(); }, 1000);
},
error:function(err)
{
   setTimeout(function () { waitingDialog.hide(); }, 1000);
}
});

  
  
  }





  function ViewSummaryRepairReport()
  {
       var html = '';
 var formData = new FormData();
    formData.append("Action", "SRReport");


     formData.append("AssertID", $('.modalTab1 .ddlAssertOwner').val());
      formData.append("Quarter", $('.modalTab1 .ddlQuarter').val());

     formData.append("Year", $('.modalTab1 .ddlYear').val());
  

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


           var obj = JSON.parse(result)
            $('.divSRR,.tbDetail').empty();
           // $('.divSRR').empty();
          
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
              html+= '<th class=" text-center ">"Repair <br /> Length (m)"</th>';
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


function ViewSummaryPlanReport()
  {
  
 

          var html = '';
 var formData = new FormData();
    formData.append("Action", "SUMPReport");
    formData.append("AssertID", $('.modalTab2 .ddlAssertOwner').val());
      formData.append("Quarter", $('.modalTab2 .ddlQuarter').val());

     formData.append("Year", $('.modalTab2 .ddlYear').val());

  

     waitingDialog.show('LOADING -  Summary Plan Report', {dialogSize: 'lg', progressType: 'light'});

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
         setTimeout(function () { waitingDialog.hide(); }, 1000);
        }
        });
}

  function ViewQuarterlyReport()
  {
  
 

          var html = '';
 var formData = new FormData();
    formData.append("Action", "QRReport");
     formData.append("AssertID", $('.modalTab3 .ddlAssertOwner').val());
      formData.append("Quarter", $('.modalTab3 .ddlQuarter').val());

     formData.append("Year", $('.modalTab3 .ddlYear').val());
       waitingDialog.show('LOADING -  Summary Plan Report', {dialogSize: 'lg', progressType: 'light'});

     $('.divQR,.tbDetail').empty();

    var html='';

    

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

  

   html+= '<table class="table table-bordered tblQR"';
         html+= '<thead>';
            html+= '<tr class="sticky-row bg-primary">';
           html+= ' <th class="sticky-cell text-center ">เขต</th>';
          html+= ' <th class=" text-center ">เส้นท่อ,ตำแหน่ง</th>';
          html+= ' <th class=" text-center ">จุดเชื่อมต่อเนื่องจาก</th>';
          html+= ' <th class=" text-center ">Length(m)</th>';
           html+= ' <th class=" text-center ">Actual(%)</th>';
          
           html+= ' <th class=" text-center ">Plan/Status</th>';
           html+='</tr>';



           var obj = JSON.parse(result)
           

        

             $.each(obj, function( index, item ) {
                 html+= '<tr>';
                   html+= '<td class="sticky-cell">'+item.Region+'</td>';
                     html+= '<td>'+item.RC+","+item.KP+'</td>';
                     html+= '<td>'+item.Digfrom+'</td>';
                     html+= '<td>'+item.RepairLength+'</td>';
                     html+= '<td>'+item.Actual+'</td>';
                      html+= '<td>'+item.PlanStatus+'</td>';
                       html+= '</tr>';
                      

  });


   html+= '</table>';

    

                $('.divQR,.tbDetail').append(html);
    MergeRow2($('.divQR table'));

      setTimeout(function () { waitingDialog.hide(); }, 1000);
  
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
    .modal-dialog 
    {
    	
    width: 80%;
   
    margin: 30px auto;
      
}

.container-fluid .modal-body
{
	 min-height:500px;
	}



.sticky-table table td.sticky-cell, .sticky-table table th.sticky-cell
    {
    	background-color: #ffffff;
    	outline: 1px solid #ddd;position: relative;z-index: 10;}
    	




</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Report </div>
     <div class="card-body">


      <div class="row">

            <div class="col-md-4">
        <a class="btn btn-block btn-lg btn-primary xzoom" data-toggle="modal" data-target=".modalTab1">
            <i class="fa fa-cog fa-spin" id="icone_grande"></i> <br><br>
            <span class="texto_grande"> Summary Repair Report</span></a>
      </div>

           <div class="col-md-4">
        <a class="btn btn-block btn-lg btn-success xzoom" data-toggle="modal" data-target=".modalTab2">
            <i class="fa fa-bar-chart" id="icone_grande"></i> <br><br>
            <span class="texto_grande"> Summary Plan Report</span></a>
      </div>
      <div class="col-md-4">
        <a class="btn btn-block btn-lg btn-danger xzoom" data-toggle="modal" data-target=".modalTab3">
            <i class="fa fa-map-marker" id="icone_grande"></i> <br><br>
            <span class="texto_grande" style="font-size:24px;">Quarterly Report </span></a>
      </div>

    
          </div>

         
         
        </div>

     </div>
         
<!--- Content --->
</div> 
    </div>




     <div class="modal modalTab1 myModal  fade" id="Div1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H2"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Summary Repaire Report</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body ">


        <div class="row" style="padding-top:10px;">

     <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span22">Assert Owner :</span>
        <select class="form-control ddlAssertOwner" id="Select15" name="AssertOwner">


</select>



</div>
          </div>
               <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span19">Quarter :</span>
       <select class="form-control ddlQuarter" >

</select>


</div>
          </div>
             
         <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span14">Year :</span>
                            <select class="form-control ddlYear" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>

          <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab1"  data-loading-text="Loading ..."><i class="fa fa-spinner fa-spin"></i>VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExport">EXPORT</button>
          </div>
          </div>
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
                    <th class=" text-center ">"Repair
                      <br /> Length (m)"</th>
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
          
      </div>
      <div class="row" style="padding-left:10px;">
             <div class="col-sm-12">
          <p class="text-sm-left"> Note 1* - ขุดผิวท่อและ Coating ยังคงอยู่ในสภาพดี %IR เกิดจาก ซิ้งค์ของสาธารณูปโภคอื่น</p>
        
          <p class="text-sm-left">Note 2* - จุดขุดเป็นบริเวณถนนที่มีการจราจรหนาแน่น ทำให้ต้องมีการประสานงานหลายหน่วยงาน และ เตรียมมาตราการเพื่อให้เกิดผลกระทบต่อชุมชนน้อยที่สุด </p>
          </div>
          </div>

      
       <div class="modal-footer">
       
      

      
      </div>
    </div>
  </div>
</div>

     <div class="modal modalTab2 myModal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Summary Plan Report</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body ">


        <div class="row" style="padding-top:10px;">

     <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span2">Assert Owner :</span>
        <select class="form-control ddlAssertOwner" id="Select1" name="RouteCode">


</select>



</div>
          </div>
               <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Quarter :</span>
       <select class="form-control ddlQuarter" data-val="true" data-val-number="The field ToMonth must be a number." data-val-required="The ToMonth field is required." id="Select2" name="ToMonth">

</select>


</div>
          </div>
             
         <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span4">Year :</span>
                            <select class="form-control ddlYear"  id="Select3" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>

          <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab2">VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExportChart">EXPORT</button>
          </div>
          </div>
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
      <div class="modal-footer">
       
      
      </div>
       </div>
  </div>
</div>



<div class="modal modalTab3 myModal  fade" id="SummaryDistance" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H1"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Querterly Report</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body ">


        <div class="row" style="padding-top:10px;">

    <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span1">Assert Owner :</span>
        <select class="form-control ddlAssertOwner " >


</select>



</div>
          </div>
               <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span5">Quarter :</span>
       <select class="form-control ddlQuarter" >

</select>


</div>
          </div>
             
         <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span6">Year :</span>
                            <select class="form-control ddlYear" ><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>

          <div class="col-sm-3">
          <button type="button" class="btn btn-lg btn-primary btnViewTab3">VIEW</button>
        <button type="button" class="btn btn-lg btn-success btnExportQuarterReport">EXPORT</button>
          </div>
          </div>

          <div class="row">
          <div class="col-sm-12">
          
          <div class="sticky-table sticky-headers sticky-ltr-cells divQR">
           <div class="tbDetail table-responsive">
        <table  id="Table1" class="table table-bordered tblSummary">
            <thead>
           
                <tr class="sticky-row bg-primary">
                    
                   <th class="sticky-cell text-center ">เขต</th>
                   	 <th class=" text-center ">เส้นท่อ,ตำแหน่ง</th>
                    <th class=" text-center ">จุดเชื่อมต่อเนื่องจาก</th>
                    <th class=" text-center ">Length(m)</th>
                    <th class=" text-center ">Actual(%)</th>
                    <th class=" text-center ">"Repair
                      <br /> Length (m)"</th>
                     <th class=" text-center ">Plan/Status</th>
                    


                </tr>

            </thead>
           
        </table>
        </div>
      
    </div>
          </div>
          
          </div>


      </div>
     

     
       <div class="modal-footer">
       
      
      </div>
    </div>
  </div>
</div>


  <!-- Page level plugin JavaScript-->
   
    <!-- Custom scripts for all pages-->
   <script src="<%= ResolveUrl("~/Js/chartNew/Chart.Canvas.js") %>"></script>
     
    
   <script src="<%= ResolveUrl("~/Js/ui/Plan/Report-charts.js") %>"></script>
    </div>
    </div>
</asp:Content>

