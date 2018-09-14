$(document).ready(function () {



    InitialPage();
    LoadEvent();
    LoadSave();
    LoadDropdownlist();
    Search();
});


function LoadSave() {

    $('.btnSave').click(function () {
        var curStep = $(".setup-content");

        var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],select");
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

        formData.append("MENU_OID", $(".hddID").val());
        formData.append("ROW_STATE", $("input[name=chkStatus]").is(":checked") ? '1' : '0');
        formData.append("Icon", $('.divshowIcon').find("i:first").attr('data'));
        formData.append("Position", $("input[name=chkPosition]:checked").val());

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

                                    formData = null;
                                    Search();
                                    LoadDropdownlist();
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
}

function InitialPage() {
    $('.btnAdd').on('click', function (e) {
        var $item = $(this).closest("tr");
        LoadPopup(null);
    });

    $('.bthSearch').on('click', function (e) {
        Search();
    });

    $('.chkStatus').bootstrapToggle()

    $('[data-toggle="popover"]').popover({
        html: true,
        title: "Select Icon",
        content: function () {
            return $('.divIcon').html();
        }
    });


    $(document).on('click', '.fontawesome-icon-list .fa-hover', function (event) {

        var $item = $(this).find("i:first");

        $('.divshowIcon').html('<i class="' + $item.attr('data') + ' fa-2x " style="color:#007bff" aria-hidden="true" data="' + $item.attr('data') + '"></i>');
        //  alert($item.attr('data'))
    });

}

function LoadEvent() {
    $('.table>tbody>tr > btnEdit').on('click', function (e) {
        var $item = $(this).closest("tr");
      //  alert($item.data)
        // $(".modalpopup").modal()

    });


    $(document).on('click', ".divMainTable .btnEdit", function (event) {
        var $item = $(this).closest("tr");
        LoadPopup($item.attr('data'))


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



                        formData.append("MENU_OID", $item.attr('data'));

                        formData.append("Action", "Delete");

                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {

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






  


}

function ClearControl() {
    $(".hddID").val('');
    $('.chkStatus').bootstrapToggle("on")
    $(".txtPageName").val('');
    $(".txtScreen").val('');
    $(".txtLink").val('');
    $(".txtDesc").val('');
    $(".txtOrderNo").val('');
    
    $("input[name=chkStatus][value=L]").prop('checked', true);
    $(".divshowIcon").empty();
    $(".divshowIcon").html('<button type="button" class="btn  btn-primary" style="">Icon</button>'); 
}


function LoadPopup(id) {

    var html = '';
    var formData = new FormData();

    ClearControl();

    
    if (id != null && id != '') {
        formData.append("Action", "Search");
        formData.append("MENU_OID", id);

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

        LoadDropdownlist();
        $(".modalpopup").modal()

    }

}



function SetControl(item) {

   
    $(".hddID").val(item.MENU_OID);
    LoadDropdownlist(item.MENUGROUP_OID);

   
    $("input[name=chkPosition][value=" + item.Position + "]").prop('checked', true);

    $('.chkStatus').bootstrapToggle((item.ROW_STATE == "1" ? "on" : "off"))
    $(".txtPageName").val(item.Name);
    $(".txtScreen").val(item.SCREEN);
    $(".txtLink").val(item.LINK);
    $(".txtDesc").val(item.DESC);
    $(".txtOrderNo").val(item.OrderNo);
    $(".divshowIcon").empty();

 //   alert(item.Icon)
    if (item.Icon == "") {
        $(".divshowIcon").html('<button type="button" class="btn  btn-primary" style="">Icon</button>');
    } else {
        $('.divshowIcon').html('<i class="' + item.Icon + ' fa-2x " style="color:#007bff" aria-hidden="true" data="' + item.Icon + '"></i>');
     }
    
}

function LoadDropdownlist(selectMenuGroupID) { 


var html = '';
    var formData = new FormData();
    formData.append("Action", "loadMemuGroup");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)


          
            $('.selectMENUGROUPSearch').empty().append('<option value="">เลือก</option>');
            $.each(obj, function (key, item) {

               
                $('.selectMENUGROUPSearch').append("<option value='" + item.MENU_OID + "'>" + item.Name + "</option>");


            });

            obj = $.grep(obj, function (element, index) {
               
                return (element.MENU_OID != $(".hddID").val());
            });

            $('.selectMENUGROUP').empty().append('<option value="">เลือก</option>');
           
               $.each(obj, function (key, item) {
                   $('.selectMENUGROUP').append("<option value='" + item.MENU_OID + "' " + ((selectMenuGroupID == item.MENU_OID ? "selected" : "")) + ">" + item.Name + "</option>");

                
               });

         }
          });
         
}



function Search() {

    var html = '';

    var selectMenuGroup = $('.selectMENUGROUPSearch').val() != null ? $('.selectMENUGROUPSearch').val() : "";
    //alert(selectMenuGroup)
    
    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("Name", $(".txtNameSearch").val());
    formData.append("MENUGROUP_OID", selectMenuGroup);
    formData.append("Position", $("input[name=chkPositionSearch]:checked").val());

    waitingDialog.show('LOADING', { dialogSize: 'lg', progressType: 'primary' }); 
    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {



            var obj = JSON.parse(result)
            $('.divMainTable').empty();

            html += '';
            html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
            html += '<thead>';
            html += '<tr>';
            html += '<th>Edit</th>';
            html += '<th>Delete</th>';
            html += '<th>Name</th>';
             html += '<th>Group Name</th>';
             html += '<th>Icon</th>';
              html += '<th>Screen</th>';
              html += '<th>Link</th>';
              html += '<th>Order</th>';
              html += '<th>Position</th>';
              html += '<th>Status</th>';
            
            html += '</tr>';
            html += '</thead>';
            html += '<tfoot>';
            html += '<tr>';
            html += '<th>Edit</th>';
            html += '<th>Deletet</th>';
            html += '<th>Name</th>';
             html += '<th>Group Name</th>';
            html += '<th>Icon</th>';
            html += '<th>Screen</th>';
            html += '<th>Link</th>';
            html += '<th>Order</th>';
            html += '<th>Position</th>';
            html += '<th>Status</th>';
           
            html += '</tr>';
            html += '</tfoot>';

            html += '<tbody>';

            $.each(obj, function (key, item) {



                html += '<tr class="TRow" data="' + item.MENU_OID + '">';
                html += '<td class="text-center">' + '<i class="fa fa-2x fa-pencil-square btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>' + '</td>';
                html += '<td class="text-center">' + '<i class="fa fa-2x fa-times btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.MENUGROUPName + '</td>';
                html += '<td><i class="' + item.Icon + ' fa-2x" style=" color:#2c97e9"></i></td>';
                html += '<td>' + item.SCREEN + '</td>';
                html += '<td>' + item.LINK + '</td>';
                html += '<td>' + item.OrderNo + '</td>';
                html += '<td>' + item.Position + '</td>';
                html += '<td class="text-center">' + (item.ROW_STATE == '1' ? '<i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i>'
                                                     : '<i class="fa fa-battery-empty fa-2x" aria-hidden="true" style=" color:red"></i>') + '</td>';
             
                html += '</tr>';
            });
            html += '</tbody>';
            html += '</table>';

            $('.divMainTable').append(html);
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });
            setTimeout(function () { waitingDialog.hide(); }, 500);


           // LoadEvent();

        },
        error: function (err) {
            alert(err.statusText)
            setTimeout(function () { waitingDialog.hide(); }, 1000);
        }
    });

}
