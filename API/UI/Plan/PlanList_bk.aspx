<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanList_bk.aspx.cs" Inherits="UI_Plan_PlanList_bk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


   <!-- <script src="<%= ResolveUrl("~/Js/ui/MenuPage.js") %>" type="text/javascript"></script>-->



    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/MenuHandler.ashx") %>"; 


  

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
 <div class="card-header"><i class="fa fa-internet-explorer fa-2x" style="color:#428bca"></i> Plan List </div>
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
  <span class="input-group-addon" id="Span2" style=" width:160px">DIG from :</span>
    <select   class="form-control selectDIGFrom" id="selectDIGFrom"  >
   
  </select>
</div>
          </div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span1" style=" width:160px">Region :</span>
    <select   class="form-control selectRegion" id="selectRegion"  >
   
  </select>
</div>
          </div>

            

           <div class="col-sm-1">
        <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">ค้นหา</button>
      </div>
          </div>
            <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span3" style=" width:160px">Type Of Pipeline :</span>
    <select   class="form-control selectPipeline" id="selectPipeline"  >
   
  </select>
</div>
          </div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span4" style=" width:160px">Assert Owner :</span>
    <input   class="form-control txtAssertOwner" id="txtAssertOwner"  />

</div>
          </div>
          </div>
         
          <div class="row" style="padding-top:10px;">

          <div class="col-sm-2"></div>
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span5" style=" width:160px">Route Code :</span>
    <select   class="form-control selectRouteCode" id="selectRouteCode"  >
   
  </select>
</div>
          </div>
                <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span6" style=" width:160px">Risk Score :</span>
    <select   class="form-control selectRiskScore" id="selectRiskScore"  >
   
  </select>
</div>
          </div>
          </div>

            <div class="row" style="padding-top:10px;">

      <div class="col-sm-2"></div>
     
       <div class="col-sm-6">
      
        <table style="width:100%; border-spacing: 10px;">
        <tr>
        <td>
         <span class="input-group-addon" id="Span7" >Status :</span>
        </td>
        <td>
         <div class="funkyradio">
            <div class="funkyradio-primary" style="padding-left:5px">
             <input type="radio" name="rdUserType"  value="radio1" id="rdAll"  />
             <label for="rdAll">All</label>
             </div>
             </div>
        </td>
        <td>
          <div class="funkyradio">
            <div class="funkyradio-success" style="padding-left:5px">
             <input type="radio" name="rdUserType"  value="rdActive" id="rdActive"  />
             <label for="rdActive">Active</label>
             </div>
             </div>
        </td>

         <td>
          <div class="funkyradio">
            <div class="funkyradio-danger" style="padding-left:5px">
             <input type="radio" name="rdUserType"  value="rdInActive" id="rdInActive"  />
             <label for="rdInActive">In Active</label>
             </div>
             </div>
        </td>
       
        </tr>
  </table>
      

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
                 <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Region</th>
                  <th>RC</th>
                  <th>Section</th>
                  <th>KP</th>
                  <th>DIG From</th>
                   <th>Risk</th>
                     <th>Plan Date</th>
                    <th>Complete</th>
                     <th>Report</th>
                       <th>No.Costing Defect</th>
                      <th>No.Pipe Defect</th>
                       <th>Repair Lenght</th>
                  <th>Status</th>
                </tr>
              </thead>
              <tfoot>
                <tr>
                <th>VIEW</th>
                  <th>DELETE</th>
                 <th>Region</th>
                  <th>RC</th>
                  <th>Section</th>
                  <th>KP</th>
                  <th>DIG From</th>
                   <th>Risk</th>
                     <th>Plan Date</th>
                    <th>Complete</th>
                     <th>Report</th>
                       <th>No.Costing Defect</th>
                      <th>No.Pipe Defect</th>
                       <th>Repair Lenght</th>
                  <th>Status</th>
                
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">
                <td><i class="fa-2x glyphicon glyphicon-zoom-in btnEdit" aria-hidden="true" style=" color:#2c97e9"></i></td>
                 <td><i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i></td>
                  <td>Region 1</td>
                  <td>400</td>
                  <td>BV1-BV6</td>
                  <td>102</td>
                  <td>Other</td>
                   <td><i class="fa-2x glyphicon glyphicon-stop" aria-hidden="true" style=" color:red"></i></td>
                   <td>01/10/2559</td>
                    <td>20/10/2559</td>
                     <td>22/10/2559</td>
                       <td>0</td>
                        <td>0</td>
                          <td>33</td>
                  <td><i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i></td>
                  
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
        </div>
  </div>








</asp:Content>

