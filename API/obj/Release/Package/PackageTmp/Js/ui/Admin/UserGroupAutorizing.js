var userGroup = "1";


$(document).ready(function () {

    Search();
    InitialData();
});

function InitialData() {


    $('.btnOperation').click(function () {

        $(".card-MHeader").removeClass('bgAssertOwner').addClass('bgOperation');

        $(".spUserGroup").html("ผู้ปฏิบัติงาน");
        userGroup = "1";

        Search();
    });


    $('.btnAssertOwner').click(function () {

        $(".card-MHeader").removeClass('bgOperation').addClass('bgAssertOwner');
        $(".spUserGroup").html("Assert Owner");
        userGroup = "2";
       
        Search();
     
    });



    $('.btnSave').on("click", function (e) {

        var $tableMenus = $('.divMenuGroup table');
        tags = new Array();
        $.each($tableMenus, function (index, tableMenu) {
            $(tableMenu).find("tr.TRow").each(function () {

                this_tag = new Object();
               this_tag.USERGROUP_Autorize_OID = $(this).attr("USERGroup_Autorize_OID");
                this_tag.USERGROUPID = $(this).attr("USERGroupID");
                this_tag.MENU_OID = $(this).attr("MENU_OID"); ;

                this_tag.VIEW = $(this).find(".ckView").is(':checked');
                this_tag.EDIT = $(this).find(".ckEdit").is(':checked');
                this_tag.DELETE = $(this).find(".ckDelete").is(':checked');
                this_tag.Row_State = $(this).find(".chkStatus").is(':checked');
                tags.push(this_tag);


            });

        });

        var formData = new FormData();
        formData.append("Action", "Add");
        formData.append('objList', JSON.stringify(tags));

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

                      //  waitingDialog.show('LOADING', { dialogSize: 'lg', progressType: 'primary' });


                        $.ajax({
                            url: currentURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                              //  $(".alert").toggleClass('in out');

                                BAlert('Saved', 'Save data successfully!.');
                                //var obj = JSON.parse(result)
                                Search();
                               
                            /*    setTimeout(function () {
                                    waitingDialog.hide();
                                }, 1000);*/
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


function Search() {

    var html = '';

    $('#accordion').empty();

    
    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("UserGroupID", userGroup);
    
      $.ajax({
          url: currentURL,
          type: "POST",
          data: formData,
          contentType: false,
          processData: false,
          success: function (result) {

              var obj = JSON.parse(result)

              if (obj != null) {

                  var menuGroupList = $.grep(obj, function (e) { return (e.MENUGROUP_OID == ''); });

                  if (menuGroupList != null) {

                      $.each(menuGroupList, function (index, menuGroup) {
                          html += '<div class="panel panel-default">';
                          html += '<div class="panel-heading">';
                          html += '<h4 class="panel-title">';
                          html += '<a data-toggle="collapse" data-parent="#accordion" href="#' + menuGroup.MENU_OID + '"><span class="' + menuGroup.Icon + '">';
                          html += '</span>' + menuGroup.MENUName + '</a>';
                          html += '</h4>';
                          html += '</div>';
                          html += '<div id="' + menuGroup.MENU_OID + '" class="panel-collapse collapse in">';
                          html += ' <div class="panel-body">';
                          html += '<div class="table-responsive divMenuGroup  div' + menuGroup.MENU_OID + '">';
                          html += '<table class="table table-bordered table-blue tableMenu" id="Table1" width="100%" cellspacing="0">';
                          html += '<thead>';
                          html += '<tr>';
                          html += ' <th>Menu</th>';
                          html += '<th>Main Menu</th>';
                          html += '<th>VIEW</th>';
                         // html += '<th>EDIT</th>';
                        //  html += '<th>DELETE</th>';
                          html += '<th>STATUS</th>';
                          html += '</tr>';
                          html += '</thead> <tbody>';



                          var menuList = $.grep(obj, function (e) { return e.MENUGROUP_OID == menuGroup.MENU_OID; });

                          // alert(Object.keys(menuList).length)
                         // if (Object.keys(menuList).length == 0) {
                          menuList.unshift(menuGroup);
                         // }

                          if (menuList != null) {


                              $.each(menuList, function (index, menu) {
                                  html += '<tr class="TRow" USERGroup_Autorize_OID="' + menu.USERGROUP_Autorize_OID + '"  USERGROUPID="' + userGroup + '" MENU_OID="' + menu.MENU_OID + '">';
                                  html += '<td>' + menu.MENUName + '</td>';
                                  html += '<td>' + menuGroup.MENUName + '</td>';
                                  html += '<td> <input name="ckView" class="ckView" value="' + menu.VIEW + '" ' + (menu.VIEW == '1' ? "checked" : "") + '   type="checkbox" /></td>';
                                //  html += '<td> <input name="ckEdit" class="ckEdit" value="' + menu.EDIT + '" ' + (menu.EDIT == '1' ? "checked" : "") + '  type="checkbox" /></td>';
                                 // html += '<td> <input name="ckDelete" class="ckDelete"  value="' + menu.DELETE + '" ' + (menu.DELETE == '1' ? "checked" : "") + '  type="checkbox" /></td>';
                                  html += '<td class="text-center">' + (menu.Row_State.trim() == '1' ? '<input   class="chkStatus" name="chkStatus" checked type="checkbox"  data-toggle="toggle" data-size="small">'
                                                     : '<input  class="chkStatus" name="chkStatus"   type="checkbox"  data-toggle="toggle" data-size="small">') + '</td>';
                                  html += '</tr>';
                              });

                          }

                          html += '</tbody>  </table>';

                          html += ' </div>';
                          html += '</div>';
                          html += '</div>';
                          html += '</div>';
                      });

                      $('#accordion').append(html);
                      $('.chkStatus').bootstrapToggle();
                  
                  }

              }

          }
      });

}