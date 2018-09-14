<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanActionBeforeCoatingRemoval.aspx.cs" Inherits="UI_Plan_PlanActionBeforeCoatingRemoval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css?ver=1.0") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js?ver=1.0") %>" type="text/javascript"></script>
      <script src="<%= ResolveUrl("~/Js/interact_v1.3.3.js?ver=1.0") %>" type="text/javascript"></script>
      <script src="<%= ResolveUrl("~/Js/jquery-ui.js?ver=1.0") %>" type="text/javascript"></script>
        <script src="<%= ResolveUrl("~/Js/Drawline.js?ver=1.0") %>" type="text/javascript"></script>
      
<style  type="text/css">

.custom-file-upload {
    display: block;
    width: auto;
    font-size: 16px;
    margin-top: 30px;
    border: 1px solid #ccc;
    label {
        display: block;
        margin-bottom: 5px;
    }
}


.table
{
	 max-width: none;
	}
	    .tblPointData
    {
    	
    	height:315px;
    	width:1030px;
    	background-color:#110c0c;
    	}

    .canvas
	{
		width:1050px;
		height:350px;
		position:absolute;
		background-color:none;
		cursor:move;
		opacity: 0.5;
    filter: alpha(opacity=80);
		}
		
		.jquery-line
{
	 border:3px;
	}
		
		
		
input.invalid { border: 1px solid #f00;
                color:Red; }
span.invalid { 
                color:Red; }
</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_BFRemovalHandler.ashx") %>"; 
     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];

      var selectObj=[];
      var point=2;

      var  x = 0, y = 0;
    
    
    </script>


   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_BFRemoval.js") %>" type="text/javascript"></script>
  <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_BFRemoval_Dragdrop.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
  <div class="container-fluid">

  <div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Action </div>
     <div class="card-body">


    

     <div class="row">
      <div class="col-sm-12">
     <div class="login-signup">
      <div class="row">
        <div class="col-sm-12 nav-tab-holder">
        <ul class="nav nav-tabs row" role="tablist">
          <li role="presentation" class=" col-sm-2"><a  href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteSurvey.aspx") %>" aria-controls="home" role="tab" data-toggle="tab">Site Survey & Digging Location</a></li>
          <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSitePreparation.aspx") %>"  >Site Preparation <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionWeatherCollection.aspx") %>"  >Weather Collection <br>&nbsp;</a></li>
             <li role="presentation" class="col-sm-2 active"><a href="#" aria-controls="CoatingDefect" role="tab" data-toggle="tab">Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>" >After Coating Removal<br>&nbsp;</a></li>
                 <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAppliedCoating.aspx") %>" >Applied Coating<br>&nbsp;</a></li>
               <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterAppliedCoating.aspx") %>">After Applied Coating<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteRecovery.aspx") %>" >Site Reovery<br>&nbsp;</a></li>
        </ul>
      </div>

      </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
          <div class="row ">

            <div class="col-sm-12 mobile-pull ">
              <article role="login" >
                <h3 class="text-center"><i class="fa fa-lock"></i>Inspection Before Coating Removal</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Existing Coat</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span48" >Coating Type </span>
    <select   class="form-control ddlCoatingTypeID" id="ddlCoatingTypeID"  >
   
  </select>
</div>
          </div>
            <div class="col-sm-6">
                <div class="input-group">
  <span class="input-group-addon" id="Span1" >Repair Length</span>
    <input type="text"    class="form-control txtRepairLength" placeholder="Repair Length" id="txtRepairLength"  />
                    <span class="input-group-addon"  >m</span>
</div>
          </div>
           
          </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
             <div class="input-group">
  <span class="input-group-addon" id="Span50" >Field Join Type </span>
    <select   class="form-control ddlFieldJoinTypeID" id="ddlFieldJoinTypeID"  >
      <option value="1">Field Join 1</option>
   <option value="2">Field Join 2</option>
   <option value="3">Field Join 3</option>
    <option value="3">Field Join 4</option>
  </select>
</div>
          </div>
            <div class="col-sm-6">
           
 <table style="width:80%; border-spacing: 10px;">
        <tr>
        <td style="width:20%">
         <span class="input-group-addon" id="Span5" >water condense :</span>
        </td>

        <td>
          <div class="funkyradio">
            <div class="funkyradio-success" style="padding-left:5px">
             <input type="radio" name="chkStatus"  value="1" id="rdActive"  class="rdActive" />
             <label for="rdActive">Yes</label>
             </div>
             </div>
        </td>

         <td>
          <div class="funkyradio">
            <div class="funkyradio-danger" style="padding-left:5px">
             <input type="radio" name="chkStatus"  value="0"  id="rdInActive" class="rdInActive"  />
             <label for="rdInActive">No</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">
           <div class="col-sm-6">
             <div class="input-group">
  <span class="input-group-addon" id="Span2" >Coating Thickness</span>
    <input type="text"    class="form-control txtCoatingThickness" placeholder="Coating Thickness" id="txtCoatingThickness"  />
     <span class="input-group-addon" id="Span12" >&#181m</span>
</div>
          </div>
             <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span3" >Holiday Test</span>
    <input type="text"    class="form-control txtHolidayTest" placeholder="Number" style="margin-right:3px;" id="txtHolidayTest"  />
     <button type="button" class="btn btn-lg bg-success btnGenerate ">Generate</button>
</div>
          </div>
          </div>

    </div>
    </div>

    </div>
    </div>
      <div class="row "  style="padding-top:20px;">
                   
                    <div class="col-sm-11">

                     <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Coating damage mapping</h4>
                    </div>
    <div class="card-body">
   

   <div class="row">
   
   <div class="col-sm-12">
     <div class="row divPoint"  style="padding-top:10px;">
      <span class="Result invisible"> </span>
      <button type="button" class="btn btn-lg bg-primary checkSelect invisible " style=" margin-right:3px;">Check</button>
      <button type="button" class="btn btn-lg bg-success addDefect  invisible" style=" margin-right:3px;"><i class="fa fa-plus"> Defect</i></button>
     <!--  X:<input class="lbPositionX" type="text" /> &nbsp;Y: <input class="lbPositionY" type="text" />-->
       
   <div id="select1" class="draggable drag-drop yes-drop text-center">1 </div>
<div id="select2" class="draggable drag-drop yes-drop  text-center">2 </div>
</div>
<div class="row "  style="padding-top:2px;">
 <div class="col-sm-1">
 <span class="important-message success">U/S Position</span>
  <img src="<%= ResolveUrl("~/Img/arrow.png") %>"  />
  <span class="lbMinLength invisible" style=" position:absolute"> 0 (m)</span>
 </div>
 <div class="col-sm-5 text-center">
   <img src="<%= ResolveUrl("~/Img/gasflow.png") %>"  />
 
 </div>
  <div class="col-sm-2 text-right" style="vertical-align: bottom;">
  <div class="row "  style="padding-top:70px;"></div>
   <h2 class="lbMaxLength" > </h2>
 </div>
</div>

  <div class="row "  style="padding-top:0px;overflow-y:scorll;">
  
  <div class="col-sm-9 table-responsive" style="height:365px;">

  <div class="canvas">
<canvas id="mycanvas"  width="1070" height="360">
			
		</canvas>


 

 </div>


 </div>

 <div class="col-sm-3">
 <img src="<%= ResolveUrl("~/Img/wdegree360.jpg") %>" style=" margin-right:10px;"/>
  </div>
   </div>
   <div class="row">
   
   <div class="col-sm-6 text-center">
   <h5 class="lbRepairLengthCaption"> Repair Length(m)</h5>
   </div>
   </div>

   


          
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          	 <button id="open_btn1" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture:Overall coating damnaged</p> </button>
          </div>
          <div class="col-sm-6">
           <button id="open_btn2" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture:Overall coating damnaged</p> </button>
          </div>
          </div>

              <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          	<div id="filelist1">
  <table id="filename1" class="table table-hover  table-fixed" style="width:100%; background-color:#ffffff;">
    <thead>
       <tr class="table-info"><th scope="col">File name</th><th scope="col">File size</th><th scope="col">Delete</th></tr>
      
    </thead>
    <tbody>
    </tbody>
  </table>
</div>
          </div>
          <div class="col-sm-6">
           	<div id="filelist2">
  <table id="filename2" class="table table-hover  table-fixed" style="width:100%; background-color:#ffffff;">
    <thead>
       <tr class="table-info"><th scope="col">File name</th><th scope="col">File size</th><th scope="col">Delete</th></tr>
      
    </thead>
    <tbody>
    </tbody>
  </table>
</div>
          </div>
          </div>
          <div class="row">
          <div class="col-sm-12">
            <h4 class="text-left">Condition of Existing Coating</h4>
          </div>
          </div>

           <div class="row" style="padding-top:10px;">
            <div class="col-sm-1">
             <button type="button" class="btn btn-lg bg-success btnPreview" style=" margin-right:3px;">Preview</button>

            </div>
               <div class="col-sm-5">
                <div class="input-group">
  <span class="input-group-addon" id="Span6" >Grith Weld Position (Distance from U/S) :</span>
    <input type="text"    class="form-control txtDegreeLength" placeholder="Grith Weld" id="txtDegreeLength"  />
  <span class="input-group-addon" id="Span7" > m</span>
</div>

          </div>

              <div class="col-sm-5">
                <div class="input-group">
  <span class="input-group-addon" id="Span4" >Seam Weld Position (Degree Position) : </span>
    <input type="text"    class="form-control txtDegree" placeholder="Seam Weld" id="txtDegree"  />
     <span class="input-group-addon" id="Span8" >  &deg;</span>
</div>

          </div>
        
              <div class="col-sm-1">
                 <button type="button" class="btn btn-lg bg-success btnNew pull-right invisible" style=" margin-right:3px;">Add</button>
              </div>
           </div>
            <div class="row" style="padding-top:10px;">
         <div class="col-sm-12 divDefectTable table-responsive" style=" overflow-x:scroll">
  <div style="width:1500px;">
  <table class="table table-bordered table-blue tblDefectTable">
   <thead>
      <tr>
         <th rowspan="2">Item</th>
         <th rowspan="2">Defect Type</th>
         <th colspan="2">Distance</th>
         <th colspan="2">Degree Position</th>
         <th rowspan="2">Degree Position</th>
         <th rowspan="2">Risk Score</th>
          <th rowspan="2">Remark</th>
         <th rowspan="2">Browse</th>
      </tr>
      <tr>
         <th>Width</th>
         <th>Length</th>
         <th>From</th>
         <th>Length(mm)</th>
      </tr>
    
   </thead>
   </table>
   </div>
      </div>
     </div>



          <div class="row" style="padding-top:10px;">
          <div class="col-sm-4">
          <div class="col-sm-6">
           <h4 class="text-left">Defect Type:</h4>
            <p>1.Crack</p>
          <p>2.Pin hole</p>
          <p>3.Blister</p>
           <p>7.Etc</p>
          </div>
          <div class="col-sm-6">
           <h4>&nbsp;</h4>
          <p>4.Chalk</p>
          <p>5.Discoloration</p>
          <p>6.Gouge</p>
          
          </div>


          </div>

           <div class="col-sm-4">
          

          <table class="table table-bordered">
   <thead>

     <th colspan="5" class="text-center">Risk score</th>
   </thead>
   <tbody>
   <tr>
   <td class="level1">1</td>
   <td class="level2">2</td>
   <td class="level3">3</td>
   <td class="level4">4</td>
   <td class="level5">5</td>
   </tr>
   </tbody>
   </table>


          </div>

          <div class="col-sm-4">
          <dlv class="col-sm-7">
           <img src="<%= ResolveUrl("~/Img/degrees-360.gif") %>" style=" margin-right:10px; width:200px;height:auto;"/>

          </dlv>
          <div class="col-sm-5">
         <h5> Degree of 
Coating condition
(Follow Flow Direction)</h5>
          </div>
          </div>
          </div>
<div class="row" style="padding-top:10px;">


          <div class="col-sm-12 text-left">
       
        <button type="button" class="btn btn-lg bg-success btnSave ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
          </div>
          </div>

          </div>

    </div>
    </div>
                            <!--- Body --->

       
      
         
         <!--- Body --->
                    </div>
                    </div>

            

              </article>
            </div>

         
          </div>

        
          <!-- end of row -->
        </div>
        <!-- end of home -->

     

       

  </div>
  </div>
  </div>
     </div>


       
     </div>
     </div>
     </div>
     </div>


<!--Modal-->


<!-- End Modal-->
    </div>
</asp:Content>

