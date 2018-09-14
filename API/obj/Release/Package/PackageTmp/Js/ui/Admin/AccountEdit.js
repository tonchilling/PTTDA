


    var UserID = "";

    var SetDefaultUserGroup = "";



    $(document).ready(function () {
        InitialData();
        LoadRequest();
        // LoadEvent();


        $('#my_tooltip').popup({
            type: 'tooltip',
            vertical: 'top',
            transition: '0.3s all 0.1s',
            tooltipanchor: $('.btnSearch')
        });



        $(".btnSearch").click(function () {

            $('#my_tooltip').popup('toggle');

        });



        $(".btnSearchPopup").click(function () {


            SearchPTTUser();

        });






        $(".chkRegionAll").click(function () {
            if ($(".chkRegionAll").is(':checked')) {
                $(".txtRegion > option").prop("selected", "selected");
                $(".txtRegion").trigger("change");
            } else {



                $('.txtRegion').val('').trigger("change");

            }
        });




        $(".chkAssertOwerAll").click(function () {
            if ($(".chkAssertOwerAll").is(':checked')) {
                $(".txtAssertOwner > option").prop("selected", "selected");
                $(".txtAssertOwner").trigger("change");
            } else {



                $('.txtAssertOwner').val('').trigger("change");

            }
        });

        $('.btnSetDefault').on('click', function (e) {

            var formData = new FormData();
            var isValid = true;


            formData.append("Action", "SetUserGroup");
            if ($(".UserGroup1").is(':checked')) {
                SetDefaultUserGroup = "1";
            } else if ($(".UserGroup2").is(':checked')) {
                SetDefaultUserGroup = "2";
            }
            formData.append("UserID", UserID);
            formData.append("UserGroupID", SetDefaultUserGroup);

            if (isValid) {

                $.confirm({
                    icon: 'fa fa-warning',
                    title: 'Confirm',
                    content: 'Do you want to SetDefault?',
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
                                        // Search();
                                        //  $(".modalpopup").modal('hide');
                                        //   ClearControl();
                                        //  window.location.href = accountList;
                                        BAlert('Set Default', 'Save data successfully!.');
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



            // alert($(".txtRegion").val());
        });


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




            formData.append("userStatus", $("input[name=chkStatus]").is(":checked") ? '1' : '0');
            formData.append("userType", $("input[name=rdUserType]:checked").val());

            formData.append("userRegion", $(".txtRegion").val());
            formData.append("AssertOwner", $(".txtAssertOwner").val());
            // formData.append("userRegion", $("input[name=rdGroupRegion]:checked").map(function () { return this.value; }).get());
            formData.append("userPlan", $("input[name=rdGroupPlan]:checked").map(function () { return this.value; }).get());

            formData.append("UserRoleID", $('.selectUserRole').val())


            formData.append("UserID", UserID);


            if ($(".UserGroup1").is(':checked')) {
                formData.append("UserGroupID", "1");
            } else if ($(".UserGroup2").is(':checked')) {
                formData.append("UserGroupID", "2");
            }

            formData.append("SetDefaultUserGroup", SetDefaultUserGroup)

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
                                        // Search();
                                        //  $(".modalpopup").modal('hide');
                                        ClearControl();
                                        window.location.href = accountList;

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



        $('.btnCancel').click(function () {

            window.location.href = accountList;
        });



    });

    function InitialData() {

      
        $('.btnSearch').invisible();
     //   LoadAssertOwner();

     //   LoadRegion();




    }

    function LoadAssertOwner(desireAssertOwner) {
        var form = $('form:first'); // You need to use standard javascript object here
        var formData = new FormData(form);
        formData.append("Action","LoadSelect2");
        $.ajax({
            url: assertOwnerURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

                if (result != "") {
                    var obj = JSON.parse(result);
               $(".txtAssertOwner").select2({
            tags: true,
            data: obj,
            width: '100%'
        });




        $(".txtAssertOwner").val(desireAssertOwner).trigger('change');
     


                }
               

            },
            error: function (err) {
                alert(err.statusText)
            }
        });

    }



    function LoadDepartment(selectValue) {
        var form = $('form:first'); // You need to use standard javascript object here
        var formData = new FormData(form);
        formData.append("DropDrownType", "LoadSelect2");
        formData.append("TableName", "M_Department");
        $.ajax({
            url: DropDownListURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

                if (result != "") {
                    var obj = JSON.parse(result);
                    $(".selectDepartment").select2({
                        tags: true,
                        data: obj,
                        width: '100%'
                    });




                    $(".selectDepartment").val(selectValue).trigger('change');



                }


            },
            error: function (err) {
                alert(err.statusText)
            }
        });

    }

    function LoadRegion(desireRegion) {
        var form = $('form:first'); // You need to use standard javascript object here
        var formData = new FormData(form);
        formData.append("Action", "LoadSelect2");
        $.ajax({
            url: regionURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

                if (result != "") {
                    var obj = JSON.parse(result);
                    $(".txtRegion").select2({
                        tags: true,
                        data: obj,
                        width: '100%'
                    });

                    
                    $(".txtRegion").val(desireRegion).trigger('change');

                }


            },
            error: function (err) {
                alert(err.statusText)
            }
        });

    }


function LoadRequest() {

    var form = $('form:first'); // You need to use standard javascript object here
    var formData = new FormData(form);

    var action = getParameterByName('Action');
    UserID = getParameterByName('ID');
    if (action == 'VIEW')

        $('.txtUserLogin').disabled();
    $('.btnSearch').invisible();

        formData.append("Action", action);
    formData.append("UserID", UserID);
    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {


            ClearControl();

            if (result != "") {
                var obj = JSON.parse(result);

                $.each(obj, function (key, item) {
                    SetControl(item);



                   // LoadDropDownList($('.selectPositionPSI'), 'M_PositionPSI', item.PositionPSI);
                    LoadDropDownList($('.selectPosition'), 'M_Position', item.Position);

               //     LoadDropDownList($('.selectDepartment'), 'M_Department', item.Department);


                    if ($('.rdUserType').val() != '3') {
                        $('.txtFirstName').disabled();
                        $('.txtLastName').disabled();
                        $('.txtEmail').disabled();
                        $('.txtExt').disabled();

                      
                    }

                    $(".btnSearchPopup").invisible();
                });


            } else {

             

             //   LoadDropDownList($('.selectPositionPSI'), 'M_PositionPSI');

                LoadDropDownList($('.selectPosition'), 'M_Position');


                LoadDepartment('');
               // LoadDropDownList($('.selectDepartment'), 'M_Department');

                LoadAssertOwner('');

                LoadRegion('');
            }

            $('.txtPositionPSI').disabled();
            $('.selectDepartment').disabled();

            setTimeout(function () { waitingDialog.hide(); }, 1000);

        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}


function LoadEvent() {
    $('.table>tbody>tr > btnEdit').on('click', function (e) {
        var $item = $(this).closest("tr");
     
       // $(".modal").modal()

    });


    $('.btnEdit').on('click', function (e) {
        var $item = $(this).closest("tr");
      //  LoadPopup($item.attr('data'))
        window.location.href = accountEdit;

    });

    $('.btnAdd').on('click', function (e) {
        var $item = $(this).closest("tr");



      //  LoadPopup(null)

        window.location.href = accountEdit;


    });


 

    




    

    $('.chkStatus').bootstrapToggle()
    $('.chkStatusView').bootstrapToggle()


}

$(document).on('click', '.rdUserType', function (e) {

    if ($(this).val() == '3') {
        $('.txtCompanyName').val('');
        $('.btnSearch').visible();
        $('.txtFirstName').enabled();
        $('.txtLastName').enabled();
        $('.txtEmail').enabled();
        $('.txtExt').enabled();
        $('.txtPassword').enabled();
      
        $('.btnSearch').invisible();

        $('.txtPositionPSI').disabled();
        $('.selectDepartment').disabled();

      
    }
    else if ($(this).val() == '2') {
        $('.txtCompanyName').val('');
        $('.btnSearch').visible();
        $('.txtFirstName').enabled();
        $('.txtLastName').enabled();
        $('.txtEmail').enabled();
        $('.txtExt').enabled();
        $('.txtPassword').enabled();
        $('.txtPositionPSI').enabled();
        $('.selectDepartment').enabled();

}
    else {
        

        if ($(this).val() == '1' && $('.txtCompanyName').val()=="") {
            $('.txtCompanyName').val('บริษัท ปตท. จำกัด (มหาชน)');
        }

        $('.btnSearch').visible();
        $('.txtFirstName').disabled();
        $('.txtLastName').disabled();
        $('.txtEmail').disabled();
        $('.txtExt').disabled();
        $('.txtPassword').disabled();
        $('.txtPositionPSI').disabled();
        $('.selectDepartment').disabled();
    }



});

$(document).on('click', '.btnSelect', function (e) {

    var $item = $(this).closest("tr");


    $('.txtUserLogin').val($item.attr('data'));

    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("Code", $item.attr('data'));

    $.ajax({
        url: pttUserURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var objPTTUser = JSON.parse(result)


            $(".UserGroup1").closest('.btn').button('toggle');
            $("input[name=rdUserType][value=1]").prop("checked", true);
            $.each(objPTTUser, function (index, item) {

                $('.txtFirstName').val(item.FNAME);
                $('.txtLastName').val(item.LNAME);
                $('.selectTitleName').val(item.TitleID);
                $('.selectTitleName').selectpicker('refresh')
                $('.txtEmail').val(item.EmailAddr);
                $('.txtExt').val(item.HOMETEL);
                $('.txtPositionPSI').val(item.POSITION);
                $('.selectDepartment').val(item.UNITCODE);
                

                $('.txtFirstName').disabled();
                $('.txtLastName').disabled();
                $('.txtEmail').disabled();
                $('.txtExt').disabled();
                $('.txtPositionPSI').disabled();
                $('.selectDepartment').disabled();
                $('.txtPassword').disabled();
            });


        }
    });
});


function SearchPTTUser() {



    var html = '';
    var tr = '';
    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("Code", $('.txtUserLoginSearch').val());
    formData.append("FName", $('.txtFNameSearch').val());
    formData.append("LName", $('.txtLNameSearch').val());
    tableName = '.divMainTable';


 //   waitingDialog.show('SEARCHING..', { dialogSize: 'lg', progressType: 'primary' });

    $(tableName).empty();

    html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';


    html += '';

   html += '<thead>';
                html += '<tr >';
                html += '<th></th>';
                     html += '<th>Code</th>';
                       html += '<th>First Name</th>';
                    html += '<th>Last Name</th>';
                    html += '<th>Position</th>';

  html += '</tr>';
  html += '</thead>';


    html += '<tbody>';


    $.ajax({
        url: pttUserURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var objPTTUserList = JSON.parse(result)


            $.each(objPTTUserList, function (index, item) {

                // $trLast = $('.tblPTTUser > tbody');

                html += ' <tr class="TRow" data="' + item.CODE + '">';
                html += ' <td>  <button class="my_tooltip_close  btn btn-success btnSelect">เลือก</button></td>';
                html += '<td>' + item.CODE + '</td>';
                html += '<td>' + item.FNAME + '</td>';
                html += ' <td>' + item.LNAME + '</td>';
                html += '<td>' + item.POSNAME + '</td>';
                html += '</tr>';



            });
              html += '</tbody>';


            $(tableName).append(html);


            $(tableName+' >table').DataTable({

                dom: 'Bfrtip',
                searching: false


            });

         //   setTimeout(function () { waitingDialog.hide(); }, 1000);

        }
    });



}
function Search() {

    var html = '';
    var formData = new FormData();
    formData.append("Action", "Search");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {



            var obj = JSON.parse(result)
            $('.divMainTable table').empty();
            $('.divMainTable').empty();
          
            html += '';
            html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
            html += '<thead>';
            html += '<tr>';
            html += '<th>แก้ไข</th>';
            html += '<th>รหัสพนักงาน</th>';
            html += '<th>ชื่อ-สกุล</th>';
            html += '<th>หน่าวยงาน</th>';
            html += '<th>ตำแหน่งงานใน PTT</th>';
            html += '<th>ตำแหน่งงานบนระบบ</th>';
            html += '<th>ประเภทผู้ใช้งาน</th>';
            html += '<th>วันที่แก้ไขล่าสุด</th>';
           
            html += '<th>Status</th>';
         /*   html += '<th>สิทธิการใช้งาน</th>';*/
         /*  html += '<th>ลบ</th>';*/
            html += '</tr>';
            html += '</thead>';
            html += '<tfoot>';
            html += '<tr>';
            html += '<th>แก้ไข</th>';
            html += '<th>รหัสพนักงาน</th>';
            html += '<th>ชื่อ-สกุล</th>';
            html += '<th>หน่าวยงาน</th>';
            html += '<th>ตำแหน่งงานใน PTT</th>';
            html += '<th>ตำแหน่งงานบนระบบ</th>';
            html += '<th>ประเภทผู้ใช้งาน</th>';
            html += '<th>วันที่แก้ไขล่าสุด</th>';
            
            html += '<th>Status</th>';
            /*   html += '<th>สิทธิการใช้งาน</th>';*/
            /*  html += '<th>ลบ</th>';*/
           
            html += '</tr>';
            html += '</tfoot>';

            html += '<tbody>';

            $.each(obj, function (key, item) {


                html += '<tr class="TRow" data="' + item.UserID + '">';
                html += '<td class="text-center">' + '<i class="fa fa-2x fa-pencil-square btn btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>' + '</td>';
                html += '<td>' + item.UserLogin + '</td>';
                html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                html += '<td>' + item.DepartmentName + '</td>';
                html += '<td>' + item.PositionPSIName + '</td>';
                html += '<td>' + item.PositionName + '</td>';
                html += '<td>' + item.UserTypeName + '</td>';
                html += '<td>' + item.UpdateDate + '</td>';
             
              /*  html += '<td>' + item.USERRoleName + '</td>';*/
                html += '<td class="text-center">' + (item.Status == '1' ? '<input   class="chkStatusView"  disabled   checked type="checkbox" data-toggle="toggle"   data-size="small">'
                : '<input  class="chkStatusView"   type="checkbox" data-toggle="toggle" disabled    data-size="small">') + '</td>';
                 /* html += '<td class="text-center">' + (item.Status=='1'? '<i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i>'
                 : '<i class="fa fa-battery-empty fa-2x" aria-hidden="true" style=" color:red"></i>') + '</td>';*/

             
              /*  html += '<td class="text-center">' + '<i class="fa fa-2x fa-times btn btnDelete" aria-hidden="true" style=" color:red"></i>' + '</td>';*/
                html += '</tr>';
            });
            html += '</tbody>';
            html += '</table>';


         
            $('.divMainTable').append(html);
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false
               
            });

        

            LoadEvent();

        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}


function LoadPopup(id)
 { 

 var html = '';
 var formData = new FormData();

 ClearControl();
 if(id!=null && id !='')
 {
    formData.append("Action", "Search");
    formData.append("UserID", id);

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

   
     $(".modalpopup").modal()

    }

}


function SetControl(item) {

    $(".hddUserID").val(item.UserID);
    $("input[name=rdUserType][value=" + item.UserType + "]").prop("checked", true);
    $(".txtUserLogin").val(item.UserLogin);
    $('.chkStatus').bootstrapToggle((item.Status == '1' ? "on" : 'off'))
    LoadDropdownlist(item.USERRoleID);
    $(".txtCompanyName").val(item.Company);
    $(".selectTitleName").val(item.Title);
    $('.selectTitleName').selectpicker('refresh')
    $(".txtFirstName").val(item.FirstName);
    $(".txtLastName").val(item.LastName);
    $('.txtPositionPSI').val(item.PositionPSI);
   
  //  $(".selectUserRole").val(item.USERRoleID);
  //  $(".selectDepartment").val(item.Department);
    $(".selectPosition").val(item.Position);
  //  $(".selectPositionPSI").val(item.PositionPSI);
    $(".txtExt").val(item.Ext);
    $(".txtEmail").val(item.Email);

    if (item.UserGroupID == "1") {
        $(".UserGroup1").closest('.btn').button('toggle');
    }
    else if (item.UserGroupID == "2") {
        $(".UserGroup2").closest('.btn').button('toggle');
    }

   // $(".UserGroup1").closest('.btn').button('toggle');

    desireRegion = item.UserRegion != null ? item.UserRegion.split(",") : null;
    LoadRegion(desireRegion);


    LoadDepartment(item.Department);
  

    desireAssertOwner = item.AssertOwner != null ? item.AssertOwner.split(",") : null;
    LoadAssertOwner(desireAssertOwner);
    $('.txtPositionPSI').disabled();
    $('.selectDepartment').disabled();
    $('.txtPassword').disabled();
    if ( item.UserPlan != '') {
        array = item.UserPlan.split(",");

        $.each(array, function (i) {

            $("input[name=rdGroupPlan][value=" + array[i] + "]").prop('checked', true)

        });


    }
   /* [UserID],
	[UserLogin],
	[Password],
	[Title],
	[NickName],
	[FirstName],
	[LastName],
	[UserType],
	[UserRegion],
	[UserPlan],
	[Department],
	[Position],
	[Email],
	[Status],
	[CreateDate],
	[CreateBy],
	[UpdateDate],
	[UpdateBy]*/

}



function ClearControl() {
    $(".hddUserID").val('');
    $("input[name=rdUserType]").prop('checked', false)
    $(".txtUserLogin").val('');
    $('.chkStatus').bootstrapToggle("on")
    $(".txtCompanyName").val('');
    $(".selectTitleName").val('');
    $('.selectTitleName').selectpicker('refresh')
    $(".txtFirstName").val('');
    $(".txtLastName").val('');
    $(".selectDepartment").val('');
    $(".selectPosition").val('');
  //  $(".selectPositionPSI").val('');
    $(".selectUserRole").val('');
    $('.txtPositionPSI').val('');
   // $('.txtDepartment').val('');
    $(".txtExt").val('');
    $(".txtEmail").val('');


    $("input[name=rdGroupRegion]").prop('checked', false)
    $("input[name=rdGroupPlan]").prop('checked', false)

}




function LoadDropdownlist(SelectUSERRoleID) {


    var html = '';
    var formData = new FormData();
    formData.append("Action", "loadUserRole");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            var obj = JSON.parse(result)



            $('.selectUserRole').empty().append('<option value="">เลือก</option>');
            $.each(obj, function (key, item) {


                $('.selectUserRole').append("<option value='" + item.USERRoleID + "'" + ((SelectUSERRoleID == item.USERRoleID ? "selected" : "")) + ">" + item.Name + "</option>");


            });



            /* $('.selectMENUGROUP').empty().append('<option value="">เลือก</option>');

            $.each(obj, function (key, item) {
            $('.selectMENUGROUP').append("<option value='" + item.MENU_OID + "' " + ((selectMenuGroupID == item.MENU_OID ? "selected" : "")) + ">" + item.Name + "</option>");


            });
            */
        }
    });

}
