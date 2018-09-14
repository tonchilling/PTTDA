<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="MainMasterList.aspx.cs" Inherits="UI_Master_MainMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<!--<script src="<%= ResolveUrl("~/Js/ui/Master/M_KP.js") %>" type="text/javascript"></script>-->
<script language=javascript>

 var currentURL= "<%= ResolveUrl("~/ASHX/Master/M_KPHandler.ashx")%>"; 
 var ID="";


 var regionData = [
    {
        id: 0,
        text: 'Region 1'
    },
    {
        id: 1,
        text: 'Region 2'
    },
    {
        id: 2,
        text: 'Region 3'
    },
    {
        id: 3,
        text: 'Region 4'
    }
];


$(document).ready(function () {

RegionControl();
     });




     function RegionControl()
     {
     
     
 $(".txtRegion").select2({
        tags: true,
    
         data: regionData,
         width: '100%'
     });


  $(".chkRegionAll").click(function () {
         if ($(".chkRegionAll").is(':checked')) {
             $(".txtRegion > option").prop("selected", "selected");
             $(".txtRegion").trigger("change");
         } else {



             $('.txtRegion').val('').trigger("change");

         }
     });



   

     }
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
<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" ></i> Master List </div>
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

           <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span1">Region :</span>
   <select name="RegionID" class="form-control" id="Select2" 
   data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
           <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span6">Assert Owner :</span>
   <select name="RegionID" class="form-control" id="Select3" 
   data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
             <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span2">Route Code :</span>
   <select name="RegionID" class="form-control" id="Select1" 
   data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
           

         
          </div>

           <div class="row" style="padding-top:10px;">

           <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span7">Type Of Route Code :</span>
   <select name="RegionID" class="form-control" id="Select4" 
   data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
           <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span8">License :</span>
   <select name="RegionID" class="form-control" id="Select5" 
   data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
             <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span9">Coating Type :</span>
   <select name="RegionID" class="form-control" id="Select6" 
   data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
           

         
          </div>
     
            <div class="row" style="padding-top:10px;">

       <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span10">Location Class :</span>
   <select name="RegionID" class="form-control" id="Select7" 
   data-val-required="The RegionID field is required." data-val-number="The field RegionID must be a number." data-val="true"><option selected="selected" value="0">ทั้งหมด</option>

</select>


</div>
          </div>
    
   
      <div class="col-sm-2">
        <button type="button" class="btn btn-lg btn-primary bthSearch">ค้นหา</button>
       
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
          <i class="fa fa-file " ></i> List
          </div>
          <div class="col-sm-1">
         
           </div>
           <div class="col-sm-1">
        <!--   <input type="button" class="btn btn-lg btn-primary   btnAdd pull-right" value="เพิ่ม" style="" />
        •	Route Code
•	ใบอนุญาต
•	Coating Type
•	Location Class
•	Asset Owner
•	Region
•	Type of Route Code

        -->
           </div>
           </div>
          </div>
        <div class="card-body card-body2">
       
            <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">
              <thead>
                <tr>

                 <th>Region</th>
                   <th>Asset Owner</th>
                  <th>Route Code</th>
                   <th>Type of Route Code</th>
                 <th>License</th>
                  <th>Coating Type</th>
                   <th>Location Class</th>

                
                </tr>
              </thead>
              <tfoot>
                <tr>

                <th>Region</th>
                   <th>Asset Owner</th>
                  <th>Route Code</th>
                   <th>Type of Route Code</th>
                 <th>License</th>
                  <th>Coating Type</th>
                   <th>Location Class</th>
                
                </tr>
              </tfoot>
              <tbody>
                <tr class="TRow">

                  <td><a href="<%= ResolveUrl("~/UI/Master/RegionList.aspx")%>"> Region 1</a></td>
                  <td><a href="<%= ResolveUrl("~/UI/Master/AssertOwnerList.aspx")%>"> Assert Owner 1</a></td>
                   <td><a href="<%= ResolveUrl("~/UI/Master/RouteCodeList.aspx")%>">RC0650</a></td>
                      <td><a href="<%= ResolveUrl("~/UI/Master/TypeOfRouteCodeList.aspx")%>">Route Type 1</td>
                       <td><a href="<%= ResolveUrl("~/UI/Master/LicenseList.aspx")%>">L001</a></td>
                      <td><a href="<%= ResolveUrl("~/UI/Master/CoatingTypeList.aspx")%>">FBE</a></td>
                      <td><a href="<%= ResolveUrl("~/UI/Master/LocationClassList.aspx")%>">1</a></td>

                 
                  
                </tr>

              </tbody>
            </table>
          </div>
          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
          </div>

</div>
   </div>

<!--- Content --->


        </div>
  </div>
  </div>
  </div>
  </div>
  </div>


  <div class="modal modalpopup fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="exampleModalLabel"> <i class="fa fa-cog fa-spin fa-2x" ></i> KP</h5>
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
    <input   class="form-control txtKPCode" type='text' id="txtKPCode"  />
   
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

