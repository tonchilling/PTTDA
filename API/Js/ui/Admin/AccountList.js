


$(document).ready(function () {

    Search();
    LoadEvent();
    LoadDropDownList($('.ddlAssetOwnerSearch'), "M_AssertOwner");
   // LoadAssertOwner();
    LoadDropDownList($('.selectPositionSearch'), 'M_Position');

    LoadDepartment('');
   // LoadDropDownList($('.selectDepartmentSearch'), 'M_Department');
  /*  $(".txtRegion").select2({
        tags: true,
    
         data: data,
         width: '100%'
     });

     $(".txtAssertOwner").select2({
         tags: true,
         width: '100%'
     });*/



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
        formData.append("userRegion", $("input[name=rdGroupRegion]:checked").map(function () { return this.value; }).get());
        formData.append("userPlan", $("input[name=rdGroupPlan]:checked").map(function () { return this.value; }).get());

        formData.append("UserRoleID", $('.selectUserRole').val())

       


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

});


function LoadEvent() {
    $('.table>tbody>tr > btnEdit').on('click', function (e) {
        var $item = $(this).closest("tr");
     
       // $(".modal").modal()

    });



    $(document).on('click', '.bthSearch', function (e) {

        Search();
    });
    


    $(document).on('click', '.btnEdit', function (e) {
        var $item = $(this).closest("tr");
      //  LoadPopup($item.attr('data'))

        //   Submit("EDIT", $item.attr('data'));
        var encodedUrl = encodeURIComponent('Action=ADD');


        window.location.href = accountEdit + "?" + 'Action=VIEW&ID=' + $item.attr('data');

    });

    $(document).on('click', '.btnAdd', function (e) {
        var $item = $(this).closest("tr");




      /*  var form = $("form:first");

        var inputAction = $("<input>")
               .attr("type", "hidden")
               .attr("id", "Action").val("ADD");

        var inputID = $("<input>")
               .attr("type", "hidden")
               .attr("id", "PKID").val("");

        form.append($(inputAction));
         form.append($(inputID));

        form.attr("action", accountEdit)
        form.submit();

        return true;*/

        var encodedUrl = encodeURIComponent('Action=ADD');


        window.location.href = accountEdit + "?" + 'Action=ADD';


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



                        formData.append("UserID", $item.attr('data'));

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
                                Search();
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
                $(".selectDepartmentSearch").select2({
                    tags: true,
                    data: obj,
                    width: '100%'
                });




                $(".selectDepartmentSearch").val(selectValue).trigger('change');



            }


        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}


function Submit(action,id) {

    var form = $("form:first");

    var inputAction = $("<input>")
               .attr("type", "hidden")
               .attr("id", "ActionXX").val(action);

    var inputID = $("<input>")
               .attr("type", "hidden")
               .attr("Name", "PKID").val(id);

    form.append($(inputAction));
   // form.append($(inputID));

    form.attr("action", accountEdit)
    form.submit();

    return true;
}
function Search() {

    var html = '';
    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("Department",  $('.selectDepartmentSearch').val());
    formData.append("FirstName", $('.txtFirstNameSearch').val());
    formData.append("LastName", $('.txtLastNameSearch').val());

    formData.append("AssertOwner", $('.ddlAssetOwnerSearch').val());
    formData.append("Position", $('.selectPositionSearch').val());
    formData.append("UserType", $('.selectUserTypeSearch').val());

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
            html += '<th>EDIT</th>';
            html += '<th>DELETE</th>';
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
            html += '<th>EDIT</th>';
            html += '<th>DELETE</th>';
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
          
                html += '<td style="width:5%" class="text-center">' + (item.IsSave == '1' ? '<i class="fa fa-2x fa-pencil-square btn btnEdit" aria-hidden="true" style=" color:#2c97e9"></i>' : "") + '</td>';
                html += '<td  style="width:5%" class="text-center">' + (item.IsSave == '1' ? '<i class="fa fa-2x fa-times btn btnDelete" aria-hidden="true" style=" color:red"></i>' : "") + '</td>';
                html += '<td>' + item.UserLogin + '</td>';
                html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                html += '<td>' + item.DepartmentName + '</td>';
                html += '<td>' + item.PositionPSIName + '</td>';
                html += '<td>' + item.PositionName + '</td>';
                html += '<td>' + item.UserTypeName + '</td>';
                html += '<td>' + item.UpdateDate + '</td>';
                html += '<td class="text-center">' + (item.Status == '1' ? '<input   class="chkStatusView"  disabled   checked type="checkbox" data-toggle="toggle"   data-size="small">'
                : '<input  class="chkStatusView"   type="checkbox" data-toggle="toggle" disabled    data-size="small">') + '</td>';
              /*  html += '<td>' + item.USERRoleName + '</td>';*/
               /* html += '<td class="text-center">' + (item.Status == '1' ? '<input   class="chkStatusView"  disabled   checked type="checkbox" data-toggle="toggle"   data-size="small">'
                : '<input  class="chkStatusView"   type="checkbox" data-toggle="toggle" disabled    data-size="small">') + '</td>';
                  html += '<td class="text-center">' + (item.Status=='1'? '<i class="fa fa-battery-full fa-2x" aria-hidden="true" style=" color:#94f26f"></i>'
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


          //  $('.chkStatus').bootstrapToggle()
          //  $('.chkStatusView').bootstrapToggle()
           // LoadEvent();

        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}




function LoadAssertOwner() {
    var form = $('form:first'); // You need to use standard javascript object here
    var formData = new FormData(form);
    formData.append("Action", "LoadSelect2");
    $.ajax({
        url: assertOwnerURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            if (result != "") {
                var obj = JSON.parse(result);
                $(".txtAssetOwnerSearch").select2({
                    tags: true,
                    data: obj,
                    width: '100%'
                });




              //  $(".txtAssetOwnerSearch").val(desireAssertOwner).trigger('change');



            }


        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}


/*
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

}*/






