<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="InspectionData2_bk.aspx.cs" Inherits="UI_Plan_InspectionData2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Js/boostrap.table.js" type="text/javascript"></script>
<script type="text/javascript">


    window.onload = function () {

        //  LoadTable();

        $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });

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
             <table class="table table-bordered ">
            <thead>
                            <tr class="bg-primary">
                                <th style="width:250px"  rowspan="2">Item</th>
                                <th style="width:250px"  rowspan="2">RC</th>
                                  <th style="width:250px"  colspan="2">Pipeline Section</th>
                                <th width="160"  rowspan="2">Region</th>
                                <th width="160"  rowspan="2">Dig From</th>
                                <th width="160"  rowspan="2">Serverity</th>
                                 <th style="width:250px"  rowspan="2">Progress</th>
                                    <th width="160" colspan="4">ม.ค.</th>
                                    <th width="160" colspan="4">ก.พ.</th>
                                    <th width="160" colspan="4">มี.ค.</th>
                                    <th width="160" colspan="4">เม.ย.</th>
                                    <th width="160" colspan="4">พ.ค.</th>
                                    <th width="160" colspan="4">มิ.ย.</th>
                                    <th width="160" colspan="4">ก.ค.</th>
                                    <th width="160" colspan="4">ส.ค.</th>
                                    <th width="160" colspan="4">ก.ย.</th>
                                    <th width="160" colspan="4">ต.ค.</th>
                                    <th width="160" colspan="4">พ.ย.</th>
                                    <th width="160" colspan="4">ธ.ค.</th>
                                     <th width="160"  rowspan="2">Remark</th>
                            </tr>


                            <tr class="bg-primary ">
                             
                           
                            <td>Start-End</td>
                           <td>KP</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                            </tr>
                        </thead>
                        <tbody>

                          <tr class="bg-danger  accordion-toggle" data-toggle="collapse"  data-target=".pipeline1">
                                        <td colspan="57"><a class="detail-icon text-white" href="javascript:"><i class="glyphicon glyphicon-wrench fa-2x" aria-hidden="true"></i>&nbsp;Transmission Pipeline</a></td>
                                    </tr>

                                        <tr  class=" first-row pipeline1"  >
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">1</td>
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">
                                                        RC0650
                                                    </td>
                                                     

                                                    <td rowspan="2">BV9-BV20</td>
                                                    <td rowspan="2">22+399</td>
                                                    <td  style="text-align: center;" rowspan="2">9</td>
                                                    <td  style="text-align: center;" rowspan="2">Severe Dent</td>
                                                    <td  class="text-center" style="padding: 8px 0px; text-align: center; " rowspan="2">
                                                        <a href="#" style="color:Red">High</a>
                                                    </td>
                                                     <td class="month-td text-center">
                                                     Plan
                                                        </td>
                                                        <td class="month-td text-center bg-info">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">ปท.3 ปอก.</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                       
                                                        </td>
                                                        <td class="month-td text-center  bg-info">

                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" >
                                                                
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td rowspan="2" class="month-td text-center">
                                                        </td>
                                                </tr>
                                                  <tr class="hiddenRow pipeline1">
                                                  <td class="month-td text-center">
                                                     Actual
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                       
                                                </tr>
                        
                             <tr class="bg-danger accordion-toggle" data-toggle="collapse"  data-target=".pipeline2">
                                        <td colspan="57"><a class="detail-icon text-white" href="javascript:"><i class="glyphicon glyphicon-wrench fa-2x" aria-hidden="true"></i>&nbsp;IPP/SPP Pipeline</a></td>
                                    </tr>

                                    <tr class="alert-warning pipeline2 accordion-toggle" data-toggle="collapse"  data-target=".subpipeline2">
                                     <td></td>   <td colspan="56"><a class="detail-icon text-dark" href="javascript:">Gas Transmission Asset (GTA-สทพ.)</a></td>
                                    </tr>

                                                   <tr  class=" first-row pipeline2 subpipeline2"  >
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">1</td>
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">
                                                       RC4401
                                                    </td>
                                                     

                                                    <td rowspan="2">บริษัท ไทยออยล์ เพาเวอร์ จำกัด</td>
                                                    <td rowspan="2">0+921</td>
                                                    <td  style="text-align: center;" rowspan="2">1</td>
                                                    <td  style="text-align: center;" rowspan="2">Life extension</td>
                                                    <td  class="text-center" style="padding: 8px 0px; text-align: center; " rowspan="2">
                                                        <a href="#" style="color:Red">High</a>
                                                    </td>
                                                     <td class="month-td text-center">
                                                     Plan
                                                        </td>
                                                        <td class="month-td text-center bg-info">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">ปท.3 ปอก.</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                       
                                                        </td>
                                                        <td class="month-td text-center  bg-info">

                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" >
                                                                
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td rowspan="2" class="text-center">
                                                        ประเมินขยายอายุใช้งาน ตามมติ กพช.
                                                        </td>
                                                </tr>
                                                  <tr class="hiddenRow pipeline2 subpipeline2">
                                                  <td class="month-td text-center">
                                                     Actual
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>

                                    
                                    <tr class="alert-warning pipeline2 accordion-toggle" data-toggle="collapse"  data-target=".subpipeline3">
                                     <td></td>   <td colspan="56"><a class="detail-icon" href="javascript:">Gas Transmission Assert</a></td>
                                    </tr>

                                                   <tr  class=" first-row pipeline2 subpipeline3"  >
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">1</td>
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="2">
                                                        15/10/2017
                                                    </td>
                                                     

                                                    <td rowspan="2">BV9-BV20</td>
                                                    <td rowspan="2">22+399</td>
                                                    <td  style="text-align: center;" rowspan="2">9</td>
                                                    <td  style="text-align: center;" rowspan="2">DCVG</td>
                                                    <td  class="text-center" style="padding: 8px 0px; text-align: center; " rowspan="2">
                                                        <a href="#" style="color:Red">High</a>
                                                    </td>
                                                     <td class="month-td text-center">
                                                     Plan
                                                        </td>
                                                        <td class="month-td text-center bg-info">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">ปท.3 ปอก.</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                       
                                                        </td>
                                                        <td class="month-td text-center  bg-info">

                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center  bg-info">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" >
                                                                
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td  class=" text-center">
                                                        </td>
                                                </tr>
                                                  <tr class="hiddenRow pipeline2 subpipeline3">
                                                  <td class="month-td text-center">
                                                     Actual
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Spec
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    PO
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                        </td>
                                                        <td class="month-td text-center bg-success">
                                                         <a title=""  class="" href="PlanEdit.aspx" data-original-title='    <div class="text-left">IPP/SPP Pipeline</div>&#10;    <div class="text-left">Gas Transmission Assert</div>&#10;    <div class="text-left">DCVG</div>&#10;    <div class="text-left text-danger">High</div>&#10;    <div class="text-left">RC:15/10/2017</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    Action
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        
                                                         <td  class="text-center">
                                                        </td>
                                                </tr>
                                                
                                  
                                               
                                           
                                              

                                                </tbody>
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
							
							<div class="timeline-panel  alert alert-danger back-widget-set xzoom">
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
							<div class="timeline-panel alert alert-success back-widget-set xzoom">
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
							<div class="timeline-panel alert alert-danger xzoom">
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

