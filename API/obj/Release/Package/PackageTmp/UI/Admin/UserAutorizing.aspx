<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserAutorizing.aspx.cs" Inherits="UI_Admin_UserAutorizing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


      <script src="<%= ResolveUrl("~/Js/ui/Admin/UserAutorize.js") %>" type="text/javascript"></script>
      <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Admin/UserPermissionHandler.ashx") %>"; 


  

    </script>

     <style type="text/css">
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


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">

    <!--- Content --->


    <div class="card cardbody">
        <div class="card-header">
          <i class="fa fa-users fa-2x text-primary" ></i> Master / User Autorized </div>
        <div class="card-body">



       

        <!-- Detail -->

         <div class="row" style="padding-top:30px;">
          <div class="col-sm-4">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="glyphicon glyphicon-folder-close" style="color:#F8D90E;" ></i> Select Menu 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
          
           </div>
           </div>
          </div>
        <div class="card-body">
       
          <div class="row">
         <div class="col-sm-12 divfordtreeview">
            <!-- TREEVIEW CODE -->
         <ul class="fordtreeview list-group  bthSearch">
  <li class="list-group-item"><input type="text" class="form-control menufilter" placeholder="Search Menu"/></li>
    <li class="list-group-item listTopMenu">
    <span class="hasSub"><i class="glyphicon glyphicon-folder-close folder"></i> All Menu</span>
    <ul class="list-group expanded"> 
     <li class="list-group-item"><i class="fa fa-internet-explorer link"></i> <span data="05FE1943-9AF2-4D3A-A837-FEEFF511B9F3">Activity Flow</span></li>
     <li class="list-group-item"><i class="fa fa-internet-explorer link"></i><span data="3DD32011-D84B-4D51-BA25-FE79C7243B0F">Report</span></li>
     <li class="list-group-item"><i class="fa fa-internet-explorer link"></i><span data="E213A181-1EB8-48F4-996B-3F9F81D71787">List Plan</span></li>
      <li class="list-group-item"><i class="fa fa-internet-explorer link"></i><span data="E213A181-1EB8-48F4-996B-3F9F81D71787">Repair History</span></li>
       <li class="list-group-item"><i class="fa fa-internet-explorer link"></i><span data="E213A181-1EB8-48F4-996B-3F9F81D71787">Mobile Data</span></li>
          <li class="list-group-item"><i class="fa fa-internet-explorer link"></i><span data="E213A181-1EB8-48F4-996B-3F9F81D71787">User Configuration</span></li>
</ul>
        </li>

   
</ul>
            <!-- TREEVIEW CODE -->
            </div>
            </div>
          
          </div>
          </div>

</div>
            <div class="col-sm-8">

             <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="glyphicon glyphicon-folder-close" style="color:#F8D90E;" ></i> <span class="lbMenuSelect"> Select Menu </span>
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
          
           </div>
           </div>
          </div>
        <div class="card-body">

          <div class="row">
          <div class="col-sm-2"></div>
        <div class="col-sm-6">
         <div class="form-group input-group ">
  <span class="input-group-addon" id="basic-addon1">Account : </span>
  <input id="txtUserLogin" type="text" class="form-control txtUserLogin" data="" placeholder="Account" aria-label="Menu" aria-describedby="basic-addon1">
</div>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
       
          <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">ค้นหา</button>
       
        </div>
          <div class="col-sm-1">
       
          <button type="button" class="btn btn-lg btn-success btnSave pull-right">บันทึก</button>
       
        </div>
        </div>
         <!--ตัวกรอง -->
           <div class="row" >

            <div class="col-sm-2"></div>
         <div class="col-sm-8"> 
            <div class="funkyradio">
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
        <div class="funkyradio-info" style="padding-left:5px">
            <input type="radio" name="rdUserType" class="rdUserType bthSearch"  value="" id="rdAll" checked/>
            <label for="rdAll">ALL</label>
        </div>
        </td>

        <td>
        <div class="funkyradio-primary" style="padding-left:5px">
            <input type="radio" name="rdUserType" class="rdUserType bthSearch"  value="1" id="rdPTT" />
            <label for="rdPTT">PTT PLC</label>
        </div>
        </td>
        <td>
         <div class="funkyradio-success" style="padding-left:5px">
            <input type="radio" name="rdUserType" class="rdUserType bthSearch" value="2" id="rdBSA" />
            <label for="rdBSA">BSA</label>
        </div>
        </td>
        <td>
           <div class="funkyradio-danger" style="padding-left:5px">
            <input type="radio" name="rdUserType" class="rdUserType bthSearch" value="3" id="rdOther" />
            <label for="rdOther">Other</label>
        </div>
        </td>
     

        </tr>
  </table>
      

    </div>

         
          </div>

             

          </div>

        <!-- ตัวกรอง-->
        <div class="row">
        <div class="col-sm-12">
        
        

         <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue tableMain" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Account</th>
                  <th>Account Type</th>
                  <th>Screen</th>
                  <th>VIEW</th>
                <!--  <th>EDIT</th>
                  <th>DELETE</th>
                  <th>STATUS</th>-->
                </tr>
              </thead>
              <tfoot>
                <tr>
                  <th>Account</th>
                  <th>Account Type</th>
                  <th>Screen</th>
                  <th>VIEW</th>
               <!--   <th>EDIT</th>
                  <th>DELETE</th>
                  <th>STATUS</th>-->
                </tr>
              </tfoot>
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

        <!-- Detail -->

          </div>

          </div>


    <!--- Content --->

        </div>
        </div>
  </div>
</div>
</asp:Content>

