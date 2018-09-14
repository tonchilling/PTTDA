<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanActionSitePreparation.aspx.cs" Inherits="UI_Plan_PlanActionSitePreparation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>

    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>

   <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_SitePreparation.js") %>" type="text/javascript"></script>


   <script language="javascript">
    var fileList;
     var realFiles=[];       
var keepDeleteFiles = [];
var keepDeleteFileName = [];

    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_SitePreparationHandler.ashx") %>"; 
       var underGroupURL= "<%= ResolveUrl("~/ASHX/Master/M_UndergroundHandler.ashx") %>"; 
  </script>


  <style>
  
  input[type='checkbox'] {
    width: 24px;
    height: 24px;
    cursor: pointer;
}


#poProgress 
{
	 background-color: #2ba6cb;
    position: relative;
    margin-left: 35px;
}

#poProgress ul {
   /* border-left: .25em solid #449d44;
    padding-bottom: -5px;*/
}

#poProgress li:before {
  /*  content: "";
    display: inline-block;
    width: 2em;
    height: 0;
    position: relative;
  
    border-top: .25em solid #449d44;
    margin-left: -40px;*/
}

.divUnderground li
{
	padding-top:5px;
}
.divUnderground input[type='text']
{
	width:50%;
	
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
          <li role="presentation" class=" col-sm-2"><a  href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteSurvey.aspx") %>" >Site Survey & Digging Location</a></li>
          <li role="presentation" class="active col-sm-2"><a href="#" >Site Preparation <br>&nbsp;</a></li>
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
                <h3 class="text-center"><i class="fa fa-lock"></i>Site Preparation</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Digging Location</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
          <div class="input-group">
  <span class="input-group-addon" id="Span48" >Area owner </span>
    <select   class="form-control ddlAreaOwner" id="ddlAreaOwner"  >
      <option value="1">PTT right of way</option>
  </select>
</div>
          </div>
            <div class="col-sm-1 pull-right ">
               <div class="input-group ">
  <span class=" " id="Span49">GPS</span>
  
   
</div>
<span>(องศาทศนิยม)</span>
          </div>
           <div class="col-sm-2">
             <div class="input-group">
  <span class="input-group-addon" id="Span1">N</span>
     <input type="text"    class="form-control txtNorth" placeholder="North" id="txtNorth"  />
</div>
           </div>
             <div class="col-sm-3">
              <div class="input-group">
  <span class="input-group-addon" id="Span2">E</span>
     <input type="text"    class="form-control txtEast" placeholder="East" id="txtEast"  />
</div>
           </div>
           
          </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2">
           
           <span class=" " id="Span3">GPS Equipment</span>

          </div>
           <div class="col-sm-3">
             <div class="input-group">
  <span class="input-group-addon" id="Span4">Brand</span>
     <input type="text"    class="form-control txtBrand" placeholder="Brand" id="txtBrand"  />
</div>
           </div>
           
            <div class="col-sm-3">
             <div class="input-group">
  <span class="input-group-addon" id="Span5">Model</span>
     <input type="text"    class="form-control txtModel" placeholder="Model" id="Model"  />
</div>
           </div>
            <div class="col-sm-3">
             <div class="input-group">
  <span class="input-group-addon" id="Span6">S/N</span>
     <input type="text"    class="form-control txtSN" placeholder="S/N" id="txtSN"  />
</div>
           </div>
          </div>

          <div class="row" style="padding-top:10px;">
             <div class="col-sm-5">
          <div class="input-group">
  <span class="input-group-addon" id="Span11" >Section</span>
    <select   class="form-control ddlPipelineSection" id="ddlPipelineSection"  >
     
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
                     <h4 class="text-left">Soild data</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px; ">

          <div class="col-sm-6">
          <div class="row">
           <div class="col-sm-11">
           <div class="input-group">
  <span class="input-group-addon" id="Span8" >Soil Type</span>
    <select   class="form-control ddlSoildType" id="ddlSoildType"  >
      <option value="1">1</option>
  </select>
  </div>
  </div>
           </div>
 <div class="row" style="padding-top:10px; ">

          <div class="col-sm-11">
      

            <div class="card ">
                    <div class="card-header" style=" background-color: #2da7ed;" >
                      <h5 style="color:White">Underground public utility</h5>
                    </div>
                      <div class="card-body divUnderground" style=" background-color: #a3daf9;">
             <ul >
    <li><label><input type="checkbox" class="chk"/> FOC</label> </li>
     <li><label><input type="checkbox" class="chk"/> Zinc Ribbon</label> </li>
       <li><label><input type="checkbox" class="chk"/> Ground Rod</label> </li>
          <li><label><input type="checkbox" class="chk"/> Other Utility</label>
    <ul >
      <li class="row" ><label class="col-sm-4"><input type="checkbox" class="chk"/> Pipeline</label> <input type="text" class="form-control  "  id="txtOtherPipeline"  /></li>
        <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Power Line</label> <input type="text" class="form-control "  id="Text1"  /></li>
          <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Water Supplier</label> <input type="text" class="form-control "  id="Text2"  /></li>
            <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Community Line</label> <input type="text" class="form-control"   id="Text3"  /></li>
       </ul>
       </li>
   <li><label><input type="checkbox" class="chk"/> Etc.</label> </li>
    </ul>
    </div>
    </div>
         
</div>
</div>


          </div>
            <div class="col-sm-6">
            <div class="row" >
            <div class="col-sm-11">
              <div class="input-group">
  <span class="input-group-addon" id="Span10" >Depth of cover</span>
    <input type="text"    class="form-control txtDepthOfCover" placeholder="Depth of cover" id="txtDepthOfCover"  />
     <span class="input-group-addon" id="Span7" >m</span>
</div>
            </div>
            </div>
            <div class="row" style="padding-top:10px; ">
            <div class="col-sm-11">
              <div class="input-group">
  <span class="input-group-addon" id="Span55" >Bacteria APB </span>
    <input type="text"    class="form-control txtBacteriaAPB" placeholder="Bacteria APB" id="txtBacteriaAPB"  />
</div>
           </div>
</div>

  <div class="row" style="padding-top:10px; ">
            <div class="col-sm-11">
                 <div class="input-group">
                  <span class="input-group-addon" id="Span39" >Bacteria SRB</span>
                <input type="text"    class="form-control txtBacteriaSRB" placeholder="Bacteria SRB" id="txtBacteriaSRB"  />
             </div>
           </div>
</div>
 <div class="row" style="padding-top:10px; ">
            <div class="col-sm-11">
                     <div class="input-group">
  <span class="input-group-addon" id="Span40" >pH (Underground water)</span>
    <input type="text"    class="form-control txtPH" placeholder="Bacteria SRB" id="txtPH"  />
</div>

                    
           </div>
</div>
<div class="row" style="padding-top:10px; ">
            <div class="col-sm-11">
                       <div class="input-group">
            <span class="input-group-addon" id="Span9" >Dig Length</span>
               <input type="text"    class="form-control txtDigLength" placeholder="Dig Length" id="txtDigLength"  />
                <span class="input-group-addon" id="Span12" >m</span>
                  </div>
           </div>
</div>





          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-12">
          	 <button id="open_btn1" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture: After Site Preparation<br> ภาพถ่ายหลังจากการเตรียมหลุมเสร็จแล้ว</p> 
                </button>
          </div>
        
          </div>
          
               <div class="row" style="padding-top:10px;">

          <div class="col-sm-12">
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
        
          </div>

          <div class="row">
          <div class="col-sm-12">
          
          <h4 >More Detail </h4>
     <textarea   class="form-control txtMoreDetail"  id="txtMoreDetail" placeholder="Note" rows="5"  ></textarea>


          </div>
          </div>

            <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
       
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

