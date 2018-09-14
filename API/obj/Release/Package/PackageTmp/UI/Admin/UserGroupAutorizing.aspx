<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserGroupAutorizing.aspx.cs" Inherits="UI_Admin_UserGroupAutorizing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script language=javascript>


 var currentURL= "<%= ResolveUrl("~/ASHX/Admin/UserGroupAutorizeHandler.ashx")%>"; 
 var ID="";



 $(document).ready(function () {


 //bgOperation


});



</script>
 <script src="<%= ResolveUrl("~/Js/ui/Admin/UserGroupAutorizing.js?versionDate=V1") %>" type="text/javascript"></script>

 <style type="text/css">
     
     
     td.details-control {
    background: url('../resources/details_open.png') no-repeat center center;
    cursor: pointer;
}
tr.shown td.details-control {
    background: url('../resources/details_close.png') no-repeat center center;
}


    .radio-green [type="radio"]:checked+label:after {
    border-color: #00C851;
    background-color: #00C851;
}
/*Gap*/

.radio-green-gap [type="radio"].with-gap:checked+label:before {
    border-color: #00C851;
}

.radio-green-gap [type="radio"]:checked+label:after {
    border-color: #00C851;
    background-color: #00C851;
}

input[type="checkbox"]{
  width: 24px; /*Desired width*/
  height: 24px; /*Desired height*/
  cursor: pointer;

}

input[type="radio"]{
  width: 24px; /*Desired width*/
  height: 24px; /*Desired height*/
  cursor: pointer;

}
.spUserGroup
{
	 font-size:20px;
	 color:#ffffff;
	}

.bgOperation
{
	 background-color:#337ab7;
	}
	
	.bgAssertOwner
{
	 background-color:#5cb85c;
	}

    .panel-group .panel {
    margin-bottom: 0;
    overflow: hidden;
    border-radius: 4px;
}

.panel {
    margin-bottom: 20px;
    background-color: #fff;
    border: 1px solid transparent;
    border-radius: 4px;
    -webkit-box-shadow: 0 1px 1px rgba(0,0,0,0.05);
    box-shadow: 0 1px 1px rgba(0,0,0,0.05);
}

.panel-default {
    border-color: #ddd;
}

    .glyphicon { margin-right:10px; }
.panel-body { padding:0px; }
.panel-body table tr td { padding-left: 15px }
.panel-body .table {margin-bottom: 0px; }





.panel-default>.panel-heading {
    color: #333;
    background-color: #f5f5f5;
    border-color: #ddd;
    border: 1px solid transparent;
}


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">

    <!--- Content --->


    <div class="card cardbody">
       <div class="card-header">   <i class="fa fa-cog fa-spin fa-2x" ></i> User Group Autorization </div>

          
              <div class="card-body">


      <div class="row">

            <div class="col-md-4">
        <a class="btn btn-block btn-lg btnOperation btn-primary xzoom">
            <i class="fa fa-users" id="icone_grande"></i> <br><br>
            <span class="texto_grande"> ผู้ปฏิบัติงาน</span></a>
      </div>

           <div class="col-md-4">
        <a class="btn btn-block btn-lg btnAssertOwner btn-success xzoom" >
            <i class="fa fa-users" id="icone_grande"></i> <br><br>
            <span class="texto_grande">Asset Owner</span></a>
      </div>
     

    
          </div>

          <div class="row" style="padding-top:10px;">
          <div class="col-sm-12">
             <div class="card " >
           <div class="card-header  card-MHeader  bgOperation">
           <div class="row">
    <div class="col-sm-10">
         <i class="fa fa-file " style="color:#ffffff;font-size:20px;" ></i> <span class="spUserGroup" > ผู้ปฏิบัติงาน</span>
          </div>
          <div class="col-sm-2 text-right">
         
           <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
          
           </div>
           </div>
          </div>

         <div class="card-body card-body2">
             <div class="row"  style=" padding-top:10px;">
        <div class="col-sm-12">
         <div class="table-responsive divMainTable">
       <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"><span class=" glyphicon glyphicon-globe">
                            </span>Home</a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                         <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table1" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                <tr class="TRow">
                  <td>Home</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox6" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"><span class="fa fa-calendar">
                            </span>&nbsp;Inspenction</a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table2" width="100%" cellspacing="0">
             <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                <tr class="TRow">
                  <td>Inspection Plan</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox7" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><span class=" fa fa-file-pdf-o">
                            </span>&nbsp;Report</a>
                        </h4>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">
                           <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table3" width="100%" cellspacing="0">
             <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                <tr class="TRow">
                  <td>Report</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox8" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour"><span class=" glyphicon glyphicon-phone">
                            </span>Mobile Date</a>
                        </h4>
                    </div>
                    <div id="collapseFour" class="panel-collapse collapse">
                        <div class="panel-body">
                             <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table4" width="100%" cellspacing="0">
               <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                <tr class="TRow">
                  <td>Mobile Date</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                 <!-- <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox9" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>

                 <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive"><span class=" fa fa-window-maximize ">
                            </span>&nbsp;Master</a>
                        </h4>
                    </div>
                    <div id="collapseFive" class="panel-collapse collapse">
                        <div class="panel-body">
                             <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table5" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                 <tr class="TRow">
                  <td>Master</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox12" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                <tr class="TRow">
                  <td>Main Menu</td>
                  <td>Master</td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                 <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox10" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                   <tr class="TRow">
                  <td>ข้อมูล Route Code</td>
                    <td>Master</td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox11" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>

                 <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix"><span class="fa fa-wrench ">
                            </span>&nbsp;System configuration</a>
                        </h4>
                    </div>
                    <div id="collapseSix" class="panel-collapse collapse">
                        <div class="panel-body">
                             <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
                  <!--  <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                 <tr class="TRow">
                  <td>System Configuration</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox13" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                <tr class="TRow">
                  <td>Page Management</td>
                  <td>System Configuration</td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                 <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox14" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                   <tr class="TRow">
                  <td>User Autorize</td>
                    <td>System Configuration</td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox15" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                <tr class="TRow">
                  <td>UserGroup Setting</td>
                    <td>System Configuration</td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox16" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>

                  <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven"><span class="fa fa-user">
                            </span>&nbsp;User Configuration</a>
                        </h4>
                    </div>
                    <div id="collapseSeven" class="panel-collapse collapse">
                        <div class="panel-body">
                             <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table6" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
                  <!--  <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                 <tr class="TRow">
                  <td>User Configuration</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox17" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>
                
              

              </tbody>
            </table>
                            </div>
                        </div>
                    </div>
                </div>

                    <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseEight"><span class=" glyphicon glyphicon-time">
                            </span>&nbsp;Inspection Data</a>
                        </h4>
                    </div>
                    <div id="collapseEight" class="panel-collapse collapse">
                        <div class="panel-body">
                             <div class="table-responsive divMainTable">
                            <table class="table table-bordered table-blue tableMain" id="Table7" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Menu</th>
                  <th>Main Menu</th>
                
                  <th>VIEW</th>
                <!--  <th>EDIT</th>
                  <th>DELETE</th>-->
                  <th>STATUS</th>
                </tr>
              </thead>
             
              <tbody>
                 <tr class="TRow">
                  <td>Inspection Data</td>
                  <td></td>
                 
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                 <!--  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>-->
                  <td>  <input id="Checkbox18" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
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
        </div>
        </div>
        </div>
        </div>

    <!--- Content --->

        </div>
        </div>
  </div>
</div>
</div>
</asp:Content>

