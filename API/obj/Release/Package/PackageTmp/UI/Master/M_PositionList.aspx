<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="M_PositionList.aspx.cs" Inherits="UI_Admin_M_PositionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="<%= ResolveUrl("~/Js/ui/Master/M_Position.js") %>" type="text/javascript"></script>
<script language=javascript>

 var currentURL= "<%= ResolveUrl("~/ASHX/Master/M_PositionHandler.ashx")%>"; 
 var ID="";
</script>


<style type="text/css">

@media (min-width: 768px) {
    .modal-dialog {
        width: 800px;
        margin: 30px auto
    }
    .modal-content {
        -webkit-box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
        box-shadow: 0 5px 15px rgba(0, 0, 0, .5)
    }
    .modal-sm {
        width: 300px
    }
}
@media (min-width: 992px) {
    .modal-lg {
        width: 900px
    }
}
@media (min-width: 768px) {
    .modal-dialog {
        width: 800px;
        margin: 30px auto
    }
    .modal-content {
        -webkit-box-shadow: 0 5px 15px rgba(0, 0, 0, .5);
        box-shadow: 0 5px 15px rgba(0, 0, 0, .5)
    }
    .modal-sm {
        width: 300px
    }
}
@media (min-width: 992px) {
    .modal-lg {
        width: 900
}


</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->
<div class="card cardbody ">
 <div class="card-header"><i class="glyphicon glyphicon-globe fa-2x" style="color:green"></i> UserRole List </div>
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
              <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span1" style=" width:160px">Name :</span>
     <input   class="form-control txtNameSearch" id="txtNameSearch"  />
   

</div>
          </div>

            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span2" style=" width:160px">Name Eng :</span>
    <input   class="form-control txtNameEngSearch" id="txtNameEngSearch"  />
   

</div>
          </div>
        

            

         
          </div>
     
            <div class="row" style="padding-top:10px;">

      <div class="col-sm-2"></div>
     
       <div class="col-sm-8">
      
        <table style="border-spacing: 10px;">
        <tr>
       <td>
         <span class="input-group-addon" id="Span7" >Status :</span>
        </td>
        <td >
         <div class="funkyradio">
            <div class="funkyradio-primary" style="width:150px;padding-left:5px;">
             <input type="radio" name="chkStatusSearch"  checked value="" id="rdAllSearch"  />
             <label for="rdAllSearch">All</label>
             </div>
             </div>
        </td>
       <td >
          <div class="funkyradio">
            <div class="funkyradio-success" style="width:150px;padding-left:5px">
             <input type="radio" name="chkStatusSearch"  value="1" id="rdActiveSearch"  />
             <label for="rdActiveSearch">Active</label>
             </div>
             </div>
        </td>

         <td >
          <div class="funkyradio">
            <div class="funkyradio-danger" style="width:150px;padding-left:5px">
             <input type="radio" name="chkStatusSearch"  value="0" id="rdInActiveSearch"  />
             <label for="rdInActiveSearch">In Active</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
      

    </div>
     <div class="col-sm-1"></div>
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
          
    <div class="card">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-file " ></i> UserRole 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
           <input type="button" class="btn btn-lg btn-primary   btnAdd pull-right" value="เพิ่ม" style="" />
           </div>
           </div>
          </div>
        <div class="card-body">
       
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                 <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Name</th>
                  <th>Desc</th>
                  <th>Status</th>
                  <th>Update Date</th>
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Name</th>
                  <th>Desc</th>
                  <th>Status</th>
                  <th>Update Date</th>
                
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
                <td><i class="fa-2x glyphicon glyphicon-zoom-in btnEdit" aria-hidden="true" style=" color:#2c97e9"></i></td>
                 <td><i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i></td>
                  <td>UserRole 1</td>
                  <td>R001</td>
                 <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                  <td>01/10/2559</td>
                  
                 
                  
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
        <h5 class="modal-title" id="exampleModalLabel"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> UserRole</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">



       <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span4" >Name :</span>
     <input   class="form-control txtName" type='text' id="txtName"  />
   

</div>
          </div>

            

          
          </div>


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Name Eng :</span>
    <input   class="form-control txtNameEng" type='text' id="txtNameEng"  />
   
</div>
          </div>
          </div>

          <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span6">Level :</span>
    <select   class="form-control txtRole" type='text' id="txtRole"  >
     <option value="1" >1</option>
   <option value="2">2</option>
    <option value="3">3</option>
    <option value="4">4</option>
       <option value="5">5</option>
    </select>
   
</div>
          </div>
          </div>

          
          
            <div class="row" style="padding-top:10px;">

      <div class="col-sm-1"></div>
     
       <div class="col-sm-8">
      
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
         <span class="input-group-addon" id="Span5" >Status :</span>
        </td>

        <td>
          <div class="funkyradio">
            <div class="funkyradio-success" style="padding-left:5px">
             <input type="radio" name="chkStatus"  value="1" id="rdActive"  />
             <label for="rdActive">Active</label>
             </div>
             </div>
        </td>

         <td>
          <div class="funkyradio">
            <div class="funkyradio-danger" style="padding-left:5px">
             <input type="radio" name="chkStatus"  value="0"  id="rdInActive"  />
             <label for="rdInActive">In Active</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
      

    </div>

       </div>
          


      </div>
      <div class="modal-footer">
       <button type="button" class="btn btn-lg btn-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
       
      
      </div>
    </div>
  </div>
</div>
</asp:Content>

