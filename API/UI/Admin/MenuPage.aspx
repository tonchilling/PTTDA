<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="MenuPage.aspx.cs" Inherits="UI_Admin_MenuPage" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="<%= ResolveUrl("~/Js/ui/Admin/MenuPage.js") %>" type="text/javascript"></script>



    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Admin/MenuHandler.ashx") %>"; 


  

    </script>

     <style type="text/css">
    .modal-dialog 
    {
    	
    width: 800px;
    margin: 30px auto;
      
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
        <div class="card-header ">
          <i class="fa fa-internet-explorer fa-2x" style="color:#428bca"></i> Master / Page Management </div>
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
          <div class="col-sm-6">
      
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
         <span class="input-group-addon" id="Span6" >Position :</span>
        </td>

        <td>
          <div class="funkyradio">
            <div class="funkyradio-primary" style="padding-left:5px">
             <input type="radio" checked name="chkPositionSearch"  value="" id="rdAllSearch"  />
             <label for="rdAllSearch">All</label>
             </div>
             </div>
        </td>
        <td>
          <div class="funkyradio">
            <div class="funkyradio-success" style="padding-left:5px">
             <input type="radio" name="chkPositionSearch"  value="L" id="rdLeftSearch"  />
             <label for="rdLeftSearch">Left</label>
             </div>
             </div>
        </td>

         <td>
          <div class="funkyradio">
            <div class="funkyradio-danger" style="padding-left:5px">
             <input type="radio" name="chkPositionSearch"  value="T"  id="rdTopSearch"  />
             <label for="rdTopSearch">Top</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
      

    </div>
        </div>
          <div class="row" style="padding-top:10px;">
            <div class="col-sm-2"></div>
        
         <div class="col-sm-3"> 
         <div class="form-group input-group">
  <span class="input-group-addon"  id="Span10">Name</span>
  <input id="txtNameSearch" type="text" class="form-control txtNameSearch"  required="required" placeholder="ชื่อ"  aria-describedby="basic-addon1">
</div>
         
          </div>

              <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span2">Group Name</span>
    <select   class="form-control selectMENUGROUPSearch" id="selectMENUGROUPSearch"  >
   
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
          <i class="fa fa-file " ></i> Page 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
           <button type="button" class="btn btn-lg btn-primary   btnAdd pull-right" style="">เพิ่ม</button>
           </div>
           </div>
          </div>
        <div class="card-body">
       
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Desc</th>
                  <th>Screen</th>
                  <th>Link</th>
                  <th>Order</th>
                  <th>Status</th>
                  <th>Edit</th>
                </tr>
              </thead>
              <tfoot>
                <tr>
                 <th>Name</th>
                  <th>Desc</th>
                  <th>Screen</th>
                  <th>Link</th>
                  <th>Order</th>
                  <th>Status</th>
                  <th>Edit</th>
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
                  <td>Main Menu</td>
                  <td>หน้าหลัก</td>
                  <td>Index</td>
                  <td>Index.aspx</td>
                  <td>1</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                  <td><i class="fa fa-2x fa-pencil-square btnEdit" aria-hidden="true" style=" color:#2c97e9"></i></td>
                </tr>

              </tbody>
            </table>
          </div>
          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
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

 <div class="modal modalpopup fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="fa fa-internet-explorer fa-2x " style="color:#1363a7"></i> Menu</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

     
     
       <div class="col-sm-8">
      
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
         <span class="input-group-addon" id="Span5" >Position :</span>
        </td>

        <td>
          <div class="funkyradio">
            <div class="funkyradio-success" style="padding-left:5px">
             <input type="radio" name="chkPosition"  value="L" id="rdLeft"  />
             <label for="rdLeft">Left</label>
             </div>
             </div>
        </td>

         <td>
          <div class="funkyradio">
            <div class="funkyradio-danger" style="padding-left:5px">
             <input type="radio" name="chkPosition"  value="T"  id="rdTop"  />
             <label for="rdTop">Top</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
      

    </div>

       </div>

       <div class="row" style="padding-top:10px;">
         <div class="col-sm-9">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="basic-addon1">Menu Name</span>
  <input id="txtPageName" type="text" class="form-control txtPageName"
   required="required" placeholder="Username" aria-label="Page Name" aria-describedby="basic-addon1">
</div>


        </div>

  
        
        <div class="col-sm-1">
        <a href="#" data-toggle="popover" > <div class="col-sm-1 divshowIcon"><i class="fa fa-user fa-2x " aria-hidden="true"></i></div></a>
   <div id="divIcon" class="divIcon" style="display: none"  class="container">
   <div class="row fontawesome-icon-list">
    
      <div class="fa-hover  col-sm-3"><a><i class="fa fa-users fa-2x " aria-hidden="true" data="fa fa-users"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-file-pdf-o fa-2x" aria-hidden="true" data="fa fa-file-pdf-o"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-calendar fa-2x" aria-hidden="true" data="fa fa-calendar"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-file-text fa-2x" aria-hidden="true" data="fa fa-file-text"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-address-book fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-cog fa-2x" aria-hidden="true" data="fa fa-cog"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-window-maximize fa-2x" aria-hidden="true" data="fa fa-window-maximize"></i></a></div>
      <div class="fa-hover  col-sm-3"><a><i class="fa fa-user fa-2x " aria-hidden="true" data="fa fa-user"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-folder-open fa-2x" aria-hidden="true" data="fa fa-folder-open"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-sitemap fa-2x" aria-hidden="true" data="fa fa-sitemap"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-phone fa-2x" aria-hidden="true" data="glyphicon glyphicon-phone"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-globe fa-2x" aria-hidden="true" data="glyphicon glyphicon-globe"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-file fa-2x" aria-hidden="true" data="glyphicon glyphicon-file"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa  fa-wrench fa-2x" aria-hidden="true" data="fa fa-wrench"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-internet-explorer fa-2x" aria-hidden="true" data="fa fa-internet-explorer"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-time fa-2x" aria-hidden="true" data="glyphicon glyphicon-time"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-signal fa-2x" aria-hidden="true" data="glyphicon glyphicon-signal"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-list-alt fa-2x" aria-hidden="true" data="glyphicon glyphicon-list-alt"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-calculator fa-2x" aria-hidden="true" data="fa fa-calculator"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-laptop fa-2x" aria-hidden="true" data="fa fa-laptop"></i></a></div>

  </div>
</div>
        </div>
        </div>
         <div class="row" style="padding-top:0px;">
         <div class="col-sm-12">
           <div class="input-group">
  <span class="input-group-addon" id="Span4">Menu Group</span>
    <select   class="form-control selectMENUGROUP" id="selectMENUGROUP"  >
     <option value="">-- เลือก --</option>
  <option value="1">ส่วนปฏิบัติการระบบท่อเขต 1</option>
   <option value="2">ส่วนปฏิบัติการระบบท่อเขต 2</option>
    <option value="3">ส่วนปฏิบัติการระบบท่อเขต 3</option>
  </select>
</div>
          </div>
          </div>

           <div class="row" style="padding-top:10px;">
         <div class="col-sm-12">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span3" style="width:120px;">Screen</span>
  <input id="txtScreen" type="text" class="form-control txtScreen"
   placeholder="Screen" aria-label="Screen" aria-describedby="basic-addon1">
</div>


        </div>
        </div>
            <div class="row" style="padding-top:10px;">
         <div class="col-sm-12">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span9" style="width:120px;">Link</span>
  <input id="txtLink" type="text" class="form-control txtLink"
   placeholder="Link" aria-label="Link" aria-describedby="basic-addon1">
</div>


        </div>
        </div>


          <div class="row" style="padding-top:10px;">
         <div class="col-sm-12">
       
        <div class="form-group input-group ">
  <span class="input-group-addon" id="Span1" style="width:120px;">Desc</span>
  <textarea id="txtDesc" type="text" class="form-control txtDesc" rows="4"
   required="required" placeholder="Decription" aria-label="Decription" aria-describedby="basic-addon1"></textarea>
</div>


        </div>
        </div>
         
       
           
        <div class="row">
        <div class="col-sm-4">
          <div class="form-group input-group ">
  <span class="input-group-addon" id="Span7" style="width:120px;">Order</span>
  <input id="txtOrderNo" type="text" class="form-control txtOrderNo"
   placeholder="Order No" aria-label="txtOrderNo" aria-describedby="basic-addon1">
</div>
        </div>

          <div class="col-sm-1">
           <span  style="font-weight: bold;">สถานะ</span>
           </div>
           <div class="col-sm-2">
         
        <input id="chkStatus" class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle">
    

        </div>
        </div>
     
        
   

          
        <input type=hidden class="hddID" id="hddID" />

      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>

</asp:Content>

