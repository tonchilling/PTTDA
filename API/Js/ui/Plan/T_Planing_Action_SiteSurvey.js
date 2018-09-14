

var PKID = '';



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



    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)



            if (obj != null) {



                $('.txtDateInstalled').val(obj.DateINstalled);
                $('.txtRiskScore').val(obj.RiskScore);
                $('.txtNote').val(obj.Note);
                $('.txtRiskDetail').val(obj.RiskDetail);
                $('.txtMoreDetail').val(obj.MoreDetail);
                $('.txtNorth').val(obj.North);
                $('.txtEast').val(obj.East);
                $('.txtKP').val(obj.KP);
                $('.datetimepicker').datepicker()
                $('.txtSection').val(obj.Section);
                

                LoadDropDownList($('.ddlDIGFrom'), "M_DIGFrom", obj.Digfrom);
                LoadDropDownList($('.ddlRouteCode'), "M_RouteCode", obj.RouteCode);
                LoadDropDownList($('.ddlPipeGrade'), "M_PipeGrad", obj.Pipegrade);
                LoadDropDownList($('.ddlDiameter'), "M_Diameter", obj.Diameter);
                LoadDropDownList($('.ddlWallThickness'), "M_WallThickness", obj.WallThickness);
                LoadDropDownList($('.ddlMAOP'), "M_MAOP", obj.MAOP);

            
            //    LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), '', obj.PipelineID, '', obj.RouteCode, false);
               
                objSelectFiles = obj.UploadFileList;
              
                ReloadFile1(null);
                ReloadFile2(null);

                LoadAttachFiles(obj.PlanFileList);


                $(".selectTypeOfPipelineID").disabled();
                $(".ddlDIGFrom").disabled();
                $(".txtRiskScore").disabled();
                $(".txtNote").disabled();
                $(".txtRiskDetail").disabled();
                $('.txtDateInstalled').disabled();
                $('.txtDateInstalled').disabled();


                if (obj.IsSave == '0') {

                    DisableAll();
                    $('.btnSave').addClass("invisible")
                }

                LoadPopover();


            } else {

                $('.datetimepicker').datepicker()
                LoadDropDownList($('.ddlDIGFrom'), "M_DIGFrom");
                LoadDropDownList($('.ddlRouteCode'), "M_RouteCode");
                LoadDropDownList($('.ddlPipeGrade'), "M_PipeGrad");
                LoadDropDownList($('.ddlDiameter'), "M_Diameter");
                LoadDropDownList($('.ddlWallThickness'), "M_WallThickness");
                LoadDropDownList($('.ddlMAOP'), "M_MAOP");
             //   LoadDropDownList($('.ddlTypeOfPipelineID'), "M_TypeOfPipeline");
            }

        }

    });

}


function LoadAttachFiles(planAttachFiles) {


     var html=''
   

    $.each(planAttachFiles, function (index, item) {
      

        html += "<span class='filename'style='cursor:pointer;'" +
                                     " data-toggle='popover' data-content='<image src=\"" + item.HtmlFile + "\"></image>'   >" + ' <img src="' + item.HtmlFile + '"  height="80"  class="thumbnailImg" />' + "</span>" 
    });

    $('.divAttachFile').append(html);

}
function EventControl() {



    $('.txtRiskScore').IsNumeric();
  //  $('.txtRiskDetail').IsNumeric();
    

    $(".nav-tabs a").click(function () {
    

        window.location.href = this.href + '?Action=View&PID=' + PKID; ;

     
        return false;
    
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


        formData.append("Action", "Add");
        formData.append("PID", PKID);

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

          
                fileTable.append("<tr id='" + file.No + "_row' data ='" + file.No + "' PID ='" + file.PID + "' filename ='" + file.FileName + "'>" +
                                   
                                    "<td class='filename'style='cursor:pointer;'"+
                                     " data-toggle='popover' data-content='<image src=\""+file.HtmlFile+"\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + file.FileSize + "</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile1\" aria-hidden=\"true\" style=\" color:red\"></i></td>");

               
            }
        });
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
                                     "<td class='filename'style='cursor:pointer;'"+
                                     " data-toggle='popover' data-content='<image src=\""+file.HtmlFile+"\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + file.FileSize + "</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile2\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            }
        });
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
