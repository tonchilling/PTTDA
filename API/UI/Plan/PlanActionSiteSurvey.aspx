<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" 
    CodeFile="PlanActionSiteSurvey.aspx.cs" Inherits="UI_Plan_PlanActionSiteSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>

    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>

   <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_SiteSurvey.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_SiteSurveyHandler.ashx") %>"; 
     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];

      
var keepDeleteFiles1 = [];
var keepDeleteFileName1 = [];

var keepDeleteFiles2 = [];
var keepDeleteFileName2 = [];


function Action(url)
{
    window.location.href = url+'?Action=View&PID='+PID;;
}

    </script>

<style type="text/css">
 img.thumbnailImg
 {
 	 height:100;
 	 width:auto;
 	}

</style>
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
          <li role="presentation" class="active col-sm-2"><a  href="#CreatingPlan" aria-controls="home" role="tab" data-toggle="tab">Site Survey & Digging Location</a></li>
          <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSitePreparation.aspx") %>"  >Site Preparation <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionWeatherCollection.aspx") %>"  >Weather Collection <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>" >Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>">After Coating Removal<br>&nbsp;</a></li>
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
                <h3 class="text-center"><i class="fa fa-lock"></i>Site Survey & Digging Location</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Pipeline Information</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span48" >Route Code </span>
    <select   class="form-control ddlRouteCode" id="ddlRouteCode" disabled  >
      <option value="1">Route 1</option>
   <option value="2">Route 2</option>
   <option value="3">Route 3</option>
    <option value="3">Route 4</option>
  </select>
</div>
          </div>
            <div class="col-sm-6">
               <div class="input-group">
  <span class="input-group-addon" id="Span49">Pipe grade</span>
    <select   class="form-control ddlPipeGrade" id="ddlPipeGrade"  >
      <option value="1">PipeGrade 1</option>
   <option value="2">PipeGrade 2</option>
   <option value="3">PipeGrade 3</option>
    <option value="3">PipeGrade 4</option>
  </select>
</div>
          </div>
           
          </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
             <div class="input-group">
  <span class="input-group-addon" id="Span50" >Diameter </span>
    <select   class="form-control ddlDiameter" id="ddlDiameter"  >
      <option value="1">Diameter 1</option>
   <option value="2">Diameter 2</option>
   <option value="3">Diameter 3</option>
    <option value="3">Diameter 4</option>
  </select>
</div>
          </div>
            <div class="col-sm-6">
           
<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span51" >Date Installed</span>
    <input type="text" class="form-control datetimepicker  txtDateInstalled" id="txtDateInstalled">
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">
           <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span52" >Wall Thickness</span>
    <select   class="form-control ddlWallThickness" id="ddlWallThickness"  >
      <option value="1">Thickness 1</option>
   <option value="2">Thickness 2</option>
   <option value="3">Thickness 3</option>
    <option value="3">Thickness 4</option>
  </select>
</div>
          </div>
             <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span53" >MAOP</span>
    <select   class="form-control ddlMAOP"
     id="ddlMAOP"  >
      <option value="1">MAOP 1</option>
   <option value="2">MAOP 2</option>
   <option value="3">MAOP 3</option>
    <option value="3">MAOP 4</option>
  </select>
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
                     <h4 class="text-left">Defect Infomation</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
              <div class="input-group">
  <span class="input-group-addon" id="Span54" >DIG from </span>
    <select   class="form-control ddlDIGFrom" id="ddlDIGFrom"  >
   <option value="1">Other</option>
   <option value="2">MOC</option>
   <option value="3">ILI PIG</option>
    <option value="3">CIPS,DCVG</option>
  </select>
</div>
          </div>
            <div class="col-sm-6">
              <div class="input-group">
  <span class="input-group-addon" id="Span10" style=" width:160px">Risk Score :</span>
   <select   class="form-control txtRiskScore" id="txtRiskScore"  >
  <option value="0">Please Select</option>
  <option value="1">Low</option>
  <option value="2">Medium</option>
  <option value="3">Heigh</option>
  </select>
   
</div>
          </div>
           
          </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
              <div class="input-group">
  <span class="input-group-addon" id="Span56" >Note :</span>
     <textarea   class="form-control txtNote"  id="txtNote" placeholder="Note" cols=3  ></textarea>
   

</div>
          </div>
            <div class="col-sm-6">
           
    <div class="input-group">
  <span class="input-group-addon" id="Span57" >Risk Detail </span>
    <input type="text"    class="form-control txtRiskDetail" placeholder="Risk Detail" id="txtRiskDetail"  />
</div>
          </div>
          </div>

           <div class="row" style="padding-top:10px;">
           <div class="col-sm-3">
            <div class="input-group">
  <span  id="Span1" class="input-group-addon" style=" width:160px">GPS North :</span>
    <input   class="form-control txtNorth" type="text" id="txtNorth" disabled />
</div>
           </div>
           <div class="col-sm-3">
           <div class="input-group">
  <span  id="Span3" class="input-group-addon" style=" width:160px">GPS South :</span>
    <input   class="form-control txtEast" type="text" id="txtEast" disabled></input>
</div>
           </div>

             <div class="col-sm-3">
             <div class="input-group">
                <span class="input-group-addon"  id="Span5" >Section :</span>
                  <input   class="form-control txtSection" type="text" id="txtEast" disabled></input>
            <!-- <select   class="form-control selectTypeOfPipelineID" id="selectTypeOfPipelineID" disabled></select>-->
             </div>
            </div>
             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span9" style=" width:160px">KP :</span>
    <input   class="form-control txtKP" type="text" id="txtKP" disabled   />
</div>
          </div>
           </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-12 ">

           <fieldset>
          <legend>Attachment Files</legend>
         <div class="divAttachFile"></div>
           </fieldset>
          </div>

          </div>

          
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          	 <button id="open_btn1" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
              Upload
              <p>Picture: GIS Location</p>
               </button>
          </div>
          <div class="col-sm-6">
           <button id="open_btn2" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture: Overall dig Location</p>
                </button>
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
          
          <h4 >More Detail </h4>
     <textarea   class="form-control txtMoreDetail"  id="txtMoreDetail" placeholder="More Detail" rows="5"  ></textarea>


          </div>
          </div>

    </div>
    </div>
                            <!--- Body --->

       
      
         <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
       
        <button type="button" class="btn btn-lg bg-success btnSave ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
          </div>
          </div>
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

