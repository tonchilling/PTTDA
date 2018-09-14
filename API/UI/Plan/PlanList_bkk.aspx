<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanList.aspx.cs" Inherits="UI_Plan_PlanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


   <!-- <script src="<%= ResolveUrl("~/Js/ui/MenuPage.js") %>" type="text/javascript"></script>-->

       <script src="<%= ResolveUrl("~/Js/jquery.easyui.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Js/datagrid-groupview.js?v2") %>" type="text/javascript"></script>


        <link href="<%= ResolveUrl("~/Css/easyui.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Css/icon.css") %>" rel="stylesheet" type="text/css" />
      <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>

  

    <script language="javascript">
     var planAtion1= "<%= ResolveUrl("~/UI/Plan/PlanActionSiteSurvey.aspx") %>"; 
     var planAtion2= "<%= ResolveUrl("~/UI/Plan/PlanActionSitePreparation.aspx") %>"; 
     var planAtion3= "<%= ResolveUrl("~/UI/Plan/PlanActionWeatherCollection.aspx") %>"; 
     var planAtion4= "<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>"; 
     var planAtion5= "<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>"; 
     var planAtion6= "<%= ResolveUrl("~/UI/Plan/PlanActionAppliedCoating.aspx") %>"; 
     var planAtion7= "<%= ResolveUrl("~/UI/Plan/PlanActionAfterAppliedCoating.aspx") %>"; 
     var planAtion8= "<%= ResolveUrl("~/UI/Plan/PlanActionSiteRecovery.aspx") %>"; 




    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_PlaningHandler.ashx") %>"; 
    
      var planSpecPOURL= "<%= ResolveUrl("~/ASHX/Plan/T_PlanSpecPOHandler.ashx") %>"; 
  var createPlan= "<%= ResolveUrl("~/UI/Plan/CreatePlan.aspx") %>"; 
  

    </script>

        <script src="<%= ResolveUrl("~/Js/ui/Plan/T_PlanList.js") %>" type="text/javascript"></script>

     <style type="text/css">
         
         
         .modal:nth-of-type(even) {
    z-index: 1042 !important;
}
.modal-backdrop.in:nth-of-type(even) {
    z-index: 1041 !important;
}






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
	text-decoration:none;
	}
	
    .modal-dialog 
    {
    	
    width: 1020px;
    margin: 30px auto;
      
}


.btn .badge {
    position: relative;
    top: -1px;
    float: right;
}

.badge {
    display: inline-block;
  
    font-size: 28px;
    font-weight: 700;
    line-height: 1;
    text-align: center;
    white-space: nowrap;
  padding-bottom:30px;
    border-radius: .25rem;
}



.btn-circle-lg {
  width: 209px;
  height: 209px;
  text-align: center;
  padding: 13px 0;
  font-size: 30px;
  line-height: 2.00;
  border-radius: 200px;
  position:absolute;
}
 
 
 
 .chk-lg {
    width: 60px;
    height: 60px;
    cursor: pointer;
    color:#333333;
}


.float_center {
  float: right;

  position: relative;
 
  right:35%;
  text-align: left;
}


 .badgebox + .badge {
    text-indent: -999999px;
    width: 36px;
    height:28px;
}


.modal-footer {
    -ms-flex-align: center;
    -ms-flex-pack: end;
    padding: 15px;
    border-top: 1px solid #e9ecef;
}

 .datepicker {
      z-index: 1600 !important; /* has to be larger than 1050 */
    }




    @color: #aae1fd;
#demo1 {
  position: relative;
  margin-left:35px;
}


#demo1 ul {
   
    border-left: .25em solid #449d44;
    padding-bottom:-5px;
  
}

#demo1 ul # ul {
    margin-top: -16px;
    margin-left: 16px;
    
}

#demo1 li 
{
	list-style:none;
  /*  position: relative;
    bottom: -1.25em;*/
}

#demo1 li:before {
    content: "";
    display: inline-block;
    width: 2em;
    height: 0;
    position: relative;
   /* left: -25px;*/
    border-top: .25em solid #449d44;
   margin-left:-40px;
}

#demo1 ul #demo1 ul:before, h3:before, li:after {
   
}

/*
h3 {
    position: absolute;
    top: -1em;
    left: 1.75em;
}

h3:before {
    left: -2.25em;
    top: .5em;
}*/
    
    
    .circle {
    background: #449d44;
    border-radius: 40px;
    color: white;
    height: 80px;
    font-weight: bold;
    width: 80px;
  padding-left:2px;
   display: table;
}
.circle p {
    vertical-align: middle;
    display: table-cell;
    color:#ffffff;
}
    
    
    
input[type='checkbox'] {
    width: 24px;
    height: 24px;
    cursor: pointer;
}




    
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Plan List </div>
     <div class="card-body">

      <div class="row table-responsive">
      <div class="col-sm-12">
      <div class="card mb-3">
        <div class="card-header card-headerBlue">
        <div class="row">
         <div class="col-sm-6">
          <i class="fa fa-searcg fa-2x" style="color:#007bff" ></i>  Planning
         </div>
           <div class="col-xs-6 text-right">
             <button type="button" class="btn btn-lg btn-primary    btnAdd" style=" visibility:hidden" >Create Plan</button>
             <button type="button" class="btn btn-lg btn-primary    btnExport" style=" visibility:hidden">Export Plan</button>
             <button type="button" class="btn btn-lg btn-primary    btnConfirm" style=" visibility:hidden">Confirm Inspection Plan</button>
             
           
           
           </div>
          </div>
          </div>
        <div class="card-body card-body2 ">

       
          
           <div class="row" style="padding-top:10px;">
                <div class="col-sm-3">

              

           <div class="input-group">
  <span class="input-group-addon" id="Span20">Region :</span>
   <select name="ddlRegion" class="form-control" id="ddlRegion" data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>
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
  <span class="input-group-addon" id="Span19">Dig From</span>
       <select class="form-control" data-val="true" data-val-number="The field ToMonth must be a number." data-val-required="The ToMonth field is required." id="ddlDIGFrom" name="ddlDIGFrom">

</select>


</div>
          </div>
             
         <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span14">Year :</span>
                            <select class="form-control ddlYear" data-val="true" data-val-number="The field CustomerTypeID must be a number."
                             data-val-required="The CustomerTypeID field is required." id="ddlYear"  name="ddlYear"><option selected="selected" value="0">ทั้งหมด</option>
<option value="2015">2015</option>
<option value="2016">2016</option>
<option value="2017">2017</option>
<option value="2018">2018</option>
<option value="2019">2019</option>
<option value="2020">2020</option>
<option value="2019">2021</option>
<option value="2020">2022</option>

</select>
   

</div>
          </div>
     
      </div>

        <div class="row" style="padding-top:10px;">

       
            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span15">Pipline Type:</span>
                            <select class="form-control" data-val="true" data-val-number="The field CustomerTypeID must be a number." data-val-required="The CustomerTypeID field is required." id="ddlPipeline" name="CustomerTypeID"><option selected="selected" value="0">ทั้งหมด</option>

</select>
   

</div>
          </div>
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span16">Assert Owner</span>
                            <select class="form-control" data-val="true" data-val-number="The field Assert Owner must be a number." data-val-required="The Assert Owner field is required." id="ddlAssertOwner" name="ddlAssertOwner"><option selected="selected" value="0">ทั้งหมด</option>

</select>
   

</div>
          </div>
         

          <div class="col-sm-sm-3">
            <button type="button" class="btn btn-lg btn-primary bthSearch">ค้นหา</button>
          </div>


          </div>

       <div class="row" style="padding-top:10px;">
                <div class="col-sm-12">
         <table class="easyui-datagrid table-blue"  title="">
        
        <thead data-options="frozen:true">
                <tr>
                    
                     <th data-options="field:'ck',checkbox:true,width:120,align:'center'" rowspan="2">RC</th>
                    <th data-options="field:'Edit',width:80,align:'center',formatter:editFormat"  rowspan="2">Edit</th>
                     <th data-options="field:'Delete',width:100,align:'center',formatter:deleteFormat"  rowspan="2">Delete</th>
                    <th data-options="field:'RouteCode',width:80,align:'center'" rowspan="2">RC</th>
                    <th data-options="field:'StartEndPipeline',width:100,align:'center'" colspan="2">Pipline</th>
                    <th data-options="field:'RegionCode',width:60,align:'center'" rowspan="2">Region</th>
                    <th data-options="field:'DIGFrom',width:80,align:'center'" rowspan="2">Dig From</th>
                    <th data-options="field:'RiskScore',width:60,align:'center',formatter:serFormat" rowspan="2">Serverity</th>
                    <th data-options="field:'Progress',width:60,align:'center',formatter:progressFormat" rowspan="2">Progress</th>
                   <th data-options="field:'TimeLine',width:120,align:'center',formatter:timelineFormat"  rowspan="2">Timeline</th>
                     
                </tr>
                <tr>
               
              
                    <th data-options="field:'StartEndPipeline',width:150,align:'center'">Start - End</th>
                    <th data-options="field:'KP',width:80,align:'center'">KP</th>
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
            
                <th data-options="field:'jan_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'jan_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'jan_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'jan_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
              

                
                <th data-options="field:'feb_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'feb_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'feb_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'feb_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                 

                
                <th data-options="field:'mar_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'mar_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'mar_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'mar_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                  

                <th data-options="field:'apr_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'apr_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'apr_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'apr_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                  


                <th data-options="field:'may_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'may_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'may_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'may_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                 




                <th data-options="field:'jun_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'jun_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'jun_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'jun_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                 


                <th data-options="field:'jul_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'jul_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'jul_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'jul_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                 



                <th data-options="field:'aug_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'aug_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'aug_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'aug_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                 


                  
                <th data-options="field:'sep_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'sep_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'sep_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'sep_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                

                       <th data-options="field:'oct_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'oct_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'oct_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'oct_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
               


                  
                       <th data-options="field:'nov_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'nov_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'nov_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'nov_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                  

                     <th data-options="field:'dec_1color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">1</th>
                <th data-options="field:'dec_2color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">2</th>
                <th data-options="field:'dec_3color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">3</th>
                <th data-options="field:'dec_4color',width:80,align:'center',styler:weekStyle,formatter:weekFormat">4</th>
                


                
            </tr>
        </thead>
    </table>
          </div>
          </div>


           <div class="row mb-5" style="padding-top:30px;"></div>
          	<div class="row ">
				<div class="col-md-12">
					
					<div style="display:inline-block;width:100%;">
					<ul class="timeline timeline-horizontal">
						<li class="timeline-item ">
							
							<div class="timeline-panel  alert alert-danger back-widget-set xzoom" style="height:220px;">
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




    <div class="modal modalConfirmInspection myModal1  fade" id="SummaryDistance" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H1"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Confirm Inspection Plan</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body ">


        <div class="row" style="padding-top:10px;">
         <div class="col-sm-6">
          <label for="chk1" class="btn btn-success " style="padding-right:3px;width:50%">Planner <input type="checkbox" id="chk1" class="badgebox"><span class="badge">&check;</span></label>
         </div>
         <div class="col-sm-6">
         	<a href="#aboutModal"  class="btn btn-circle-lg btn-primary " style="padding-top:25px;">
         <table class="float_center"><tr><td>
            <input type=checkbox class="chk-lg " />
          </td></tr>
          <tr><td>
       <input type=checkbox class="chk-lg" />
       </td></tr>
       </table>
       
             </a>
         </div>
          </div>
            <div class="row" style="padding-top:10px;">
         <div class="col-sm-6">
          <label for="chk2" class="btn btn-success " style="padding-right:3px;width:50%">วิศวกร รท.วรก. <input type="checkbox" id="chk2" class="badgebox"><span class="badge">&check;</span></label>
         </div>
          </div>

         <div class="row" style="padding-top:10px;">
         <div class="col-sm-6">
          <label for="chk3" class="btn btn-success" style="padding-right:3px;width:50%">วิศวกร รท.วรก. <input type="checkbox" id="chk3" class="badgebox"><span class="badge">&check;</span></label>
         </div>
          </div>

             <div class="row" style="padding-top:10px;">
         <div class="col-sm-6">
          <label for="chk4" class="btn btn-success" style="padding-right:3px;width:50%">ผจ.ฝ่าย(วรก.) <input type="checkbox" id="chk4" class="badgebox"><span class="badge">&check;</span></label>
         </div>
          </div>
            <div class="row" style="padding-top:10px;">
         <div class="col-sm-6">
          <label for="chk5" class="btn btn-success" style="padding-right:3px;width:50%">ผุู้ช่วยระบบท่อ <input type="checkbox" id="chk5" class="badgebox"><span class="badge">&check;</span></label>
         </div>
          </div>


      </div>
     

     
       <div class="modal-footer">
       
         <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
         <button type="button" class="btn btn-lg btn-default btnClose" >ปิด</button>
      </div>
    </div>
  </div>
</div>

   <div class="modal  myPlanSpectPO  fade" id="myPlan"  tabindex="-1  role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H2"> <i class="glyphicon glyphicon-globe  fa-2x fa-spin" style="color:#1363a7"></i></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body ">


        <div class="row" style="padding-top:10px;">
        <div class="col-sm-1">
        <h4 class="lbPlan">Spec</h4>
        </div>
         <div class="col-sm-10">
     
     <div class="Progress">
  <div class="progress-bar progress-bar-success " role="progressbar" aria-valuenow="40"
  aria-valuemin="0" aria-valuemax="100" style="width:40%">
  <h4>  40% </h4>
  </div>
</div>
         </div>
          </div>

          <div class="row">
          <div class="col-sm-1">
          </div>

          <div class="col-sm-10">
          <div class="card invisible pbPO">
          <div class="card-header">
          <span >Progress</span>
          </div>
          
          <div class="card-body card-body2 ">
            <div class="circle">
                <p>PROCESS</p>
            </div>
          <div id="demo1"  >
      
  <ul>
  
  <li class="connect" ><label><input type="checkbox" class="chkPO chkPO10"/> PR:10%</label>
    <ul class="accounts">
      <li ><label>กระบวนการจัดหา</label>
        <ul class="subaccounts">
          <li class="connect"><label>ประมูล</label>
          <label><input type="checkbox" class="chkPO chkPO30" /> ชี้แจงแบบ : 30%</label> <label><input type="checkbox" class="chkPO chkPO40"/> ยื่นซอง : 40%</label><label>
          <input type="checkbox" class="chkPO chkPO601"/> สรุปผู้จ้าง : 60%</label>
          </li>
          
          <li>
            <label><input type="checkbox" class="chkPO chkPO602"/> จัดจ้างตรง 60%</label>
      
      </li>
      </ul>
      </li>
      <li><label>ออก PO</label>
          <label><input type="checkbox" class="chkPO chkPO70"/> กรรมการจัดหา : 70%</label>
           <label><input type="checkbox" class="chkPO chkPO80"/> ผจ.จบ.: 80%</label><label><input type="checkbox" class="chkPO chkPO90"/> ผู้อนุมัติ : 90%</label>
          </li>
      
       </ul>
       </li>
    <li><label><input type="checkbox" class="chkPO chkPO100"/> ผู้รับจ้างรับ PO :100%</label> </li>
    </ul>
    



</div>
         </div>
            </div>
          </div>
          
          </div>
 
   <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-5">
           <div class="input-group divComplete">
  <span class="input-group-addon" id="Span1" >% Complete:</span>
     <input   class="form-control txtComplete" type='text' id="txtComplete" placeholder="กรุณาระบุ % ความคืบหน้าของ Spec"  />
   

</div>
          </div>
        <div class="col-sm-5">
              <div class="row">
       

<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span46" >Start Date </span>
    <input type="text" class="form-control datetimepicker  txtStartDate" id="txtStartDate">
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>

      
                   </div>
                
          </div>
          </div>
            <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span24" >Note :</span>
     <textarea   class="form-control txtNote"  id="txtNote" placeholder="บันทึกข้อความ" cols=3  ></textarea>
   

</div>
<br />
<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span3" >Event Date </span>
    <input type="text" class="form-control datetimepicker  txtEventDate" id="txtEventDate">
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>

  <div class="input-group divPONumber invisible" style="padding-top:10px;">
  <span class="input-group-addon" id="Span2" >PO Number :</span>
     <input type="text"   class="form-control txtPONumber "  id="txtPONumber" placeholder="PO Number"  ></textarea>
   

</div>
          </div>

              <div class="col-sm-5">
              <div class="row">
            <div class="input-group">
  <span class="input-group-addon" id="Span47" >End Date </span>
    <input type="text"    class="form-control txtEndDate datetimepicker" id="txtEndDate"  />
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
                   </div>
                   <div class="row" style="padding-top:10px;">
                     <div class="input-group divNote invisible" >
                         
                      <textarea   class="form-control txtEditNote"  id="txtEditNote" placeholder="บันทึกข้อความ" cols=3  ></textarea>
   

                  </div>
                   </div>
                   <div class="row" style="padding-top:10px;">
                  
                      <button type="button" class="btn btn-lg btn-info btnEditPlanDate" style="margin-right:5px;">Edit Plan Date</button>
                       <button type="button" class="btn btn-lg btn-success btnSavePlanDate invisible" style="margin-right:5px;">บันทึก Plan Date</button>
                          <button type="button" class="btn btn-lg btn-default btnClosePlanDate invisible" style="margin-right:5px;" >ยกเลิก</button>
                   </div>
          </div>

          
          </div>
        
     

     
       <div class="modal-footer">
      
        <button type="button" class="btn btn-lg btn-success btnSaveSpecPO">บันทึก</button> 
         <button type="button" class="btn btn-lg btn-success btnCreateAction invisible">สร้าง/แก้ไข</button>
         <button type="button" class="btn btn-lg btn-default btnClose" >ปิด</button>
      
      
        
      </div>

       <div class="row" style="padding-bottom:10px;">
       <div class="col-sm-1"></div>
        <div class="col-sm-10">
         <div id="divSpec" class="card">
         <div class="card-body" >
         <div class="table-responsive" style=" height:180px;">
  <table id="filenames" class="table table-hover  table-fixed tblHistory" style="width:100%; background-color:#ffffff;">
    <thead>
       <tr class="table-info"><th scope="col">Date</th><th scope="col">Status</th><th scope="col">Note</th><th scope="col">Create By</th></tr>
      
    </thead>
    <tbody>
    <tr>
    <td>05 มกราคม 2561</td>
      <td>20% อยู่ระหว่างการดำเนินการวางแผน</td>
    </tr>

     <tr>
    <td>15 มกราคม 2561</td>
      <td>60% Spec รอการตรวจสอบ</td>
    </tr>
    </tbody>
  </table>
  </div>
  </div>
</div>
</div>
       </div>


    </div>
  </div>
</div>










    </div>

    

    
  
</asp:Content>

