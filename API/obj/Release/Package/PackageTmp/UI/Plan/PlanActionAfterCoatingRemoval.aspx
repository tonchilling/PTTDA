<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanActionAfterCoatingRemoval.aspx.cs" Inherits="UI_Plan_PlanActionAfterCoatingRemoval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>
      <script src="<%= ResolveUrl("~/Js/interact_v1.3.3.js") %>" type="text/javascript"></script>

      <script src="<%= ResolveUrl("~/Js/jquery-ui.js") %>" type="text/javascript"></script>
<style  type="text/css">

    
    #outer-dropzone {
  height: 140px;
}

#inner-dropzone {
  height: 80px;
}

.table
{
	 max-width: none;
	}

    .tblPointData
    {
    	
    	height:315px;
    	width:1016px;
    	background-color:#110c0c;
    	}

    .canvas
	{
		width:1040px;
		height:324px;
		position:absolute;
		background-color:none;
		cursor:move;
		opacity: 0.5;
    filter: alpha(opacity=80);
		}
		
		/*.box
		{
			position:absolute;
			width:20px;
			height:20px;
			background-color:green;
			 border: dashed 4px transparent;
  border-radius: 10px;
   line-height:0px;
            padding-top:3px;

  transition: background-color 0.3s;
  
			
			}*/
			
			
			input.invalid { border: 1px solid #f00;
                color:Red; }
span.invalid { 
                color:Red; }
    
</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_AfterRemovalHandler.ashx") %>"; 
     var ImgWalkness="<%= ResolveUrl("~/Img/Pipline.png") %>"; 


     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];

      var selectObj=[];
      var point=2;

      var  x = 0, y = 0;
    
    
    </script>


   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_AfterRemoval.js?ver=2.0") %>" type="text/javascript"></script>
 <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_AfterRemoval_Dragdrop1.js?ver=2.0") %>" type="text/javascript"></script>
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
             <li role="presentation" class="col-sm-2 "><a href="<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>" >Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2 active"><a href="#" aria-controls="Environment" role="tab" data-toggle="tab" >After Coating Removal<br>&nbsp;</a></li>
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
                <h3 class="text-center"><i class="fa fa-lock"></i>Inspection After Coating Removal</h3>
   
                  
      <div class="row "  style="padding-top:20px;">
                   
                    <div class="col-sm-11">

                     <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Coating damage mapping</h4>
                    </div>
    <div class="card-body">
    <div class="row" style="padding-top:10px;">
             <div class="col-sm-4">
          <div class="input-group">
  <span class="input-group-addon" id="Span3" >pH</span>
    <input type="text"    class="form-control txtPH" placeholder="pH" style="margin-right:3px;" id="txtPH"  />
    
</div>
<span>(Under coating / Pipeline surface)</span>
          </div>
           <div class="col-sm-4">
          <div class="input-group">
  <span class="input-group-addon" id="Span6" >Defects</span>
    <input type="text"    class="form-control txtDefectNumber" placeholder="Defect Number" style="margin-right:3px;" id="txtDefectNumber"  /> <button type="button" class="btn btn-lg bg-success btnGenerate ">Generate</button>
</div>
          </div>
          </div>

   <div class="row">
   
   <div class="col-sm-12">
     <div class="row divPoint"  style="padding-top:10px;">
      <button type="button" class="btn btn-lg bg-primary checkSelect invisible" style=" margin-right:3px;">Check</button>
      <button type="button" class="btn btn-lg bg-success addDefect invisible" style=" margin-right:3px;"><i class="fa fa-plus"> Defect</i></button>

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
  <div class="row "  style="padding-top:10px;">
  <div class="col-sm-9 table-responsive" style="height:365px;">

   <div class="canvas">
<canvas id="mycanvas"  width="1070" height="360">
			
		</canvas>


 

 </div>


 </div>

 <div class="col-sm-2">
 <img src="<%= ResolveUrl("~/Img/wdegree360.jpg") %>" style=" margin-right:10px;"/>
  </div>

   </div>
    <div class="row">
   
   <div class="col-sm-6">
    <h4 class="text-center lbRepairLengthCaption ">Repair Length(m)</h4>
   </div>
   </div>

    <!--Defect on bared pipe(m)-->

   <div class="card">
  <div class="card-header">
    <h4 class="text-left ">Defect on bared pipe</h4>
  </div>

  <div class="card-body">
            <div class="row" style="padding-top:10px;">
            <div class="col-sm-1">
             <button type="button" class="btn btn-lg bg-success btnPreview" style=" margin-right:3px;">Preview</button>

            </div>
                <div class="col-sm-5">
                <div class="input-group">
  <span class="input-group-addon" id="Span7" >Grith Weld Position (Distance from U/S) :</span>
    <input type="text"    class="form-control txtDegreeLength " disabled placeholder="Grith Weld" id="txtDegreeLength"  />
  <span class="input-group-addon" id="Span8" > m</span>
</div>

          </div>

              <div class="col-sm-5">
                <div class="input-group">
  <span class="input-group-addon" id="Span9" >Seam Weld Position (Degree Position) : </span>
    <input type="text"    class="form-control txtDegree " disabled placeholder="Seam Weld" id="txtDegree"  />
     <span class="input-group-addon" id="Span10" > &deg;</span>
</div>

          </div>
              <div class="col-sm-1">
                 <button type="button" class="btn btn-lg bg-success btnNew pull-right invisible" style=" margin-right:3px;">Add</button>
              </div>
           </div>
            <div class="row" style="padding-top:10px;">
      <div class="col-sm-12 divDefectTable table-responsive" style=" overflow-x:scroll">
  <div style="width:2500px;">
  <table class=" table-blue" >
   <thead>
      <tr>
         <th rowspan="2">Item</th>
         <th rowspan="2">Defect Type</th>
           <th rowspan="2">Degree Position</th>
         <th colspan="3">Size(cm.)</th>
         <th colspan="4">Pipe Thk. around defedt(mm.)</th>
         <th colspan="2">Distance</th>
         <th rowspan="2">Risk Score</th>
         <th rowspan="2">Repaire Method</th>
          <th rowspan="2">Remark</th>
      </tr>
      <tr>
         <th>W</th>
         <th>L</th>
         <th>D</th>
         <th>1</th>
         <th>2</th>
         <th>3</th>
         <th>4</th>
         <th>From</th>
         <th>Length</th>
      </tr>
   </thead>
   </table>
 </div>
      </div>
     </div>



    <div class="row" style="padding-top:20px;">
    <div class="col-sm-4">
    <h4>Pipe Surface Condition :</h4>
    </div>
    
    </div>
      <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">Pit = Pitting Corrosion (การกัดกร่อนลักษณะคล้ายรูเข็ม)</div>
       <div class="col-sm-3">CR = Crack(รอยแตกบนผิวท่อ)</div>
        <div class="col-sm-4">SWD = Seam Weld Defect (สิ่งผิดปกติบนแนวเชื่อมตามยาว)</div>
         <div class="col-sm-2">PD = Plain Dent (รอยบุบ)</div>
      </div>
       <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">Uni = Uniform corrosion (การกัดกร่อนเฉพาะจุด)</div>
       <div class="col-sm-3">GC = General Corrosion (การกัดกร่อนทั่วสภาพพื้นผิว)</div>
        <div class="col-sm-4">GWD = Girth Weld Defect (สิ่งผิดปกติบนแนวเชื่อมตามเส้นรอบวง)</div>
         <div class="col-sm-2">KD = Kinked Dent (รอบบุบพับ)</div>
      </div>
         <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">GD = Dent with Gouge (รอยบุบพร้อมรอยข่วน)</div>
       <div class="col-sm-3">G = Gouge (รอยข่วน)</div>
    
      </div>
   </div>
   </div>


   <div class="row" style="padding-top:20px;"></div>
   <!--Wall Thickness Inspection-->
        
<div class="card">
<div class="card-header">
        <h4 class="text-left">Wall Thickness Inspection</h4>
</div>


<div class="card-body">

   <div class="row" >
   <div class="col-sm-8  table-responsive">
           
<canvas id="canvaswalkness"  width="1000" height="300">
			
		</canvas>
   </div>
   <div class="col-sm-4">
    <img src="<%= ResolveUrl("~/Img/wdegree360.jpg") %>" style=" margin-right:10px;"/>
   </div>
   </div>

     <div class="row" style="padding-top:10px;">
     <div class="col-sm-3">
       <h5 class="text-left">Ultrasonic Thickness Equipment</h5>
     </div>
     <div class="col-sm-3">
       <div class="input-group">
  <span class="input-group-addon" id="Span1" >Brand</span>
    <input type="text"    class="form-control txtBrand" placeholder="Brand" style="margin-right:3px;" id="txtBrand"  />
    </div>
     </div>
     <div class="col-sm-3">
       <div class="input-group">
  <span class="input-group-addon" id="Span2" >Model</span>
    <input type="text"    class="form-control txtModel" placeholder="Model" style="margin-right:3px;" id="txtModel"  />
    </div>
     </div>
      <div class="col-sm-3">
       <div class="input-group">
  <span class="input-group-addon" id="Span4" >S/N</span>
    <input type="text"    class="form-control txtSN" placeholder="S/N" style="margin-right:3px;" id="txtSN"  />
    </div>
     </div>
     </div>
     <div class="row" style="padding-top:10px;">
       <div class="col-sm-3 offset-sm-3">
       <div class="input-group">
  <span class="input-group-addon" id="Span5" >Guage</span>
    <input type="text"    class="form-control txtGuage" placeholder="Guage" style="margin-right:3px;" id="txtGuage"  />
    </div>
     </div>
     </div>
       <div class="row" style="padding-top:10px;">
            <div class="col-sm-12">
             <button type="button" class="btn btn-lg bg-success btnPreview1 invisible" style=" margin-right:3px;">Preview</button>
            </div>
           </div>
  <div class="row" style="padding-top:10px;">
   <div class="col-sm-12 divWallThickness">
   <table class="table table-bordered table-blue tblWallThickness">
   <thead>
      <tr>
         <th rowspan="2">Position No.</th>
         <th colspan="6" class="text-center">Clock position</th>
         
      </tr>
      <tr>
         <th>0</th>
         <th>90</th>
         <th>135</th>
         <th>180</th>
         <th>225</th>
         <th>270</th>
      </tr>
   </thead>
   <tfoot>
         <tr>
         <th colspan="5"></th>
         <th>Minimum</th> 
          <th><span class="lbMinimum"></span></th> 
      </tr>
        <tr>
         <th colspan="5"></th>
         <th>Average</th> 
            <th><span class="lbAverage"></span></th> 
      </tr>
   </tfoot>
   </table>
   </div>
  </div>
   <div class="row" style="padding-top:10px;">
   <div class="col-sm-6">
   <h4>Number of  Wall thickness inspection : </h4>
   </div>
   </div>
      <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">Repair length < 1 m = 2 Position</div>
      </div>
       <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">Repair length 1-5 m = 4 Position</div>
      </div>
         <div class="row" style="padding-top:10px;">
      <div class="col-sm-3">Repair length > 5 m = 6 Position</div>
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
</asp:Content>

