var fileList1, fileList2;
var fileAll1, fileAll2;
var realFiles1 = [];
var realFiles2 = [];


var keepDeleteFiles1 = [];
var keepDeleteFileName1 = [];

var keepDeleteFiles2 = [];
var keepDeleteFileName2 = [];

var keepDeleteDefect = [];
var defectArray = [];

var orgRemark;

var widthAll = [180, 270, 0, 90];
var isValid = true;
var PKID = '';

var DefectList = null;
var WallThicknessList = null;
var WallThicknessLength = 0;
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



                $('.txtPH').val(obj.PH);
                $('.txtDefectNumber').val(obj.DefectNumber);
                $('.txtBrand').val(obj.Brand);
                $('.txtModel').val(obj.Model)
                $('.txtSN').val(obj.SN)
                $('.txtGuage').val(obj.Guage)
                $('.txtDegree').val(obj.Degree)
                $('.txtDegreeLength').val(obj.DegreeLength)


                DefectList = obj.DefectList;
                WallThicknessList = obj.WallThicknessList;
                RepairLength = obj.RepairLength;
                //  GeneratePointTable(obj.RepairLength);

                if (DefectList != null && DefectList.length > 0) {
                    $('.btnGenerate').addClass("invisible")
                    $('.txtDefectNumber').prop('disabled', true);


                }


                var repairLength = parseFloat(RepairLength);



                $('.lbRepairLengthCaption').text('Repair Length ' + parseFloat(repairLength) + ' (m)');

                $('.lbMaxLength').text(parseFloat(repairLength) + ' (m)');

                LoadConditionTable(obj.DefectNumber, DefectList);


                WallThicknessLength = ((WallThicknessList.length == 0) ? obj.WallThicknessNumber : WallThicknessList.length);
                LoadWallThicknessTable(obj.WallThicknessNumber, WallThicknessList, obj.MinClockPosition, obj.AvgClockPosition);

                Drawwalkness(WallThicknessLength, RepairLength);




                objSelectFiles = obj.UploadFileList;


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
                waitingDialog.show('Defect on bared pipe', { dialogSize: 'lg', progressType: 'primary' });

            }, 1000);



            setTimeout(function () {

                PreviewPoint();
                waitingDialog.hide();
            }, 2000);

        }

    });

}



function GeneratePointTable(RepairLength) {


    var tableStr = "";
    var tablePoint = $('.tblPointData');
    var width = 4;


    tablePoint.empty();

    var repairLength = RepairLength;



    if (repairLength <= 1) {
        repairLength = repairLength * 10;


    }

    repairLength = 10;

    tableStr += '<tbody>';
    for (row = 0; row < width; row++) {
        tableStr += '<tr>';

        for (col = 0; col < repairLength; col++) {

            if (col == 0) {
                tableStr += '<td style="width:87px" class="dropzone" val="' + widthAll[row] + '_' + col.toString() + '"></td>';
            } else {
                tableStr += '<td style="width:81px" class="dropzone" val="' + widthAll[row] + '_' + col.toString() + '"></td>';
            }
          //  tableStr += '<td   val="' + widthAll[row] + '_' + col.toString() + '"></td>';
        }

        tableStr += '</tr>';
    }

    tableStr += '</tbody>';
    ///Defect on bared pipe(m)
    //$('.lbRepairLengthCaption').val('Repair Length( ' + repairLength + ' m)');
    $('.lbRepairLengthCaption').text('Repair Length ' + parseFloat(RepairLength) + ' (m)');
    $('.lbMaxLength').text(parseFloat(RepairLength) + ' (m)');

    tablePoint.append(tableStr);


}
function EventControl() {




    $('.txtPH').IsNumeric();
    $('.txtDefectNumber').IsNumeric();
   // $('.txtBrand').IsNumeric();
 //   $('.txtModel').IsNumeric();
   // $('.txtSN').IsNumeric();

 //   $('.txtGuage').IsNumeric();

    $(".nav-tabs a").click(function () {
    

        window.location.href = this.href + '?Action=View&PID=' + PKID; ;

     
        return false;
    
    });


    $('.btnSave').on("click", function (e) {

        var defectMoveLast = false;

        var divDefect = $(".divDefectTable");
        var formData = new FormData();
        curStep = $(".tab-content");


        formData.append("txtPH", $('.txtPH').val());
        formData.append("txtDefectNumber", $('.txtDefectNumber').val());
        formData.append("txtBrand", $('.txtBrand').val());
        formData.append("txtModel", $('.txtModel').val());
        formData.append("txtSN", $('.txtSN').val());
        formData.append("txtGuage", $('.txtGuage').val());
        formData.append("txtDegree", $('.txtDegree').val());
        formData.append("txtDegreeLength", $('.txtDegreeLength').val());


       /* var $tableBody = $('.tblDefectTable').find("tbody"),
            $tableBody1 = $('.tblWallThickness').find("tbody"),*/



            var tableArry = [];
          var tableObj = {};

        var i = 0;
        $('.tblDefectTable > tbody  > tr').each(function () {

            var row = $(this);


            if (IsOverRepaireLength(row.find('.txtLength'))) {

                isValid = false;
                defectMoveLast = true;

                

            }

            tableObj = {};
            tableObj.PID = PKID;
            tableObj.ItemNo = row.find('.txtItemNo').val();
            tableObj.DefectTypeID = row.find('.ddlDefectType').val();
            tableObj.DegreePosition = row.find('.txtDegreePosition').val();
            tableObj.SizeW = row.find('.txtSizeW').val();
            tableObj.SizeL = row.find('.txtSizeL').val();
            tableObj.SizeD = row.find('.txtSizeD').val();
            tableObj.PipeDefect1 = row.find('.txtPipeDefect1').val();
            tableObj.PipeDefect2 = row.find('.txtPipeDefect2').val();
            tableObj.PipeDefect3 = row.find('.txtPipeDefect3').val();
            tableObj.PipeDefect4 = row.find('.txtPipeDefect4').val();
            tableObj.FromDistance = row.find('.ddlFromDistance').val();
            tableObj.Length = row.find('.txtLength').val();
            tableObj.RiskScore = row.find('.ddlRiskScore').val();
            tableObj.Remark = row.find('.txtRemark').val();
            tableObj.RepaireMethod = row.find('.txtRepaireMethod').val();

          
            //defectObj.File = row.find('.txtFile');
            
            if (row.find('.txtItemNo').val() != "") {
                tableArry.push(tableObj);
            }

            if (row.find('.txtFile') != null && row.find('.txtFile')[0]!=null) {

            if( row.find('.txtFile')[0].files.length>0)
            {
                formData.append('defectFile_' + row.find('.txtItemNo').val(), row.find('.txtFile')[0].files[0]);
                 }

              
            }
            i++;
        });


       

        formData.append('defectInputList', JSON.stringify(tableArry));


        tableArry = [];

        $('.tblWallThickness > tbody  > tr').each(function () {

            var row = $(this);


            tableObj = {};
            tableObj.PID = PKID;
            tableObj.ItemNo = row.attr('ItemNo');
            tableObj.PositionNo = row.find('.txtPositionNo').val();
            tableObj.ClockPosition0 = row.find('.txtClockPosition0').val();
            tableObj.ClockPosition90 = row.find('.txtClockPosition90').val();
            tableObj.ClockPosition135 = row.find('.txtClockPosition135').val();
            tableObj.ClockPosition180 = row.find('.txtClockPosition180').val();
            tableObj.ClockPosition225 = row.find('.txtClockPosition225').val();
            tableObj.ClockPosition270 = row.find('.txtClockPosition270').val();

            //defectObj.File = row.find('.txtFile');

            
                tableArry.push(tableObj);
        

           
        });


        if (isValid) {

        formData.append('wallThicknessInputList', JSON.stringify(tableArry));

        formData.append("Action", "Add");
        formData.append("PID", PKID);



        formData.append('DeleteDefectFiles', keepDeleteDefect.join(","));

        AddPointToCavas();

        var mycanvas = document.getElementById("mycanvas");
        var dataImg = mycanvas.toDataURL("image/png");

        dataImg = dataImg.replace("data:image/png;base64,", '');
        formData.append("DefectImgBase64", dataImg);




        mycanvas = document.getElementById("canvaswalkness");
        var dataImg = mycanvas.toDataURL("image/png");

        dataImg = dataImg.replace("data:image/png;base64,", '');


        formData.append("WallThicknessImgBase64", dataImg);

       

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
        else {

            if (defectMoveLast)
            {
                var divDefectTable = $('.divDefectTable');

                $('html, body').animate({
                    scrollTop: divDefectTable.offset().top
                }, 500);


                divDefectTable.delay(600).animate({
                    scrollLeft: '+=700px'
                }, 300);



            } else {

                $('html, body').animate({
                    scrollTop: $(".divDefectTable").offset().top
                }, 500);
            }


        }


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
   



    $(document).on('click', '.btnDelete', function (e) {



        var itemNo = $(this).closest('tr').attr('ItemNo');

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


                                                                        keepDeleteDefect.push(itemNo);
                                                                         var trClient= $('.tblWallThickness').find("tbody").find("tr[ItemNo="+itemNo+"]");

                                                                         $(this).closest('tr').remove();
                                                                         BAlert('Deleted', 'Delete data successfully!.');

                                                }
                                    },
                    close: function () {
                                        }
                            }
                    });
 

    });


    $(".btnNew").on("click", function (e) {

        var tableStr = "";
        var lastItem = 0;
        var $tableBody = $('.tblDefectTable').find("tbody"),
       // $tableBody1 = $('.tblWallThickness').find("tbody"),
        $trLast = $tableBody.find("tr:last"),
     //   $trLast1 = $tableBody1.find("tr:last"),
        $trNew = $trLast.clone();
        //, $trNew1 = $trLast1.clone();



        if ($trLast.length > 0) {
            lastItem = $trNew.find('.txtItemNo').val()
            lastItem = parseInt(lastItem) + 1;
            $trNew = $trLast.clone().find('input').val('').end(); ;
            $trNew.find('.txtFileName').text('')
            $trNew.find('.txtFileName').closest('td').empty().append('<input class="form-control   txtFile" type="file"/>')
            $trNew.find('.txtItemNo').val(lastItem)
            $trNew.attr('ItemNo', lastItem);
            $trLast.after($trNew);


            LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlRiskScore'), "M_RiskScore");
            LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlDefectType'), "M_PipeSurfaceType");
            LoadDropDownList($('.tblDefectTable > tbody  > tr:last').find('.ddlFromDistance'), "M_Degree");


           // $trNew1.attr('ItemNo', lastItem);

         //   $trNew1.find('.txtPositionNo').val(lastItem)
          //  $trLast1.after($trNew1);
        } else {

            LoadConditionTable(1, null);
        }









       




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
  


    $(".btnGenerate").on("click", function (e) {


        var row = $('.txtDefectNumber').val();

        LoadConditionTable(row, null);




        $('html, body').animate({
            scrollTop: $(".divDefectTable").offset().top
        }, 500);


        // divDefectTable
    });





}




function IsOverRepaireLength(objControl) {


   


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



function FindMinAndAVGValue(objList) {

    var maximumn = 0,
    tempMaximum = 0,
        tempMin = 0,
    avg = 0;

    $.each(objList, function (index, item) {

        if (tempMin == 0) {
            tempMin = parseFloat(item.ClockPosition0);
            
        }
        else if (parseFloat(item.ClockPosition0) < tempMin) {
            tempMin = parseFloat(item.ClockPosition0);
           
        }

        if (parseFloat(item.ClockPosition90) < tempMin) {
            tempMin = parseFloat(item.ClockPosition90);
            
        }


        if (parseFloat(item.ClockPosition135) < tempMin) {
            tempMin = parseFloat(item.ClockPosition135);
            
        }
        if (parseFloat(item.ClockPosition180) < tempMin) {
            tempMin = parseFloat(item.ClockPosition180);
            
        }

        if (parseFloat(item.ClockPosition225) < tempMin) {
            tempMin = parseFloat(item.ClockPosition225);
          
        }

        if (parseFloat(item.ClockPosition270) < tempMin) {
            tempMin = parseFloat(item.ClockPosition270);
           
        }

        avg += parseFloat(item.ClockPosition0);
        avg += parseFloat(item.ClockPosition90);
        avg += parseFloat(item.ClockPosition135);
        avg += parseFloat(item.ClockPosition180);
        avg += parseFloat(item.ClockPosition225);
        avg += parseFloat(item.ClockPosition270);

    });

    avg = avg / (6 * objList.length);

    $('.lbMinimum').text(tempMin.toFixed(2));
    $('.lbAverage').text(avg.toFixed(2));


}


function LoadWallThicknessTable(row, objList,minClockPosition,avgClockPosition) {
    var tableStr = "";


    $(".divWallThickness").empty();


    tableStr = "";

    tableStr += '<table class="table table-bordered table-blue tblWallThickness">';
    tableStr += '<thead>';
    tableStr += '<tr>';
    tableStr += '<th rowspan="2">Position No.</th>';
    tableStr += '<th colspan="6" class="text-center">Clock position</th>';

    tableStr += ' </tr>';
    tableStr += '<tr>';
    tableStr += '<th>0&deg;</th>';
    tableStr += '<th>90&deg;</th>';
    tableStr += '<th>135&deg;</th>';
    tableStr += '<th>180&deg;</th>';
    tableStr += '<th>225&deg;</th>';
    tableStr += '<th>270&deg;</th>';
    tableStr += '</tr>';
    tableStr += '</thead>';



    tableStr += '<tbody>';
  
    if (objList.length==0) {
        for (i = 0; i < row; i++) {
            tableStr += '<tr ItemNo="' + (i + 1) + '">';
            tableStr += '<td>' + '<input class="form-control  txtPositionNo" type="text" value="' + (i + 1) + '" disabled/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition0" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition90" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtClockPosition135" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtClockPosition180" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition225" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition270" type="text"/>' + '</td>';
            tableStr += '</tr>';
        }
    } else {

        $.each(objList, function (index, item) {

            tableStr += '<tr ItemNo="' + item.ItemNo + '">';
            tableStr += '<td>' + '<input class="form-control  txtPositionNo" type="text" value="' + item.PositionNo + '" disabled/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition0" type="text" value="' + item.ClockPosition0 + '" />' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition90" type="text" value="' + item.ClockPosition90 + '"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtClockPosition135" type="text" value="' + item.ClockPosition135 + '"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtClockPosition180" type="text" value="' + item.ClockPosition180 + '"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition225" type="text" value="' + item.ClockPosition225 + '"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtClockPosition270" type="text" value="' + item.ClockPosition270 + '"/>' + '</td>';
            tableStr += '</tr>';
    });
    
    
    }

    tableStr += '</tbody>';



    tableStr += '<tfoot>';
    tableStr += '<tr>';
    tableStr += '<th colspan="5"></th>';
    tableStr += '<th style="background:#bee5eb"><h5>Minimum(mm)</h5></th> ';
    tableStr += '<th style="background:#bee5eb"><h5 class="lbMinimum"></h5></th>';
    tableStr += '</tr>';
    tableStr += '<tr>';
    tableStr += '<th colspan="5"></th>';
    tableStr += '<th style="background:#bee5eb"><h5>Average(mm)</h5></th>';
    tableStr += '<th style="background:#bee5eb"><h5 class="lbAverage"></h5></th> ';
    tableStr += '</tr>';
    tableStr += '</tfoot>';
    tableStr += '</table>';




    $(".divWallThickness").append(tableStr);
    $('.lbMinimum').text(minClockPosition);
    $('.lbAverage').text(avgClockPosition);

   // FindMinAndAVGValue(objList)


    $('.txtPositionNo').IsNumeric();
    $('.txtClockPosition0').IsNumeric();
    $('.txtClockPosition90').IsNumeric();
    $('.txtClockPosition135').IsNumeric();
    $('.txtClockPosition180').IsNumeric();
    $('.txtClockPosition225').IsNumeric();
    $('.txtClockPosition270').IsNumeric();
}

function LoadConditionTable(row, DefectList) {
    var tableStr = "";



    $(".divDefectTable").empty();

    tableStr += '<table class="table table-bordered table-blue tblDefectTable" style="width:2500px;">';
    tableStr += '<thead>';
    tableStr += '<tr>';
 //   tableStr += '<th rowspan="2">Delete</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Item</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Defect Type</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Degree Position  (&deg;)</th>';
    tableStr += '<th colspan="3" class="align-middle text-center">Size(cm.)</th>';
    tableStr += '<th colspan="4" class="align-middle text-center">Pipe Thk. around defect(mm.)</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Distance From <br>US</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Risk Score</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Repair Method</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Remark</th>';
    tableStr += '<th rowspan="2" class="align-middle text-center">Files</th>';
    tableStr += '</tr>';
    tableStr += '<tr>';
    tableStr += '<th class="text-center">W</th>';
    tableStr += '<th class="text-center">L</th>';
    tableStr += '<th class="text-center">D</th>';
    tableStr += '<th class="text-center">1</th>';
    tableStr += '<th class="text-center">2</th>';
    tableStr += '<th class="text-center">3</th>';
    tableStr += '<th class="text-center">4</th>';
  //  tableStr += '<th>From</th>';
  //  tableStr += '<th>Length(cm.)</th>';
    tableStr += '</tr>';


    tableStr += '</thead>';
    tableStr += '<tbody>';


    if (DefectList == null) {
        for (i = 0; i < row; i++) {
            tableStr += '<tr ItemNo="' + (i + 1) + '">';
         //   tableStr += '<td>' + '<i class="btn fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
            tableStr += '<td>' + '<input class="form-control  txtItemNo" type="text" value="' + (i + 1) + '" disabled/>' + '</td>';
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDefectType"></select>' + '</td>';
            tableStr += '<td style="width:150px;">' + '<select class="form-control   txtDegreePosition" ></select>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtSizeW" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtSizeL" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtSizeD" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect1" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect2" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect3" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect4" type="text"/>' + '</td>';
          //  tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlFromDistance"></select>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtLength" type="text"/>' + '</td>';
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlRiskScore"></select>' + '</td>';
            tableStr += '<td style="width:150px;">' + '<select class="form-control   txtRepaireMethod"></select>' + '</td>';

            tableStr += '<td>' + '<input class="form-control   txtRemark" type="text"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtFile" type="file"/>' + '</td>';
            tableStr += '</tr>';
        }


       
    } else {


        $.each(DefectList, function (index, item) {



            tableStr += '<tr ItemNo="' + (i + 1) + '">';
         //   tableStr += '<td>' + '<i class="btn fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
            tableStr += '<td>' + '<input class="form-control  txtItemNo" type="text" value="' + item.ItemNo + '"  disabled/>' + '</td>';
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlDefectType"></select>' + '</td>';
            tableStr += '<td style="width:150px;">' + '<select class="form-control   txtDegreePosition" ></select>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtSizeW" type="text" value="' + item.SizeW + '" />' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtSizeL" type="text" value="' + item.SizeL + '"/>' + '</td>';
            tableStr += '<td>' + '<input  class="form-control   txtSizeD" type="text" value="' + item.SizeD + '" />' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect1" type="text" value="' + item.PipeDefect1 + '"  />' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect2" type="text" value="' + item.PipeDefect2 + '"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect3" type="text" value="' + item.PipeDefect3 + '"/>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtPipeDefect4" type="text" value="' + item.PipeDefect4 + '"/>' + '</td>';
         //   tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlFromDistance"></select>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtLength" type="text"  value="' + item.Length + '"/>' + '</td>';
            tableStr += '<td  style="width:150px;">' + '<select  class="form-control   ddlRiskScore"></select>' + '</td>';
          //  tableStr += '<td>' + '<input class="form-control   txtRepaireMethod" type="text" value="' + item.RepaireMethod + '" />' + '</td>';
          //  tableStr += '<td>' + '<input class="form-control   txtRepaireMethod" type="text" value="' + item.RepaireMethod + '" />' + '</td>';
            tableStr += '<td style="width:150px;">' + '<select class="form-control   txtRepaireMethod"></select>' + '</td>';
            tableStr += '<td>' + '<input class="form-control   txtRemark" type="text" value="' + item.Remark + '"/>' + '</td>';
            if (item.FileName != null && item.FileName != "") {

                tableStr += "<td>" + "<label class=\"txtFileName filename\" style=\"cursor:pointer;\" data-toggle=\"popover\"" +
            " data-content='<image src=\"" + item.HtmlFile + "\"></image>' >" + item.FileName.substring(0,5)+'..' + " </label>" +
            "<i class=\"fa fa-2x fa-times btn btnDeleteFile\" style=\"color:red\"></i> <input class=\"form-control   txtFile success\"  style=\"display:none\" type=\"file\" />" + "</td>";

                
            } else {

                tableStr += '<td>' + ' <input class="form-control   txtFile success" type="file" />';


            }
            tableStr += '</tr>';


    });
    
    
    }

    tableStr += '</tbody>';
    tableStr += '</table>';


    $(".divDefectTable").append(tableStr);

    $('.txtDegreePosition').IsNumeric();
    $('.txtSizeW').IsNumeric();
    $('.txtSizeL').IsNumeric();
    $('.txtSizeD').IsNumeric();
    $('.txtPipeDefect1').IsNumeric();
    $('.txtPipeDefect2').IsNumeric();
    $('.txtPipeDefect3').IsNumeric();
    $('.txtPipeDefect4').IsNumeric();
    $('.txtLength').IsNumeric();
//    $('.txtRepaireMethod').IsNumeric();


    LoadPopover();
 
    



    /*$($(".ddlDefectType")).append("<option value='0'>Crack</option>");
    $($(".ddlDefectType")).append("<option value='1'>Pine hole</option>");
    $($(".ddlDefectType")).append("<option value='2'>Blister</option>");
    $($(".ddlDefectType")).append("<option value='3'>Chalk</option>");
    $($(".ddlDefectType")).append("<option value='4'>Discoloration</option>");
    $($(".ddlDefectType")).append("<option value='5'>Gouge</option>");



    $($(".ddlRiskScore")).append("<option value=''>กรุณาเลือก</option>");
    $($(".ddlRiskScore")).append("<option value='1'>1</option>");
    $($(".ddlRiskScore")).append("<option value='2'>2</option>");
    $($(".ddlRiskScore")).append("<option value='3'>3</option>");
    $($(".ddlRiskScore")).append("<option value='4'>4</option>");
    $($(".ddlRiskScore")).append("<option value='5'>5</option>");*/






    if (DefectList != null) {

        var i = 0;
        $('.tblDefectTable > tbody  > tr').each(function () {

            var row = $(this);

            LoadWidth(row.find('.txtDegreePosition'), DefectList[i].DegreePosition);
            LoadDropDownList(row.find('.ddlRiskScore'), "M_RiskScore", DefectList[i].RiskScore);
            LoadDropDownList(row.find('.ddlDefectType'), "M_PipeSurfaceType", DefectList[i].DefectTypeID);
            LoadDropDownList(row.find('.ddlFromDistance'), "M_Degree", DefectList[i].FromDistance);
            LoadDropDownList(row.find('.txtRepaireMethod'), "M_RepaireType", DefectList[i].RepaireMethod);
            i++;

        });



    } else {

        LoadWidth($('.txtDegreePosition'));
        LoadDropDownList($('.ddlRiskScore'), "M_RiskScore");
        LoadDropDownList($('.ddlDefectType'), "M_PipeSurfaceType");
        LoadDropDownList($('.ddlFromDistance'), "M_Degree");
        LoadDropDownList($('.txtRepaireMethod'), "M_RepaireType");
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
                                    "<td class='filename'>" + file.FileName + "</td>" +
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
                                    "<td class='filename'>" + file.FileName + "</td>" +
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
