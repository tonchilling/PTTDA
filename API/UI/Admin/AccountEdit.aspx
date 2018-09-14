<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master"
 AutoEventWireup="true" CodeFile="AccountEdit.aspx.cs"
   EnableEventValidation="false" EnableViewStateMac="false"  Inherits="UI_Admin_AccountEdit" %>


   

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

 <script src="<%= ResolveUrl("~/Js/ui/Admin/AccountEdit.js?versionDate=DateTime.Now") %>" type="text/javascript"></script>
 
 <script src="<%= ResolveUrl("~/Js/jquery-popup-overlay.js?versionDate=DateTime.Now") %>" type="text/javascript"></script>

  <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Admin/AccountEditHandler.ashx") %>"; 
     var accountList= "<%= ResolveUrl("~/UI/Admin/AccountList.aspx") %>"; 
      var pttUserURL= "<%= ResolveUrl("~/ASHX/Admin/PTTUserInfoHandler.ashx") %>"; 
     

       var assertOwnerURL= "<%= ResolveUrl("~/ASHX/Master/M_AssertOwnerHandler.ashx") %>"; 
         var regionURL= "<%= ResolveUrl("~/ASHX/Master/M_RegionHandler.ashx") %>"; 



        
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

 .modal-dialog 
    {
    	
    width: 100%;
    margin: 5px auto;
      
}

.buying-selling {
    width: 100%; 
    
}

.well 
{

    min-height: 20px;
    padding: 19px;
    margin-bottom: 20px;
    background-color: #f5f5f5;
    border: 1px solid #e3e3e3;
    border-radius: 4px;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
    box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
}


 .well 
 {
 	min-width:600px;
        box-shadow: 0 0 10px rgba(0,0,0,0.3);
        display:none;
        margin:1em;
    }

    .popup_wrapper
    {
    	 bottom:400px;
    	}


        .TRow > td 
        {
        	padding:5px;
          }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
  <div class="container-fluid setup-content">
  <div class="row">
    <div class="col-sm-12">


    <div class="card cardbody ">
 <div class="card-header"> <i class="fa fa-user fa-2x" style="color:#428bca"></i> Master / Account Management /Edit</div>
     <div class="card-body">


        <div class="row">

        <div class="col-sm-7">
        <div class="row">
        <div class="col-sm-4">
          <span class="input-group-addon" id="Span17"> ประเภทบัญชีผู้ใช้งาน: </span>

        </div>
         <div class="col-sm-7">
        <div class="funkyradio">
        <table style="width:100%;">
        <tr>
        <td>
        <div class="funkyradio-primary" >
            <input type="radio" class="rdUserType" name="rdUserType"  value="1" id="rdPTT" checked/>
            <label for="rdPTT">PTT PLC</label>
        </div>
        </td>
        <td>
         <div class="funkyradio-success" >
            <input type="radio" class="rdUserType" name="rdUserType" value="2" id="rdBSA" />
            <label for="rdBSA">BSA</label>
        </div>
        </td>
        <td>
           <div class="funkyradio-danger" >
            <input type="radio" class="rdUserType" name="rdUserType" value="3" id="rdOther" />
            <label for="rdOther">Other</label>
        </div>
        </td>
        </tr>
  </table>
      

    </div>

       </div>
       </div>
       <div class="row" style="padding-top:10px;">
         <!-- <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span13">Role:</span>
    <select   class="form-control selectUserRole" id="selectUserRole"  >
     <option value="">-- เลือก --</option>
  <option value="1">Administrator</option>
   <option value="2">Engineer</option>
    <option value="3">Staff</option>
  </select>
</div>
          </div>-->
         <div class="col-sm-8">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="basic-addon1">รหัสพนักงาน</span>
  <input id="txtUserLogin" type="text" class="form-control txtUserLogin" required="required" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" />
   &nbsp; 
</div>



        </div>

        <div class="col-sm-1">
         <button type="button" class="btn btn-lg btn-success btnSearch">ค้นหา</button>
           </div>
          
       </div>
       <div class="row">
        <div class="col-sm-8">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span9">PASSWORD</span>
  <input id="txtPassword" type="text" class="form-control txtPassword" placeholder="Passord" aria-label="Passord" aria-describedby="basic-addon1">
</div>


        </div>
         <div class="col-sm-4">
         
        <input id="chkStatus" class="chkStatus" name="chkStatus" checked type="checkbox"  data-toggle="toggle">
    

        </div>
       </div>
       </div>
        <div class="col-sm-4  text-center">
          <span class="input-group-addon" id="Span19">กลุ่มผู้ใช้งาน</span>
                         <div class="buying-selling-group" id="buying-selling-group" data-toggle="buttons">
                        
        <label class="btn btn-default buying-selling">
            <input type="radio" name="options" class="UserGroup1"  id="UserGroup1" autocomplete="off">
            <span class="radio-dot"></span>
            <span class="buying-selling-word">ผู้ปฏิบัติงาน</span>
           
        </label>
    
        <label class="btn btn-default buying-selling">
            <input type="radio" name="options" class="UserGroup2"  id="UserGroup2" autocomplete="off">
            <span class="radio-dot"></span>
            <span class="buying-selling-word">Viewer</span>
        </label>
</div>
        
        </div>
      

      

      
       </div>
      
 
        <div class="row" style="padding-top:10px;">
        <div class=col-sm-6>
        
          <div class="form-group input-group">
  <span class="input-group-addon" id="Span3">ชื่อบริษัท&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
  <input id="txtCompanyName" type="text" class="form-control txtCompanyName"   placeholder="ชื่อบริษัท" aria-label="ชื่อบริษัท" aria-describedby="basic-addon1">


        </div>
       

       </div>
     </div>
       <div class="row" style="padding-top:10px;">

       <div class="col-sm-2">

  <select  class="selectpicker selectTitleName" name="selectTitleName"   id="selectTitleName"  data-height="30"  data-style="btn-primary" >
  <option value="1" >นาย/Mr</option>
   <option value="2">นางสาว/Miss </option>
    <option value="3">นาง/Mrs </option>
  </select>

        </div>

         <div class="col-sm-4">
          <div class="form-group input-group">
  <span class="input-group-addon"  id="Span1">ชื่อ</span>
  <input id="txtFirstName" type="text" class="form-control txtFirstName"  required="required" placeholder="ชื่อ"  aria-describedby="basic-addon1">
</div>
          </div>
            <div class="col-sm-6">
          <div class="form-group input-group" >
  <span class="input-group-addon"  id="Span2">นามสกุล</span>
  <input id="txtLastName" type="text" class="form-control txtLastName"  required="required" placeholder="นามสกุล"  aria-describedby="basic-addon1">
</div>
          </div>
          </div>
        
         <div class="row" style="padding-top:10px;">


         <div class="col-sm-6">
           
        <div class="input-group">
  <span class="input-group-addon" id="Span4">หน่วยงาน</span>
    <select   class="js-states form-control selectDepartment" id="selectDepartment"  >
     <option value="">-- เลือก --</option>
  <option value="1">ส่วนปฏิบัติการระบบท่อเขต 1</option>
   <option value="2">ส่วนปฏิบัติการระบบท่อเขต 2</option>
    <option value="3">ส่วนปฏิบัติการระบบท่อเขต 3</option>
  </select>
</div>
          </div>
          </div>
          <div  class="row" style="padding-top:10px;">
           <div class="col-sm-6">
                 <div class="form-group input-group" >
  <span class="input-group-addon"  id="Span2">ตำแหน่งใน PIS</span>
  <input id="txtPositionPSI" type="text" class="form-control  txtPositionPSI"    aria-describedby="basic-addon1">
</div>
      <!--    <div class="input-group">
  <span class="input-group-addon" id="Span8">ตำแหน่งใน PIS</span>
    <select   class="form-control selectPositionPSI"  id="selectPositionPSI"   >
        <option value="">--  เลือก --</option>
  <option value="1">ช่างเทคนิค</option>
   <option value="2">ช่างซ่อมท่อ</option>
    <option value="3">พนักงานประจำ</option>
  </select>
</div>-->
          </div>
            <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span5">ตำแหน่งบนระบบ</span>
    <select   class="form-control selectPosition"  id="selectPosition"   >
      <option value="">-- เลือก --</option>
  <option value="1">ช่างเทคนิค</option>
   <option value="2">ช่างซ่อมท่อ</option>
    <option value="3">พนักงานประจำ</option>
  </select>
</div>
          </div>
          </div>
          <div class="row" style="padding-top:10px;">
            <div class="col-sm-6">
          <div class="form-group input-group">
  <span class="input-group-addon" id="Span6">หมายเลขภายใน</span>
  <input id="txtExt"  type="text" class="form-control txtExt" placeholder="หมายเลขภายใน"  aria-describedby="basic-addon1">
</div>
          </div>
            <div class="col-sm-6">
          <div class="input-group">
  <span class="input-group-addon" id="Span7">Email</span>
  <input id="txtEmail"  type="text" class="form-control txtEmail" placeholder="Email"  aria-describedby="basic-addon1">
</div>
          </div>
          </div>
         
          <div class="row" style="padding-top:10px;">
            <div class="col-sm-5">

       <div class="input-group">
           <span class="input-group-addon" id="Span15">Region</span>
  <select class="txtRegion js-states form-control" id="txtRegion" multiple="multiple">
  
  </select>
  </div>
</div>
<div class="col-sm-1">
  <label for="chkRegionAll" class="btn btn-success " style="padding-right:3px;">All<input type="checkbox" 
  id="chkRegionAll" class="badgebox chkRegionAll"><span class="badge ">&check;</span></label>
</div>
  <div class="col-sm-5">

       <div class="input-group">
           <span class="input-group-addon" id="Span16">Asset Owner&nbsp;&nbsp;&nbsp;</span>
  <select class="txtAssertOwner  form-control" id="Select1" multiple="multiple">
  </select>
  </div>
       
</div>
<div class="col-sm-1">
  <label for="chkAssertOwerAll" class="btn btn-success " style="padding-right:3px;">All<input type="checkbox" 
  id="chkAssertOwerAll" class="badgebox chkAssertOwerAll"><span class="badge ">&check;</span></label>
</div>

          </div>
   

           <div class="row" style="padding-top:10px;">
    <div class="col-sm-12">
      <div class="card ">
        <div class="card-header card-header-sub" >
        <span style="font-weight: bold;"> <i class="fa fa-2x fa-check-square-o" style="color:#37d517"></i> Plan</span></div>
         
        <div class="card-body">
          
            <div class="table-responsive">
            <table class="table table-bordered table-blue" id="Table1" width="100%" cellspacing="0">
              <thead>
                <tr >
                  <th colspan="6"  class="text-center">Inspection</th>
                </tr>
                <tr >
                     <th>Create Plan</th>
                       <th>Edit Timeline</th>
                    <th>EditPlan Date</th>
                    <th>Export Plan</th>
                     <th>Confirm Plan</th>
                      <th>Approve Plan</th>
  </tr>
              </thead>
            
              <tbody>
                <tr class="TRow">
                  <td><input name="rdGroupPlan" value="1"  type="checkbox" /></td>
                  <td><input name="rdGroupPlan" value="2" type=checkbox /></td>
                   <td><input name="rdGroupPlan" value="3" type=checkbox /></td>
                  <td><input name="rdGroupPlan" value="4" type=checkbox /></td>
                  <td><input name="rdGroupPlan" value="5" type=checkbox /></td>
                   <td><input name="rdGroupPlan" value="6" type=checkbox /></td>
                </tr>

               
              </tbody>
            </table>
          </div>

        </div>
        <div class="card-footer small text-right"> <button type="button" class="btn btn-lg btn-primary btnSetDefault">Set Default</button>
      <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-secondary btnCancel" data-dismiss="modal">ยกเลิก</button></div>
        
      </div>
      </div>
      </div>
        <input type=hidden class="hddUserID" id="hddUserID" />

     


     </div>
     </div>
     


    </div> 
    </div>
        </div>
  </div>


    <div id="my_popup">

    ...popup content...

    <!-- Add an optional button to close the popup -->
    <button class="my_popup_close">Close</button>

  </div>

  <div id="my_tooltip" class="well">
    <a href="#" class="my_tooltip_close" style="float:right;padding:0 0.4em;">×</a>
    <h4></h4>
    <div class="row">
        <div class="col-sm-10">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span10">รหัสพนักงาน</span>
  <input id="Text1" type="text" class="form-control txtUserLoginSearch" placeholder="รหัสพนักงาน"  aria-describedby="basic-addon1">
</div>


        </div>
        <div class="col-sm-2">
          <button class="btn btn-primary btnSearchPopup">ค้นหา</button>
        </div>
        </div>
        <div class="row">
        <div class="col-sm-6">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span11">ชื่อ</span>
  <input id="Text2" type="text" class="form-control txtFNameSearch" placeholder="ชื่อ"  aria-describedby="basic-addon1">
</div>


        </div>
          <div class="col-sm-6">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span12">สกุล</span>
  <input id="Text3" type="text" class="form-control txtLNameSearch" placeholder="สกุล"  aria-describedby="basic-addon1">
</div>


        </div>
        </div>
       <div class="row">
       <div class="col-sm-12">
       <div class="divMainTable">
       <table class="table table-bordered table-blue tblPTTUser" id="Table2" width="100%" cellspacing="0">
              <thead>
                <tr >
                <th></th>
                     <th>Code</th>
                       <th>First Name</th>
                    <th>Last Name</th>
                    <th>Position</th>

  </tr>
              </thead>
              <tbody>
            
              </tbody>
              </table>
</div>
              </div>
         </div>
  
   
</div>


</asp:Content>

