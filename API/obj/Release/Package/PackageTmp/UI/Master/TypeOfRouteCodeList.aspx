<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="TypeOfRouteCodeList.aspx.cs" Inherits="UI_Master_TypeOfRouteCodeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="<%= ResolveUrl("~/Js/ui/Master/M_TypeOfRouteCode.js") %>" type="text/javascript"></script>
<script language=javascript>

 var currentURL= "<%= ResolveUrl("~/ASHX/Master/M_TypeOfRouteCodeHandler.ashx")%>"; 
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

input[type=checkbox]
{
width: 24px;
height: 24px;
color:Green;
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
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" ></i> TypeOfRouteCode List </div>
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
        <div class="card-body card-body2">


          <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span2" style=" width:160px">Code :</span>
    <input   class="form-control txtTypeOfRouteCodeSearch" id="txtTypeOfRouteCodeSearch"  />
   
  </select>
</div>
          </div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span1" style=" width:160px">Name :</span>
     <input   class="form-control txtTypeOfRouteCodeNameSearch" id="txtTypeOfRouteCodeNameSearch"  />
   
  </select>
</div>
          </div>

            

         
          </div>
     
            <div class="row" style="padding-top:10px;">

      <div class="col-sm-2"></div>
     
       <div class="col-sm-5">
      
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
   
      <div class="col-sm-2">
        <button type="button" class="btn btn-lg btn-primary bthSearch ">ค้นหา</button>
         <button type="button" class="btn btn-lg btn-success btnExportChart">EXPORT</button>
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
          <i class="fa fa-file " ></i> TypeOfRouteCode 
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
           <input type="button" class="btn btn-lg btn-primary   btnAdd pull-right" value="เพิ่ม" style="" />
           </div>
           </div>
          </div>
        <div class="card-body card-body2">
       
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                 <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Name</th>
                  <th>Code</th>
                  <th>Status</th>
                  <th>Update Date</th>
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Name</th>
                  <th>Code</th>
                  <th>Status</th>
                  <th>Update Date</th>
                
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
                <td><i class="fa-2x glyphicon glyphicon-zoom-in btnEdit" aria-hidden="true" style=" color:#2c97e9"></i></td>
                 <td><i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i></td>
                  <td>TypeOfRouteCode 1</td>
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


  <div class="modal modalpopup fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="fa fa-cog fa-spin fa-2x" ></i> TypeOfRouteCode</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span3">Code :</span>
    <input   class="form-control txtTypeOfRouteCode" type='text' id="txtTypeOfRouteCode"  />
   
</div>
          </div>
          </div>

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

