<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="QuaterlyReport.aspx.cs" Inherits="UI_Master_QuaterlyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="<%= ResolveUrl("~/Css/stickytable/jquery.stickytable.min.css") %>">
 <script src="<%=ResolveUrl("~/Js/stickytable/jquery.stickytable.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/js/chart/Chart.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ExportToCSVFile.js") %>" type="text/javascript"></script>
     <script language="javascript">

         var currentURL = "<%= ResolveUrl("~/ASHX/Report/ReportMHandler.ashx") %>"; 
           var inspectionURL= "<%= ResolveUrl("~/ASHX/Plan/T_PlaningHandler.ashx") %>"; 
         var chart = null;
         var PID = '';
       var regionID = '', pipelineID = '', assetOwnerID = '', routeCodeID = '';
       var ReportObj;
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

               //  exportTableToCSV($('.tblQR'), 'QuaterlyReport.csv');
                      ExportFile("1");

                });

              LoadEvent();

});


    

    $(document).on('click', '.btnReview', function (e) {
        var $item = $(this).closest("tr");
        PID = $item.attr('PK');
     
        LoadPopup($item.attr('data'))
    });

    $(document).on('click', '.btnViewTab1', function (e) {

  
   Search();
  // ViewChart();
  
    });

    function LoadPopup(data) {

        $(".txtReview").val(data);
        
        $(".modalpopup").modal()
    }



    $(document).on('click', '.btnSave', function (e) {


        var formData = new FormData();

        formData.append("PID", PID);
        formData.append("Review", $(".txtReview").val());
        formData.append("Action", "AddReview");

        $.confirm({
            icon: 'fa fa-warning',
            title: 'Confirm',
            content: 'Do you want to save?',
            type: 'green',
            animation: "RotateX",
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'Confrim',
                    btnClass: 'btn-green',
                    action: function () {


                        $.ajax({
                            url: inspectionURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                                BAlert('Saved', 'Save data successfully!.');

                                formData = null;
                                Search();
                               
                                $(".modalpopup").modal('hide');
                                ClearControl();

                            },
                            error: function (err) {
                                alert(err.statusText)
                            }
                        });


                    }
                },
                close: function () {
                }
            }
        });



    });

    function ClearControl()
    {
        $(".txtReview").val('');
    }

 function ExportFile(reportNo)
  {

     var exportType="ExportQR",
    fileName="QuaterlyReport";
  
   exportCSVFile(fileName, ReportObj, fileName); 
  }





 function LoadEvent()
 {
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

 }


 function AssignDropDownToData(tregionID, tassetOwnerID, tpipelineID, trouteCodeID) {
     regionID = (tregionID != null ? tregionID : $(".ddlRegion").val());
     assetOwnerID = (tassetOwnerID != null ? tassetOwnerID : $(".ddlAssertOwner").val());
     //  pipelineID = (tpipelineID != null ? tpipelineID : $(".ddlPipeline").val());
     routeCodeID = (trouteCodeID != null ? trouteCodeID : $(".ddlRouteCode").val());
 }


 function Search()
  {
      
 var formData = new FormData();
   
     formData.append("Action", "QRReport");

     formData.append("AssertOwnerID", $('.ddlAssertOwner').val());
     formData.append("RegionID", $('.ddlRegion').val());
        formData.append("DIGFromID", $('.ddlDIGFrom').val());
        formData.append("TypeOfPipelineID", $('.ddlPipeline').val());
           formData.append("RouteID", $('.ddlRouteCode').val());
           formData.append("Year", $('.ddlYear').val());
           formData.append("Quarter","");
     

     waitingDialog.show('LOADING - Report', {dialogSize: 'lg', progressType: 'light'});

     $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

         var obj = JSON.parse(result)
         ReportObj=obj;
         LoadTable(obj)
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
       $('.divQR,.tbDetail').empty();

       html += '<table class="table table-bordered tblSummary"';
       html += '<thead>';
       html += '<tr class="sticky-row bg-primary">';
       html += '<th class=" text-center "  colspan="13"></th>';
       html += '<th class="text-center"  colspan="3">Coating Inspection Result</th>';
       html += '<th class="text-center"  colspan="2">Pipeline Inspection Result</th>';
       html += '<th class=" text-center "  colspan="1"></th>';
       html += '<th></th>';
       html += '</tr>';
       html += '<tr class="sticky-row bg-primary">';
       html += '<th class="sticky-cell text-center "> No.</th>';
       html += '<th class=" text-center ">Region</th>';
       html += '<th class=" text-center ">Asset Owner</th>';
       html += '<th class=" text-center ">Type Of line</th>';
       html += '<th class=" text-center ">RC</th>';
       html += '<th class=" text-center ">Pipeline Section</th>';
       html += '<th class=" text-center ">KP</th>';
       html += '<th class=" text-center ">"Repair <br /> Length (m)"</th>';
       html += '<th class=" text-center ">Dig from</th>';
       html += '<th class=" text-center ">Progress</th>';
       html += '<th class=" text-center ">Status</th>';
       html += '<th class=" text-center ">Note</th>';
       html += '<th class=" text-center ">Risk level</th>';
       html += '<th class=" text-center ">Coating Type</th>';
       html += '<th class=" text-center ">Damage Type</th>';
       html += '<th class=" text-center ">จำนวนจุด</th>';
       html += '<th class=" text-center ">Damage type</th>';
       html += '<th class=" text-center ">จำนวนจุด</th>';
       html += '<th class=" text-center ">Repair Method</th>';
       html += '<th class=" text-center ">บทวิเคราะห์</th>';
       html += '</tr>';
       html += '</thead>';



           
           
      /* public string PID { get; set; }
       public string No { get; set; }
       public string AssertOwnerID { get; set; }
       public string AssertOwner { get; set; }
       public string TypeOfPipelineID { get; set; }
       public string PipelineID { get; set; }
       public string PipelineType { get; set; }
       public string Region { get; set; }
       public string RegionID { get; set; }
       public string RegionCode { get; set; }
       public string RouteCode { get; set; }
       public string RC { get; set; }
       public string PipelineSection { get; set; }
       public string RiskLevel { get; set; }
       public string PipelineSectionCode { get; set; }
       public string KP { get; set; }
       public string RepairLength { get; set; }
       public string Digfrom { get; set; }
       public string SpecDesc { get; set; }
       public string PODesc { get; set; }
       public string ActionDesc { get; set; }
       public string FinishDesc { get; set; }
       public string Progress { get; set; }
       public string CoatingType { get; set; }
       public string CoatingDMGType { get; set; }
       public string CoatingPoint { get; set; }
       public string PipelineDMGType { get; set; }
       public string PipelinePoint { get; set; }
       public string RepaireMethod { get; set; }*/
        

       $.each(objList, function (index, item) {

           var status = "";
           var riskLevel = "";
           var review = "";
           if (item.SpecDesc != "")
           {
               status += item.SpecDesc;
           }

           if (item.PODesc != "") {
               status += "/"+item.PODesc;
           }

           if (item.ActionDesc != "") {
               status += "/" + item.ActionDesc;
           }

           if (item.FinishDesc != "") {
               status += "/" + item.FinishDesc;
           }

          
           if (item.Review == "")
           {
               review = "<span class='btn btn-lg btn-primary btnReview' style='cursor:pointer'>REVIEW</span>";
           }
           else {
               review = "<span class='btnReview text-primary' style='cursor:pointer;text-decoration: underline;'>" + item.Review + "</i>";
           }

          
           switch (item.RiskLevel)
           {
               case "3": riskLevel = "<span style='color:red'>High</span>"; break;
               case "2": riskLevel = "<span style='color:blue'>Medium</span>"; break;
               default: riskLevel = "Low";  break;
           }

           html += '<tr PK="' + item.PID + '" data="' + item.Review + '">';
                 html += '<td>' + item.No + '</td>';
                   html+= '<td>'+item.Region+'</td>';
                   html += '<td>' + item.AssertOwner + '</td>';
                   html += '<td>' + item.PipelineType + '</td>';
                   html += '<td>' + item.RC + '</td>';
                   html += '<td>' + item.PipelineSectionCode + '</td>';
                   html += '<td>' + item.KP + '</td>';

                   html += '<td>' + item.RepairLength + '</td>';
                   html += '<td>' + item.Digfrom + '</td>';
                   html += '<td>' + item.Progress + '</td>';
                   html += '<td>' + (status) + '</td>';
                   html += '<td>' + item.Note + '</td>';
                   html += '<td>' + riskLevel + '</td>';
                   html += '<td>' + item.CoatingType + '</td>';
                   html += '<td>' + item.CoatingDMGType + '</td>';
                   html += '<td>' + item.CoatingPoint + '</td>';
                   html += '<td>' + item.PipelineDMGType + '</td>';
                   html += '<td>' + item.PipelinePoint + '</td>';
                   html += '<td>' + item.RepaireMethod + '</td>';
                   html += '<td>' + review + '</td>';
                       html+= '</tr>';
                      

  });


   html+= '</table>';

    

                $('.divQR,.tbDetail').append(html);
   

      
  


  }



  
function compareDataPointX(dataPoint1, dataPoint2) {
    return dataPoint1.x - dataPoint2.x;
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

    	    	.tblSummary tr.collapse
    	{
    		background-color: #ffffff;
    
    		
    		}
    		
 


@media (min-width: 768px) {
    .modal-dialog {
        width: 800px;
        margin: 30px auto
    }
    .modal-content {
        -webkit-box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
        box-shadow: 0 5px 15px rgba(0, 0, 0, .5)
    }
    .modal-sm {
        width: 300px
    }
}
@media (min-width: 992px) {
    .modal-lg {
        width: 900px
    }
}
@media (min-width: 768px) {
    .modal-dialog {
        width: 800px;
        margin: 30px auto
    }
    .modal-content {
        -webkit-box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
        box-shadow: 0 5px 15px rgba(0, 0, 0, .5)
    }
    .modal-sm {
        width: 300px
    }
}
@media (min-width: 992px) {
    .modal-lg {
        width: 900
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
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" ></i>  Querterly Report</div>
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
          <i class="fa fa fa-bar-chart " ></i> View
          </div>
          <div class="col-sm-1">
         
           </div>
         
           </div>
          </div>
        <div class="card-body card-body2">
       
            

           <div class="row" style="padding-top:10px;">
          <div class="col-sm-12">
               <div class="sticky-table sticky-headers divQR">
           <div class="tbDetail table-responsive">
               <table class="table table-bordered tblSummary"';
      <thead>
      <tr class="sticky-row bg-primary">
      <th class=" text-center "  colspan="13"></th>
      <th class="text-center"  colspan="3">Coating Inspection Result</th>
      <th class="text-center"  colspan="2">Pipeline Inspection Result</th>
           <th class=" text-center "  colspan="1"></th>
      <th></th>
      </tr>
      <tr class="sticky-row bg-primary">
      <th class="sticky-cell text-center "> No.</th>
      <th class=" text-center ">Region</th>
      <th class=" text-center ">Asset Owner</th>
      <th class=" text-center ">Type Of line</th>
      <th class=" text-center ">RC</th>
      <th class=" text-center ">Pipeline Section</th>
      <th class=" text-center ">KP</th>
      <th class=" text-center ">"Repair <br /> Length (m)"</th>
      <th class=" text-center ">Dig from</th>
      <th class=" text-center ">Progress</th>
      <th class=" text-center ">Status</th>
      <th class=" text-center ">Note</th>
      <th class=" text-center ">Risk level</th>
      <th class=" text-center ">Coating Type</th>
      <th class=" text-center ">Damage Type</th>
      <th class=" text-center ">จำนวนจุด</th>
      <th class=" text-center ">Damage type</th>
      <th class=" text-center ">จำนวนจุด</th>
      <th class=" text-center ">Repair Method</th>
      <th class=" text-center ">บทวิเคราะห์</th>
      </tr>
      </thead>
           
        </table>
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


    <div class="modal modalpopup fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"><i class="fa fa-cog fa-spin fa-2x" ></i>บทวิเคราะห์</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">

    <textarea rows="20"   class="form-control txtReview" type='text' id="txtReview"  ></textarea>
   
</div>
          </div>
          </div>

          


      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>

    <script src="<%= ResolveUrl("~/Js/chartNew/Chart.Canvas.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/ui/Report/SummaryRiskReport.js") %>"></script>
</asp:Content>