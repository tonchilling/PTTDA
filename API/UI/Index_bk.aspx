<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Index_bk.aspx.cs" Inherits="UI_Index_bk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <script src="<%= ResolveUrl("~/Js/MultiSelect.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Js/boostrap.table.js") %>" type="text/javascript"></script>

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
    
    
    div.tooltip-inner
    {
    	
    	max-width:800px;
    	
    	}
    	
    	 div.tooltip-inner table
    {
    	border-collapse:separate;
    	text-align:left;
      border-spacing:5px;
    
    
    	
    	}
    	
    	
    	
    td.green
    {
    	color:#008000;
    	
    	}
    	
    	  td.blue
    {
    	color:#337ab7;
    	
    	}
    	
    	
    .multiselect
    {
    	 height:38px;
    	width:auto;
    	}
    	
    	 .multiselect.focus,
    	  .multiselect.hover,
    	  .multiselect:active,
    {
    	 color: #333;
    background-color: #ffffff;
    border-color: #adadad;
    height:38px;
    width:20em;
    	}	
    		

.btn .caret {
    float:right;
}

    	
    	span.multiselect-native-select {
	position: relative
}
span.multiselect-native-select select {
	border: 0!important;
	clip: rect(0 0 0 0)!important;
	height: 1px!important;
	margin: -1px -1px -1px -3px!important;
	overflow: hidden!important;
	padding: 0!important;
	position: absolute!important;
	width: 1px!important;
	left: 50%;
	top: 30px
}


.multiselect-selected-text >.btn.caret
{
	width:20em;
	}
	
	
		
		
.multiselect-container {
	position: absolute;
	list-style-type: none;
	margin: 0;
	padding: 0
}
.multiselect-container .input-group {
	margin: 5px
}
.multiselect-container>li {
	padding: 0
}
.multiselect-container>li>a.multiselect-all label {
	font-weight: 700
}
.multiselect-container>li.multiselect-group label {
	margin: 0;
	padding: 3px 20px 3px 20px;
	height: 100%;
	font-weight: 700
}
.multiselect-container>li.multiselect-group-clickable label {
	cursor: pointer
}
.multiselect-container>li>a {
	padding: 0
}
.multiselect-container>li>a>label {
	margin: 0;
	height: 100%;
	cursor: pointer;
	font-weight: 400;
	padding: 3px 0 3px 30px
}
.multiselect-container>li>a>label.radio, .multiselect-container>li>a>label.checkbox {
	margin: 0
}
.multiselect-container>li>a>label>input[type=checkbox] {
	margin-bottom: 5px
}
.btn-group>.btn-group:nth-child(2)>.multiselect.btn {
	border-top-left-radius: 4px;
	border-bottom-left-radius: 4px
}
.form-inline .multiselect-container label.checkbox, .form-inline .multiselect-container label.radio {
	padding: 3px 20px 3px 40px
}
.form-inline .multiselect-container li a label.checkbox input[type=checkbox], .form-inline .multiselect-container li a label.radio input[type=radio] {
	margin-left: -20px;
	margin-right: 0
}


    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
    <div class="container-fluid">


      <!-- Area Chart Example
      <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-area-chart"></i> Area Chart Example</div>
        <div class="card-body">
          <canvas id="myAreaChart" width="100%" height="30"></canvas>
        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>-->
      <div class="row" style="margin-top:50px;">
        <div class="col-lg-12">
          <!-- Example Bar Chart Card-->
          <div class="card mb-3">
            <div class="card-header">
             <i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Dashboard</div>
            <div class="card-body">

                 <div class="row" style="padding-top:10px;">


                    <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span2">Customer Type :</span>
                            <select class="form-control" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="CustomerTypeID" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>
<option value="37">PTT</option>
<option value="38">NGR</option>
<option value="39">NGV</option>
<option value="40">TREASURY DEPT.</option>
<option value="41">-</option>
</select>
   

</div>
          </div>
                    <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span1">Type Of Route Code :</span>
    <select class="form-control" data-val="true" data-val-number="The field TypeOfRouteCodeID must be a number." data-val-required="The TypeOfRouteCodeID field is required." id="Select1" name="TypeOfRouteCodeID"><option selected="selected" value="0">ทั้งหมด</option>
<option value="41">PIPING</option>
<option value="42">TRANSMISSION</option>
<option value="43">DISTRIBUTION</option>
<option value="44">BRANCH</option>
<option value="45">DISTRIBUTION_LP</option>
</select>

</div>
          </div>
                    <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span5">Region :</span>
   <select name="RegionID" class="form-control" id="Select2" 
   data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
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
                   
         
               </div>
          <div class="row" style="padding-top:10px">
          
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span6">Quarter :</span>
   <select name="RegionID" class="form-control" id="Select3" data-val-required="The Quater field is required." 
   data-val-number="The field Quater must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
<option value="1">Q1</option>
<option value="2">Q2</option>
<option value="3">Q3</option>
<option value="3">Q4</option>
</select>


</div>
          </div>
            <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Month :</span>
     <select class="form-control" data-val="true" data-val-number="The field FromMonth must be a number." data-val-required="The FromMonth field is required." id="FromMonth" name="FromMonth"><option selected="selected" value="1">ม.ค.</option>
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
       <select class="form-control" data-val="true" data-val-number="The field ToMonth must be a number." data-val-required="The ToMonth field is required." id="ToMonth" name="ToMonth"><option value="1">ม.ค.</option>
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

            <div class="col-sm-1">
              <button type="button" class="btn btn-lg btn-primary bthSearch">ค้นหา</button>
            </div>
          </div>
     
         

              <div class="row" style="padding-top:10px;">
              <div class="col-sm-12">
              <div class="card ">
  <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-file " ></i> Planning 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
          
           </div>
           </div>
          </div>
        <div class="card-body card-body2">
           <div class="row">

                <div class="col-sm-12 my-auto">
                  

                  <div id="myBarChart" style="height: 370px; width: 100%;"></div>
                </div>
             </div>
             
             </div>
             </div>
             </div>
              </div>

               <div class="row" style="padding-top:10px;">
              <div class="col-sm-12">
              <div class="card ">
  <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-file " ></i> ความหมายของข้อมูลที่แสดงในกราฟ 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
          
           </div>
           </div>
          </div>
        <div class="card-body card-body2">
           <div class="row">

                <div class="col-sm-12 my-auto">
                  
                    กราฟแสดง Progress<br>
            สีน้ำเงิน คือ กราฟแสดงปริมาณงานที่รอการดำเนินการอยู่<br>
            สีส้ม คือ กราฟแสดงปริมาณงานที่ดำเนินการแล้วต้องแก้ไขผลการตรวจสอบ<br>
            สีเขียว คือ กราฟแสดงปริมาณงานที่ดำเนินการเสร็จสิ้นสมบูรณ์<br>
            สีแดงคือกราฟแสดงปริมาณงานที่เลยกำหนดการดำเนินการ 
                 
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


       <!-- Example DataTables Card-->
      <div class="row table-responsive">
      <div class="col-sm-12">
      <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Planning</div>
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

          <div class="row">
          <div class="col-sm-12">

           <div style="margin:20px 0;">
    <table class="easyui-datagrid" title="">
        
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
     
          	<div class="row " style="padding-top:50px;>
				<div class="col-md-12">
					
					<div style="display:inline-block;width:100%;">
					<ul class="timeline timeline-horizontal">
						<li class="timeline-item ">
							
							<div class="timeline-panel  alert alert-warning back-widget-set xzoom" style="height:220px;">
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
							<div class="timeline-panel alert alert-success back-widget-set xzoom" style="height:220px;">
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
							<div class="timeline-panel alert alert-danger xzoom" style="height:220px;">
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
      
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>
      </div>
      </div>


       
     

      <!-- Activity flow-->
      <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Activity Flow</div>
        <div class="card-body card-body2">
          <div class="table-responsive">
          

             <img src="<%=ResolveUrl("~/Img/Plan/ActiviyFlow.jpg")  %>" />


           
          </div>
        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>
   
    <!-- /.container-fluid-->
    <!-- /.content-wrapper-->
    <footer class="sticky-footer">
      <div class="container">
        <div class="text-center">
          <small>Copyright © Your Website 2017</small>
        </div>
      </div>
    </footer>
     </div>
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fa fa-angle-up"></i>
    </a>
    </div>
    <!-- Logout Modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
          <div class="modal-footer">
            <button class="btn btn-default" type="button" data-dismiss="modal">ยกเลิก</button>
            <a class="btn btn-primary" href="login.html">Logout</a>
          </div>
        </div>
      </div>
    </div>


    <style>
    .first-row td {
        border-top:2px solid #000 !important;
    }
</style>
    <script>
       


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



        $('.pipeline1').collapse('show');
        $('.pipeline2').collapse('show');

        $(".multiselect-ui").multiselect('selectAll', false);
        $(".multiselect-ui").multiselect('updateButtonText');


        $(document).ready(function () {

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

           

        });

        $('[data-toggle="tooltip"]').tooltip({ html: true });

      


</script>

    <!-- Page level plugin JavaScript
    <script src="<%= ResolveUrl("~/js/chart/Chart.min.js") %>"></script>
     <script src="<%= ResolveUrl("~/js/sb-admin-charts.min.js") %>"></script>
     -->
      <script src="<%= ResolveUrl("~/Js/chartNew/Chart.Canvas.js") %>"></script>
       <script src="<%= ResolveUrl("~/Js/ui/Index.js") %>"></script>


    <!-- Custom scripts for all pages-->
    <script src="<%= ResolveUrl("~/js/sb-admin.min.js") %>"></script>
    <!-- Custom scripts for this page-->

   
  </div>
</asp:Content>

