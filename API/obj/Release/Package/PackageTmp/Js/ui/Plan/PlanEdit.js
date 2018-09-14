
var CDNo = '0';
var CDID = '';
$(document).ready(function () {
    $(".nav li").on("click", function () {
        $(".nav li").removeClass("active");
        $(this).addClass("active");
    });



    LoadDropDownList($('.ddlDIGFromID'), "m_digfrom");
    LoadDropDownList($('.ddlRegionID'), "m_region");
    LoadDropDownList($('.ddlPipelineID'), "m_pipelinelength");
    LoadDropDownList($('.ddlRouteCodeID'), "m_routecode");
    LoadDropDownList($('#ddlHolidayTestID'), "M_Holiday");
    LoadDropDownList($('#ddlAssetOwnerID'), "M_AssertOwner");
    LoadDropDownList($('.mCoatingDefect .ddlClockPosition'), "M_ClockPosition");
    LoadDropDownList($('.mPipeDefect .ddlClockPosition'), "M_ClockPosition");

    $('.divMainTable table').DataTable({

        dom: 'Bfrtip',
        searching: false

    });



    $('.datetimepicker').datepicker()

    $('.btnAddCoatingDefect').on('click', function (e) {


        $(".mCoatingDefect").modal();

    });

    $('.btnSavecoatingDefect').on('click', function (e) {


       // alert('btnSavecoatingDefect')
        SaveDefect(3);

    });

    $('.btnSavePipeDefect').on('click', function (e) {


        // alert('btnSavecoatingDefect')
        SaveDefect(4);


    });

    $('.btnSaveEnvironment').on('click', function (e) {


        // alert('btnSavecoatingDefect')
        SaveDefect(5);


    });


    


    $(document).on('click', '.btnDeletetab3', function (e) {


        var $item = $(this).closest("tr");

       // alert($item.attr('no'))
        DeleteDefect($item.attr('no'), '3')
      //  LoadPopup($item.attr('no'))


    });


    $(document).on('click', '.btnDeletetab4', function (e) {


        var $item = $(this).closest("tr");

      
        DeleteDefect($item.attr('no'), '4')
        


    });


    $(document).on('click', '.btnDeletetab5', function (e) {


        var $item = $(this).closest("tr");


        DeleteDefect($item.attr('no'), '5')



    });
    


  

    $('.btnAddPipeDefect').on('click', function (e) {


        $(".mPipeDefect").modal();

    });

    $('.btnAddEnvironment').on('click', function (e) {


        $(".mEnvironment").modal();

    });

    $('.btnSavePlan').on('click', function (e) {


        Save();

    });






});


function DeleteDefect(No,tab) {
    var formData = new FormData();

    formData.append("No", No);

    formData.append("Action", "Draft");
    formData.append("Step", "Delete");
    formData.append("tab", tab);


    isValid = true;

    if (isValid) {

        $.confirm({
            icon: 'fa fa-warning',
            title: 'Confirm',
            content: 'Do you want to delete?',
            type: 'green',
            animation: "RotateX",
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'Confrim',
                    btnClass: 'btn-green',
                    action: function () {


                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                                BAlert('Deleting', 'Delete data successfully!.');

                                formData = null;

                                var obj = JSON.parse(result)
                                LoadDefectTable(obj, tab);
                                // Search();
                                // LoadDropdownlist();
                                $(".myModal").modal('hide');
                                // ClearControl();

                            },
                            error: function (err) {
                                alert(err.statusText)
                            }
                        });


                    }
                },
                close: function () {
                }
            }
        });
    }

}

function SaveDefect(tab) {
    var curStep;

    switch (tab) {
        case 3: curStep = $(".mCoatingDefect");
            mainName = ".mCoatingDefect"; 
            break;
        case 4: curStep = $(".mPipeDefect"); 
                 mainName = ".mPipeDefect";
                 break;
             case 5: curStep = $(".mEnvironment");
                 mainName = ".mEnvironment";
                 break;
    }
   


   
    var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select");
    var isValid = true;
    var formData = new FormData();



    /* T_Planing */
    $(".form-group").removeClass("has-error");
    for (var i = 0; i < curInputs.length; i++) {
        if (!curInputs[i].validity.valid) {
            isValid = false;
            $(curInputs[i]).closest(".form-group").addClass("has-error");
        }
        

    }

    if (tab != 5) {
        formData.append("ID", CDID);
        formData.append("No", CDNo);
        formData.append("Type", $(mainName + " .txtType").val());
        formData.append("KP", $(mainName + " .txtKPDefect").val());
        formData.append("Width", $(mainName + " .txtWidth").val());
        formData.append("Length", $(mainName + " .txtLength").val());
        formData.append("ClockPostionID", $(mainName + " .ddlClockPosition").val());
        formData.append("RepairByID", $(mainName + " .txtRepairBy").val());


        var inputFiles = curStep.find("input[type='file']");


        for (var i = 0; i < inputFiles.length; i++) {
            formData.append('defect-' + i, inputFiles[i].files[0]);

        }
    } else {

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            } else {


                formData.append(curInputs[i].id, curInputs[i].value);
            }
        }


    
    }


    formData.append("Action", "Draft");
    formData.append("Step", "Add");
    formData.append("tab", tab);


    

     if (isValid) {

         $.confirm({
             icon: 'fa fa-warning',
             title: 'Confirm',
             content: 'Do you want to save?',
             type: 'green',
             animation: "RotateX",
             typeAnimated: true,
             buttons: {
                 tryAgain: {
                     text: 'Confrim',
                     btnClass: 'btn-green',
                     action: function () {


                         $.ajax({
                             url: currentURL,
                             type: "POST",
                             data: formData,
                             contentType: false,
                             processData: false,
                             success: function (result) {

                                 BAlert('Saved', 'Save data successfully!.');

                                 formData = null;

                                 var obj = JSON.parse(result)
                                 LoadDefectTable(obj, tab);
                                 // Search();
                                 // LoadDropdownlist();
                                 $(".myModal").modal('hide');
                                 // ClearControl();

                             },
                             error: function (err) {
                                 alert(err.statusText)
                             }
                         });


                     }
                 },
                 close: function () {
                 }
             }
         });
     }


}

function LoadDefectTable(objectList,tab) {


    var divMain;
    var tableName
    if (tab == "3") {
        tableName = '#CoatingDefect .divMainTable';
        divMain = $(tableName);
    } else if (tab == "4") {
        tableName = '#PipeDefect  .divMainTable';
        divMain = $(tableName);
    } else if (tab == "5") {
        tableName = '#Environment  .divMainTable';
        divMain = $(tableName);
        
    }

    divMain.empty();


    var html = '';
    html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
    if (tab == "5") {

        html += '';
      
        html += '<thead>';
        html += '<tr>';
       html += '<th>No</th>';
       html += '<th>Dry Temp</th>';
       html += '<th>Wet Temp</th>';
      html += '<th>Dew Temp</th>';
      html += '<th>Pipe Surface</th>';
      html += '<th>Relative Humidity</th>';
     html += '<th>EDIT</th>';
     html += '<th>DELETE</th>';
        html += '</tr>';

        html += '</thead>';
        html += '<tfoot>';
        html += '<tr>';
        html += '<th>No</th>';
        html += '<th>Dry Temp</th>';
        html += '<th>Wet Temp</th>';
        html += '<th>Dew Temp</th>';
        html += '<th>Pipe Surface</th>';
        html += '<th>Relative Humidity</th>';
        html += '<th>EDIT</th>';
        html += '<th>DELETE</th>';
        html += '</tr>';
        html += '</tfoot>';

        html += '<tbody>';

        $.each(objectList, function (key, item) {


            html += '<tr class="TRow" No="' + item.No + '">';

            html += '<td>' + item.No + '</td>';
            html += '<td>' + item.DryTemp + '</td>';
            html += '<td>' + item.WetTemp + '</td>';
            html += '<td>' + item.DewTemp + '</td>';
            html += '<td>' + item.PipeSurface + '</td>';
            html += '<td>' + item.RelativeHumidity + '</td>';
           
            html += '<td style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-pencil-square btn btnEdittab' + tab + '" aria-hidden="true" style=" color:#2c97e9"></i>' + '</td>';
            html += '<td  style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-times btn btnDeletetab' + tab + '" aria-hidden="true" style=" color:red"></i>' + '</td>';
            html += '</tr>';
        });
       

    
     }
    else {

        html += '';
      
        html += '<thead>';
        html += '<tr>';
        html += '<th>No</th>';
        html += '<th>Type</th>';
        html += '<th>KP</th>';
        html += '<th>Width(mm)</th>';
        html += '<th>Length(mm)</th>';
        html += '<th>Clock Position</th>';
        html += '<th>File Attached</th>';
        html += '<th>Repair By</th>';
        html += '<th>VIEW</th>';
        html += '<th>DELETE</th>';
        html += '</tr>';

        html += '</thead>';
        html += '<tfoot>';
        html += '<tr>';
        html += '<th>No</th>';
        html += '<th>Type</th>';
        html += '<th>KP</th>';
        html += '<th>Width(mm)</th>';
        html += '<th>Length(mm)</th>';
        html += '<th>Clock Position</th>';
        html += '<th>File Attached</th>';
        html += '<th>Repair By</th>';
        html += '<th>VIEW</th>';
        html += '<th>DELETE</th>';
        html += '</tr>';
        html += '</tfoot>';

        html += '<tbody>';


        $.each(objectList, function (key, item) {



            html += '<tr class="TRow" No="' + item.No + '">';

            html += '<td>' + item.No + '</td>';
            html += '<td>' + item.Type + '</td>';
            html += '<td>' + item.KP + '</td>';
            html += '<td>' + item.Width + '</td>';
            html += '<td>' + item.Length + '</td>';
            html += '<td>' + item.ClockPostionID + '</td>';
            html += '<td>' + item.FileName1 + '</td>';
            html += '<td>' + item.RepairByID + '</td>';
            html += '<td style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-pencil-square btn btnEdittab' + tab + '" aria-hidden="true" style=" color:#2c97e9"></i>' + '</td>';
            html += '<td  style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-times btn btnDeletetab' + tab + '" aria-hidden="true" style=" color:red"></i>' + '</td>';
            html += '</tr>';
        });
       

    }


    html += '</tbody>';
    html += '</table>';


    divMain.append(html);

  
    $(tableName+' table').DataTable({

        dom: 'Bfrtip',
        searching: false

    });



}


function Save() {


    var curStep = $("#CreatingPlan");

    var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select");
    var isValid = true;
    var formData = new FormData();



    /* T_Planing */
    $(".form-group").removeClass("has-error");
    for (var i = 0; i < curInputs.length; i++) {
        if (!curInputs[i].validity.valid) {
            isValid = false;
            $(curInputs[i]).closest(".form-group").addClass("has-error");
        } else {

         
            formData.append(curInputs[i].id, curInputs[i].value);
        }
    }


    curStep = $("#CoatingRepair");
    curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select");


    
    $(".form-group").removeClass("has-error");
    for (var i = 0; i < curInputs.length; i++) {
        if (!curInputs[i].validity.valid) {
            isValid = false;
            $(curInputs[i]).closest(".form-group").addClass("has-error");
        } else {


            formData.append(curInputs[i].id, curInputs[i].value);
        }
    }


     var inputFiles = curStep.find("input[type='file']");

   
    for (var i = 0; i < inputFiles.length; i++) {
        formData.append('CoatingRepair-' + i, inputFiles[i].files[0]);

    }







    formData.append("Action", "Add");

     isValid = true;

    if (isValid) {

        $.confirm({
            icon: 'fa fa-warning',
            title: 'Confirm',
            content: 'Do you want to save?',
            type: 'green',
            animation: "RotateX",
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'Confrim',
                    btnClass: 'btn-green',
                    action: function () {


                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                                BAlert('Saved', 'Save data successfully!.');

                                formData = null;
                               // Search();
                                // LoadDropdownlist();
                                $(".modalpopup").modal('hide');
                               // ClearControl();

                            },
                            error: function (err) {
                                alert(err.statusText)
                            }
                        });


                    }
                },
                close: function () {
                }
            }
        });




    }


  /*  $('#CreatingPlan input,#CreatingPlan select').each(function () {
        alert(this.id+":"+this.value);
    });*/

}


function bs_input_file() {
    $(".input-file").before(
		function () {
		    if (!$(this).prev().hasClass('input-ghost')) {
		        var element = $("<input type='file' class='input-ghost' style='visibility:hidden; height:0'>");
		        element.attr("name", $(this).attr("name"));
		        element.change(function () {
		            element.next(element).find('input').val((element.val()).split('\\').pop());
		        });
		        $(this).find("button.btn-choose").click(function () {
		            element.click();
		        });
		        $(this).find("button.btn-reset").click(function () {
		            element.val(null);
		            $(this).parents(".input-file").find('input').val('');
		        });
		        $(this).find('input').css("cursor", "pointer");
		        $(this).find('input').mousedown(function () {
		            $(this).parents('.input-file').prev().click();
		            return false;
		        });
		        return element;
		    }
		}
	);
}
$(function () {
    bs_input_file();
});