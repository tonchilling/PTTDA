﻿
$(document).ready(function () {



    Search();
    InitialPage();


});


function ClearControl() {

    ID = "";
   
    $(".txtMAOPCode").val('');
    $(".txtName").val('');
    $("input[name=rdActive]").prop('checked', true);
    $("input[name=chkStatus][value=1]").prop('checked', true);
}


function SetControl(item) {






    ID = item.MAOPID;

    
   
    $(".txtMAOPCode").val(item.MAOPCode);
    $(".txtName").val(item.Name);
    $("input[name=chkStatus][value=" + item.Status + "]").prop('checked', true);
   

}


function InitialPage() {


   
    LoadEvent();
}




function Search() {

    var html = '';

    var IsSave = "0";

    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("MAOPCode", $(".txtMAOPCodeSearch").val());
    formData.append("Name", $(".txtMAOPNameSearch").val());
    formData.append("Status", $("input[name=chkStatusSearch]:checked").val());
    // formData.append("MENUGROUP_OID", selectMenuGroup);

    $('.divMainTable').empty();

    html += '';
    html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
    html += '<thead>';
    html += '<tr>';
    html += '<th>EDIT</th>';
    html += '<th>DELETE</th>';
    html += '<th>Code</th>';
    html += '<th>Name</th>';

    html += '<th>Status</th>';
    html += '<th>Update Date</th>';
    html += '</tr>';
    html += '</thead>';
    html += '<tfoot>';
    html += '<tr>';
    html += '<th>EDIT</th>';
    html += '<th>DELETE</th>';
    html += '<th>Code</th>';
    html += '<th>Name</th>';

    html += '<th>Status</th>';
    html += '<th>Update Date</th>';
    html += '</tr>';
    html += '</tfoot>';

    html += '<tbody>';
    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {



            var obj = JSON.parse(result)
           

            $.each(obj, function (key, item) {

                IsSave = item.IsSave;

                html += '<tr class="TRow" data="' + item.MAOPID + '">';
                html += '<td style="width:5%" class="text-center">' + (item.IsSave == '1' ? '<i class="fa fa-2x fa-pencil-square btn btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>' : "") + '</td>';
                html += '<td  style="width:5%" class="text-center">' + (item.IsSave == '1' ? '<i class="fa fa-2x fa-times btn btnDelete" aria-hidden="true" style=" color:red"></i>' : "") + '</td>';
                html += '<td>' + item.MAOPCode + '</td>';
                html += '<td>' + item.Name + '</td>';
          

                html += '<td class="text-center">' + (item.Status == '1' ? '<input   class="chkStatusView"  disabled   checked type="checkbox" data-toggle="toggle"   data-size="small">'
                : '<input  class="chkStatusView"   type="checkbox" data-toggle="toggle" disabled    data-size="small">') + '</td>';

                html += '<td>' + item.UpdateDate + '</td>';
             
                html += '</tr>';
            });
            html += '</tbody>';
            html += '</table>';

            $('.divMainTable').append(html);
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });


            if (IsSave != "1") {

                $('.btnAdd').invisible();
            }


            //$('.chkStatusView').bootstrapToggle()
          

          //  event.stopPropagation();
        },
        error: function (err) {
           
           alert(err)
        }
    });

}

function LoadEvent() {



    $('.btnAdd').on('click', function (e) {

        ClearControl();
        $(".modalpopup").modal();

    });



    $('.btnSave').on('click', function (event) {

        // alert(ID)


        var curStep = $(".setup-content");

        var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select");
        var isValid = true;
        var formData = new FormData();



        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            } else {


                formData.append(curInputs[i].id, curInputs[i].value);
            }
        }


      //  alert($("input[name=chkStatus]:checked").val())
        formData.append("MAOPID", ID);
        formData.append("Status", $("input[name=chkStatus]:checked").val());
        formData.append("Action", "Add");


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
                                    Search();
                                    // LoadDropdownlist();
                                    $(".modalpopup").modal('hide');
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




    $(document).on('click', ".divMainTable .btnEdit", function (event) {
        var $item = $(this).closest("tr");

    
        LoadPopup($item.attr('data'))

      //  event.preventDefault();
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



                        formData.append("MAOPID", $item.attr('data'));

                        formData.append("Action", "Delete");

                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {


                                BAlert('Deleted','Delete data successfully!.');

                                formData = null;
                                Search();
                                $(".modalpopup").modal('hide');
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



        $('.bthSearch').on('click', function (e) {
       
            Search();
        });



     //   event.preventDefault();
 

}


function LoadPopup(id) {

    var html = '';
    var formData = new FormData();

    ClearControl();


    if (id != null && id != '') {
        formData.append("Action", "Search");
        formData.append("MAOPID", id);

        $.ajax({
            url: currentURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {



                var obj = JSON.parse(result);

                $.each(obj, function (key, item) {
                    SetControl(item);

                });

                $(".modalpopup").modal();
            }
        });
    }
    else {

     //   LoadDropdownlist();
        $(".modalpopup").modal()

    }

}
