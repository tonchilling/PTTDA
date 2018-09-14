var fileList1, fileList2;
var fileAll1, fileAll2;
var realFiles1 = [];
var realFiles2 = [];
var widthAll = [180, 270, 0,90];

var keepDeleteFiles1 = [];
var keepDeleteFileName1 = [];

var keepDeleteFiles2 = [];
var keepDeleteFileName2 = [];

var keepDeleteDefect = [];
var defectArray = [];


var orgRemark;

var isValid = true;
var PKID = '';

var tempConditionList = null;

var RepairLength = 0;


var objMain = null;

$(document).ready(function () {



    EventControl();
    InitialData();


});


function InitialData() {
    PKID = getParameterByName('PID');


    
    LoadData(PKID);
   
}


function LoadData(PID) {

    var progress = "";
    var html = "";

    var formData = new FormData();
    formData.append("Action", "View");
    formData.append("PID", PID);

    $('.btnGenerate').removeClass("invisible")

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)

            objMain = obj;


            if (obj != null) {


                if (obj.RepairLength != null) {
                    $('.txtRepairLength').val(parseFloat(obj.RepairLength));
                }
                $('.txtCoatingThickness').val(obj.CoatingThickness);

                $('.txtHolidayTest').val(obj.HolidayTest);
                $('.txtDegree').val(obj.Degree);
                $('.txtDegreeLength').val(obj.DegreeLength);

                if (obj.WaterCondense != null) {
                    if (obj.WaterCondense == '1') {
                        $('.rdActive').prop('checked', true)
                    } else {
                        $('.rdInActive').prop('checked', true)
                    }
                }

                //  GeneratePointTable();


                var repairLength = parseFloat($('.txtRepairLength').val());



                $('.lbRepairLengthCaption').text('Repair Length ' + parseFloat(repairLength) + ' (m)');
                $('.lbMaxLength').text(parseFloat(repairLength) + ' (m)');


                LoadDropDownList($('.ddlCoatingTypeID'), "M_CoatingType", obj.CoatingTypeID);
                LoadDropDownList($('.ddlFieldJoinTypeID'), "M_FieldJointType", obj.FieldJoinTypeID);

                tempConditionList = obj.ConditionList;


                if (tempConditionList != null && tempConditionList.length > 0) {
                    $('.btnGenerate').addClass("invisible")
                    $('.txtHolidayTest').prop('disabled', true);


                }



                LoadConditionTable(0, tempConditionList);



                objSelectFiles = obj.UploadFileList;



                ReloadFile1(null);
                ReloadFile2(null);

                if (obj.IsSave == '0') {

                    DisableAll();
                }

                if (obj.IsSave == '1') {

                    $('.ddlRiskScore').enabled();
                    $('.btnPreview').removeClass("invisible")
                    $('.btnSave').removeClass("invisible")
                }

            } else {

                $('.datetimepicker').datepicker()
                LoadDropDownList($('.ddlCoatingTypeID'), "M_CoatingType");
                LoadDropDownList($('.ddlFieldJoinTypeID'), "M_FieldJointType", obj.FieldJointTypeID);
            }



            setTimeout(function () {
                waitingDialog.show('Loading for Defect Point', { dialogSize: 'lg', progressType: 'info' });

            }, 1000);


            setTimeout(function () {

                PreviewPoint();

                waitingDialog.hide();
            }, 3000);





        }

    });

}

function EventControl() {



    $('.txtRepairLength').IsNumeric();
    $('.txtCoatingThickness').IsNumeric();
    $('.txtHolidayTest').IsNumeric();


    $('.txtHolidayTest').IsNumeric();

  



    $(".nav-tabs a").click(function () {
    

        window.location.href = this.href + '?Action=View&PID=' + PKID; ;

     
        return false;
    
    });


    $('.btnSave').on("click", function (e) {


        var divDefect = $(".divDefectTable");
        var formData = new FormData();
        var repaireLength = $('.txtRepairLength').val();
        curStep = $(".tab-content");
        var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");
        var curDefectInputs = divDefect.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            } else {


                formData.append(curInputs[i].id, curInputs[i].value);

            }
        }



        var defectObj = {};

        i = 0;
        $('.tblDefectTable > tbody  > tr').each(function () {

            var row = $(this);


            if (IsOverRepaireLength(row.find('.txtDisLength'))) {

                isValid = false;
               

            }

            defectObj = {};
            defectObj.PID = PKID;
            defectObj.No = row.find('.txtItemNo').val();
            defectObj.DefectTypeID = row.find('.ddlDefectType').val();
            defectObj.DisWidth = row.find('.txtDisWidth').val();
            defectObj.DisLength = row.find('.txtDisLength').val();
            defectObj.DegreeFrom = row.find('.ddlDegreeFrom').val();
            defectObj.DegreeLength = row.find('.txtDegreeLength').val();
            defectObj.DegreePosition = row.find('.ddlDegreePosition').val();
            defectObj.RiskScore = row.find('.ddlRiskScore').val();
            defectObj.Remark = row.find('.txtRemark').val();

          
            //defectObj.File = row.find('.txtFile');

            if (row.find('.txtItemNo').val() != "") {
                defectArray.push(defectObj);
            }

            if (row.find('.txtFile') != null && row.find('.txtFile')[0] != null) {

                if (row.find('.txtFile')[0].files.length > 0) {
                    formData.append('defectFile_' + row.find('.txtItemNo').val(), row.find('.txtFile')[0].files[0]);
                }

                // formData.append('defectFile', $(row.find('.txtFile'))[0].files[0]);
            }
            i++;
        });


        formData.append('defectList', JSON.stringify(defectArray));


        AddPointToCavas();
        var mycanvas = document.getElementById("mycanvas");
        var dataImg = mycanvas.toDataURL("image/png");

        dataImg = dataImg.replace("data:image/png;base64,",'');
        formData.append("DefectImg", dataImg);



        i = 1;
        realFiles1.forEach(function (file) {
            formData.append('file1_' + i, file);
            i++;
        });



        i = 1;
        realFiles2.forEach(function (file) {
            formData.append('file2_' + i, file);
            i++;
        });


        if ($('.rdActive').is(":checked")) {
            formData.append('WaterCondense', '1');
        } else {
            formData.append('WaterCondense', '0');
        }


        formData.append("Action", "Add");
        formData.append("PID", PKID);

        formData.append('DeleteFiles', keepDeleteFiles1.join(",") + ',' + keepDeleteFiles2.join(","));
        formData.append('DeleteFileNames', keepDeleteFileName1.join(",") + ',' + keepDeleteFileName2.join(","));

        formData.append('DeleteConditionFiles', keepDeleteDefect.join(","));





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
                                    setTimeout(function () {
                                        location.reload();

                                    }, 1000);

                                    //  LoadTable2();
                                    //  var obj = JSON.parse(result)

                                    //   $(".myPlanSpectPO").modal('hide');
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
        



    });








    $("#open_btn1").on("click", function (e) {
        $.FileDialog({ multiple: true }).on('files.bs.filedialog', function (ev) {
            ev.files.forEach(function (f) {
                realFiles1.push(f);
            });
            var text = "";

            ReloadFile1(realFiles1);
            //  $("#output").val(text);
        }).on('cancel.bs.filedialog', function (ev) {

            if (realFiles1 != null) {
                var text = "";


                ReloadFile1(realFiles1);
                // $("#output").val(text);

            } else {
                $("#output").val("Cancelled!");
            }
        });

        event.preventDefault();
    });



    $("#open_btn2").on("click", function (e) {
        $.FileDialog({ multiple: true }).on('files.bs.filedialog', function (ev) {
            ev.files.forEach(function (f) {
                realFiles2.push(f);
            });
            var text = "";

            ReloadFile2(realFiles2);
            //  $("#output").val(text);
        }).on('cancel.bs.filedialog', function (ev) {

            if (realFiles2 != null) {
                var text = "";


                ReloadFile2(realFiles2);
                // $("#output").val(text);

            } else {
                $("#output").val("Cancelled!");
            }
        });

        event.preventDefault();
    });




    $(document).on('click', '.btnDeleteFile', function (e) {

        var $inputFile = $(this).closest("td").find('input[type="file"]');
        var $lable = $(this).closest("td").find('label');
        $lable.css("display", "none");
        $(this).css("display", "none");
        $inputFile.css("display", "block");
       // $inputFile.
    });


 /*   $("input:file").change(function () {
        var fileName = $(this).val();
        $(".filename").html('xx');


    });*/
    $(document).on('click', '.btnDeletefile1', function (e) {
        var $item = $(this).closest("tr");

        if ($item.attr('PID') != null) {
            keepDeleteFiles1.push($item.attr('data'));
            keepDeleteFileName1.push("1\\" + $item.attr('filename'));
            objSelectFiles = $.grep(objSelectFiles, function (e) {
                return e.No != $item.attr('data');
            });


        }
        else if (realFiles1 != null) {
            if (realFiles1.length == 1) {
                realFiles1.pop(0);
            } else {
                realFiles1.pop($item.attr('data'));
            }
        }
        ReloadFile1(realFiles1);
        // alert($item.attr('data'))
    });

    $(document).on('click', '.btnDeletefile2', function (e) {
        var $item = $(this).closest("tr");

        if ($item.attr('PID') != null) {
            keepDeleteFiles2.push($item.attr('data'));
            keepDeleteFileName2.push("2\\" + $item.attr('filename'));
            objSelectFiles = $.grep(objSelectFiles, function (e) {
                return e.No != $item.attr('data');
            });


        }
        else if (realFiles2 != null) {
            if (realFiles2.length == 1) {
                realFiles2.pop(0);
            } else {
                realFiles2.pop($item.attr('data'));
            }
        }
        ReloadFile2(realFiles2);
        // alert($item.attr('data'))
    });





    $(document).on('click', '.txtRemark', function (e) {




        $(this).popover({
            html: true,
            title: "Edit Comment",
            content: function () {

                orgRemark = $(this);
                var message = '<textarea  class="txtEditRemark form-control" style="width:500px" >' + $(this).val() + '</textarea>';
                return message;
            }
        });

        if ($('.popover').is(':visible')) {
            $('.popover').remove();
            // alert('visible')
        }
        else {
            $(this).popover("show");
        }



    });

 $(document).on('keyup', '.txtEditRemark', function (e) {

     orgRemark.val($(this).val())
     //alert('ss')
 });





    $(document).on('click', '.btnDelete', function (e) {


     $.confirm({
                    icon: 'fa fa-warning',
                    title: 'Confirm',
                    content: 'Do you want to delete?',
                    type: 'red',
                    animation: "RotateX",
                    typeAnimated: true,
                    buttons: {
                        tryAgain: {
                            text: 'Confrim',
                            btnClass: 'btn-danger',
                            action: function () {


                                         keepDeleteDefect.push($(this).closest('tr').find('.txtItemNo').val());

                                             $(this).closest('tr').remove();

                                                  BAlert('Deleted', 'Delete data successfully!.');

                                                 }
                                        },
                            close: function () {}
                                  }
                });
 
    

    });

    $(".btnNew").on("click", function (e) {

     var tr = "";
        var tableStr = "";
        var lastItem = 0;
         var $tableBody = $('.tblDefectTable').find("tbody"),
        $trLast = $tableBody.find("tr:last"),
        $trNew = $trLast.clone() ;
        lastItem = $trNew.find('.txtItemNo').val()
        lastItem = lastItem!=null ? parseInt(lastItem) + 1:1;

        tableStr += '<tr>';
       // tableStr += '<td>' + '<i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
        tableStr += '<td>' + '<input class="form-control  txtItemNo" type="text" value="' + (lastItem) + '" disabled/>' + '</td>';
        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDefectType"></select>' + '</td>';
        tableStr += '<td>' + '<input class="form-control   txtDisWidth" type="text"/>' + '</td>';
        tableStr += '<td>' + '<input class="form-control   txtDisLength" type="text"/>' + '</td>';
        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDegreeFrom"></select>' + '</td>';
        tableStr += '<td>' + '<input  class="form-control   txtDegreeLength" type="text"/>' + '</td>';
        tableStr += '<td>' + '<input class="form-control   ddlDegreePosition" type="text"/>' + '</td>';
        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlRiskScore"></select>' + '</td>';
        tableStr += '<td>' + '<input class="form-control   txtRemark" type="text"/>' + '</td>';
        tableStr += '<td>' + '<input class="form-control   txtFile" type="file"/>' + '</td>';
        tableStr += '</tr>';


        $tableBody.append(tableStr);

        LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlRiskScore'), "M_RiskScore");
        LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlDefectType'), "M_DefectType");
        LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlDegreeFrom'), "M_Degree");

   

    /*    var tableStr = "";
        var lastItem = 0;
        var $tableBody = $('.tblDefectTable').find("tbody"),
        $trLast = $tableBody.find("tr:last"),
        $trNew = $trLast.clone() ;
        lastItem = $trNew.find('.txtItemNo').val()
        lastItem = parseInt(lastItem) + 1;
        $trNew = $trLast.clone().find('input').val('').end(); ;
        $trNew.find('.txtFileName').text('')
        $trNew.find('.txtFileName').closest('td').append('<input class="form-control   txtFile" type="file"/>')
        $trNew.find('.txtItemNo').val(lastItem)*/



        $trLast.after($trNew);


        $('.txtDisWidth').IsNumeric();
        $('.txtDisLength').IsNumeric();

        $('.txtDegreeLength').IsNumeric();
        $('.ddlDegreePosition').IsNumeric();

    });


    $(".btnGenerate").on("click", function (e) {


        var row = $('.txtHolidayTest').val();
        RepairLength = $('.txtRepairLength').val();





        $('.lbRepairLengthCaption').text('Repair Length ' + parseFloat(RepairLength) + ' (m)');
        $('.lbMaxLength').text(parseFloat(RepairLength) + ' (m)');


        LoadConditionTable(row, tempConditionList);

        GeneratePointTable();

     


        $('html, body').animate({
            scrollTop: $(".divDefectTable").offset().top
        }, 500);


        // divDefectTable
    });





}


function IsOverRepaireLength(objControl) {


    var RepairLength = parseFloat($('.txtRepairLength').val());


    if (parseFloat($(objControl).val()) > RepairLength) {

        $(objControl).closest("td").find('span.invalid').remove();
       // $(objControl).addClass('invalid');

        $(objControl).closest("td").append("<span class='invalid'>This field beetween " + 0 + "-" + RepairLength + "</span>");
       

        return true;

    } else {

        $(objControl).closest("td").find('span.invalid').remove();
    
       // $(objControl).closest("div").find('.error').css("display", "none");
        return false;
    }
}


function GeneratePointTable() {


    var tableStr = "";
    var tablePoint = $('.tblPointData');
    var width = 4;
    tablePoint.empty();

   
    
   // $('.lbRepairLengthCaption').text='Repair Length( ' + $('.txtRepairLength').val() + ' m)');


    repairLength = 10;
  
    tableStr += '<tbody>';
    for (row =0; row < width; row++) {
        tableStr += '<tr>';

        for (col = 0; col < repairLength; col++) {


            if (col == 0) {
                tableStr += '<td style="width:87px" class="dropzone" val="' + widthAll[row] + '_' + col.toString() + '"></td>';
            } else {
                tableStr += '<td style="width:81px" class="dropzone" val="' + widthAll[row] + '_' + col.toString() + '"></td>';
            }
        }

        tableStr += '</tr>';
    }

    tableStr += '</tbody>';

  

    tablePoint.append(tableStr);
}




function LoadConditionTable(holidayTest, conditionList) {
    var tableStr = "";
    $(".divDefectTable").empty();

    tableStr += '<table class="table table-bordered table-blue tblDefectTable" style="width:1600px;">';
    tableStr += '<thead>';
    tableStr += '<tr class="text-center">';
  //  tableStr += '<th rowspan="2">Delete</th>';
    tableStr += '<th rowspan="2" class="align-middle">Item</th>';
    tableStr += '<th rowspan="2" class="align-middle">Defect Type</th>';
    tableStr += '<th colspan="2" class="text-center">Dimension(mm)</th>';
    //   tableStr += '<th colspan="2" class="text-center">Degree Position</th>';
    tableStr += '<th rowspan="2" class="align-middle">Distance from U/S<br>(m)</th>';
    tableStr += '<th rowspan="2" class="align-middle">Degree Position (&deg;)</th>';
    tableStr += '<th rowspan="2" class="align-middle">Risk Score</th>';
    tableStr += '<th rowspan="2" class="align-middle">Remark</th>';
    tableStr += '<th rowspan="2" class="align-middle">Files</th>';
    tableStr += '</tr>';
    tableStr += '<tr>';
    tableStr += '<th class="text-center">Width</th>';
    tableStr += '<th class="text-center">Length</th>';
    //tableStr += '<th >From</th>';
  //  tableStr += '<th >Length(mm)</th>';
    tableStr += '</tr>';

    tableStr += '</thead>';
    tableStr += '<tbody>';


    if (conditionList == null) {
        for (i = 0; i < holidayTest; i++) {
            tableStr += '<tr>';
          //  tableStr += '<td>' + '<i class="btn fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
            tableStr += '<td style="width:150px;">' + '<input class="form-control  txtItemNo" type="text" value="' + (i + 1) + '" disabled/>' + '</td>';
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDefectType"></select>' + '</td>';

            tableStr += '<td  style="width:150px;">' + '<input  class="form-control   txtDisWidth" type="text"/>'  + '</td>';
            tableStr += '<td style="width:150px;">' + '<input  class="form-control   txtDegreeLength" type="text"/>' + '</td>';
            tableStr += '<td style="width:150px;">' + '<input class="form-control   txtDisLength" type="text"/>' + '</td>';
           // tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDegreeFrom"></select>' + '</td>';

            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDegreePosition"></select>' + '</td>';
         
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlRiskScore"></select>' + '</td>';
            tableStr += '<td  style="width:300px;">' + '<input class="form-control   txtRemark" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtFile" type="file"/>' + '</td>';
            tableStr += '</tr>';
        }

    } else {


    $.each(conditionList, function (index, item) {


        /*
        public string ID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string DefectTypeID{ get; set; }
        public string DisWidth{ get; set; }
        public string DisLength { get; set; }
        public string DegreeFrom { get; set; }
        public string DegreeLength { get; set; }
        public string DegreePosition { get; set; }
        public string RiskScore { get; set; }
        public string Remark { get; set; }
       
        public string FileName { get; set; }
        
        */

        tableStr += '<tr>';
      //  tableStr += '<td>' + '<i class="btn fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
        tableStr += '<td style="width:150px;">' + '<input class="form-control  txtItemNo" type="text"  value="' + item.No + '" disabled/>' + '</td>';
        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDefectType"></select>' + '</td>';

        tableStr += '<td style="width:150px;">' + '<input  class="form-control   txtDisWidth" type="text" value="' + item.DisWidth + '" />' + '</td>';
        tableStr += '<td style="width:150px;">' + '<input  class="form-control   txtDegreeLength" type="text" value="' + item.DegreeLength + '" />' + '</td>';
   
      //  tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDegreeFrom"></select>' + '</td>';

        tableStr += '<td style="width:150px;">' + '<input class="form-control   txtDisLength" type="text" value="' + item.DisLength + '" />' + '</td>';


        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDegreePosition"></select>' + '</td>'; 
     
        tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlRiskScore"></select>' + '</td>';
        tableStr += '<td  style="width:300px;">' + '<input   class="form-control   txtRemark" value="' + item.Remark + '" type="text"/>' + '</td>';

        //   tableStr += '<td>' + '<input class="form-control   txtFile" type="file" value="' + item.FileName + '" />' + '</td>';
        if (item.FileName != null && item.FileName != "") {

            tableStr += "<td>" + "<label class=\"txtFileName filename\" style=\"cursor:pointer;\" data-toggle=\"popover\"" +
            " data-content='<image src=\"" + item.HtmlFile + "\"></image>' >" + item.FileName + " </label>" +
            "<i class=\"fa fa-2x fa-times btn btnDeleteFile\" style=\"color:red\"></i> <input class=\"form-control   txtFile success\"  style=\"display:none\" type=\"file\" />" + "</td>";
         /*   tableStr += '<td>' + '<input class="form-control  success  txtFile" type="file" style="display:none" /><label   class="txtFileName">' + item.FileName + '  </label><i class="fa fa-2x fa-times btn btnDeleteConditionFile" style="color:red"></i>' + '</td>';*/
        } else {

            tableStr += '<td>' + ' <input class="form-control   txtFile success" type="file" />';
            //  tableStr += '<td>' + '  <div class="custom-file-upload"><input class=" txtFile " type="file" /></div>' + '</td>';
            //   <div class="custom-file-upload">

            /*tableStr += '<td>' + '<div class="upload-btn-wrapper">';
            tableStr += '<button class="btn">Upload a file</button>';
            tableStr += '<input type="file" name="myfile" />';
            tableStr += '</div>';
            tableStr += '</td>';*/

        }

        tableStr += '</tr>';

    });
    
    
    }

    tableStr += '</tbody>';
    tableStr += '</table>';


    $(".divDefectTable").append(tableStr);



   // $('.txtDisWidth').IsNumeric();
    $('.txtDisLength').IsNumeric();

    $('.txtDegreeLength').IsNumeric();
  //  $('.ddlDegreePosition').IsNumeric();



    if (conditionList != null) {

        var i = 0;
        $('.tblDefectTable > tbody  > tr').each(function () {

            var row = $(this);
            // alert(conditionList[i].DegreeFrom)

         
            LoadDropDownList(row.find('.ddlRiskScore'), "M_RiskScore", conditionList[i].RiskScore);
            LoadDropDownList(row.find('.ddlDefectType'), "M_DefectType", conditionList[i].DefectTypeID);
            LoadDropDownList(row.find('.ddlDegreeFrom'), "M_Degree", conditionList[i].DegreeFrom);
            LoadWidth(row.find('.ddlDegreePosition'), conditionList[i].DegreePosition);


            i++;

        });

     


    } else {
        LoadWidth($('.ddlDegreePosition'));
        LoadDropDownList($('.ddlRiskScore'), "M_RiskScore");
        LoadDropDownList($('.ddlDefectType'), "M_DefectType");
        LoadDropDownList($('.ddlDegreeFrom'), "M_Degree");
    
    }


}




function LoadWidth(objControl, selectValue) {
    var row = 0;
    for (row = 0; row < widthAll.length; row++) {
        $(objControl).append("<option value='" + widthAll[row] + "'" + ((selectValue == widthAll[row] ? "selected" : "")) + ">" + widthAll[row] + "</option>");
    }

}

function ReloadFile1(newFiles) {
    var fileTable = $("#filename1 tbody");
    fileTable.empty();
    var fileid = 1;

    if (objSelectFiles != null) {

        fileid = objSelectFiles.length;
        $.each(objSelectFiles, function (index, file) {

            if (file.UploadType == '1') {

                fileTable.append("<tr id='" + file.No + "_row' data ='" + file.No + "' PID ='" + file.PID + "' filename ='" + file.FileName + "' >" +
                                    "<td class='filename'style='cursor:pointer;'" +
                                     " data-toggle='popover' data-content='<image src=\"" + file.HtmlFile + "\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + file.FileSize + "</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile1\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            }
        });

        LoadPopover();
    }

    if (newFiles != null) {
        newFiles.forEach(function (f) {
            fileTable.append("<tr id='" + fileid + "_row' data ='" + fileid + "'>" +
                                    "<td class='filename'>" + f.name + "</td>" +
                                    "<td class='filesize'>" + f.size + "</td>" +
                                    "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile1\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            fileid++;
        });
    }
}

function ReloadFile2(newFiles) {
    var fileTable = $("#filename2 tbody");
    fileTable.empty();
    var fileid = 1;

    if (objSelectFiles != null) {

        fileid = objSelectFiles.length;
        $.each(objSelectFiles, function (index, file) {


            if (file.UploadType == '2') {

                fileTable.append("<tr id='" + file.No + "_row' data ='" + file.No + "' PID ='" + file.PID + "' filename ='" + file.FileName + "' >" +
                                     "<td class='filename'style='cursor:pointer;'" +
                                     " data-toggle='popover' data-content='<image src=\"" + file.HtmlFile + "\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + file.FileSize + "</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile2\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            }
        });
        LoadPopover();
    }

    if (newFiles != null) {
        newFiles.forEach(function (f) {
            fileTable.append("<tr id='" + fileid + "_row' data ='" + fileid + "'>" +
                                    "<td class='filename'>" + f.name + "</td>" +
                                    "<td class='filesize'>" + f.size + "</td>" +
                                    "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile2\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            fileid++;
        });
    }
}
