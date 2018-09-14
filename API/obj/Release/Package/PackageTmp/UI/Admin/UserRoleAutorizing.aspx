<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserRoleAutorizing.aspx.cs" Inherits="UI_Admin_UserRoleAutorizing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


      <script src="<%= ResolveUrl("~/Js/ui/Admin/UserRoleAutorize.js") %>" type="text/javascript"></script>
      <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Admin/UserRoleAutorizeHandler.ashx") %>"; 


  

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
          <i class="fa fa-users fa-2x" style="color:red"></i> Master / UserRole Autorized </div>
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
  
        </li>

        <li class="list-group-item listLeftMenu">

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
          <i class="glyphicon glyphicon-folder-close" style="color:#F8D90E;" ></i> Assign page to user 
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
  <span class="input-group-addon" id="basic-addon1">Menu</span>
  <input id="txtMenu" type="text" class="form-control txtMenu" data="" placeholder="Menu" aria-label="Menu" aria-describedby="basic-addon1">
</div>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
       
          <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">Refresh</button>
       
        </div>
          <div class="col-sm-1">
       
          <button type="button" class="btn btn-lg btn-success btnSave pull-right">บันทึก</button>
       
        </div>
        </div>
         <!--ตัวกรอง -->
         

        <!-- ตัวกรอง-->
        <div class="row">
        <div class="col-sm-12">
        
        

         <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue tableMain" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Role</th>
                  <th>Screen</th>
                  <th>VIEW</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                  <th>STATUS</th>
                </tr>
              </thead>
              <tfoot>
                <tr>
                 <th>Role</th>
                  <th>Screen</th>
                  <th>VIEW</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                  <th>STATUS</th>
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">

                  <td>Admin</td>
                  <td>Activity Flow</td>
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td>  <input id="chkStatus" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

                 <tr class="TRow">

                  <td>My Baby</td>
                  <td>Activity Flow</td>
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td>  <input id="Checkbox3" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>


                <tr class="TRow">

                  <td>Other</td>
                  <td>Activity Flow</td>
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td>  <input id="Checkbox1" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle" data-size="small"></td>
                </tr>

                <tr class="TRow">
   
                  <td>PTT PLC</td>
                  <td>Activity Flow</td>
                  <td>
                 <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td> <input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td>  <input id="Checkbox2" class="chkStatus" name="chkStatus"  type="checkbox" data-toggle="toggle" data-size="small"></td>
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

        <!-- Detail -->

          </div>

          </div>


    <!--- Content --->

        </div>
        </div>
  </div>
</div>
</asp:Content>

