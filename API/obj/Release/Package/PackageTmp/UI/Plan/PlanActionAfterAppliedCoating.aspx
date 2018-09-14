<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanActionAfterAppliedCoating.aspx.cs" Inherits="UI_Plan_PlanActionAfterAppliedCoating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>
<style  type="text/css">

.login-signup {
  padding: 0 0 25px;
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
	/* background-color:#17a2b8 !important;*/
	 color:#000;
	}
	
	
	legend:before {
      content: counter(fieldset);
      counter-increment: fieldset;
      position: absolute;
      left: -25px;
      width: 30px;
      height: 30px;
      line-height: 30px;
      border-radius: 15px;
      text-align: center;
      background: $brand-primary;
      color: white;
      font-size: 75%;
      font-weight: bold;
    }
    
    
    
.btn .badge {
    position: relative;
    top: -1px;
    float: right;
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


input[type="checkbox"]{
  width: 24px; /*Desired width*/
  height: 24px; /*Desired height*/
  cursor: pointer;

}



</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>

  <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_AfterAppliedCoating.js?ver=2.2") %>" type="text/javascript"></script>

<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_AfterAppliedCoatingHandler.ashx") %>"; 
     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];

    var keepDeleteFiles1 = [];
var keepDeleteFileName1 = [];

var keepDeleteFiles2 = [];
var keepDeleteFileName2 = [];
    

    </script>


   

 
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
          <li role="presentation" class=" col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSitePreparation.aspx") %>" >Site Preparation <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionWeatherCollection.aspx") %>"  >Weather Collection <br>&nbsp;</a></li>
             <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>" >Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>">After Coating Removal<br>&nbsp;</a></li>
                <li role="presentation" class="col-sm-2 "><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAppliedCoating.aspx") %>">Applied Coating<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2 active"><a href="#Environment" aria-controls="Environment" role="tab" data-toggle="tab">After Applied Coating<br>&nbsp;</a></li>
             <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteRecovery.aspx") %>" >Site Reovery<br>&nbsp;</a></li>
        </ul>
      </div>

      </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
          <div class="row ">

            <div class="col-sm-12 mobile-pull ">
              <article role="login" >
                <h3 class="text-center"><i class="fa fa-lock"></i>Inspection After Applied Coating</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Dry Film Thickness</h4>
                    </div>
    <div class="card-body">

   
 <div class="row "  style="padding-top:10px;">
 <div class="col-sm-12">
 <h5 class="text-left"></h5>
   </div>
   </div>

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span1">DFT Equipment</span>
     <input type="text"    class="form-control txtDryDFTEquipment" placeholder="DFT Equipment" id="txtDryDFTEquipment"  />
</div>
          </div>

           <div class="col-sm-4">
             <div class="input-group">
  <span class="input-group-addon" id="Span3">Brand</span>
     <input type="text"    class="form-control txtDryBrand" placeholder="Brand" id="txtDryBrand"  />
</div>
           </div>
             <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span4">Model</span>
     <input type="text"    class="form-control txtDryModel" placeholder="Model" id="txtDryModel"  />
</div>
           </div>
           
          </div>
            <div class="row" style="padding-top:10px; ">
               <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span2">S/N</span>
     <input type="text"    class="form-control txtDrySN" placeholder="S/N" id="txtDrySN"  />
</div>
          </div>
            </div>

             <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
       
        <button type="button" class="btn btn-lg bg-success btnNew ">เพิ่ม</button>
       
        <button type="button" class="btn btn-lg btn-danger btnDeleteDryFilm">ลบ</button>
        
          </div>
          </div>

           <div class="row" style="padding-top:10px; ">
<div class="col-sm-12">

 <table class="table table-bordered table-blue tblDry">
   <thead>
      <tr>
       <th rowspan="2" class="text-center"></th>
         <th rowspan="2" class="text-center">Position No.</th>
         <th rowspan="2" class="text-center"  style="width:200px;">Coating Repair Type</th>
           <th  colspan="4" class="text-center">Dry Flim Thickness Around New Coating (&#181m) </th>
               <th  rowspan="2" class="text-center">Avg.DFT</th>
                  
  </tr>
   <tr>
    <th class="text-center">1</th>
     <th class="text-center">2</th>
      <th class="text-center">3</th>
       <th class="text-center">4</th>
   </tr>
  </thead>
  <tbody>
  <tr>
   <td><input class="form-control   chkSelect"  type="checkbox"/></td>
     
   <td><input class="form-control   txtPositionNo" type="text" disabled/></td>
    <td><select class="form-control   ddlRepairType"  style="width:170px;" > <option>กรุณาเลือก</option></select></td>
  <td><input class="form-control   txtClockPosition1" type="text"/></td>
  <td><input class="form-control   txtClockPosition2" type="text"/></td>
  <td><input class="form-control   txtClockPosition3" type="text"/></td>
   <td><input class="form-control   txtClockPosition4" type="text"/></td>
    <td><input class="form-control   txtAVGDFT" type="text" disabled/></td>
  </tr>
  
  
  </tbody>
<tfoot>
 <tr >
<th colspan="6"></th>
<th style="background:#bee5eb"><h5>Minimum (&#181m)</h5></th>
<th style="background:#bee5eb"><h5 class="lbMinimum"></h5></th>
 </tr>
 <tr>
<th colspan="6"></th>
<th style="background:#bee5eb"><h5>Average (&#181m)</h5></th>
 <th style="background:#bee5eb"><h5 class="lbAverage"></h5></th> 
 </tr>
 </tfoot>


  </table>
   

</div>
</div>

<div class="row" style="padding-top:20px;">
   <div class="col-sm-6">
   <h4>Repair type</h4>
   <div class="row">
   <div class="col-sm-6">
    <img src="<%= ResolveUrl("~/Img/spotcoatingrepaire.jpg") %>"  />
   </div>
     <div class="col-sm-6">
    <img src="<%= ResolveUrl("~/Img/overallcoatingrepaire.jpg") %>"  />
   </div>
   </div>
   </div>
    <div class="col-sm-3"> <h4>Number of DFT Inspection</h4>
      <div class="row " >
      <div class="col-sm-12">
      - Coating Repair Length < 0.5 = 1 Position
      </div>
      
      </div>
       <div class="row " >
      <div class="col-sm-12">
      - Coating Repair Length = 0.5-5 = 2 Position
      </div>
      
      </div>
     <div class="row " >
      <div class="col-sm-12">
      - Coating Repair Length > 5 = 3 Position
      </div>
      
      </div>
    </div>
     <div class="col-sm-3"> <h4>Requirement</h4>
       <div class="row " >
      <div class="col-sm-12">
      -  Minimum > 500 &#181m
      </div>
      
      </div>
        <div class="row " >
      <div class="col-sm-12">
      -  Average >650 or Coating Specification
      </div>
      
      </div>
     </div>
   </div>
    



    <div class="row "  style="padding-top:30px;">
 <div class="col-sm-12">
 <h5 class="text-left">Holiday Test</h5>
   </div>
   </div>
    <div class="row" style="padding-top:10px;">

          <div class="col-sm-4">
            <div class="input-group">
  <span class="input-group-addon" id="Span48" >Test Method</span>
    <select   class="form-control ddlHolidayTestMethod" id="ddlHolidayTestMethod"  >
      <option value="1">M 1</option>
   <option value="2">M 2</option>
   <option value="3">M 3</option>
    <option value="3">M 4</option>
  </select>
</div>
<span>(High Voltage AC or DC , Low Voltage)</span>
          </div>

           <div class="col-sm-4">
             <div class="input-group">
  <span class="input-group-addon" id="Span6">Brand</span>
     <input type="text"    class="form-control txtHolidayBrand" placeholder="Brand" id="txtHolidayBrand"  />
</div>
           </div>
             <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span7">Model</span>
     <input type="text"    class="form-control txtHolidayModel" placeholder="Model" id="txtHolidayModel"  />
</div>
           </div>
           
          </div>
           <div class="row" style="padding-top:10px;">

        

           <div class="col-sm-4">
             <div class="input-group">
  <span class="input-group-addon" id="Span8">S/N</span>
     <input type="text"    class="form-control txtHolidaySN" placeholder="S/N" id="txtHolidaySN"  />
</div>
           </div>
             <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span9">Test Voltage (kV) </span>
     <input type="text"    class="form-control txtHolidayTestVoltage" placeholder="Test Voltage" id="txtHolidayTestVoltage"  />
</div>
           </div>
           
          </div>

            <div class="row "  style="padding-top:10px;">
          <div class="col-sm-12">
          
       
     <textarea   class="form-control txtHolidayRemark"  id="txtHolidayRemark" placeholder="Remark" rows="5"  ></textarea>


          </div>
          </div>


             <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          	 <button id="open_btn1" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
                Upload
                <p>Picture:Overall Coating Repair</p></button>
          </div>
          <div class="col-sm-6">
           <button id="open_btn2" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture:Overall Coating Repair</p> </button>
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
    <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
       
        <button type="button" class="btn btn-lg bg-success btnSave ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
          </div>
          </div>
    </div>
    </div>

    </div>
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

