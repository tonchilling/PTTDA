<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
     CodeFile="PlanActionSiteRecovery.aspx.cs" Inherits="UI_Plan_PlanActionSiteRecovery" %>

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

hr.style1{
	border-top: 2px solid #000;
}

 .popover img
    {
    	max-width:560px;
    	cursor:pointer;
    	
    	}


</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_SiteRecoveryHandler.ashx") %>"; 

        var reportURL= "<%= ResolveUrl("~/UI/Report/MReport.aspx") %>"; 
     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];

    var keepDeleteFiles1 = [];
var keepDeleteFileName1 = [];

var keepDeleteFiles2 = [];
var keepDeleteFileName2 = [];
   
    </script>


   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_SiteRecovery.js") %>" type="text/javascript"></script>
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
              <li role="presentation" class="col-sm-2 "><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterAppliedCoating.aspx") %>" >After Applied Coating<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2 active"><a href="#Environment" aria-controls="Environment" role="tab" data-toggle="tab">Site Reovery<br>&nbsp;</a></li>
        </ul>
      </div>

      </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
          <div class="row ">

            <div class="col-sm-12 mobile-pull ">
              <article role="login" >
                <h3 class="text-center"><i class="fa fa-lock"></i>Site Reovery</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left"></h4>
                         <button type="button" class="btn btn-lg bg-primary btnExport pull-right ">Export</button>
                    </div>
    <div class="card-body">
          <div class="row" style="padding-top:10px;">

          <div class="col-sm-6">
          	 <button id="open_btn1" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture:Overall </p> </button>
          </div>
          <div class="col-sm-6">
           <button id="open_btn2" class="btn btn-info"
              style="width:100%; height:120px;font-size:30px;">
              <i  class="fa fa-plus " ></i>
               Upload
                <p>Picture:Overall </p> </button>
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

              <div class="row "  style="padding-top:10px;">
          <div class="col-sm-12">
          
       
     <textarea   class="form-control txtRemark"  id="txtRemark" placeholder="Remark" rows="5"  ></textarea>


          </div>
          </div>

          
              <div class="row "  style="padding-top:80px;">
          <div class="col-sm-4 text-center">
            <h5 class="lbInspector"></h5>
          <hr class="style1">
            <h4 class="lbPosition1" >( Inspector )</h4>
           <h5  class="lbInspectorDate">Date.....................................................</h5>

          </div>
            <div class="col-sm-4 text-center">
              <h5 class="lbEngineer"></h5>
          <hr class="style1">
            <h4 class="lbPosition2" >( Engineer )</h4>
           <h5 class="lbEngineerDate">Date.....................................................</h5>

          </div>
            <div class="col-sm-4 text-center">
              <h5 class="lbManager"></h5>
          <hr class="style1">
          
           <h4 class="lbPosition3" >( Manager )</h5>
           <h5 class="lbManagerDate">Date.....................................................</h5>

          </div>
          </div>

    <div class="row" style="padding-top:10px;">

          <div class="col-sm-12 text-right">
         <button type="button" class="btn btn-lg bg-primary btnConfirm ">ส่งอนุมัติ</button>
         <button type="button" class="btn btn-lg bg-danger btnReject ">ไม่อนุมัติ</button>
        <button type="button" class="btn btn-lg bg-success btnSave ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
          </div>
          </div>

          <div class="row">
          <div class="col-sm-12">
          
          	<div class="divLogHistory">
  <table id="Table1" class="table table-hover  table-fixed" style="width:100%; background-color:#ffffff;">
    <thead>
       <tr class="table-info"><th scope="col">Status</th><th scope="col">Comment</th><th scope="col">Created</th></tr>
      
    </thead>
    <tbody>
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
<div class="modal myModal fade" id="confirm-submit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header  header-blue">
                <h5 class="modal-title" id="H2"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Confirm</h5>
            </div>
            <div class="modal-body">

             <div class="row" style="padding-top:10px;">
            <div class="col-sm-12 text-center">
                 <h4>Are you sure to confirm ?</h4>
                </div>
                </div>

                   <div class="row" style="padding-top:10px;">
            <div class="col-sm-12 text-center">
             <a href="#" id="submit" class="btn btn-lg btn-success success">Approve</a>
             <button type="button" class="btn btn-default btn-lg" data-dismiss="modal">Cancel</button>
            
            </div>
            </div>
             
                <div class="row "  style="padding-top:10px;">
          <div class="col-sm-12">
          
       
     <textarea   class="form-control txtNote"  id="Textarea2" placeholder="Remark" rows="5"  ></textarea>


          </div>
          </div>
            </div>

 
    </div>
</div>
<!-- End Modal-->
</asp:Content>

