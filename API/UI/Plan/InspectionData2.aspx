<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="InspectionData2.aspx.cs" Inherits="UI_Plan_InspectionData2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Js/boostrap.table.js" type="text/javascript"></script>
       <script src="<%= ResolveUrl("~/Js/jquery.easyui.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Js/datagrid-groupview.js") %>" type="text/javascript"></script>


        <link href="<%= ResolveUrl("~/Css/easyui.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Css/icon.css") %>" rel="stylesheet" type="text/css" />
<script type="text/javascript">



    var data = { "total": 28, "rows": [
	{
	    "rc": "RC0650",
	    "pipline_name": "Transmission Pipline",
	    "start-end": "BV9-BV20",
	    "kp": "22-339",
	    "region": "9",
	    "dig": "Severe Dent",
	    "serverity": "1",
	    "progress": "1",
	    "jan_1": "2",
	    "jan_2": "3",
	    "jan_3": "4",
	    "jan_4": "1",

	    "fab_1": "1",
	    "fab_2": "1",
	    "fab_3": "1",
	    "fab_4": "1",

	    "mar_1": "1",
	    "mar_2": "1",
	    "mar_3": "1",
	    "mar_4": "1",

	    "apr_1": "1",
	    "apr_2": "1",
	    "apr_3": "1",
	    "apr_4": "1",

	    "may_1": "1",
	    "may_2": "1",
	    "may_3": "1",
	    "may_4": "1",

	    "jun_1": "1",
	    "jun_2": "1",
	    "jun_3": "1",
	    "jun_4": "1"

	},
	{
	    "rc": "RC0650",
	    "pipline_name": "Transmission Pipline",
	    "start-end": "BV9-BV20",
	    "kp": "22-339",
	    "region": "9",
	    "dig": "Severe Dent",
	    "serverity": "1",
	    "progress": "2",

	    "jan_1": "",
	    "jan_2": "5",
	    "jan_3": "5",
	    "jan_4": "5",

	    "fab_1": "5",
	    "fab_2": "5",
	    "fab_3": "5",
	    "fab_4": "5",

	    "mar_1": "5",
	    "mar_2": "5",
	    "mar_3": "5",
	    "mar_4": "5",

	    "apr_1": "5",
	    "apr_2": "5",
	    "apr_3": "5",
	    "apr_4": "5",

	    "may_1": "5",
	    "may_2": "5",
	    "may_3": "5",
	    "may_4": "6",

	    "jun_1": "6",
	    "jun_2": "5",
	    "jun_3": "5",
	    "jun_4": "5"
	},

	{
	    "rc": "RC0651",
	    "pipline_name": "IPP / SPP Pipline > Gas Transmission Asset (GTA-สทพ)",
	    "start-end": "BV9-BV21",
	    "kp": "22-339",
	    "region": "9",
	    "dig": "Severe Dent",
	    "serverity": "0",
	    "progress": "1"
	},
	{
	    "rc": "RC0651",
	    "pipline_name": "IPP / SPP Pipline > Gas Transmission Asset (GTA-สทพ)",
	    "start-end": "BV9-BV21",
	    "kp": "22-339",
	    "region": "9",
	    "dig": "Severe Dent",
	    "serverity": "0",
	    "progress": "2"
	}
]
}

    window.onload = function () {

        //  LoadTable();

        $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });


        $(".easyui-datagrid").datagrid({
            rownumbers: true,
            singleSelect: true,
            data: data,
            method: 'get',
            view: groupview,
            groupField: 'rc',
            groupFormatter: groupRow,
            onLoadSuccess: onLoadSuccess
        });


    }


    function groupRow(value, rows) {
        return rows[0].pipline_name
    }

    function onLoadSuccess(data) {
        for (var i = 0; i < data.rows.length; i++) {
            $(this).datagrid('mergeCells', { index: i, field: 'rc', rowspan: 2 });
            $(this).datagrid('mergeCells', { index: i, field: 'start-end', rowspan: 2 });
            $(this).datagrid('mergeCells', { index: i, field: 'kp', rowspan: 2 });
            $(this).datagrid('mergeCells', { index: i, field: 'region', rowspan: 2 });
            $(this).datagrid('mergeCells', { index: i, field: 'dig', rowspan: 2 });
            $(this).datagrid('mergeCells', { index: i, field: 'serverity', rowspan: 2 });
            i = i + 1;
        }

        // $('.xtooltip').tooltip({
        //     position: 'top'
        // });
    }


    function progressFormat(value, row, index) {
        if (value == "1") {
            return "<a href='#'>Plan</a>";
        } else if (value == "2") {
            return "<a href='#'>Actual</a>";
        }
    }

    function weekFormat(value, row, index) {
        //console.log(index);
        if (value == "1") {
            return "";
        } else if (value == "2") {
            return "<a href=#' data-original-title='test' data-toggle='tooltip' data-placement='top'>PO</a>";
        } else if (value == "3") {
            return "Spece";
        } else if (value == "4") {
            return "Action";
        }
    }


    function weekStyle(value, row, index) {
        if (value == 1) {
            return "background:#69F0AE;"
        } else if (value == 2) {
            return "background:#69F0AE;"
        } else if (value == 3) {
            return "background:#69F0AE;"
        } else if (value == 4) {
            return "background:#69F0AE;"
        } else if (value == 5) {
            return "background:#80D8FF;"
        } else if (value == 6) {
            return "background:#80D8FF;"
        } else if (value == 7) {
            return "background:#80D8FF;"
        } else if (value == 8) {
            return "background:#80D8FF;"
        }
    }

    function serFormat(value, row, index) {
        if (value == "1") {
            return "<span style='color:red'>High</span>";
        } else if (value == "0") {
            return "<span style='color:gray'>Low</span>";
        }
    }


</script>

<style type="text/css">
 body
 {
 	   color:#000000;
		font-size:16px;
 	}
 	
 	.tbDetail  thead tr
 	{
 		 background-color:#007bff !important;
 		}
 		
 		.hiddenRow {
    padding: 0 !important;
}
td a
{
	color:#007bff;
	}
/*
   .table-fix table {
    width: 100%;
    display:block;
}
.table-fix thead {
    display: inline-block;
    width: 100%;
   
}

*/
 /* .table-fix tbody {
   
   display: block;
    width: 100%;
    overflow: auto;
}*/
  
  
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Inspection Data </div>
     <div class="card-body">


     <!-- Example DataTables Card-->
      <div class="row table-responsive">
      <div class="col-sm-12">
      <div class="card mb-3">
        <div class="card-header card-headerBlue">
          <i class="fa fa-searcg fa-2x" style="color:#007bff" ></i>  Planning</div>
        <div class="card-body card-body2 ">

       
          
           <div class="row" style="padding-top:10px;">
                <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span20">Region :</span>
   <select name="RegionID" class="form-control" id="Select13" data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
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
  <span class="input-group-addon" id="Span22">Route Code :</span>
        <select class="form-control routecode-list" id="Select15" name="RouteCode"><option value="0">ทั้งหมด</option>
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
  <span class="input-group-addon" id="Span19">Dig From</span>
       <select class="form-control" data-val="true" data-val-number="The field ToMonth must be a number." data-val-required="The ToMonth field is required." id="Select12" name="ToMonth">

</select>


</div>
          </div>
             
         <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span14">Year :</span>
                            <select class="form-control" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="Select7" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>
<option value="2017">2017</option>
<option value="2018">2018</option>

</select>
   

</div>
          </div>
     
      </div>

        <div class="row" style="padding-top:10px;">

       
            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span15">Pipline Type:</span>
                            <select class="form-control" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="Select8" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>

</select>
   

</div>
          </div>
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span16">Assert Owner</span>
                            <select class="form-control" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="Select9" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>

</select>
   

</div>
          </div>
            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span17">Region :</span>
    <select class="form-control" data-val="true" data-val-number="The field TypeOfRouteCodeID must be a number." data-val-required="The TypeOfRouteCodeID field is required." id="Select10" name="TypeOfRouteCodeID">

</select>

</div>
          </div>

          <div class="col-sm-sm-3">
            <button type="button" class="btn btn-lg btn-primary bthSearch">ค้นหา</button>
          </div>


          </div>

       <div class="row" style="padding-top:10px;">
                <div class="col-sm-12">
          <div class="table-responsive text-secondary" style="padding-bottom:20px;">
               <table class="easyui-datagrid table-blue" title="">
        
        <thead data-options="frozen:true">
                <tr>
                    <th data-options="field:'rc',width:80,align:'center'" rowspan="2">RC</th>
                    <th data-options="field:'pipline_head',width:100,align:'center'" colspan="2">Pipline</th>
                    <th data-options="field:'region',width:60,align:'center'" rowspan="2">Region</th>
                    <th data-options="field:'dig',width:80,align:'center'" rowspan="2">Dig From</th>
                    <th data-options="field:'serverity',width:60,align:'center',formatter:serFormat" rowspan="2">Serverity</th>
                    <th data-options="field:'progress',width:60,align:'center',formatter:progressFormat" rowspan="2">Progress</th>
                </tr>
                <tr>
                    <th data-options="field:'start-end',width:150,align:'center'">Start - End</th>
                    <th data-options="field:'kp',width:80,align:'center'">KP</th>
                </tr>
        </thead>
        <thead>
                <tr>
                    <th colspan="4">Jan<Section></Section></th>
                    <th colspan="4">Fab<Section></Section></th>
                    <th colspan="4">Mar<Section></Section></th>
                    <th colspan="4">Apr<Section></Section></th>
                    <th colspan="4">May<Section></Section></th>
                    <th colspan="4">Jun<Section></Section></th>
                    <th colspan="4">Jul<Section></Section></th>
                    <th colspan="4">Ang<Section></Section></th>
                    <th colspan="4">Sep<Section></Section></th>
                    <th colspan="4">Oct<Section></Section></th>
                    <th colspan="4">Nov<Section></Section></th>
                    <th colspan="4">Dec<Section></Section></th>
                </tr>
        </thead>
        <thead>
            <tr>
                <th data-options="field:'jan_1',width:50,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'jan_2',width:50,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'jan_3',width:50,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'jan_4',width:50,align:'center',styler:weekStyle,formatter:weekFormat">4</th>

                
                <th data-options="field:'fab_1',width:50,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'fab_2',width:50,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'fab_3',width:50,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'fab_4',width:50,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                
                <th data-options="field:'mar_1',width:30,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'mar_2',width:30,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'mar_3',width:30,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'mar_4',width:30,align:'center',styler:weekStyle,formatter:weekFormat">4</th>

                <th data-options="field:'apr_1',width:30,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'apr_2',width:30,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'apr_3',width:30,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'apr_4',width:30,align:'center',styler:weekStyle,formatter:weekFormat">4</th>

                <th data-options="field:'may_1',width:30,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'may_2',width:30,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'may_3',width:30,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'may_4',width:30,align:'center',styler:weekStyle,formatter:weekFormat">4</th>

                <th data-options="field:'jun_1',width:30,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'jun_2',width:30,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'jun_3',width:30,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'jun_4',width:30,align:'center',styler:weekStyle,formatter:weekFormat">4</th>

                <th data-options="field:'jul_1',width:30,align:'center'">1</th>
                <th data-options="field:'jul_2',width:30,align:'center'">2</th>
                <th data-options="field:'jul_3',width:30,align:'center'">3</th>
                <th data-options="field:'jul_4',width:30,align:'center'">4</th>

                <th data-options="field:'ang_1',width:30,align:'center'">1</th>
                <th data-options="field:'ang_2',width:30,align:'center'">2</th>
                <th data-options="field:'ang_3',width:30,align:'center'">3</th>
                <th data-options="field:'ang_4',width:30,align:'center'">4</th>

                <th data-options="field:'sep_1',width:30,align:'center'">1</th>
                <th data-options="field:'sep_2',width:30,align:'center'">2</th>
                <th data-options="field:'sep_3',width:30,align:'center'">3</th>
                <th data-options="field:'sep_4',width:30,align:'center'">4</th>

                <th data-options="field:'oct_1',width:30,align:'center'">1</th>
                <th data-options="field:'oct_2',width:30,align:'center'">2</th>
                <th data-options="field:'oct_3',width:30,align:'center'">3</th>
                <th data-options="field:'oct_4',width:30,align:'center'">4</th>

                <th data-options="field:'nov_1',width:30,align:'center'">1</th>
                <th data-options="field:'nov_2',width:30,align:'center'">2</th>
                <th data-options="field:'nov_3',width:30,align:'center'">3</th>
                <th data-options="field:'nov_4',width:30,align:'center'">4</th>

                <th data-options="field:'dec_1',width:30,align:'center'">1</th>
                <th data-options="field:'dec_2',width:30,align:'center'">2</th>
                <th data-options="field:'dec_3',width:30,align:'center'">3</th>
                <th data-options="field:'dec_4',width:30,align:'center'">4</th>
                
            </tr>
        </thead>
    </table>

           
          </div>
          </div>
          </div>


           <div class="row mb-5" style="padding-top:30px;"></div>
          	<div class="row ">
				<div class="col-md-12">
					
					<div style="display:inline-block;width:100%;">
					<ul class="timeline timeline-horizontal">
						<li class="timeline-item ">
							
							<div class="timeline-panel  alert alert-danger back-widget-set xzoom" style="height:230px">
								<div class="timeline-heading">
									<h4 class="timeline-title">Note</h4>
									<p><small class="text-muted"><i class="glyphicon glyphicon-time"></i> 11 hours ago via Twitter</small></p>
								</div>
								<div class="timeline-body">
									<div class="text-left"> 1.TBC=to be confirmed<br>
          2.ข้อมูลกาารแบ่งประเภท Assert นำมาจากหน่วยงาน</div>
								</div>
							</div>
                           <!-- <div class="timeline-badge primary"><i class="glyphicon glyphicon-check"></i></div>-->
						</li>
						<li class="timeline-item">
							<!--<div class="timeline-badge success"><i class="glyphicon glyphicon-check"></i></div>-->
							<div class="timeline-panel alert alert-success back-widget-set xzoom" style="height:230px">
								<div class="timeline-heading">
									<h4 class="timeline-title">Remark</h4>
									<p><small class="text-muted"><i class="glyphicon glyphicon-time"></i> 11 hours ago via Twitter</small></p>
								</div>
								<div class="timeline-body2">
									 <table class="table table-responsive">
          <tr>
          <td> <i class="fa fa-square alert-info fa-2x" aria-hidden="true" ></i></td>
          <td>Plan</td>
          <td>&nbsp;</td>
          <td> <i class="fa fa-square alert-warning fa-2x"  aria-hidden="true" ></i></td>
          <td>Shift from previous year</td>
          </tr>

           <tr>
          <td> <i class="fa fa-square alert-success fa-2x" aria-hidden="true" ></i></td>
          <td>Actual</td>
          <td>&nbsp;</td>
          <td> <i class="fa fa-square alert-danger fa-2x" aria-hidden="true" ></i></td>
          <td>Shift to next year</td>
          </tr>
          
          </table>
								</div>
							</div>
						</li>
						<li class="timeline-item">
							<!--<div class="timeline-badge info"><i class="glyphicon glyphicon-check"></i></div>-->
							<div class="timeline-panel alert alert-danger xzoom" style="height:230px">
								<div class="timeline-heading">
									<h4 class="timeline-title">Reference documents</h4>
									<p><small class="text-muted"><i class="glyphicon glyphicon-time"></i> 11 hours ago via Twitter</small></p>
								</div>
								<div class="timeline-body">
									 <div class="text-left">
         <i class="fa fa-check-square-o" aria-hidden="true"></i> PRJ_PTTDA_Requirements Specification_V0.4_Updated 22-12-17
         </div>
								</div>
							</div>
						</li>
						
					</ul>
				</div>
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
         
<!--- Content --->
</div> 
    </div>
    </div>

    <script>
        $('[data-toggle="tooltip"]').tooltip({ html: true });






        $('.pipeline1').collapse('show');
        $('.pipeline2').collapse('show');
         //  $('.region3').collapse('show');



   




      /*
        var $table = $('.table-fix'),
    $bodyCells = $table.find('thead tr:nth-child(2)').children(),
    colWidth;

       

      
        colWidth = $bodyCells.map(function () {
            return $(this).width();
        }).get();

       
        $table.find('tbody tr').children().each(function (i, v) {
            $(v).width(colWidth[i]);
        });    
        */
        </script>

</asp:Content>

