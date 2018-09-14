var isValid = true;
var PKID = '';

$(document).ready(function () {



    InitalData();

    Event();
   





});



function InitalData() {
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

                /*  public string ID { get; set; }
                public string PID { get; set; }
                public string SurfaceType { get; set; }
                public string SurfaceBrand { get; set; }
                public string SurfaceModel { get; set; }
                public string CoatingTypeID { get; set; }
                public string CoatingBrand { get; set; }
                public string CoatingModel { get; set; }*/

                if (obj.SurfaceType == "1") {
                    $('#chkSurface1').prop("checked", true);
                    $('.lbSurface').text('Replica');
                } else if (obj.SurfaceType == "2") {
                    $('#chkSurface2').prop("checked", true);
                    $('.lbSurface').text('Digital Surface Profile Guage');
                } else if (obj.SurfaceType == "3") {
                    $('#chkSurface3').prop("checked", true);
                    $('.lbSurface').text('Surface Profile Guage');
                }



                $('.txtSurfaceBrand').val(obj.SurfaceBrand);
                $('.txtSurfaceModel').val(obj.SurfaceModel);
                $('.txtSurfaceModel').val(obj.SurfaceModel);
                $('.txtCoatingBrand').val(obj.CoatingBrand);
                $('.txtCoatingModel').val(obj.CoatingModel);



                LoadSurfaceTable(obj.UploadFileList);
                LoadCoatininfoTable(obj.CoatingInfoList);

                $('.datetimepicker').datepicker()
                LoadDropDownList($('.ddlCoatingTypeID'), "M_CoatingType", obj.CoatingTypeID);



                var value = obj.CoatingTypeName;

              

                if (value.toLowerCase().indexOf('liquid') > -1) {
                    $(".tblCoatingInfoTable").removeClass('invisible');

                } else {
                    $(".tblCoatingInfoTable").addClass('invisible');
                }



              

                if (obj.IsSave == '0') {

                    DisableAll();
                }


            } else {

                LoadDropDownList($('.ddlCoatingTypeID'), "M_CoatingType");
            }

        }

    });


}



function LoadSurfaceTable(objList) {

    var i = 0;
    var imgLable = "";

    if (objList != null && objList.length > 0) {
        $('.tblSurfaceTable > tbody  > tr').each(function () {
            var row = $(this);
            var obj = objList[i];

            if (obj != null) {
                row.find('.txtItemNo').val(obj.No);
                row.find('.txtProfile').val(obj.Profile);

                if (obj.FileName != null) {
                    row.find('.txtFile').css("display", "none");



                    if (obj.FileName != "") {
                        row.find('.txtFile').closest("td").append("<label class=\"txtFileName filename\" style=\"cursor:pointer;\" data-toggle=\"popover\"" +
            "data-content='<image src=\"" + obj.HtmlFile + "\"></image>' >" + obj.FileName + " </label>" +
            "<i class=\"fa fa-2x fa-times btn btnDeleteFile\" style=\"color:red\"></i>");

                    } else {
                        row.find('.txtFile').css("display", "block");

                    }




                }
            }
            i++;
        });

        $('.txtPartA').IsNumeric();
        $('.txtPartB').IsNumeric();
        $('.txtSolvent').IsNumeric();

        LoadPopover();
    }

}


function LoadCoatininfoTable(objList) {

    var i = 0;
    $('.tblCoatingInfoTable > tbody  > tr').each(function () {

  /*    <td><input class="form-control   txtPartA" type="text"/></td>
  <td><input class="form-control   txtPartB" type="text"/></td>
   <td><input class="form-control   txtSolvent" type="text"/></td>
    <td><input class="form-control   txtRemark" type="text"/></td>*/

        var row = $(this);
        var obj = objList[i];
        row.find('.txtPartA').val(obj.PartA);
        row.find('.txtPartB').val(obj.PartB);
        row.find('.txtSolvent').val(obj.Solvent);
        row.find('.txtRemark').val(obj.Remark);
      
        i++;
    });

    $('.txtPartA').IsNumeric();
    $('.txtPartB').IsNumeric();
    $('.txtSolvent').IsNumeric();

}


function Event() {




   // $('.txtSurfaceBrand').IsNumeric();
   // $('.txtSurfaceModel').IsNumeric();
  //  $('.txtCoatingModel').IsNumeric();
  //  $('.txtCoatingBrand').IsNumeric();
    $('.txtProfile').IsNumeric();
    

  //  $('.txtPartA').IsNumeric();
  //  $('.txtPartB').IsNumeric();
  //  $('.txtSolvent').IsNumeric();

   
    $(".nav-tabs a").click(function () {


        window.location.href = this.href + '?Action=View&PID=' + PKID; ;


        return false;

    });


    $(".ddlCoatingTypeID").on("change", function (e) {

        var value = $(this).find("option:selected").text()

      
        if (value.toLowerCase().indexOf('liquid') > -1) {
            $(".tblCoatingInfoTable").removeClass('invisible');

        } else {
            $(".tblCoatingInfoTable").addClass('invisible');
        }

    });

    


    $(".chkSurface").on("click", function (e) {


        switch ($(this).val()) {

            case "1": $('.lbSurface').text('Replica'); break;
            case "2": $('.lbSurface').text('Digital Surface Profile Guage'); break;
            case "3": $('.lbSurface').text('Surface Profile Guage'); break;
        }

    });



    $(document).on('click', '.btnDeleteFile', function (e) {

        var $inputFile = $(this).closest("td").find('.txtFile');
        var $lable = $(this).closest("td").find('label');
        $lable.css("display", "none");
        $(this).css("display", "none");
        $inputFile.css("display", "block");
        // $inputFile.
    });


    $('.btnSave').on("click", function (e) {


        var chkValue = "";
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

        if ($("#chkSurface1").is(":checked")) {
            chkValue = "1";
        } else if ($("#chkSurface2").is(":checked")) {
            chkValue = "2";
        }
        else if ($("#chkSurface3").is(":checked")) {
            chkValue = "3";
        }


        formData.append("SurfaceType", chkValue);
        formData.append("Action", "Add");
        formData.append("PID", PKID);




        var surfaceArray = [];
        var surfaceObj = {};

        i = 0;
        $('.tblSurfaceTable > tbody  > tr').each(function () {

            var row = $(this);

            if (row.find('.txtFile')[0].files.length > 0) {
            surfaceObj = {};
            surfaceObj.PID = PKID;
            surfaceObj.No = row.find('.txtItemNo').val();

            surfaceObj.Profile = row.find('.txtProfile').val();
      

            if (row.find('.txtItemNo').val() != "") {
                surfaceArray.push(surfaceObj);
            }

           

                if (row.find('.txtFile')[0].files.length > 0) {
                    formData.append('uploadFile_' + row.find('.txtItemNo').val(), row.find('.txtFile')[0].files[0]);
                }

                // formData.append('defectFile', $(row.find('.txtFile'))[0].files[0]);
            }
            i++;
        });


        formData.append('surfaceList', JSON.stringify(surfaceArray));


        var coatinInfoArray = [];
        var coatinInfoObj = {};
        i = 1;
        $('.tblCoatingInfoTable > tbody  > tr').each(function () {

            var row = $(this);

            coatinInfoObj = {};
            coatinInfoObj.PID = PKID;
            coatinInfoObj.No = i.toString();
            coatinInfoObj.PartA = row.find('.txtPartA').val();
            coatinInfoObj.PartB = row.find('.txtPartB').val();
            coatinInfoObj.Solvent = row.find('.txtSolvent').val();
            coatinInfoObj.Remark = row.find('.txtRemark').val();
            coatinInfoArray.push(coatinInfoObj);
            i++;

        });

        formData.append('coatingInfomationList', JSON.stringify(coatinInfoArray));





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


}

