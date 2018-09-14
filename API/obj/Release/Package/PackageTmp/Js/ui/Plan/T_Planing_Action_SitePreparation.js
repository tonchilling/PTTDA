
var isValid = true;
var PKID = '';



$(document).ready(function () {



    EventControl();
    InitialData();


});


function InitialData() {
    PKID = getParameterByName('PID');


   
    LoadData(PKID);

}

function LoadUnderGroup(underGroundList) {



    var objParentSelect;
    var divUnderground = $('.divUnderground')
    var html = "";

    divUnderground.empty();
    var formData = new FormData();
    formData.append("Action", "Search");


   
      /*  <ul >
    <li><label><input type="checkbox" class="chk"/> FOC</label> </li>
     <li><label><input type="checkbox" class="chk"/> Zinc Ribbon</label> </li>
       <li><label><input type="checkbox" class="chk"/> Ground Rod</label> </li>
          <li><label><input type="checkbox" class="chk"/> Other Utility</label>
    <ul >
      <li class="row" ><label class="col-sm-4"><input type="checkbox" class="chk"/> Pipeline</label> <input type="text" class="form-control  "  id="txtOtherPipeline"  /></li>
        <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Power Line</label> <input type="text" class="form-control "  id="Text1"  /></li>
          <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Water Supplier</label> <input type="text" class="form-control "  id="Text2"  /></li>
            <li  class="row"  ><label class="col-sm-4"><input type="checkbox" class="chk"/> Community Line</label> <input type="text" class="form-control"   id="Text3"  /></li>
       </ul>
       </li>
   <li><label><input type="checkbox" class="chk"/> Etc.</label> </li>
    </ul>
    */

    html = html + "<ul>";
    $.ajax({
        url: underGroupURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            var objList = JSON.parse(result)



            if (objList != null) {



                var objParent = $.grep(objList, function (e) { return (e.ParentUID == ''); });

                $.each(objParent, function (index, item) {

                    objParentSelect = null;
                    if (underGroundList != null) {
                        objParentSelect = $.grep(underGroundList, function (e) { return (e.UID == item.UID); });
                    }

                    if (underGroundList != null && Object.keys(objParentSelect).length > 0) {
                        html = html + ' <li><label><input type="checkbox" class="chkUnderground" data="' + item.UID + '" checked/> ' + item.Name + '</label> </li>';
                    } else {
                        html = html + ' <li><label><input type="checkbox" class="chkUnderground" data="' + item.UID + '"/> ' + item.Name + '</label> </li>';
                    }

                    var objChild = $.grep(objList, function (e) { return (e.ParentUID == item.UID); });
                    if (Object.keys(objChild).length > 0) {
                        html = html + "<ul>";

                        $.each(objChild, function (index, item) {
                            objParentSelect = null;
                            if (underGroundList != null) {
                                objParentSelect = $.grep(underGroundList, function (e) { return (e.UID == item.UID); });
                            }

                            if (underGroundList != null && Object.keys(objParentSelect).length > 0) {
                                html = html + '<li class="row" ><label class="col-sm-4"><input type="checkbox" class="chkUnderground" data="' + item.UID + '" checked/> ' + item.Name + '</label> ';
                                html = html + ' <input type="text" class="form-control inputUnderground "    name="' + item.UID + '"  value="' + objParentSelect[0].Value + '"   /></li>';
                              
                            } else {
                                html = html + '<li class="row" ><label class="col-sm-4"><input type="checkbox" class="chkUnderground" data="' + item.UID + '"/> ' + item.Name + '</label> ';
                                html = html + ' <input type="text" class="form-control inputUnderground "    name="' + item.UID + '"    /></li>';
                            }


                         
                          
                        });
                        html = html + "</ul>";
                    }

                });

            }
            html = html + "</ul>";
            divUnderground.append(html);

        }
    });

   
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

            


                $('.txtNorth').val(obj.North);
                $('.txtEast').val(obj.East);
                $('.txtBrand').val(obj.Brand);
                $('.txtModel').val(obj.Model);
                $('.txtSN').val(obj.SN);
                $('.txtPipelineSection').val(obj.PipelineSection);
                $('.txtSoildType').val(obj.SoildType);
                $('.txtBacteriaAPB').val(obj.BacteriaAPB);
                $('.txtBacteriaSRB').val(obj.BacteriaSRB);
                $('.txtPH').val(obj.PH);
                $('.txtDepthOfCover').val(obj.DepthOfCover);
                $('.txtMoreDetail').val(obj.MoreDetail);
                $('.txtDigLength').val(obj.DigLength);
                
             


              


                $('.datetimepicker').datepicker()


                LoadDropDownList($('.ddlAreaOwner'), "M_AreaOwner", obj.AreaOwner);
                LoadDropDownList($('.ddlSoildType'), "M_SoilType", obj.SoildType);
                LoadDropDownList($('.ddlPipelineSection'), "M_TypeOfPipeline", obj.PipelineSection);

                LoadUnderGroup(obj.underGroundList);

                objSelectFiles = obj.UploadFileList;
               
                ReloadFile(null);
              

                if (obj.IsSave == '0') {

                    DisableAll();
                }


            } else {

                LoadUnderGroup(null);

                $('.datetimepicker').datepicker()
                LoadDropDownList($('.ddlAreaOwner'), "M_AreaOwner");
                LoadDropDownList($('.ddlSoildType'), "M_SoilType");
                LoadDropDownList($('.ddlPipelineSection'), "M_TypeOfPipeline");
            }

        }

    });

}

function EventControl() {




    $(".txtNorth").IsNumeric();
    $(".txtEast").IsNumeric();
   // $(".txtBrand").IsNumeric();
   // $(".txtModel").IsNumeric();
  //  $(".txtSN").IsNumeric();
    $(".txtDepthOfCover").IsNumeric();
    $(".txtBacteriaAPB").IsNumeric();
    $(".txtBacteriaSRB").IsNumeric();
    $(".txtPH").IsNumeric();
    $(".txtDigLength").IsNumeric();
    $(".txtDigLength").IsNumeric();

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
        realFiles.forEach(function (file) {
            formData.append('file1_' + i, file);
            i++;
        });


        /*  public string  Underground_Foc { get; set; }
        public string  Underground_OtherPipline { get; set; }
        public string  Underground_Powerline { get; set; }
        public string  Underground_Etc { get; set; }

        chkUnderground_Foc
        chkUnderground_OtherPipline
        chkUnderground_Powerline
        chkUnderground_Etc
        */

        if ($('.chkUnderground_Foc').is(":checked")) {
            formData.append('Underground_Foc', '1');
        }

        if ($('.chkUnderground_OtherPipline').is(":checked")) {
            formData.append('Underground_OtherPipline', '1');
        }

        if ($('.chkUnderground_Powerline').is(":checked")) {
            formData.append('Underground_Powerline', '1');
        }

        if ($('.chkUnderground_Etc').is(":checked")) {
            formData.append('Underground_Etc', '1');
        }


        tags = new Array();
        $('.chkUnderground').each(function (i, obj) {

            if ($(obj).is(':checked')) {

                this_tag = new Object();
                this_tag.UID = $(obj).attr("data");
                var input = $('.inputUnderground')
                this_tag.Value = $("[name='" + this_tag.UID + "'") != null ? $("[name='" + this_tag.UID + "'").val() : "";

                tags.push(this_tag);

            }
        });


        formData.append("Action", "Add");
        formData.append("PID", PKID);
        formData.append('objList', JSON.stringify(tags));

        formData.append('DeleteFiles', keepDeleteFiles.join(","));
        formData.append('DeleteFileNames', keepDeleteFileName.join(","));





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
                realFiles.push(f);
            });
            var text = "";

            ReloadFile(realFiles);
            //  $("#output").val(text);
        }).on('cancel.bs.filedialog', function (ev) {

            if (realFiles != null) {
                var text = "";


                ReloadFile(realFiles);
                // $("#output").val(text);

            } else {
                $("#output").val("Cancelled!");
            }
        });

        event.preventDefault();
    });



  



    $(document).on('click', '.btnDeletefile', function (e) {
        var $item = $(this).closest("tr");

        if ($item.attr('PID') != null) {
            keepDeleteFiles.push($item.attr('data'));
            keepDeleteFileName.push("1\\" + $item.attr('filename'));
            objSelectFiles = $.grep(objSelectFiles, function (e) {
                return e.No != $item.attr('data');
            });


        }
        else if (realFiles != null) {
            if (realFiles.length == 1) {
                realFiles.pop(0);
            } else {
                realFiles.pop($item.attr('data'));
            }
        }
        ReloadFile(realFiles);
        // alert($item.attr('data'))
    });

   




}




function ReloadFile(newFiles) {
    var fileTable = $("#filename1 tbody");
    fileTable.empty();
    var fileid = 1;

    if (objSelectFiles != null) {

        fileid = objSelectFiles.length;
        $.each(objSelectFiles, function (index, file) {

      
                fileTable.append("<tr id='" + file.No + "_row' data ='" + file.No + "' PID ='" + file.PID + "' filename ='" + file.FileName + "' >" +
                                    "<td class='filename'style='cursor:pointer;'" +
                                     " data-toggle='popover' data-content='<image src=\"" + file.HtmlFile + "\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + file.FileSize + "</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
       
        });
    }

    if (newFiles != null) {
        newFiles.forEach(function (f) {


           
            fileTable.append("<tr id='" + fileid + "_row' data ='" + fileid + "'>" +
                                    "<td class='filename'>" + f.name + "</td>" +
                                    "<td class='filesize'>" + f.size + "</td>" +
                                    "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            fileid++;
        });
    }

    LoadPopover();
}

