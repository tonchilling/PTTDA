<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="InspectionDataEdit.aspx.cs" Inherits="UI_Plan_InspectionDataEdit" %>

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
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Inspection Data > Edit </div>
     <div class="card-body">


      <div class="row">
          <div class="col-sm-12">

        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-12">
          <i class="fa fa-file " ></i> Detail 
          </div>
         
          </div>
          </div>
        <div class="card-body2">
       <div class="row" style="padding-top:30px;padding-left:10px; padding-bottom:10px;">
       <div class="col-sm-12">
       
       <!-- Detail -->
               <div class="form-group table-responsive">
                    <div class="col-xs-offset-3 col-xs-6">
                        <table class="table table-bordered list-table" style="background:#FFF;">
                            <thead>
                                <tr class="bg-primary">
                                    <th class="text-center">Inspection</th>
                                    <th class="text-center">Approve by<br />Engineer</th>
                                    <th class="text-center" >Approve by<br />ผจ.ปท</th>
                                    <th class="text-center">Approve by<br />รท.</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="text-center">
                                   
                                        <i class="fa-2x  glyphicon glyphicon-time" aria-hidden="true" style=" color:#2c97e9"></i>
                                    </td>
                                    <td class="text-center">
                                        
                                    </td>
                                    <td class="text-center">
                                        
                                    </td>
                                    <td class="text-center">
                                           
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

  <div class="row" style="padding-top:10px;">
                    <label class="control-label col-xs-2 no-padding">Location Details</label>
                    <div class="col-xs-2 text-field no-padding">
                        <a href="/PipingInspection_test/InspectionPlan/EditPlan/1100" target="_blank">
                            RA4
                        </a>
                    </div>

                    <label class="control-label col-xs-2 no-padding">หน่วยงาน</label>
                    <div class="col-xs-2 text-field">ปท.5 ปตก.</div>

                    <label class="control-label col-xs-2 no-padding">Route Code</label>
                    <div class="col-xs-2 text-field">RC4100</div>
                </div>

                <div class="row" style="padding-top:10px;">
                    <label class="control-label col-xs-2 no-padding">Drawing</label>
                    <div class="col-xs-2 text-field">
                    </div>
                        <label class="control-label col-xs-2 no-padding required-label">Inspection Date</label>
                        <div class="col-xs-2">
                            <div class="input-group date">
                                <input class="form-control date-picker" data-val="true" data-val-date="The field InspectionDate must be a date." data-val-required="The InspectionDate field is required." id="InspectionDate" name="InspectionDate" type="text" value="01/01/2018" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                </div>


                 <div class="row" style="padding-top:10px;">
                 
                  
                    <div class="col-sm-10">
                    <div class="row">  
                      <label class="control-label col-sm-2 no-padding required-label">เอกสารระบบ</label>
                    <div class="col-sm-6">
                        <label for="primary" class="btn btn-primary " style="padding-right:3px;">ISO 9002 <input type="checkbox" id="primary" class="badgebox"><span class="badge">&check;</span></label>
        <label for="info" class="btn btn-info  " style="padding-right:3px;">ISO 14001 <input type="checkbox" id="info" class="badgebox"><span class="badge">&check;</span></label>
        <label for="success" class="btn btn-success " style="padding-right:3px;">ISO 18001 <input type="checkbox" id="success" class="badgebox"><span class="badge">&check;</span></label>
        <label for="warning" class="btn btn-warning " style="padding-right:3px;">อื่นๆ <input type="checkbox" id="warning" class="badgebox"><span class="badge">&check;</span></label>
       
        </div>
        <input type="text"   class="form-control txtRouteCode col-sm-2 "  id="txtRouteCode" />   

       
</div> 
        </div>
        
                             
                        </div>
                
                   
                </div>

         <!-- Detail -->
       </div>
       
       </div>
          
          <div class="row">
       
                </div>


               

     
          </div>
          
          </div>


</div>
   </div>

        </div>



      <div class="row">
          <div class="col-sm-12">

        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-12">
          <i class="fa fa-file " ></i> General condition / สภาพโดยทั่วไป 
          </div>
         
          </div>
          </div>
        <div class="card-body2">
       <div class="row" style="padding-top:30px;padding-left:10px; padding-bottom:10px;">
       <div class="col-sm-12">
       
       <!-- Detail -->
           

  <div class="row" style="padding-top:10px;">
                    <label class="control-label col-xs-2 no-padding">* General condition / สภาพโดยทั่วไป</label>
                    <div class="col-xs-2 text-field no-padding">
                     
<input type="checkbox" id="toggle-two">
<script>
    $(function () {
        $('#toggle-two').bootstrapToggle({
            on: 'YES',
            off: 'NO'
        });
    })
</script>
                    </div>


                </div>

  
                
                   
                </div>

         <!-- Detail -->
       </div>
       
       </div>
          
          <div class="row">
       
                </div>


               

     
          </div>
          
          </div>


</div>
   </div>

        </div>



          <div class="row">
          <div class="col-sm-12">

        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-12">
          <i class="fa fa-file " ></i> Corrosion condition / สภาพการเกิด Corrosion
          </div>
         
          </div>
          </div>
        <div class="card-body2">
       <div class="row" style="padding-top:30px;padding-left:10px; padding-bottom:10px;">
       <div class="col-sm-12">
       
       <!-- Detail -->
           

  <div class="row" style="padding-top:10px;">
                  
 <div class="col-sm-12">


                  <!-- จุดตรวจ 1 -->

                  <div class="card cardbody">
    <div class="card-header card-headerBlue">
        <h4 class="panel-title">จุดตรวจสอบที่ 1</h4>
    </div>
    <div class="panel-body">
        <div class="form-group">
            <div style="background:#EEE;" class="col-xs-12">
                จุดที่ 1
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-xs-12 required-label" style="text-align:left;">
                สภาพการเกิด Corrosion
                <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].ConditionCause" data-valmsg-replace="true"></span>
            </label>
        </div>
        <div class="form-group" style="padding-left:40px;">
            <div class="col-xs-11">
                    <label class="radio-inline" style="margin-right:10px;">
                        <input class="condition-cause" data-val="true" data-val-number="The field ConditionCause must be a number." id="CorrosionConditions_0__ConditionCause" name="CorrosionConditions[0].ConditionCause" type="radio" value="1" /> No Corrosion
                    </label>
                    <label class="radio-inline" style="margin-right:10px;">
                        <input class="condition-cause" id="CorrosionConditions_0__ConditionCause" name="CorrosionConditions[0].ConditionCause" type="radio" value="2" /> < 20% w.t.
                    </label>
                    <label class="radio-inline" style="margin-right:10px;">
                        <input class="condition-cause" id="CorrosionConditions_0__ConditionCause" name="CorrosionConditions[0].ConditionCause" type="radio" value="3" /> 20 - 80% w.t.
                    </label>
                    <label class="radio-inline" style="margin-right:10px;">
                        <input class="condition-cause" id="CorrosionConditions_0__ConditionCause" name="CorrosionConditions[0].ConditionCause" type="radio" value="4" /> > 80% w.t.
                    </label>
                    <label class="radio-inline" style="margin-left:10px;">
                        <input class="condition-cause" id="CorrosionConditions_0__ConditionCause" name="CorrosionConditions[0].ConditionCause" type="radio" value="5" /> Defect  อื่นๆ เช่น "Dent" "Crack" "etc."
                    </label>
            </div>
        </div>

        <div class="form-group corrosion-size-group ">
            <label class="control-label col-xs-12 required-label" style="text-align:left;">Corrosion size - ความลึกของ Defect (if depth > 20% w.t.) /กรณี > 20% w.t. ให้ระบุขนาด</label>
        </div>
        <div class="form-group corrosion-size-group ">
                <label class="control-label col-xs-1 no-padding">Depth</label>
                <div class="col-xs-2">
                    <div class="input-group date">
                        <input class="form-control" data-val="true" data-val-number="The field Depth must be a number." id="CorrosionConditions_0__Depth" name="CorrosionConditions[0].Depth" type="number" value="" />
                        <span class="input-group-addon">mm.</span>
                    </div>
                    <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].Depth" data-valmsg-replace="true"></span>
                </div>
                <label class="control-label col-xs-1 no-padding">Length</label>
                <div class="col-xs-2">
                    <div class="input-group date">
                        <input class="form-control" data-val="true" data-val-number="The field Length must be a number." id="CorrosionConditions_0__Length" name="CorrosionConditions[0].Length" type="number" value="" />
                        <span class="input-group-addon">mm.</span>
                    </div>
                    <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].Length" data-valmsg-replace="true"></span>
                </div>
                <label class="control-label col-xs-1 no-padding">Width</label>
                <div class="col-xs-2">
                    <div class="input-group date">
                        <input class="form-control" data-val="true" data-val-number="The field Width must be a number." id="CorrosionConditions_0__Width" name="CorrosionConditions[0].Width" type="number" value="" />
                        <span class="input-group-addon">mm.</span>
                    </div>
                    <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].Width" data-valmsg-replace="true"></span>
                </div>
        </div>

        <div class="form-group">
            <label class="control-label col-xs-12 required-label" style="text-align:left;">
                Inspection method / วิธีการที่ใช้ตรวจสอบ
                <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].InspectionMethod" data-valmsg-replace="true"></span>
            </label>
            <div class="col-xs-11" style="padding-left:40px;">
                    <label class="radio-inline" style="margin-left:20px; padding-top:0px; vertical-align:top;">
                        <input class="inspection-method-radio" data-val="true" data-val-number="The field InspectionMethod must be a number." id="CorrosionConditions_0__InspectionMethod" name="CorrosionConditions[0].InspectionMethod" type="radio" value="1" /> VT
                    </label>
                    <label class="radio-inline" style="margin-left:20px; padding-top:0px; vertical-align:top;">
                        <input class="inspection-method-radio" id="CorrosionConditions_0__InspectionMethod" name="CorrosionConditions[0].InspectionMethod" type="radio" value="2" /> UT
                    </label>

                <div class="form-inline" style="display:inline-block;">
                        <label class="radio-inline" style="margin-left:20px; padding-top:0px; vertical-align:top;">
                            <input class="inspection-method-radio" id="CorrosionConditions_0__InspectionMethod" name="CorrosionConditions[0].InspectionMethod" type="radio" value="3" /> อื่นๆ ระบุ
                        </label>

<textarea class="form-control inspection-method-other-textbox" cols="20" disabled="disabled" id="CorrosionConditions_0__InspectionMethodOther" name="CorrosionConditions[0].InspectionMethodOther" rows="2">
</textarea>                </div>
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-xs-12 required-label" style="text-align:left;">
                Repair / การแก้ไข
                <span class="field-validation-valid" data-valmsg-for="CorrosionConditions[0].RepairChoice" data-valmsg-replace="true"></span>
            </label>
            <div class="col-xs-11" style="padding-left:40px;">
                    <label class="radio-inline" style="margin-left:20px; padding-top:0px;">
                        <input class="repair-choice-radio" data-val="true" data-val-number="The field RepairChoice must be a number." id="CorrosionConditions_0__RepairChoice" name="CorrosionConditions[0].RepairChoice" type="radio" value="1" /> No Repair
                    </label>
                    <div class="form-inline" style="display:inline-block;">
                        <label class="radio-inline" style="margin-left:20px; padding-top:0px;">
                            <input class="repair-choice-radio" id="CorrosionConditions_0__RepairChoice" name="CorrosionConditions[0].RepairChoice" type="radio" value="2" /> Coating with
                        </label>
<input class="form-control coating-with-textbox" disabled="disabled" id="CorrosionConditions_0__CoatingWith" name="CorrosionConditions[0].CoatingWith" type="text" value="" />                    </div>
                    <div class="form-inline" style="display:inline-block;">
                        <label class="radio-inline" style="margin-left:20px; padding-top:0px;">
                            <input class="repair-choice-radio" id="CorrosionConditions_0__RepairChoice" name="CorrosionConditions[0].RepairChoice" type="radio" value="3" /> อื่นๆ
                        </label>
<input class="form-control rapair-other-textbox" disabled="disabled" id="CorrosionConditions_0__RepairChoiceOther" name="CorrosionConditions[0].RepairChoiceOther" type="text" value="" />                    </div>
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-xs-12 required-label" style="text-align:left;">Import photo / รูปภาพจุดที่ 1</label>
            <div class="col-xs-6" style="padding-left:50px;">

<input data-val="true" data-val-required="The ExtensionType field is required." id="CorrosionConditions_0__Image_ExtensionType" name="CorrosionConditions[0].Image.ExtensionType" type="hidden" value="All" />
<input data-val="true" data-val-required="The UploadType field is required." id="CorrosionConditions_0__Image_UploadType" name="CorrosionConditions[0].Image.UploadType" type="hidden" value="CorrosionConditionImage" />
<input data-val="true" data-val-number="The field Order must be a number." data-val-required="The Order field is required." id="CorrosionConditions_0__Image_Order" name="CorrosionConditions[0].Image.Order" type="hidden" value="0" />
<input data-val="true" data-val-required="The IsMultipleFile field is required." id="CorrosionConditions_0__Image_IsMultipleFile" name="CorrosionConditions[0].Image.IsMultipleFile" type="hidden" value="True" />
<div id="file-upload-container-CorrosionConditionImage-0">
        <input type="file" id="file-input-CorrosionConditionImage-0" class="btn btn-default" style="width:100%" />
    <ul class="old-file-list file-list" id="old-file-list-CorrosionConditionImage-0">
    </ul>
    <ul class="upload-file-list file-list" id="upload-file-list-CorrosionConditionImage-0">
    </ul>
</div>

          </div>
        </div>
    </div>
</div>


                  <!-- จุดตรวจ 1 -->
               </div>      

                    </div>


                </div>

  
                
                   
                </div>

         <!-- Detail -->
       </div>
       
       </div>
          
          <div class="row">
       
                </div>


               

     
          </div>
          
          </div>


</div>
   </div>

        </div>


          </div>
        
        </div>
  <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
     </div>
         
<!--- Content --->
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

