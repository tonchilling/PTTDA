
var PKID = "";
var Action = "";

var fileid = 0;
var regionID='',pipelineID = '',assetOwnerID='',routeCodeID='';
var assertOwnerChange = false;
var keepDeleteFiles=[];
var keepDeleteFileName = [];

$(document).ready(function () {



    InitialData();
    AutorizePage();

    $('.btnSave').on("click", function (e) {

        Save();
    });



    $('.btnClose').on("click", function (e) {

        window.location.href = listURL;
    });
    $('.datetimepicker').datepicker()


    $('.btnAdd').on("click", function (e) {

        window.location.href = ' <%= ResolveUrl("~/UI/Plan/PlanAction.aspx") %>';
    });


    $(document).on('click', '.btnDeletefile', function (e) {
        var $item = $(this).closest("tr");

        if ($item.attr('PID') != null) {
            keepDeleteFiles.push($item.attr('data'));
            keepDeleteFileName.push($item.attr('filename'));
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


    $("#open_btn").on("click", function (e) {
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


    $(document).on('change', '.selectRegionID', function (e) {

        AssignDropDownToData();
        regionID = $(this).val();
        LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadAssetOwnerDropDownList($(".selectAssetOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadRouteCodeDropDownList($(".selectRouteCodeID"), regionID, pipelineID, assetOwnerID, routeCodeID);

    });




    $(document).on('change', '.selectTypeOfPipelineID', function (e) {

        assertOwnerChange = true;

        
        AssignDropDownToData();

        pipelineID = $(this).val();




       
            LoadRegionDropDownList($(".selectRegionID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadAssetOwnerDropDownList($(".selectAssetOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadRouteCodeDropDownList($(".selectRouteCodeID"), regionID, pipelineID, assetOwnerID, routeCodeID);

        //  setTimeout(function () { waitingDialog.hide(); }, 1000);
    });


    $(document).on('change', '.selectAssetOwner', function (e) {

        AssignDropDownToData();
        assetOwnerID = $(this).val();
            LoadRegionDropDownList($(".selectRegionID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadRouteCodeDropDownList($(".selectRouteCodeID"), regionID, pipelineID, assetOwnerID, routeCodeID);
    });


    $(document).on('change', '.selectRouteCodeID', function (e) {
      
        assertOwnerChange = true;
        AssignDropDownToData();
        routeCodeID = $(this).val();
        LoadSection($(".selectRouteCodeID option:selected").text(), $(".txtKP").val());
            LoadRegionDropDownList($(".selectRegionID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadAssetOwnerDropDownList($(".selectAssetOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);

       


    });


    $(document).on('keyup', '.txtKP', function (e) {
        LoadSection($(".selectRouteCodeID option:selected").text(), $(this).val());

    });


});

function LoadSection(RouteCode, KP)
{
    var formData = new FormData();
    formData.append("RouteCodeName", RouteCode);
    formData.append("KP", KP);
    formData.append("Action", "FindByRouteCode");

    $(".txtSection").val('');
    $.ajax({
        url: sectionURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {


            var data;
            var error = "";

            if (result != "") {
                data = JSON.parse(result);

                if (data != null) {
                    $(".txtSection").val(data.SectionName);
                }
            }
            

          


        },
        error: function (err) {
            alert(err.statusText)
        }
    });
}


function AssignDropDownToData(tregionID, tassetOwnerID, tpipelineID, trouteCodeID) {
    regionID = (tregionID!=null ? tregionID : $(".selectRegionID").val());
    assetOwnerID = (tassetOwnerID != null ? tassetOwnerID : $(".selectAssetOwner").val());
    pipelineID = (tpipelineID != null ? tpipelineID : $(".selectTypeOfPipelineID").val());
    routeCodeID = (trouteCodeID != null ? trouteCodeID : $(".selectRouteCodeID").val());   
}
function Save() {

    var curStep = $(".setup-content");

    var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");
    var isValid = true;
    var formData = new FormData();



    $(".form-group").removeClass("has-error");
    for (var i = 0; i < curInputs.length; i++) {
        if (!curInputs[i].validity.valid) {
            isValid = false;
            $(curInputs[i]).closest(".form-group").addClass("has-error");
        } else {

         //   alert(curInputs[i].id)
            formData.append(curInputs[i].id, curInputs[i].value);
        }
    }


  /*  var inputFiles = curStep.find("input[type='file']");
    var i = 1;
    for (var i = 0; i < inputFiles.length; i++) {
        formData.append('file_-' + i, inputFiles[i].files[0]);
        i++;

    }*/

    i = 1;

   formData.append('DeleteFiles', keepDeleteFiles.join(","));
   formData.append('DeleteFileNames', keepDeleteFileName.join(","));



  i = 1;
    realFiles.forEach(function (file) {
        formData.append('file_' + i, file);
        i++;
    });

  



    //  alert($("input[name=chkStatus]:checked").val())
    formData.append("PID", PKID);
    //formData.append("Status", $("input[name=chkStatus]:checked").val());
    formData.append("Action", "Add");

    //isValid = false;
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


                                var errorList;
                                var error = "";

                                if (result != "") {
                                    errorList = JSON.parse(result);

                                    if (errorList != null) {

                                        $.each(errorList, function (index, item) {

                                            error += item.text + "<br>";
                                           
                                        });

                                        $('.lblError').html(error);
                                    }
                                }
                                else {

                                    BAlert('Saved', 'Save data successfully!.');

                                    formData = null;

                                    setTimeout(function () {
                                        window.location.href = listURL;
                                    }, 1000);
                                }
                               
                                $(".modalpopup").modal('hide');
                               

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

function InitialData() {

  

    PKID = getUrlParameter("PID");
    Action = getUrlParameter("Action");

    if (PKID == undefined) {
        PKID=''
    }

    if (Action == undefined) {
        Action = 'New'

    }


    $(".txtNorth").IsNumeric();
    $(".txtEast").IsNumeric();
   // $(".txtSection").IsNumeric();
    $(".txtKP").IsNumeric();
    $(".txtRiskScore").IsNumeric();
  //  $(".txtRiskOfDetail").IsNumeric();

   LoadData();
}


function LoadData() {

    var formData = new FormData();
    formData.append("Action", Action);
    formData.append("PID", PKID);

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            var obj = null;
            if (result != '') {
                obj = JSON.parse(result)
            }

            SetControl(obj);
        }
    });
}


function SetControl(item) {





    if (item != null) {
        $(".txtNorth").val(item.North);
        $(".txtEast").val(item.East);
        $(".txtSection").val(item.Section);
        $(".txtKP").val(item.KP);
        $(".txtRiskScore").val(item.RiskScore);
        $(".txtRiskOfDetail").val(item.RiskOfDetail);
        $(".txtRemark").val(item.Remark);
        $(".txtSpecSDate").val(item.SpecSDate);
        $(".txtSpecEDate").val(item.SpecEDate);

        $(".txtPOSDate").val(item.POSDate);
        $(".txtPOEDate").val(item.POEDate);

        $(".txtActionSDate").val(item.ActionSDate);
        $(".txtActionEDate").val(item.ActionEDate);


        if (item.IsSave == '0') {
            $(".txtNorth").disabled();
            $(".txtEast").disabled();
            $(".txtSection").disabled();
            $(".txtKP").disabled();
            $(".txtRemark").disabled();
            $(".txtRiskScore").disabled();
            $(".txtRiskOfDetail").disabled();
            $(".selectDIGFromID").disabled();
            $(".selectRegionID").disabled();
            $(".selectTypeOfPipelineID").disabled();
            $(".selectRouteCodeID").disabled();
            $(".selectAssetOwner").disabled();
            $(".txtSpecSDate").disabled();
            $(".txtSpecEDate").disabled();

            $(".txtPOSDate").disabled();
            $(".txtPOEDate").disabled();

            $(".txtActionSDate").disabled();
            $(".txtActionEDate").disabled();

            $(".btn").invisible();

            $('.btnSave').invisible();
        }


        LoadDropDownList($('.selectDIGFromID'), 'M_DIGFrom', item.DIGFromID);
     
      //  pipelineID = item.PipelineID;
        LoadRegionDropDownList($(".selectRegionID"), item.RegionID, item.PipelineID, item.AssetOwner, item.RouteCodeID);
        LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), item.RegionID, item.PipelineID, item.AssetOwner, item.RouteCodeID);
        LoadAssetOwnerDropDownList($(".selectAssetOwner"), item.RegionID, item.PipelineID, item.AssetOwner, item.RouteCodeID);
        LoadRouteCodeDropDownList($(".selectRouteCodeID"), item.RegionID, item.PipelineID, item.AssetOwner, item.RouteCodeID);
     

      // LoadDropDownList($('.selectTypeOfPipelineID'), 'M_PipelineLength', item.PipelineID);
      // LoadDropDownList($('.selectRouteCodeID'), 'M_RouteCode', item.RouteCodeID);
      // LoadDropDownList($('.selectAssetOwner'), "M_AssertOwner", item.AssetOwner);

        objSelectFiles = item.UploadFileList;
        ReloadFile(null);

       
    } else {


        LoadDropDownList($('.selectDIGFromID'), 'M_DIGFrom');
        LoadRegionDropDownList($(".selectRegionID"), regionID, pipelineID, assetOwnerID, routeCodeID);
        LoadTypeOfPipelineDropDownList($(".selectTypeOfPipelineID"), regionID, pipelineID,assetOwnerID, routeCodeID );
        LoadAssetOwnerDropDownList($(".selectAssetOwner"), regionID, pipelineID,assetOwnerID, routeCodeID );
        LoadRouteCodeDropDownList($(".selectRouteCodeID"), regionID, pipelineID,assetOwnerID, routeCodeID );
       // LoadDropDownList($('.selectTypeOfPipelineID'), 'M_PipelineLength');
       // LoadDropDownList($('.selectRouteCodeID'), 'M_RouteCode');
       // LoadDropDownList($('.selectAssetOwner'), "M_AssertOwner");

    }
}

function AutorizePage() {

    var formData = new FormData();
    formData.append("Action", "GetUserSession");

    $.ajax({
        url: userAutorizeURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var editplan = "";
            var obj = JSON.parse(result);



            if (obj.EditTimeline == "1") {
                $('.divStep2').visible();
            }
            else {
                $('.divStep2').invisible();
            }

            if (obj.EditTimeline == "1") {
                $('.btnSave').enabled();
            }

          


            else if (obj.CreatePlan == "0") {
                $('.btnSave').disabled();
            }
            else {


                $('.btnSave').enabled();
                // $('.divStep2').invisible();
            }

            if (item.IsSave == '0') {
                $('.btnSave').disabled();
            }


            /*   if(obj.ExportPlan=="0")
            {
            $('.btnExport').disabled();
            }else{
            $('.btnExport').enabled();
            }


            if(obj.ConfirmPlan=="0")
            {
            $('.btnConfirm').disabled();
            }else{
            $('.btnConfirm').enabled();
            }*/

        }
    });
}

function ReloadFile(newFiles) {
    var fileTable = $("#filenames tbody");
    fileTable.empty();


    if (objSelectFiles != null) {

        fileid = objSelectFiles.length;
        $.each(objSelectFiles, function (index, file) {
            fileTable.append("<tr id='" + file.No + "_row' data ='" + file.No + "' PID ='" + file.PID + "' filename ='" + file.FileName + "' >" +
                                    "<td class='filename'style='cursor:pointer;'" +
                                     " data-toggle='popover' data-content='<image src=\"" + file.HtmlFile + "\"></image>'   >" + file.FileName + "</td>" +
                                    "<td class='filesize'>" + (Math.round(file.FileSize / 1024)) + "K</td>" +
                                  "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
        });

        LoadPopover();
    }

    if (newFiles != null) {
        newFiles.forEach(function (f) {
            fileTable.append("<tr id='" + fileid + "_row' data ='" + fileid + "'>" +
                                    "<td class='filename'>" + f.name + "</td>" +
                                    "<td class='filesize'>" + Math.round(f.size / 1024) + "K</td>" +
                                    "<td class='percentdone'><i class=\"fa fa-2x fa-times btn btnDeletefile\" aria-hidden=\"true\" style=\" color:red\"></i></td>");
            fileid++;
        });
    }
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


