
var isValid = true;
var PKPID = '';
var ID = '';


$(document).ready(function () {



    EventControl();
    InitialData();


});


function InitialData() {
    PKPID = getParameterByName('PID');


    $('.myModal1').on('shown.bs.modal', function () {

        var anim = 'zoomIn';
           //     ModalAnim(anim);

       $('.datetimepicker').datepicker({
    format: "dd/mm/yyyy hh:mm:ss",
    todayBtn: "linked",
    autoclose: true,
    todayHighlight: true,
    container: '.myModal1 modal-body'
  });

});


LoadHour($('.ddlCollectHour'));
LoadMinute($('.ddlCollectMinute'));

    LoadData(PKPID);

}


function LoadHour(control) {

    for (var i = 0; i <= 23; i++) {
        control.append("<option value='"+i+"'>"+i+"</option>");
    }
}

function LoadMinute(control) {

    for (var i = 0; i <= 59; i++) {
        control.append("<option value='" + i + "'>" + i + "</option>");
    }
}


function LoadData(PID) {

    var progress = "";
    var html = "";

  
    var formData = new FormData();
    formData.append("Action", "Search");
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

                /*   public string ID  { get; set; }
                public string PID { get; set; }   
                public string No  { get; set; }   
                public string CollectDate  { get; set; }   
                public string WetTemp  { get; set; }   
                public string DryTemp  { get; set; }   
                public string SteelSurfaceTemp  { get; set; }   
                public string DewPoint  { get; set; }
                public string RelativeHumidity { get; set; }   
                */

                LoadTable(obj);


                if (obj != null && obj.length > 0) {
                    if (obj[0].IsSave == '0') {

                        DisableAll();
                        $(".btn").invisible();
                    }
                }





            } else {

                $('.datetimepicker').datepicker()

            }

        }

    });

}


function LoadPopup(id) {

    var html = '';
    var formData = new FormData();

    ClearControl();


    if (id != null && id != '') {

        ID = id;
        formData.append("Action", "View");
        formData.append("KPID", PKPID);
         formData.append("ID", id);


        $.ajax({
            url: currentURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {



                var obj = JSON.parse(result);

                SetControl(obj);

                $(".myModal1").modal();
            }
        });
    }
    else {

     //   LoadDropdownlist();
        $(".myModal1").modal()

    }

}


function SetControl(item) {


    $('.txtCollectDate').val(item.CollectDate);
    $('.ddlCollectHour').val(item.CollectHour);
    $('.ddlCollectMinute').val(item.CollectMinute);
    $('.txtWetTemp').val(item.WetTemp);
    $('.txtDryTemp').val(item.DryTemp);
    $('.txtSteelSurfaceTemp').val(item.SteelSurfaceTemp);
    $('.txtDewPoint').val(item.DewPoint);
    $('.txtRelativeHumidity').val(item.RelativeHumidity);
}




function ClearControl() {

    $('.datetimepicker').datepicker();
    $('.txtCollectDate').val('');
    $('.ddlCollectHour').val(0);
    $('.ddlCollectMinute').val(0);
    $('.txtWetTemp').val('');
    $('.txtDryTemp').val('');
    $('.txtSteelSurfaceTemp').val('');
    $('.txtDewPoint').val('');
    $('.txtRelativeHumidity').val('');
    ID = "";
}



function EventControl() {

    $('.txtWetTemp').IsNumeric();
    $('.txtDryTemp').IsNumeric();
    $('.txtSteelSurfaceTemp').IsNumeric();
    $('.txtDewPoint').IsNumeric();
    $('.txtRelativeHumidity').IsNumeric();

    $(".nav-tabs a").click(function () {


        window.location.href = this.href + '?Action=View&PID=' + PKPID; ;


        return false;

    });



    $('.imgWeather').on("click", function (e) {

        window.open("WeatherColllectionPopup.aspx", "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=500,left=500,width=400,height=400");

    });

    $('.btnAdd').on("click", function (e) {

        ClearControl();
        $(".myModal1").modal();

    });

    $(document).on('click', ".divMainTable .btnEdit", function (event) {
        var $item = $(this).closest("tr");

       
        LoadPopup($item.attr('data'))

        //  event.preventDefault();
    });



    $('.btnSave').on("click", function (e) {



        var formData = new FormData();
        curStep = $(".setup-content");
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
        formData.append("PID", PKPID);
        formData.append("ID", ID);






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
                                    LoadData(PKPID);
                                    //  LoadTable2();
                                    //  var obj = JSON.parse(result)
                                    $(".myModal1").modal('hide');
                                    //   $(".myPlanSpectPO").modal('hide');
                                    ClearControl();

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




    $(document).on('click', ".divMainTable .btnDelete", function (event) {


        var $item = $(this).closest("tr");
        // LoadPopup($item.attr('data'))
        var formData = new FormData();


        $.confirm({
            icon: 'fa fa-warning',
            title: 'Confirm',
            content: 'Do you want to Delete?',
            type: 'red',
            animation: "RotateX",
            typeAnimated: true,
            buttons: {
                tryAgain: {
                    text: 'Confrim',
                    btnClass: 'btn-red',
                    action: function () {


                        formData.append("ID", $item.attr('data'));
                        

                        formData.append("Action", "Delete");

                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {


                                BAlert('Deleted', 'Delete data successfully!.');

                                formData = null;
                                LoadData(PKPID);
                              //  Search();
                              //  $(".modalpopup").modal('hide');
                                ClearControl();

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




}







function LoadTable(objectList) {

    var divMain;
    var tableName;
    var html = '';

    tableName = '.divMainTable';


    $(tableName).empty();

    html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';


    html += '';

    html += '<thead>';
    html += '<tr>';
    html += '<th>No</th>';
    html += '<th>Date Time</th>';
    html += '<th>Wet Temp( &#8451; )</th>';
    html += '<th>Dry Temp( &#8451; )</th>';
    html += '<th>Steel Surface Temp( &#8451; )</th>';
    html += '<th>Dew Point( &#8451; )</th>';
    html += '<th>Relative Humidity(%)</th>';
    html += '<th>EDIT</th>';
    html += '<th>DELETE</th>';
    html += '</tr>';

    html += '</thead>';


    html += '<tbody>';

    $.each(objectList, function (key, item) {


        html += '<tr class="TRow" data="' + item.ID + '">';

        html += '<td>' + item.No + '</td>';
        html += '<td>' + item.CollectDate + '  ' + ("0" + item.CollectHour).slice(-2) +':' +  ("0" + item.CollectMinute).slice(-2) + '</td>';
        html += '<td>' + item.WetTemp + '</td>';
        html += '<td>' + item.DryTemp + '</td>';
        html += '<td>' + item.SteelSurfaceTemp + '</td>';
        html += '<td>' + item.DewPoint + '</td>';
        html += '<td>' + item.RelativeHumidity + '</td>';

        html += '<td style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-pencil-square btn btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>' + '</td>';
        html += '<td  style="width:5%" class="text-center">' + '<i class="fa fa-2x fa-times btn btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
        html += '</tr>';
    });


    $(tableName).append(html);
  


}


