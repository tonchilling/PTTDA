
var isValid = true;
var PKID = '';
var objSelectFiles;


$(document).ready(function () {



    EventControl();
    InitialData();


});


function InitialData() {
    PKID = getParameterByName('PID');

    $('.btnExport').css("display", "none");

    LoadData(PKID);
   
}






function LoadData(PID) {

    var progress = "";
    var html = "";

    var formData = new FormData();
    formData.append("Action", "View");
    formData.append("PID", PID);



    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)



            if (obj != null) {



                /*  if (obj.IsApprove == '0') {
                $('.btnConfirm').css("display", "none");


                }


                if (obj.IsSave == '0') {

                $('.btnSave').css("display", "none");
                   
                  
                }


                if (obj.IsReject == '0') {
                $('.btnReject').css("display", "none");

                }
                */

                if (obj.IsApprove == '0') {
                    $('.btnConfirm').css("display", "none");


                } else if (obj.IsApprove == '1') {
                    $('.btnConfirm').css("display", "inline");
                }


                if (obj.IsReject == '0') {
                    $('.btnReject').css("display", "none");

                }

                $('.txtRemark').val(obj.Remark);
                if (obj.ApprovalName1 != null) {
                    $('.lbInspector').text(obj.ApprovalName1);
                    $('.lbPosition1').text("( "+obj.ApprovalPosition1+" )");
                    
                    $('.lbInspectorDate').text('Date : ' + obj.ApprovalDate1 + '');

                } else {

                    $('.lbInspector').html('&nbsp;');
                    $('.lbPosition1').html('&nbsp;');
                    $('.lbInspectorDate').text('Date.....................................................');
                }

                if (obj.ApprovalName2 != null) {
                    $('.lbEngineer').text(obj.ApprovalName2);
                    $('.lbPosition2').text("( " + obj.ApprovalPosition2 + " )");
                    $('.lbEngineerDate').text('Date : ' + obj.ApprovalDate2 + '');
                }
                else {
                    $('.lbEngineer').html('&nbsp;');
                    $('.lbPosition2').html('&nbsp;');
                    $('.lbEngineerDate').text('Date.....................................................');
                }


                if (obj.ApprovalName3 != null) {
                    $('.lbManager').text(obj.ApprovalName3);
                    $('.lbPosition3').text("( " + obj.ApprovalPosition3 + " )");
                    $('.lbManagerDate').text('Date : ' + obj.ApprovalDate3 + '');
                    $('.btnExport').css("display", "inline");
                    
                }
                else {
                    $('.lbManager').html('&nbsp;');
                    $('.lbPosition3').html('&nbsp;');
                    $('.lbManagerDate').text('Date.....................................................');
                }

                $('.datetimepicker').datepicker()



                //  LoadDropDownList($('.ddlRepairType'), "M_RepaireType");

                objSelectFiles = obj.UploadFileList;

                LoadApproveHistory(obj.LogApporveHistorys);
                //realFiles1 = $.grep(objSelectFiles, function (item) { return item.UploadType == '1'; });
                // realFiles2 = $.grep(objSelectFiles, function (item) { return item.UploadType == '2'; });
                ReloadFile1(null);
                ReloadFile2(null);

                if (obj.IsSave == '0') {

                    DisableAll();
                }

                if (obj.ApprovalName3 != null) {
                 
                    $('.btnExport').removeClass("invisible");
                }

            } else {
                $('.btnReject').css("display", "none");
                $('.btnConfirm').css("display", "none");
                $('.datetimepicker').datepicker()

            }

        }

    });

}


function LoadApproveHistory(objList) {
    //var tableHistory = $('.divLogHistory table');
    $(".divLogHistory").empty();
    var html="";
      html ='<table id="Table1" class="table table-hover  table-fixed" style="width:100%; background-color:#ffffff;">'
    html +='<thead>';
    html += ' <tr class="table-info"><th scope="col">Update Date</th><th scope="col">Status</th><th scope="col">Comment</th><th scope="col">Created</th></tr>';
       html +='</thead>';
       html += '<tbody>';

       $.each(objList, function (index, item) {

           html += '<tr>';
           html += '<td>' + item.CreateDate + '</td>';
           html += '<td>' + item.Remark + '</td>';
           html += '<td>' + item.Comment + '</td>';
           html += '<td>' + item.CreateBy + '</td>';
           html += '</tr>';
       });

    html += '</tbody>';
 html +=' </table>';
 $(".divLogHistory").append(html);
/* $('.divLogHistory table').DataTable({

     dom: 'Bfrtip',
     searching: false

 });*/
}

function EventControl() {



    $(".nav-tabs a").click(function () {
    

        window.location.href = this.href + '?Action=View&PID=' + PKID; ;

     
        return false;

    });



    $('.btnReject').on("click", function (e) {
        var formData = new FormData();
        formData.append("Action", "Reject");
        formData.append("PID", PKID);

        $.confirm({
            icon: 'fa fa-warning',
            title: 'Confirm Reject?',
            columnClass: 'col-md-6 col-md-offset-6',
            content: '' +
                '<form action="" class="formName">' +
                 '<div class="form-group">' +
                '<textarea placeholder="Remark" class="txtComment form-control" rows="4" required />' +
                '</div>' +
                '</form>',
            type: 'red',
            animation: "RotateX",
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'Reject',
                    btnClass: 'btn-danger',
                    action: function () {

                        var comment = this.$content.find('.txtComment').val();
                        formData.append("Comment", comment);

                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {



                                formData = null;
                              
                                BAlert('Rejected', 'Reject data successfully!.');
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



    });



    $('.btnExport').on("click", function (e) {


        newwindow = window.open(reportURL + "?PID=" + PKID, "ExportReport", 'height=400,width=800');
        if (window.focus) { newwindow.focus() }
        return false;


    });
    

    $('.btnConfirm').on("click", function (e) {
        var formData = new FormData();
        formData.append("Action", "Approve");
        formData.append("PID", PKID);

         $.confirm({
                icon: 'fa fa-warning',
                title: 'Confirm Approve ?',
                columnClass: 'col-md-6 col-md-offset-6',
                content: '' +
                '<form action="" class="formName">' +
                 '<div class="form-group">' +
                '<textarea placeholder="Remark" class="txtComment form-control" rows="4" required />' +
                '</div>' +
                '</form>',
                type: 'blue',
                animation: "RotateX",
                typeAnimated: true,
                buttons: {
                    tryAgain: {
                        text: 'Confrim',
                        btnClass: 'btn-info',
                        action: function () {

                            var comment = this.$content.find('.txtComment').val();
                            formData.append("Comment", comment);

                           
                            $.ajax({
                                url: currentURL,
                                type: "POST",
                                data: formData,
                                contentType: false,
                                processData: false,
                                success: function (result) {

                                  

                                    formData = null;
                                   
                                    BAlert('Approved', 'Approve data successfully!.');
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

                                   // LoadData(PKID);

                                    BAlert('Saved', 'Save data successfully!.');
                                     setTimeout(function () {
                                         location.reload();
                                        
                                }, 1000);
                                    formData = null;

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
