<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanEdit.aspx.cs" Inherits="UI_Plan_PlanEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<style  type="text/css">

.login-signup {
  padding: 0 0 25px;
}

.btn-success {
  background: #23bab5;
  border-radius:0;
  border: 2px solid #23bab5;
  webkit-transition: all 400ms cubic-bezier(.4,0,.2,1);
  transition: all 400ms cubic-bezier(.4,0,.2,1);
}

.btn-success:hover,.btn-success:focus {
  background: rgba(26, 161, 157, 0);
  border: 2px solid #1aa19d;
  webkit-transition: all 400ms cubic-bezier(.4,0,.2,1);
  transition: all 400ms cubic-bezier(.4,0,.2,1);
  color: #23BAB5;
}


ul {
  list-style-type: none;
}

article[role="login"] {
   background: -webkit-linear-gradient(#ffffff, #f3f2f2);
			 background: -moz-linear-gradient(#ffffff, #f3f2f2);
			background:linear-gradient(#ffffff, #f3f2f2);
			color:#000000;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  -webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 10px rgba(0, 0, 0, 0.24);
  webkit-transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  padding: 30px 50px;
  margin-bottom: 20px;
}

article[role="login"] input[type="submit"] {
  padding: 10px 15px;
  font-size: 16px;
}

article[role="login"]:hover {
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  -webkit-box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19), 0 1px 15px rgba(0, 0, 0, 0.23);
  webkit-transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
}

article[role="login"] h3 {
  font-size: 26px;
  font-weight: 300;
  color: #23bab5;
  margin-bottom: 20px;
}

article[role="login"] p {
  font-size: 16px;
  padding: 5px 15px;
}

.nav-tab-holder {
  padding: 0 0 0 30px;
  float: right;
}

.nav-tab-holder .nav-tabs {
  border: 0;
  float: none;
  display: table;
  table-layout: fixed;
  width: 100%;
}

.nav-tab-holder .nav-tabs > li {
  margin-bottom: -3px;
  text-align: center;
  padding: 0;
  display: table-cell;
  float: none;
  padding: 1px;
}

.nav-tab-holder .nav-tabs > li > a {
  background: #d9d9d9;
  color: #6c6c6c;
  margin: 0;
  font-size: 18px;
  font-weight: 300;
}

.nav-tab-holder .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
  color: #FFF;
  background-color: #23bab5;
  border: 0;
  border-radius: 0;
}





.mobile-pull {
  float: right;
}

article[role="manufacturer"] {
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  -webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 10px rgba(0, 0, 0, 0.24);
  padding: 0 0 40px;
  max-width: 420px;
  margin: -45px auto 0;
}

article[role="manufacturer"] header {
  background: #23bab5;
  color: #fff;
  padding: 10px;
  font-size: 18px;
  font-weight: 300;
}

article[role="manufacturer"] h1 {
  font-size: 26px;
  font-weight: 300;
  border-bottom: 1px solid #f2f2f2;
  padding: 25px 15px;
}

article[role="manufacturer"] ul {
  padding: 0 25px;
}

article[role="manufacturer"] ul li {
  font-size: 16px;
  border-bottom: 1px solid #eaeaea;
  padding: 20px 15px;
  color:#404040;
}

article[role="manufacturer"] ul li i {
  color: #23bab5;
}

.login-signup {
  padding: 0 0 25px;
}

@media only screen and (max-width: 767px) {
  .mobile-pull {
    float: none;
  }

  .nav-tab-holder {
    float: none;
    overflow: hidden;
  }

  .nav-tabs > li > a {
    font-size: 13px;
    font-weight: 600;
    padding: 10px 5px;
    overflow: hidden;
    text-overflow: ellipsis;
  }

  .nav-tabs > li {
    width: 50%;
  }
}

.dropdown-menu
{
	 background-color:#17a2b8 !important;
	 color:#000;
	}
</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_PlaningHandler.ashx") %>"; 

    
    </script>


   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/PlanEdit.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
  <div class="container-fluid">

  <div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Complete Date </div>
     <div class="card-body">


     	<div class="row">
        <div class="col-lg-12">
          <p>
            <a href="#" class="btn btn-sq btn-primary xzoom">
                <i class="fa fa-file fa-5x"></i><br/>
               <span style=" font-size:12px;"> Before Coating <br> Removal</span>
            </a>
            <a href="#" class="btn btn-sq btn-success xzoom">
              <i class="fa fa-file fa-5x"></i><br/>
                <span style=" font-size:12px;"> After Coating  <br> Removal</span> 
            </a>
            <a href="#" class="btn btn-sq btn-info xzoom">
              <i class="fa fa-file fa-5x"></i><br/>
               <span style=" font-size:12px;"> After New Coating <br> Performed</span>   
            </a>
            <a href="#" class="btn btn-sq btn-warning xzoom">
              <i class="fa fa-file fa-5x"></i><br/>
              <span style=" font-size:12px;"> Pipe Repair</span>   
            </a>
          
          </p>
        </div>
	</div>

     <div class="row">
      <div class="col-sm-12">
     <div class="login-signup">
      <div class="row">
        <div class="col-sm-12 nav-tab-holder">
        <ul class="nav nav-tabs row" role="tablist">
          <li role="presentation" class="active col-sm-2"><a  href="#CreatingPlan" aria-controls="home" role="tab" data-toggle="tab">Creating Plan</a></li>
          <li role="presentation" class="col-sm-2"><a href="#CoatingRepair" aria-controls="CoatingRepair" role="tab" data-toggle="tab">Coating Repair</a></li>
             <li role="presentation" class="col-sm-2"><a href="#CoatingDefect" aria-controls="CoatingDefect" role="tab" data-toggle="tab">Coating Defect</a></li>
              <li role="presentation" class="col-sm-2"><a href="#PipeDefect" aria-controls="PipeDefect" role="tab" data-toggle="tab">Pipe Defect</a></li>
                <li role="presentation" class="col-sm-2"><a href="#Environment" aria-controls="Environment" role="tab" data-toggle="tab">Environment</a></li>
        </ul>
      </div>

      </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
          <div class="row ">

            <div class="col-sm-12 mobile-pull ">
              <article role="login" >
                <h3 class="text-center"><i class="fa fa-lock"></i>Creating Plan</h3>
   
                    <div class="row ">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-7">
                    
                            <!--- Body --->

         <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span2" style=" width:160px">DIG from </span>
    <select   class="form-control ddlDIGFromID" id="ddlDIGFromID"  >
   <option value="1">Other</option>
   <option value="2">MOC</option>
   <option value="3">ILI PIG</option>
    <option value="3">CIPS,DCVG</option>
  </select>
</div>
          </div>
           
          </div>

            <div class="row" style="padding-top:10px;">

         
            <div class="col-sm-12">
           <div class="input-group">
  <span  id="Span1" style=" width:160px">North </span>
    <input type="text"   class="form-control txtNorth" id="txtNorth"></input>
</div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

        
            <div class="col-sm-12">
           <div class="input-group">
  <span  id="Span3" style=" width:160px">East </span>
    <input  type="text"   class="form-control txtEast" id="txtEast"></input>
</div>
          </div>
           
          </div>

           <div class="row" style="padding-top:10px;">

         
             <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span4" style=" width:160px">Region </span>
    <select   class="form-control ddlRegionID" id="ddlRegionID"  >
    <option value="1">Region 1</option>
   <option value="2">Region 2</option>
   <option value="3">Region 3</option>
    <option value="3">Region 4</option>
  </select>
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

        
            <div class="col-sm-12">
             <div class="input-group">
                <span  id="Span5" style=" width:160px">Type of Pipeline </span>
             <select   class="form-control ddlPipelineID" id="ddlPipelineID">
              <option value="1">Pipeline 1</option>
   <option value="2">Pipeline 2</option>
   <option value="3">Pipeline 3</option>
    <option value="3">Pipeline 4</option>
             </select>
             </div>
            </div>
          </div>

           <div class="row" style="padding-top:10px;">
        
           <div class="col-sm-12">
           <div class="input-group">
  <span  id="Span6" style=" width:160px">Asset Owner </span>
   <select   class="form-control ddlAssetOwnerID" id="ddlAssetOwnerID"  ></select>
   
</div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

          <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span7" style=" width:160px">Route Code </span>
    <select   class="form-control ddlRouteCodeID" id="ddlRouteCodeID"  >
      <option value="1">Route 1</option>
   <option value="2">Route 2</option>
   <option value="3">Route 3</option>
    <option value="3">Route 4</option>
  </select>
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

          <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span8" style=" width:160px">Section </span>
    <input type="text"    class="form-control txtSection" id="txtSection"  />
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

        
            <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span9" style=" width:160px">KP </span>
    <input type="text"    class="form-control txtKP" id="txtKP"  />
</div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

         
            <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span10" style=" width:160px">Risk Score </span>
    <input type="text"    class="form-control txtRiskScore" id="txtRiskScore"  />
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

         
            <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span39" style=" width:160px">Spec</span>
  
</div>
          </div>

           <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span41">Start Date </span>
    <input type="text"    class="form-control txtStartDateSpec datetimepicker" id="txtStartDateSpec"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>

             <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span40" >End Date </span>
    <input type="text"    class="form-control txtEndDateSpec datetimepicker" id="txtEndDateSpec"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>
           <div class="row" style="padding-top:10px;">

         
            <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span42" style=" width:160px">PO</span>
  
</div>
          </div>

           <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span43">Start Date </span>
    <input type="text"    class="form-control txtStartDatePO datetimepicker" id="txtStartDatePO"  />
     <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>

             <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span44" >End Date </span>
    <input type="text"    class="form-control txtEndDatePO datetimepicker" id="txtEndDatePO"  />
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
          </div>
           <div class="row" style="padding-top:10px;">

         
            <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span45" style=" width:160px">Action</span>
  
</div>
          </div>

           <div class="col-sm-5">

<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span46" >Start Date </span>
    <input type="text" class="form-control datetimepicker  txtStartDateAction" id="txtStartDateAction">
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>

          </div>

             <div class="col-sm-5">
           <div class="input-group">
  <span class="input-group-addon" id="Span47" >End Date </span>
    <input type="text"    class="form-control txtEndDateAction datetimepicker" id="txtEndDateAction"  />
    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
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

      <div role="tabpanel" class="tab-pane" id="CoatingRepair">
        <div class="row">

          <div class="col-sm-12 mobile-pull">
            <article role="login">
              <h3 class="text-center"><i class="fa fa-lock"></i>Coating Repair</h3>
             
             <div class="row">
             <div class="col-sm-3"></div>
             <div class="col-sm-6">
             
                     <!--- Body --->

         <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span11" style=" width:160px">Repair Using </span>
     <input type="text"   class="form-control txtRepairUsing" id="txtRepairUsing" />
</div>
          </div>
           
          </div>

              <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span12" style=" width:160px">Repair Length(m) </span>
     <input type="text"  class="form-control txtRepairLength" id="txtRepairLength" />
</div>
          </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span13" style=" width:160px">KP Repair Start </span>
     <input type="text"  class="form-control txtKPRepairStart" id="txtKPRepairStart" />
</div>
          </div>
           
          </div>

          <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span14" style=" width:160px">GPS (@KP Start) N </span>
     <input  type="text" class="form-control txtGPSKPStartN" id="txtGPSKPStartN" />
</div>
          </div>
           
          </div>
            <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span15" style=" width:160px">E </span>
     <input  type="text" class="form-control txtGPSKPStartE" id="txtGPSKPStartE" />
</div>
          </div>
           
          </div>

             <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span16" style=" width:160px">pH </span>
     <input type="text"  class="form-control txtpH" id="txtpH" />
</div>
          </div>
           
          </div>
          <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span17" style=" width:160px">Bacteria </span>
     <input type="text"  class="form-control txtBacteria" id="txtBacteria" />
</div>
          </div>
           
          </div>
        <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon text-right" id="Span18" style=" width:160px">DFT(um) </span>
     <input type="text"  class="form-control txtDFT" id="txtDFT" />
</div>
          </div>
           
          </div>
          <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon text-right" id="Span19" style=" width:160px">Holiday Test </span>
     <select   class="form-control ddlHolidayTestID" id="ddlHolidayTestID" ></select>
</div>
          </div>
           
          </div>
         <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon text-right" id="Span20" style=" width:160px">Holiday Test Value </span>
     <input type="text"  class="form-control txtHolidayTestValue" id="txtHolidayTestValue" />
</div>
          </div>
           
          </div>
             <div class="row" style="padding-top:10px;">

          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">

          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">

          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">

          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
       

         <!--- Body --->
             </div>
             </div>

            </article>
          </div>

         
        </div>
      </div>
       <div role="tabpanel" class="tab-pane" id="CoatingDefect">
        <div class="row">

          <div class="col-sm-12 mobile-pull">
            <article role="login">
              <h3 class="text-center"><i class="fa fa-lock"></i>Coating Defect</h3>
               <div class="row">
                 <div class="col-sm-12">
                   <input type="button" class="btn btn-lg btn-primary   btnAddCoatingDefect pull-right" style="margin-right:15px;" value="เพิ่ม" style="" />
                 </div>
               </div>
             <div class="row">
            
               <div class="col-sm-12">
               
                <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                 
                 <th>No</th>
                  <th>Type</th>
                  <th>KP</th>
                  <th>Width(mm)</th>
                  <th>Length(mm)</th>
                   <th>Clock Position</th>
                   <th>File Attached</th>
                    <th>Repair By</th>
                    <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                 <th>No</th>
                  <th>Type</th>
                  <th>KP</th>
                  <th>Width(mm)</th>
                  <th>Length(mm)</th>
                   <th>Clock Position</th>
                   <th>File Attached</th>
                    <th>Repair By</th>
                     <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </tfoot>
            
            </table>
          </div>


               </div>
             </div>
                 

            </article>
          </div>

         
        </div>
      </div>
        <div role="tabpanel" class="tab-pane" id="PipeDefect">
        <div class="row">

          <div class="col-sm-12 mobile-pull">
            <article role="login">
              <h3 class="text-center"><i class="fa fa-lock"></i>Pipe Defect</h3>
         <div class="row">
                 <div class="col-sm-12">
                   <input type="button" class="btn btn-lg btn-primary   btnAddPipeDefect pull-right" style="margin-right:15px;" value="เพิ่ม" style="" />
                 </div>
               </div>
             <div class="row">
            
               <div class="col-sm-12">
               
                <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="Table1" width="100%" cellspacing="0">
              <thead>
                <tr>
                 
                 <th>No</th>
                  <th>Type</th>
                  <th>KP</th>
                  <th>Width(mm)</th>
                  <th>Length(mm)</th>
                   <th>Clock Position</th>
                   <th>File Attached</th>
                    <th>Repair By</th>
                    <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                 <th>No</th>
                  <th>Type</th>
                  <th>KP</th>
                  <th>Width(mm)</th>
                  <th>Length(mm)</th>
                   <th>Clock Position</th>
                   <th>File Attached</th>
                    <th>Repair By</th>
                     <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </tfoot>
            
            </table>
          </div>


               </div>
             </div>

            </article>
          </div>

         
        </div>
      </div>
       <div role="tabpanel" class="tab-pane" id="Environment">
        <div class="row">

          <div class="col-sm-12 mobile-pull">
            <article role="login">
              <h3 class="text-center"><i class="fa fa-lock"></i>Environment</h3>
         <div class="row">
                 <div class="col-sm-12">
                   <input type="button" class="btn btn-lg btn-primary   btnAddEnvironment pull-right" style="margin-right:15px;" value="เพิ่ม" style="" />
                 </div>
               </div>
             <div class="row">
            
               <div class="col-sm-12">
               
                <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="Table2" width="100%" cellspacing="0">
              <thead>
                <tr>
                 
                 <th>No</th>
                  <th>Dry Temp</th>
                  <th>Wet Temp</th>
                   <th>Dew Temp</th>
                  <th>Pipe Surface</th>
                  <th>Relative Humidity</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                  
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                  
                 <th>No</th>
                  <th>Dry Temp</th>
                  <th>Wet Temp</th>
                   <th>Dew Temp</th>
                  <th>Pipe Surface</th>
                  <th>Relative Humidity</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </tfoot>
              <tbody>
               

              </tbody>
            </table>
          </div>


               </div>
             </div>

            </article>
          </div>

         
        </div>
      </div>
  </div>
  </div>
  </div>
     </div>


         <div class="row" style="padding-top:10px;">

          <div class="col-md-2 col-md-offset-5">
       
        <button type="button" class="btn btn-lg bg-success btnSavePlan ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
          </div>
          </div>
     </div>
     </div>
     </div>
     </div>


<!--Modal-->


 <div class="modal mCoatingDefect myModal fade" id="mCoatingDefect" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Coating Defect Data</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span21">Type :</span>
    <input   class="form-control txtType" type='text' id="txtType"  />
   
</div>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span22" >KP :</span>
     <input   class="form-control txtKPDefect" type='text' id="txtKP_Coating"  />
   

</div>
          </div>

            

          
          </div>
            <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span24" >Width(mm) :</span>
     <input   class="form-control txtWidth" type='text' id="txtWidth"  />
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span25" >Length(mm) :</span>
     <input   class="form-control txtLength" type='text' id="txtLength"  />
   

</div>
          </div>

            

          
          </div>
           <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span26" >Clock Position :</span>
     <select   class="form-control ddlClockPosition" type='text' id="ddlClockPositionPipeDefect"></select>
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span27" >Repair By :</span>
     <input   class="form-control txtRepairBy" type='text' id="txtRepairBy"  />
   

</div>
          </div>

            

          
          </div>
           
               <div class="row" style="padding-top:10px;">

            <div  class="col-sm-1"></div>
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">
                 <div  class="col-sm-1"></div>
          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">
                 <div  class="col-sm-1"></div>
          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">

            <div  class="col-sm-1"></div>
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
         
          


      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg bg-success btnSavecoatingDefect">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>

 <div class="modal mPipeDefect myModal fade" id="mPipeDefect" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H1"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Pipe Defect</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span23">Type :</span>
    <input   class="form-control txtType" type='text' id="Text12"  />
   
</div>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span28" >KP :</span>
     <input   class="form-control txtKPDefect" type='text' id="txtKP_PipeDefect"  />
   

</div>
          </div>

            

          
          </div>

           <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span33" >Depth(mm) :</span>
     <input   class="form-control txtDepth" type='text' id="txtDepth"  />
   

</div>
          </div>

            

          
          </div>

            <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span29" >Width(mm) :</span>
     <input   class="form-control txtWidth" type='text' id="Text14"  />
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span30" >Length(mm) :</span>
     <input   class="form-control txtLength" type='text' id="Text15"  />
   

</div>
          </div>

            

          
          </div>
           <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span31" >Clock Position :</span>
     <select   class="form-control ddlClockPosition" type='text' id="ddlClockPositionCoatingDefect"></select>
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span32" >Repair By :</span>
     <input   class="form-control txtRepairBy" type='text' id="Text16"  />
   

</div>
          </div>

            

          
          </div>
           
               <div class="row" style="padding-top:10px;">

            <div  class="col-sm-1"></div>
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">
                 <div  class="col-sm-1"></div>
          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">
                 <div  class="col-sm-1"></div>
          
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
               <div class="row" style="padding-top:0px;">

            <div  class="col-sm-1"></div>
            <div class="col-sm-10">
       <div class="form-group">
		<div class="input-group input-file" name="Fichier1">
    		<input type="text" class="form-control" placeholder='Choose a file...' />			
            <span class="input-group-btn">
        		<button class="btn btn-default btn-choose" type="button">Choose</button>
    		</span>


		</div>
	</div>
          </div>
           
          </div>
         
          


      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg bg-success btnSavePipeDefect">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>

<div class="modal mEnvironment  myModal fade" id="mEnvironment" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H2"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Enviromment</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span34">Dry Temp :</span>
    <input   class="form-control txtDryTemp" type='text' id="txtDryTemp"  />
   
</div>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span35">Wet Temp :</span>
    <input   class="form-control txtWetTemp" type='text' id="txtWetTemp"  />
   
</div>
          </div>
          </div>

           <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span36">Dew Temp :</span>
    <input   class="form-control txtDewTemp" type='text' id="txtDewTemp"  />
   
</div>
          </div>
          </div>

            <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span37" >Pipe Surface :</span>
     <input   class="form-control txtPipeSurface" type="text" id="txtPipeSurface"  />
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span38" >Relative Humidity :</span>
     <input   class="form-control txtRelativeHumidity" type='text' id="txtRelativeHumidity"  />
   

</div>
          </div>

            

          
          </div>
         
         
          


      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-lg bg-success btnSaveEnvironment">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
      
      
      </div>
    </div>
  </div>
</div>
<!-- End Modal-->
</asp:Content>

