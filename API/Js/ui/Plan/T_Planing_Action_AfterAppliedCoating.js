
var isValid = true;
var PKID = '';
var width = [0,90,180,270];
var objSelectFiles;
var orgRemark;
$(document).ready(function () {



    EventControl();
    InitialData();


});


function InitialData() {
    PKID = getParameterByName('PID');

   

    LoadData(PKID);
   
}



function FindMinAndAVGValue(objList) {

    var maximumn = 0,
    tempMaximum = 0,
        tempMin = 0,
    avg = 0;

    $.each(objList, function (index, item) {

        if (tempMin == 0) {
            tempMin = parseFloat(item.ClockPosition1);

        }
        else if (parseFloat(item.ClockPosition1) < tempMin) {
            tempMin = parseFloat(item.ClockPosition1);

        }

        if (parseFloat(item.ClockPosition2) < tempMin) {
            tempMin = parseFloat(item.ClockPosition2);

        }


        if (parseFloat(item.ClockPosition3) < tempMin) {
            tempMin = parseFloat(item.ClockPosition3);

        }
        if (parseFloat(item.ClockPosition4) < tempMin) {
            tempMin = parseFloat(item.ClockPosition4);

        }



        avg += parseFloat(item.ClockPosition1);
        avg += parseFloat(item.ClockPosition2);
        avg += parseFloat(item.ClockPosition3);
        avg += parseFloat(item.ClockPosition4);


    });

    avg = avg / (4 * objList.length);

    $('.lbMinimum').text(tempMin.toFixed(2));
    $('.lbAverage').text(avg.toFixed(2));


}



function LoadDryFilmTable(DryFilmList, minClockPosition, avgClockPosition) {
    var $tableBody = $('.tblDry').find("tbody");
    var tr ='';
    var $trLast = $tableBody.find("tr:last");
    var avg = 0;
    $trLast.find('input').val('').end();
    $trNew = $trLast.clone();
    $trNew.find('input').val('').end();



    if (DryFilmList != null && DryFilmList.length>0) {
        $tableBody.empty();

        $.each(DryFilmList, function (index, item) {

            $trLast = $('.tblDry > tbody');
            avg = 0;

            tr += '<tr><td><input class="form-control   chkSelect"  type="checkbox"/></td>';

            tr += '<td><input class="form-control   txtPositionNo" type="text" value="' + item.PositionNo + '" disabled/></td>';
            tr += '<td><select class="form-control   ddlRepairType"  > <option>กรุณาเลือก</option></select></td>';
            tr += '<td><input class="form-control   txtClockPosition1" value="' + item.ClockPosition1 + '" type="text"/></td>';
            tr += '<td><input class="form-control   txtClockPosition2" type="text" value="' + item.ClockPosition2 + '"/></td>';
            tr += '<td><input class="form-control   txtClockPosition3" type="text" value="' + item.ClockPosition3 + '"/></td>';
            tr += '<td><input class="form-control   txtClockPosition4" type="text" value="' + item.ClockPosition4 + '"/></td>';

            avg = (parseFloat(item.ClockPosition1) + parseFloat(item.ClockPosition2) + parseFloat(item.ClockPosition3) + parseFloat(item.ClockPosition4))/4
            tr += '<td><input class="form-control    txtAVGDFT" type="text" value="' + parseFloat(item.AVGDFT).toFixed(2) + '" disabled/></td>';
            tr += '</tr>';






        });


        $tableBody.append(tr);
       // LoadDropDownList($('.ddlRepairType'), "M_RepaireType");
        if (DryFilmList != null) {

            var i = 0;
            $('.tblDry > tbody  > tr').each(function () {

                var row = $(this);

               // alert(DryFilmList[i].RepairType)
              //  alert(DryFilmList[i].RepairType)
                 //      row.find('.ddlRepairType').val(DryFilmList[i].RepairType);
                LoadDropDownList(row.find('.ddlRepairType'), "M_CoatingRepairType", DryFilmList[i].RepairType);
                i++;

            });



        }

        $('.lbMinimum').text(minClockPosition);
        $('.lbAverage').text(avgClockPosition);
       // FindMinAndAVGValue(DryFilmList);
        $('.txtClockPosition1').IsNumeric();
        $('.txtClockPosition2').IsNumeric();
        $('.txtClockPosition3').IsNumeric();
        $('.txtClockPosition4').IsNumeric();
        $('.txtAVGDFT').IsNumeric();
        $('.txtAVGDFT').disabled();


    } 


}



function LoadData(PID) {

    var progress = "";
    var html = "";

    var formData = new FormData();
    formData.append("Action", "View");
    formData.append("PID", PID);



    LoadDropDownList($('.ddlHolidayTestMethod'), "M_TestMethod");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)



            if (obj != null) {





                $('.txtDryDFTEquipment').val(obj.DryDFTEquipment);
                $('.txtDryBrand').val(obj.DryBrand);
                $('.txtDryModel').val(obj.DryModel);
                $('.txtDrySN').val(obj.DrySN);
                $('.ddlHolidayTestMethod').val(obj.HolidayTestMethod);
                $('.txtHolidayBrand').val(obj.HolidayBrand);
                $('.txtHolidayModel').val(obj.HolidayModel);
                $('.txtHolidaySN').val(obj.HolidaySN);
                $('.txtHolidayTestVoltage').val(obj.HolidayTestVoltage);
                $('.txtHolidayRemark').val(obj.HolidayRemark);
                $('.datetimepicker').datepicker()

                $('.datetimepicker').datepicker()

                if (obj.DryFilmThicknessList != null && obj.DryFilmThicknessList.length > 0) {
                    LoadDryFilmTable(obj.DryFilmThicknessList, obj.MinClockPosition, obj.AvgClockPosition);
                } else {
                    LoadDropDownList($('.ddlRepairType'), "M_CoatingRepairType");
                }

                //  LoadDropDownList($('.ddlRepairType'), "M_RepaireType");

                objSelectFiles = obj.UploadFileList;
                //realFiles1 = $.grep(objSelectFiles, function (item) { return item.UploadType == '1'; });
                // realFiles2 = $.grep(objSelectFiles, function (item) { return item.UploadType == '2'; });
                ReloadFile1(null);
                ReloadFile2(null);

                if (obj.IsSave == '0') {

                    DisableAll();
                }

            } else {


                $('.txtClockPosition1').IsNumeric();
                $('.txtClockPosition2').IsNumeric();
                $('.txtClockPosition3').IsNumeric();
                $('.txtClockPosition4').IsNumeric();
                $('.txtAVGDFT').IsNumeric();

                $('.txtPositionNo').val("1")
                LoadDropDownList($('.ddlRepairType'), "M_CoatingRepairType");

                $('.datetimepicker').datepicker()

            }

        }

    });

}



function EventControl() {



  //  $('.txtDryDFTEquipment').IsNumeric();
   // $('.txtDryBrand').IsNumeric();
   // $('.txtDryModel').IsNumeric();
   // $('.txtDrySN').IsNumeric();

   // $('.txtHolidayBrand').IsNumeric();
 //   $('.txtHolidayModel').IsNumeric();
  //  $('.txtHolidaySN').IsNumeric();
    $('.txtHolidayTestVoltage').IsNumeric();


    $(".nav-tabs a").click(function () {
    

        window.location.href = this.href + '?Action=View&PID=' + PKID; ;

     
        return false;
    
    });


    $(document).on('click', ".btnNew", function (e) {

        var tr = "";
        var tableStr = "";
        var lastItem = 0;
        var $tableBody = $('.tblDry').find("tbody");

        $trLast = $tableBody.find("tr:last");

        lastItem = $trLast.find('.txtPositionNo').val()

      //  alert($trLast.find('.txtPositionNo'))
       
        if ($trLast.find('.txtPositionNo').length>0) {
            lastItem = parseInt(lastItem) + 1;
        } else {
            lastItem = 1;
        }


        tr += '<tr><td><input class="form-control   chkSelect"  type="checkbox"/></td>';
     
        tr += '<td><input class="form-control   txtPositionNo" type="text" value="' + (lastItem) + '"  disabled/></td>';
        tr += '<td><select class="form-control   ddlRepairType"   > <option>กรุณาเลือก</option></select></td>';
        tr += '<td><input class="form-control   txtClockPosition1"  type="text"/></td>';
        tr += '<td><input class="form-control   txtClockPosition2" type="text" /></td>';
        tr += '<td><input class="form-control   txtClockPosition3" type="text" /></td>';
        tr += '<td><input class="form-control   txtClockPosition4" type="text" /></td>';
        tr += '<td><input class="form-control    txtAVGDFT" type="text" disabled/></td>';
        tr += '</tr>';


        $tableBody.append(tr);
        LoadDropDownList($('.tblDry > tbody  > tr:last').find('.ddlRepairType'), "M_CoatingRepairType");


        $('.txtClockPosition1').IsNumeric();
        $('.txtClockPosition2').IsNumeric();
        $('.txtClockPosition3').IsNumeric();
        $('.txtClockPosition4').IsNumeric();
        $('.txtAVGDFT').IsNumeric();
      

    });

    $(document).on('click', ".btnDeleteDryFilm", function (e) {

        var deleteObjArray = [];
        var deleteObj = {};
        var formData = new FormData();

        $('.tblDry > tbody  > tr').each(function () {

            var row = $(this);

            if (row.find('.chkSelect').is(":checked")) {


                deleteObj = {};
                deleteObj.PID = PKID;
                deleteObj.PositionNo = row.find('.txtPositionNo').val();

                if (row.find('.txtPositionNo').val() != "") {
                    deleteObjArray.push(deleteObj);
                }
            }

        });



        if (deleteObjArray != null && deleteObjArray.length > 0) {

            formData.append('DeleteDryFilmList', JSON.stringify(deleteObjArray));
            formData.append("Action", "Delete");

            if (isValid) {

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


                                $.ajax({
                                    url: currentURL,
                                    type: "POST",
                                    data: formData,
                                    contentType: false,
                                    processData: false,
                                    success: function (result) {

                                        BAlert('Deleted', 'Delete data successfully!.');


                                        $('.tblDry > tbody  > tr').each(function () {

                                            var row = $(this);

                                            if (row.find('.chkSelect').is(":checked")) {

                                                row.remove();

                                                setTimeout(function () {
                                                    location.reload();

                                                }, 1500);


                                            }

                                        });




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


    });

    $('.btnSave').on("click", function (e) {



        var formData = new FormData();
        curStep = $(".tab-content");
        var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");


        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            } else {


                formData.append(curInputs[i].id, curInputs[i].value);

            }
        }

        formData.append("Action", "Add");
        formData.append("PID", PKID);

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


       

        formData.append('DeleteFiles', keepDeleteFiles1.join(",") +','+ keepDeleteFiles2.join(","));
        formData.append('DeleteFileNames', keepDeleteFileName1.join(",") + ',' + keepDeleteFileName2.join(","));




        var dryFilmArry = [];
        var dryFilmObj = {};
         i = 0;
        $('.tblDry > tbody  > tr').each(function () {

            var row = $(this);


            dryFilmObj = {};
            dryFilmObj.PID = PKID;
            dryFilmObj.PositionNo = row.find('.txtPositionNo').val();
            dryFilmObj.RepairType = row.find('.ddlRepairType').val();
            dryFilmObj.ClockPosition1 = row.find('.txtClockPosition1').val();
            dryFilmObj.ClockPosition2 = row.find('.txtClockPosition2').val();
            dryFilmObj.ClockPosition3 = row.find('.txtClockPosition3').val();
            dryFilmObj.ClockPosition4 = row.find('.txtClockPosition4').val();
            dryFilmObj.AVGDFT = row.find('.txtAVGDFT').val();


            if (row.find('.txtPositionNo').val() != "") {
                dryFilmArry.push(dryFilmObj);
            }

           
            /*     <td><input class="form-control   chkSelect"  type="checkbox"/></td>
            <td><input class="form-control   txtPositionNo" type="text"/></td>
            <td><select class="form-control   ddlRepairType"  style="width:150px;" > <option>กรุณาเลือก</option></select></td>
            <td><input class="form-control   txtClockPosition1" type="text"/></td>
            <td><input class="form-control   txtClockPosition2" type="text"/></td>
            <td><input class="form-control   txtClockPosition3" type="text"/></td>
            <td><input class="form-control   txtClockPosition4" type="text"/></td>
            <td><input class="form-control   txtAVGDFT" type="text"/></td>
            */


          
            i++;
        });


        formData.append('DryFilmList', JSON.stringify(dryFilmArry));





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
