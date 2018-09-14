﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="AccountList_oldbk.aspx.cs" Inherits="UI_Admin_AccountList_bk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">






  
    <script src="<%= ResolveUrl("~/Js/ui/Admin/AccountList.js?versionDate=DateTime.Now") %>" type="text/javascript"></script>



    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Admin/AccountListHandler.ashx") %>"; 


  

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
    	
    width: 90%;
    margin: 30px auto;
      
}

    </style>



   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
    <div class="container-fluid">
    
 

    <div class="row">
    <div class="col-sm-12">
      <div class="card cardbody">
        <div class="card-header">
          <i class="fa fa-user fa-2x" style="color:#428bca"></i> Master / Account Management </div>
        <div class="card-body">

        <div class="row">
          <div class="col-sm-12">
          
          <div class="card ">
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
        <div class="card-body">


          <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
         <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span9">หน่วยงาน</span>
    <select   class="form-control selectDepartmentSearch" id="selectDepartmentSearch"  >
     <option value="1">ทั้งหมด</option>
  <option value="1">ส่วนปฏิบัติการระบบท่อเขต 1</option>
   <option value="2">ส่วนปฏิบัติการระบบท่อเขต 2</option>
    <option value="3">ส่วนปฏิบัติการระบบท่อเขต 3</option>
  </select>
</div>
          </div>

              <div class="col-sm-3">
          <div class="form-group input-group">
  <span class="input-group-addon"  id="Span10">ชื่อ</span>
  <input id="txtFirstNameSearch" type="text" class="form-control txtFirstNameSearch"  required="required" placeholder="ชื่อ"  aria-describedby="basic-addon1">
</div>
          </div>
           <div class="col-sm-3">
          <div class="form-group input-group">
  <span class="input-group-addon"  id="Span14">Asset Owner</span>
  <input id="Text1" type="text" class="form-control txtFirstNameSearch"  required="required" placeholder="Asset Owner"  aria-describedby="basic-addon1">
</div>
          </div>

          </div>
            <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
         <div class="col-sm-4">
    <div class="input-group">
  <span class="input-group-addon" id="Span11">ตำแหน่งบนระบบ</span>
    <select   class="form-control selectPositionSearch"  id="selectPositionSearch"   >
        <option value="">ทั้งหมด</option>
  <option value="1">ช่างเทคนิค</option>
   <option value="2">ช่างซ่อมท่อ</option>
    <option value="3">พนักงานประจำ</option>
  </select>
</div>
          </div>

       <div class="col-sm-4">
    <div class="input-group">
  <span class="input-group-addon" id="Span12">ประเภทผู้ใช้งาน</span>
    <select   class="form-control selectPositionPSISearch"  id="selectPositionPSISearch"   >
        <option value="">ทั้งหมด</option>
  <option value="1">PTT PLC</option>
   <option value="2">BSA</option>
    <option value="3">Other</option>
  </select>
</div>
          </div>
      <div class="col-sm-1">
        <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">ค้นหา</button>
      </div>
          </div>

        </div>
        </div>
          </div>
        
        </div>
        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-user " ></i> Account 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
           <button type="button" class="btn btn-lg btn-primary   btnAdd pull-right" style="">Add Account</button>
           </div>
           </div>
          </div>
        <div class="card-body">
       
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Position</th>
                  <th>Office</th>
                  <th>Age</th>
                  <th>Start date</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tfoot>
                <tr>
                  <th>Name</th>
                  <th>Position</th>
                  <th>Office</th>
                  <th>Age</th>
                  <th>Start date</th>
                  <th>Status</th>
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
                  <td>Tiger Nixon</td>
                  <td>System Architect</td>
                  <td>Edinburgh</td>
                  <td>61</td>
                  <td>2011/04/25</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Garrett Winters</td>
                  <td>Accountant</td>
                  <td>Tokyo</td>
                  <td>63</td>
                  <td>2011/07/25</td>
                 <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Ashton Cox</td>
                  <td>Junior Technical Author</td>
                  <td>San Francisco</td>
                  <td>66</td>
                  <td>2009/01/12</td>
                 <td><i class="fa fa-battery-empty fa-2x" aria-hidden="true" style=" color:red"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Cedric Kelly</td>
                  <td>Senior Javascript Developer</td>
                  <td>Edinburgh</td>
                  <td>22</td>
                  <td>2012/03/29</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Airi Satou</td>
                  <td>Accountant</td>
                  <td>Tokyo</td>
                  <td>33</td>
                  <td>2008/11/28</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Brielle Williamson</td>
                  <td>Integration Specialist</td>
                  <td>New York</td>
                  <td>61</td>
                  <td>2012/12/02</td>
                   <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Herrod Chandler</td>
                  <td>Sales Assistant</td>
                  <td>San Francisco</td>
                  <td>59</td>
                  <td>2012/08/06</td>
                <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Rhona Davidson</td>
                  <td>Integration Specialist</td>
                  <td>Tokyo</td>
                  <td>55</td>
                  <td>2010/10/14</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                <tr class="TRow">
                  <td>Colleen Hurst</td>
                  <td>Javascript Developer</td>
                  <td>San Francisco</td>
                  <td>39</td>
                  <td>2009/09/15</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Sonya Frost</td>
                  <td>Software Engineer</td>
                  <td>Edinburgh</td>
                  <td>23</td>
                  <td>2008/12/13</td>
                 <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                  <tr class="TRow">
                  <td>Jena Gaines</td>
                  <td>Office Manager</td>
                  <td>London</td>
                  <td>30</td>
                  <td>2008/12/19</td>
                <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Quinn Flynn</td>
                  <td>Support Lead</td>
                  <td>Edinburgh</td>
                  <td>22</td>
                  <td>2013/03/03</td>
                <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Charde Marshall</td>
                  <td>Regional Director</td>
                  <td>San Francisco</td>
                  <td>36</td>
                  <td>2008/10/16</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Haley Kennedy</td>
                  <td>Senior Marketing Designer</td>
                  <td>London</td>
                  <td>43</td>
                  <td>2012/12/18</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
                 <tr class="TRow">
                  <td>Tatyana Fitzpatrick</td>
                  <td>Regional Director</td>
                  <td>London</td>
                  <td>19</td>
                  <td>2010/03/17</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                </tr>
               
              </tbody>
            </table>
          </div>
          </div>
          </div>

</div>
   </div>
        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>
      </div>
      </div>
    </div>
    </div>

   <div class="modal modalpopup  fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="fa fa-2x fa-user" style="color:#1363a7"></i> Account</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">
        <div class="row">

     

       <div class="col-sm-6">
        <div class="funkyradio">
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
        <div class="funkyradio-primary" style="padding-left:5px">
            <input type="radio" name="rdUserType"  value="1" id="rdPTT" checked/>
            <label for="rdPTT">PTT PLC</label>
        </div>
        </td>
        <td>
         <div class="funkyradio-success" style="padding-left:5px">
            <input type="radio" name="rdUserType" value="2" id="rdBSA" />
            <label for="rdBSA">BSA</label>
        </div>
        </td>
        <td>
           <div class="funkyradio-danger" style="padding-left:5px">
            <input type="radio" name="rdUserType" value="3" id="rdOther" />
            <label for="rdOther">Asset Owner</label>
        </div>
        </td>
        </tr>
  </table>
      

    </div>

       </div>

       <div class="col-sm-6">
           <div class="input-group">
  <span class="input-group-addon" id="Span13">Role</span>
    <select   class="form-control selectUserRole" id="selectUserRole"  >
     <option value="">-- เลือก --</option>
  <option value="1">Administrator</option>
   <option value="2">Engineer</option>
    <option value="3">Staff</option>
  </select>
</div>
          </div>
       </div>
       <div class="row" style="padding-top:10px;">
         <div class="col-sm-9">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="basic-addon1">User Name</span>
  <input id="txtUserLogin" type="text" class="form-control txtUserLogin" required="required" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1">
</div>


        </div>

         <div class="col-sm-1">
           <span  style="font-weight: bold;">สถานะ</span>
           </div>
           <div class="col-sm-2">
         
        <input id="chkStatus" class="chkStatus" name="chkStatus" checked type="checkbox"  data-toggle="toggle">
    

        </div>


        </div>
        <div class="row" style="padding-top:10px;">
        <div class=col-sm-12>
        
          <div class="form-group input-group">
  <span class="input-group-addon" id="Span3">ชื่อบริษัท&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
  <input id="txtCompanyName" type="text" class="form-control txtCompanyName"  required="required" placeholder="ชื่อบริษัท" aria-label="ชื่อบริษัท" aria-describedby="basic-addon1">


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
    <select   class="form-control selectDepartment" id="selectDepartment"  >
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
          <div class="input-group">
  <span class="input-group-addon" id="Span8">ตำแหน่งใน PIS</span>
    <select   class="form-control selectPositionPSI"  id="selectPositionPSI"   >
        <option value="">--  เลือก --</option>
  <option value="1">ช่างเทคนิค</option>
   <option value="2">ช่างซ่อมท่อ</option>
    <option value="3">พนักงานประจำ</option>
  </select>
</div>
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
         
          <div class="row"  style="padding-top:10px;">
           <div class="col-sm-12">
          <div class="card ">
        <div class="card-header card-header-sub">
         <span style="font-weight: bold;"> <i class="fa fa-2x fa-globe" style="color:#37d517"></i> พื้นที่สังกัด</span></div>
        <div class="card-body">

        <div class="row"  style="padding-top:10px;">

          <div class="col-sm-2">
          <div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="1" id="radio103">
    <label for="radio103">Region 1</label>

    </div>
    </div>
     <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="2" id="radio104" >
    <label for="radio104">Region 2</label>
</div>
</div>
 <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="3" id="radio105">
    <label for="radio105">Region 3</label>
</div>
          </div>
              <div class="col-sm-2">
          <div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="4" id="radio1">
    <label for="radio103">Region 4</label>

    </div>
    </div>
     <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="5" id="radio5" >
    <label for="radio104">Region 5</label>
</div>
</div>
 <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="6" id="radio6">
    <label for="radio105">Region 6</label>
</div>
          </div>
          </div>
           <div class="row"  style="padding-top:10px;">

          <div class="col-sm-2">
          <div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="7" id="radio7">
    <label for="radio103">Region 7</label>

    </div>
    </div>
     <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="8" id="radio8" >
    <label for="radio104">Region 8</label>
</div>
</div>
 <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="9" id="radio9">
    <label for="radio105">Region 9</label>
</div>
          </div>
              <div class="col-sm-2">
          <div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="10" id="radio10">
    <label for="radio103">Region 10</label>

    </div>
    </div>
     <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox" value="11" id="radio11" >
    <label for="radio104">Region 11</label>
</div>
</div>
 <div class="col-sm-2">
<div class="form-group radio-green">
    <input name="rdGroupRegion" type="checkbox"  value="12"id="radio12">
    <label for="radio105">Region 12</label>
</div>
          </div>
          </div>




          </div>
          </div>
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
                  <th rowspan="2" style="">Admin</th>
                  <th rowspan="2">Inspection Plan</th>
                  <th rowspan="2">Preparation <br>Inspenction Plan</th>
                  <th rowspan="2">Maintain Plan</th>
                  <th rowspan="2">Maintain</th>
                  <th rowspan="2">Inspection<br>Approval</th>
                    <th rowspan="2">HeightRisk<br>Approval</th>
                    <th rowspan="2">Inspected<br>Confirmation</th>
                       <th rowspan="2">Inspected<br>Confirmation</th>
                       <th colspan="4" class="text-center">Master</th>
                </tr>
                <tr >
                     <th>Account<br>Management</th>
                    <th>Pipeline<br>Management</th>
                    <th>Permit<br>Management</th>
                     <th>Frequency<br>Management</th>
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
                 <td><input name="rdGroupPlan" value="7" type=checkbox /></td>
                  <td><input name="rdGroupPlan" value="8" type=checkbox /></td>
                   <td><input name="rdGroupPlan" value="9" type=checkbox /></td>
                 <td><input name="rdGroupPlan" value="10" type=checkbox /></td>
                 <td><input name="rdGroupPlan" value="11" type=checkbox /></td>
                  <td><input name="rdGroupPlan" value="12" type=checkbox /></td>
                </tr>

               
              </tbody>
            </table>
          </div>

        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
        
      </div>
      </div>
      </div>
        <input type=hidden class="hddUserID" id="hddUserID" />

      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>
</asp:Content>
