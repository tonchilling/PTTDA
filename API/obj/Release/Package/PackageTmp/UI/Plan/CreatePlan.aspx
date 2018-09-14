<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CreatePlan.aspx.cs" Inherits="UI_Plan_CreatePlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>

  <script src="<%= ResolveUrl("~/Js/ui/Plan/CreatePlan.js") %>" type="text/javascript"></script>

     
<script language="javascript">
    var currentURL = '<%= ResolveUrl("~/ASHX/Plan/CreatePlanHandler.ashx") %>'; 
        var sectionURL= '<%= ResolveUrl("~/ASHX/Master/M_SectionHandler.ashx") %>'; 
    var listURL= ' <%= ResolveUrl("~/UI/Plan/PlanList.aspx") %>';
    var fileList;
    var fileAll;
    var realFiles=[];
    var objSelectFiles = null;


    </script>

    <style>
    #filelist {
    margin-top: 15px;
}

#uploadFilesButtonContainer, #selectFilesButtonContainer, #overallProgress {
    display: inline-block;
}

#overallProgress {
    float: right;
}

/*
th {
    background: #d2d7e6;
    border-bottom: 0;
    border-top: 0;
    color: #000;
    font-weight: bold;
    line-height: 1.3;
    white-space: nowrap;
}
td, th {
    border: 1px solid #fff;
    padding: 5px 12px;
    vertical-align: top;
}

td {
    background: #e6e9f5;
}*/


.inputfile {
	width: 0.1px;
	height: 0.1px;
	opacity: 0;
	overflow: hidden;
	position: absolute;
	z-index: -1;
}

.inputfile + label {
    font-size: 1.25em;
    font-weight: 700;
    color: white;
    background-color: black;
    display: inline-block;
}

.inputfile:focus + label,
.inputfile + label:hover {
    background-color: red;
}

.inputfile + label {
	cursor: pointer; /* "hand" cursor */
}

    
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->


<div class="card ">
 <div class="card-header"><i class="fa fa-internet-explorer fa-2x" style="color:#428bca"></i> Creating Plan </div>
     <div class="card-body">



         <div class="row">
          <div class="col-sm-12">
          
          <div class="card cardbody">
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
        <div class="card-body  card-body2 setup-content tab-content">

        <!--- Body --->

         <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span2" style=" width:160px">DIG from :</span>
    <select   class="form-control selectDIGFromID" id="selectDIGFromID"  >
   
  </select>
</div>
          </div>
           
          </div>

            <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span  id="Span1" style=" width:160px">GPS North :</span>
    <input   class="form-control txtNorth" type="text" id="txtNorth" />
</div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span  id="Span3" style=" width:160px">GPS South :</span>
    <input   class="form-control txtEast" type="text" id="txtEast"></input>
</div>
 

          </div>
           <div class="col-sm-1"> <button type="button" class="btn btn-md btn-success">Check</button></div>
          </div>

           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span4" style=" width:160px">Region :</span>
    <select   class="form-control selectRegionID" id="selectRegionID"  >
   
  </select>
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
             <div class="input-group">
                <span  id="Span5" style=" width:160px">Type Of line :</span>
             <select   class="form-control selectTypeOfPipelineID" id="selectTypeOfPipelineID"></select>
             </div>
            </div>
          </div>

           <div class="row" style="padding-top:10px;">
          <div class="col-sm-2"></div>
            <div class="col-sm-4">
             <div class="input-group">
               <span class="input-group-addon" id="Span6" style=" width:160px">Asset Owner :</span>
             <select   class="form-control selectAssetOwner" id="selectAssetOwner"></select>
             </div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span7" style=" width:160px" >Route Code :</span>
    <select   class="form-control selectRouteCodeID" id="selectRouteCodeID"  >
  </select>
</div>
          </div>
           
          </div>
             <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span9" style=" width:160px">KP :</span>
    <input   class="form-control txtKP" type="text" id="txtKP"   />
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span8" style=" width:160px">Section :</span>
    <input   class="form-control txtSection" type="text" id="txtSection"  />
</div>
          </div>
           
          </div>
           
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span10" style=" width:160px">Risk Score :</span>
   <select   class="form-control txtRiskScore" id="txtRiskScore"  >
  <option value="0">Please Select</option>
  <option value="1">Low</option>
  <option value="2">Medium</option>
  <option value="3">High</option>
  </select>
   
</div>
          </div>
           
          </div>
             <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span11" style=" width:160px">Risk Of Detail :</span>
  <textarea cols=2 style=" width:75%"   placeholder="Risk Of Detail" class="txtRiskOfDetail" id="txtRiskOfDetail"></textarea>
</div>
          </div>
           
          </div>
             <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span11" style=" width:160px">Remark :</span>
  <textarea cols=2 style=" width:75%"   placeholder="Remark" class="txtRemark" id="txtRemark"></textarea>
</div>
          </div>
           
          </div>


               <div class="row" style="padding-top:10px;">

            <div  class="col-sm-2"></div>
            <div class="col-sm-4">
 
	 <button id="open_btn" class="btn btn-info" style="width:100%; height:120px;font-size:30px;">
     <i  class="fa fa-plus " ></i> Upload
                <p style="color:#ffffff; font-size:14px;">Dig Sheet,DCVG Result,Alignment Sheet,Etc.</p> </button>
                                                                                                   
   

          </div>
           
          </div>
          <div class="row" style="padding-top:10px;">
            <div  class="col-sm-2"></div>
            <div class="col-sm-4">
    
<div id="filelist">
  <table id="filenames" class="table table-hover  table-fixed" style="width:100%; background-color:#ffffff;">
    <thead>
       <tr class="table-info"><th scope="col">File name</th><th scope="col">File size</th><th scope="col">Delete</th></tr>
      
    </thead>
    <tbody>
    </tbody>
  </table>
</div>

</div>
          </div>
    <div class="divStep2">

               <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-1">
           <div class="input-group">
  <span class="input-group-addon" id="Span39" style=" width:160px">Spec</span>
  
</div>
          </div>

           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span41">Start Date </span>
    <input type="text"    class="form-control txtSpecSDate datetimepicker" id="txtSpecSDate"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>

             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span40" >End Date </span>
    <input type="text"    class="form-control txtSpecEDate datetimepicker" id="txtSpecEDate"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>
           <div class="row" style="padding-top:10px;">

            <div class="col-sm-2"></div>
         
            <div class="col-sm-1">
           <div class="input-group">
  <span class="input-group-addon" id="Span42" style=" width:160px">PO</span>
  
</div>
          </div>

           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span43">Start Date </span>
    <input type="text"    class="form-control txtPOSDate datetimepicker" id="txtPOSDate"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>

             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span44" >End Date </span>
    <input type="text"    class="form-control txtPOEDate datetimepicker" id="txtPOEDate"  />
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-1">
           <div class="input-group">
  <span class="input-group-addon" id="Span45" style=" width:160px">Action</span>
  
</div>
          </div>

           <div class="col-sm-3">

<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span46" >Start Date </span>
    <input type="text" class="form-control datetimepicker  txtActionSDate" id="txtActionSDate">
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>

          </div>

             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span47" >End Date </span>
    <input type="text"    class="form-control txtActionEDate datetimepicker" id="txtActionEDate"  />
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>
</div>
            <div class="row">
                  <div class="col-sm-2"></div>
                <div class="col-sm-10 text-left">
            <span class="lblError" style="color:red"></span>
            </div>

            </div>
                <div class="row" style="padding-top:10px;">
            <div class="col-sm-2">
            
            </div>
          <div class="col-sm-4">
          
        <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
         <button type="button" class="btn btn-lg btn-default btnClose" >ปิด</button>
          </div>
          </div>
         <!--- Body --->

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
  </div>



</asp:Content>

