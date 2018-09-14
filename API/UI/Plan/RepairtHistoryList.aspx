<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="RepairtHistoryList.aspx.cs" Inherits="UI_Plan_RepairtHistoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


   <!-- <script src="<%= ResolveUrl("~/Js/ui/MenuPage.js") %>" type="text/javascript"></script>-->



    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/MenuHandler.ashx") %>"; 

    $(document).ready(function () {


     $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });

            $('.btnAdd').on("click",function(e){
            
            window.location.href =' <%= ResolveUrl("~/UI/Plan/CreatingPlan.aspx") %>';
            });

  });

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
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i> Repair History </div>
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
         
            <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span1" style=" width:160px">Region :</span>
    <select   class="form-control selectRegion" id="selectRegion"  >
   
  </select>
</div>
          </div>

             <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span5" style=" width:160px">Route Code :</span>
    <select   class="form-control selectRegion" id="select1"  ></select>
</div>
          </div>
          
           <div class="col-sm-1">
        <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">ค้นหา</button>
      </div>
      
          </div>
           
         
         

            <div class="row" style="padding-top:10px;">

      <div class="col-sm-2"></div>
     
     

       </div>


        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-10">
          <i class="fa fa-file " ></i> Page 
          </div>
          <div class="col-sm-2">
          
           
           <button type="button" class="btn btn-lg btn-success bthSearch pull-right">Export Table</button>
         
           </div>
           </div>
          </div>
        <div class="card-body">
      
    
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>
                
                 <th>Region</th>
                  <th>Year</th>
                  <th>RC</th>
                  <th>Section</th>
                  <th>KP</th>
                   <th>Dig Form</th>
                     <th>Dig Date</th>
                    <th>No. Coating Defect</th>
                     <th>No. Pipe Defect</th>
                       <th>Repair Lenght(m)</th>
                  <th>Report</th>
                </tr>
              </thead>
              <tfoot>
                <tr>
                <th>Region</th>
                  <th>Year</th>
                  <th>RC</th>
                  <th>Section</th>
                  <th>KP</th>
                   <th>Dig Form</th>
                     <th>Dig Date</th>
                    <th>No. Coating Defect</th>
                     <th>No. Pipe Defect</th>
                       <th>Repair Lenght(m)</th>
                  <th>Report</th>
                
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
               
                  <td>xx</td>
                  <td>xx</td>
                  <td>xx</td>
                  <td>xx</td>
                  <td>xx</td>
                   <td>xx</td>
                   <td>xx</td>
                    <td>xx</td>
                     <td>xx</td>
                       <td>xx</td>

                 <td><i class="fa-2x fa fa-file-pdf-o" aria-hidden="true" style=" color:red"></i></td>
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
        </div>
          </div>
        
        </div>

     </div>
         
<!--- Content --->
</div> 
    </div>








</asp:Content>

