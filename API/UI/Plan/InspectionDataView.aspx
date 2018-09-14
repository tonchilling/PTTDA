<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="InspectionDataView.aspx.cs" Inherits="UI_Plan_InspectionDataView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Js/boostrap.table.js" type="text/javascript"></script>
<script type="text/javascript">


    window.onload = function () {

        //  LoadTable();

        $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });

    }

</script>

<style type="text/css">
 body
 {
 	   color:#000000;
		font-size:16px;
 	}
 	
 	.tbDetail  thead tr
 	{
 		 background-color:#007bff !important;
 		}
 		
 		.hiddenRow {
    padding: 0 !important;
}
td a
{
	color:#007bff;
	}
	

/*
   .table-fix table {
    width: 100%;
    display:block;
}
.table-fix thead {
    display: inline-block;
    width: 100%;
   
}

*/
 /* .table-fix tbody {
   
   display: block;
    width: 100%;
    overflow: auto;
}*/
  
  
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Inspection Data > View </div>
     <div class="card-body">


      <div class="row">
          <div class="col-sm-12">

        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-12">
          <i class="fa fa-file " ></i> Plan 
          </div>
         
          </div>
          </div>
        <div class="card-body card-body2">
       <div class="row">
       <div class="col-sm-12">
       
         <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Region</label>
                    <div class="col-xs-2 text-field">
                        Region3
                    </div>

                    <label class="control-label col-xs-2">BV station</label>
                    <div class="col-xs-2 text-field">
                        3&quot; COTCO
                    </div>

                    <label class="control-label col-xs-2">Route code</label>
                    <div class="col-xs-2 text-field">
                        RC40112
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Permit name</label>
                    <div class="col-xs-2 text-field">
                        <label id="permit-name-label">-</label>
                    </div>

                    <label class="control-label col-xs-2">Startup Date</label>
                    <div class="col-xs-2 text-field">
                        <label id="startup-date-label">
                            
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Expiry Date</label>
                    <div class="col-xs-2 text-field">
                        <label id="permit-label"></label>
                        <label id="expiry-date-label">
                            
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Diameter</label>
                    <div class="col-xs-2 text-field">
                        <label id="diameter-label">
                            3
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Customer name</label>
                    <div class="col-xs-2 text-field">
                        <label id="customer-name-label">
                            -
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Customer type</label>
                    <div class="col-xs-2 text-field">
                        <label id="customer-type-label">
                            -
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Drawing No.</label>
                    <div class="col-xs-2 text-field">
                        <label id="drawing-no-label">
                            -
                        </label>
                    </div>

                    <label class="control-label col-xs-2">URL Drawing file</label>
                    <div class="col-xs-2 text-field">
                        <label id="url-drawing-file-label">
                            -
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Drawing length</label>
                    <div class="col-xs-2 text-field">
                        <label id="drawing-length-label">
                            
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Design flow</label>
                    <div class="col-xs-2 text-field">
                        <label id="design-flow-label">
                            
                        </label>
                    </div>

                    <label class="control-label col-xs-2">maxVolFlowRate</label>
                    <div class="col-xs-2 text-field">
                        <label id="max-vol-flow-rate-label">
                            
                        </label>
                    </div>

                    <label class="control-label col-xs-2">MAOP</label>
                    <div class="col-xs-2 text-field">
                        <label id="maop-label">
                            
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Design pressure</label>
                    <div class="col-xs-2 text-field">
                        <label id="design-pressure-label">
                            
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Type of Routecode</label>
                    <div class="col-xs-2 text-field">
                        <label id="type-of-routecode-label">
                            DISTRIBUTION
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Insulation</label>
                    <div class="col-xs-2 text-field">
                        <label id="insulation-label">
                            No
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <label class="control-label col-xs-2">Wall thinkness</label>
                    <div class="col-xs-2 text-field">
                        <label id="wall-thickness-label">
                            - mm
                        </label>
                    </div>

                    <label class="control-label col-xs-2">Compressor station</label>
                    <div class="col-xs-3 text-field">
                        <label id="compressor-station-label">


                            Yes
                        </label>
                    </div>

                    <label class="control-label col-xs-1">Status</label>
                    <div class="col-xs-2 text-field">
                        <label id="status-label">
                            Active
                        </label>
                    </div>
                </div>
            </div>
            <!-- Activity -->

            <div class="row">
              <div class="col-sm-12 table-responsive">
             
                <table class="table table-bordered  list-table" style="font-size:12px; background:#FFF;">
                        <thead>
                            <tr class="bg-primary">
                                <th width="90">Inspection<br />Date</th>
                                <th class="text-center">Inspection Activities</th>
                                <th width="100">Last Update</th>
                                <th width="90">Inspection<br />Preparation</th>
                                <th width="200">Update By</th>
                                <th width="90"></th>
                            </tr>
                        </thead>
                        <thead>
                            <tr class="bg-primary2">
                                <th colspan="6" class="text-center">Inspection</th>
                            </tr>
                        </thead>
                        <tbody class="inspection-tbody">
                        </tbody>
                        <thead>
                            <tr class="bg-primary2">
                                <th colspan="6"  class="text-center">Full Inspection</th>
                            </tr>
                        </thead>
                        <tbody class="full-inspection-tbody">
                                <tr>
                                    <td class="text-center">20/03/2018</td>
                                    <td>Full soil to air inspection</td>
                                    <td class="text-center">22/12/2017</td>
                                    <td class="text-center">No</td>
                                    <td>นาย พงษ์ศักดิ์ ศรีบุญ</td>
                                    <td class="text-center">
                                    
                                    <i class="fa-2x glyphicon glyphicon-pencil btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>
                                       
                                             <i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">20/03/2018</td>
                                    <td>Full corrosion under insulation inspection</td>
                                    <td class="text-center">22/12/2017</td>
                                    <td class="text-center">No</td>
                                    <td>นาย พงษ์ศักดิ์ ศรีบุญ</td>
                                    <td class="text-center">
                                       <i class="fa-2x glyphicon glyphicon-pencil btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>
                                       
                                             <i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">20/03/2018</td>
                                    <td>Full corrosion under pipe support inspection</td>
                                    <td class="text-center">22/12/2017</td>
                                    <td class="text-center">No</td>
                                    <td>นาย พงษ์ศักดิ์ ศรีบุญ</td>
                                    <td class="text-center">
                                         <i class="fa-2x glyphicon glyphicon-pencil btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>
                                       
                                             <i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>
                                    </td>
                                </tr>
                        </tbody>
                    </table>
              </div>
            </div>
         
          <div class="row">
            <div class="col-sm-12">
           <button class="btn btn-primary" type="submit">แจ้งผู้ที่มีส่วนเกี่ยวข้อง</button>
              </div>
            </div>


            <div class="row">
            <div class="col-sm-12">
               <h4 class="h4">ประวัติการเปลี่ยนแปลงวันดำเนินการ</h4>
            </div>
            </div>
         
              <div class="row">
            <div class="col-sm-12  table-responsive">
              
               <table class="table table-bordered  list-table" style="font-size:12px; background:#FFF;">
                        <thead>
                            <tr class="bg-primary">
                                <th>No</th>
                                <th>LastUpdate</th>
                                <th class="text-center">Inspection Activities</th>
                                <th>Inspection Date<br />(เดิม)</th>
                                <th>Inspection Date<br />(ใหม่)</th>
                                <th>Inspection Preparation</th>
                                <th>Update By</th>
                            </tr>
                        </thead>
                        <thead>
                            <tr class="bg-primary2">
                                <th colspan="7">Inspection</th>
                            </tr>
                        </thead>
                        <tbody class="inspection-tbody">
                        </tbody>
                        <thead>
                            <tr class="bg-primary2">
                                <th colspan="7">Full Inspection</th>
                            </tr>
                        </thead>
                        <tbody class="full-inspection-tbody">
                        </tbody>
                    </table>

            </div>
            </div>

       </div>
       
       </div>
          
          <div class="row">
       
                </div>

               <!-- <div class="row">
                <div class="col-sm-12">
                <table id="table" class="table table-responsive " style="width:100%">
                     <thead>
                            <tr class="bg-primary">
                                <th data-field="region"  colspan="1" style="width:100%">Detail</th>
                               
                            </tr>
                           
                        </thead>
</table>
                </div>
                </div>-->

               

     
          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
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

    <script>
        $('[data-toggle="tooltip"]').tooltip({ html: true });




      

            $('.region1').collapse('show');
           $('.region3').collapse('show');



   




      /*
        var $table = $('.table-fix'),
    $bodyCells = $table.find('thead tr:nth-child(2)').children(),
    colWidth;

       

      
        colWidth = $bodyCells.map(function () {
            return $(this).width();
        }).get();

       
        $table.find('tbody tr').children().each(function (i, v) {
            $(v).width(colWidth[i]);
        });    
        */
        </script>

</asp:Content>

