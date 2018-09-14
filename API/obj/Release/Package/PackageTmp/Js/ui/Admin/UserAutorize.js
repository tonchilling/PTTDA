var menuID=''

$(document).ready(function () {
    $('.hasSub').click(function () {
        $(this).parent().toggleClass('subactivated');
        $(this).parent().children('ul:first').toggle();

        /*   if ($(this).find('i').hasClass('glyphicon-folder-open')) {
        $(this).find('i').removeClass('glyphicon-folder-open').addClass('glyphicon-folder-close');
        } else {
        $(this).find('i').removeClass('glyphicon-folder-close').addClass('glyphicon-folder-open');
        }*/
    });





    var $li = $('.divfordtreeview .expanded li').click(function () {

        //  $li.css("background-color", "#ffffff");
        // $(this).css("background-color", "#81f448");
        $li.removeClass('selected');
        $(this).addClass('selected');
        // $('.txtMenu').attr('data', $(this).find('span').attr('data'));
        // alert($(this).find('span').val())

      
        $('.lbMenuSelect').val("Select Menu > "+$(this).find('span').text());
        menuID = $(this).find('span').attr('data')
        //  alert(menuID)
        // alert($(this).find('span').attr('data'))
        //  $(this).closest('li').css("background-color", "#bfe4f7");
        // $('.fordtreeview').find("li.list-group").css("background-color", "");
        // $('.fordtreeview').find("li.list-group-item").css("background-color", "");



    });

    $('.btnSave').click(function () {

        var formData = new FormData();
        var html = '';
        formData.append("Action", "Add");

        tags = new Array();
        $("tr.TRow").each(function () {

            this_tag = new Object();
            this_tag.userID = $(this).attr("userID");
            this_tag.MENU_OID = menuID;
            this_tag.USER_PERMISSION_OID = $(this).attr("USERPERMISSIONOID");
            this_tag.View = $(this).find(".ckView").is(':checked');
           this_tag.Edit = $(this).find(".ckEdit").is(':checked');
         /*  this_tag.Delete = $(this).find(".ckDelete").is(':checked');*/
            this_tag.ROW_STATE = $(this).find(".chkStatus").is(':checked');

            //   alert($(this).find(".chkStatus").is(':checked'))
            tags.push(this_tag);

            //  alert($(this).attr("data"))
            // alert($(this).find(".ckView").is(':checked'))
            //  alert(ckView)
        });

        formData.append('tags', JSON.stringify(tags));




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
                          
                               // alert(result)
                                //var obj = JSON.parse(result)
                                Search();


                            }
                        });


                    }
                },
                close: function () {
                }
            }
        });




       

    });

    $(".menufilter").keyup(function () {
        //$(this).addClass('hidden');

        var searchTerm = $(".menufilter").val();
        var listItem = $('.fordtreeview').children('li');

        var searchSplit = searchTerm.replace(/ /g, "'):containsi('")

        //extends :contains to be case insensitive
        $.extend($.expr[':'], {
            'containsi': function (elem, i, match, array) {
                return (elem.textContent || elem.innerText || '').toLowerCase()
    .indexOf((match[3] || "").toLowerCase()) >= 0;
            }
        });

        $(".fordtreeview li").not(":containsi('" + searchSplit + "')").each(function (e) {
            $(this).hide()
        });

        $(".fordtreeview li:containsi('" + searchSplit + "')").each(function (e) {
            $(this).show();
        });
    });

    $('.divMainTable table').DataTable({

        dom: 'Bfrtip',
        searching: false

    });

    //  $('.chkStatus').bootstrapToggle()

    $('.bthSearch').on('click', function (e) {
        Search();
    });

    InitialPage();


});


function InitialPage() {


  

    GetMenu();
    Search();


}

function GetMenu() {
    var html = '';

    var formData = new FormData();
    formData.append("Category", "menu");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

    
            var obj = JSON.parse(result)


            $('.listLeftMenu').empty();


            html += '<span class="hasSub"><i class="glyphicon glyphicon-folder-close folder"></i> Left Menu</span>';
            var itemGroup = obj.filter(function (tempItemGroup) {
                return (tempItemGroup.MENUGROUP_OID == '' && tempItemGroup.Position=='L')
            });

            $.each(itemGroup, function (key, objItem) {

                html += '<li class="list-group-item " onclick="MenuEvent(event,this)" data-placement="right"><i class="fa fa-internet-explorer link"></i> <span data="' + objItem.MENU_OID + '" class="hasSub">' + objItem.Name + '</span>';
                //html += '<a class="nav-link nav-link-collapse" data-toggle="collapse" href="#collapseComponents"  data-parent="#exampleAccordion" aria-expanded="true"><i class="fa fa-fw fa-wrench" style=" color:#ffffff"></i><span class="nav-link-text">Components</span></a>';
                var item = obj.filter(function (tempItem) {
                    return tempItem.MENUGROUP_OID == objItem.MENU_OID;
                });

                if (item != null) {

                    html += '<ul >';
                    $.each(item, function (key, objItem) {

                        html += '<li class="searchterm"  onclick="MenuEvent(event,this)"><i class="glyphicon glyphicon-globe linksub"></i> <span data="' + objItem.MENU_OID + '">' + objItem.Name + '</span>';

                    });
                    html += '</ul>';
                }

                html += '</li>';

            });


            html += '</ul>';
            html += '</li>';

            $('.listLeftMenu').append(html);




            $('.listTopMenu').empty();

            html = '';
            html += '<span class="hasSub"><i class="glyphicon glyphicon-folder-close folder"></i> Top Menu</span>';
            var itemGroup = obj.filter(function (tempItemGroup) {
                return (tempItemGroup.MENUGROUP_OID == '' && tempItemGroup.Position == 'T')
            });

            $.each(itemGroup, function (key, objItem) {

                html += '<li class="list-group-item " onclick="MenuEvent(event,this)" data-placement="right"><i class="fa fa-internet-explorer link"></i> <span data="' + objItem.MENU_OID + '" class="hasSub">' + objItem.Name + '</span>';
                //html += '<a class="nav-link nav-link-collapse" data-toggle="collapse" href="#collapseComponents"  data-parent="#exampleAccordion" aria-expanded="true"><i class="fa fa-fw fa-wrench" style=" color:#ffffff"></i><span class="nav-link-text">Components</span></a>';
                var item = obj.filter(function (tempItem) {
                    return tempItem.MENUGROUP_OID == objItem.MENU_OID;
                });

                if (item != null) {

                    html += '<ul >';
                    $.each(item, function (key, objItem) {

                        html += '<li class="searchterm"  onclick="MenuEvent(event,this)"><i class="glyphicon glyphicon-globe linksub"></i> <span data="' + objItem.MENU_OID + '">' + objItem.Name + '</span>';

                    });
                    html += '</ul>';
                }

                html += '</li>';

            });


            html += '</ul>';
            html += '</li>';

            $('.listTopMenu').append(html);









            $('.hasSub').click(function () {
                $(this).parent().toggleClass('subactivated');
                $(this).parent().children('ul:first').toggle();

              
            });






            $(".menufilter").keyup(function () {
                //$(this).addClass('hidden');

                var searchTerm = $(".menufilter").val();
                var listItem = $('.fordtreeview').children('li');

                var searchSplit = searchTerm.replace(/ /g, "'):containsi('")

                //extends :contains to be case insensitive
                $.extend($.expr[':'], {
                    'containsi': function (elem, i, match, array) {
                        return (elem.textContent || elem.innerText || '').toLowerCase()
    .indexOf((match[3] || "").toLowerCase()) >= 0;
                    }
                });

                $(".fordtreeview li").not(":containsi('" + searchSplit + "')").each(function (e) {
                    $(this).hide()
                });

                $(".fordtreeview li:containsi('" + searchSplit + "')").each(function (e) {
                    $(this).show();
                });
            });



        

        }
    });


}

function MenuEvent(event,liObject) {

    $('.lbMenuSelect').text("Select Menu > " + $(liObject).find('span:first').text());

   // $('.txtMenu').val($(liObject).find('span:first').text());
    menuID = $(liObject).find('span:first').attr('data')
    
    Search();
    event.stopPropagation();
}

function Search() {

    var html = '';

    var userLogin = $('.txtUserLogin').val() != null ? $('.txtUserLogin').val() : "";

   
    var formData = new FormData();
    formData.append("Action", "Search");
    formData.append("MENU_OID", menuID);
    formData.append("UserLogin", userLogin);


    if (menuID == '') {
        formData.append("UserType", 'none');
     }
    else {
        if ($('input[name=rdUserType]:checked').val() != null) {
            formData.append("UserType", $('input[name=rdUserType]:checked').val());
        }
    }
    var tempHtml = "";
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
            html += '<th>Account</th>';
            html += '<th>Account Type</th>';
          //  html += '<th>Screen</th>';
            html += '<th>View</th>';
           html += '<th>Edit</th>';
          //  html += '<th>Delete</th>';
          //  html += '<th>Status</th>';
            html += '</tr>';
            html += '</thead>';
            html += '<tfoot>';
            html += '<tr>';
            html += '<th>Account</th>';
            html += '<th>Account Type</th>';
         //   html += '<th>Screen</th>';
            html += '<th>View</th>';
         html += '<th>Edit</th>';
          //  html += '<th>Delete</th>';
          //  html += '<th>Status</th>';
            html += '</tr>';
            html += '</tfoot>';

            html += '<tbody>';
            var row = 0
            $.each(obj, function (key, item) {


              //  alert(item.VIEW)
                html += '<tr class="TRow" userID="' + item.UserID + '" USERPERMISSIONOID="' + item.USER_PERMISSION_OID + '">';
                html += '<td>' + item.UserLogin + '</td>';
                html += '<td>' + item.UserTypeName + '</td>';
               // html += '<td>' + item.Screen + '</td>';
                html += '<td> <input name="ckView" class="ckView" value="' + item.VIEW + '" ' + (item.VIEW == '1' ? "checked" : "") + '   type="checkbox" /></td>';
            html += '<td> <input name="ckEdit" class="ckEdit" value="' + item.EDIT + '" ' + (item.EDIT == '1' ? "checked" : "") + '  type="checkbox" /></td>';
             //   html += '<td> <input name="ckDelete" class="ckDelete"  value="' + item.DELETE + '" ' + (item.DELETE == '1' ? "checked" : "") + '  type="checkbox" /></td>';

              // tempHtml = (item.ROW_STATE.trim() == "1" ? '<input  class="chkStatus" name="chkStatus" checked type="checkbox" data-toggle="toggle"  data-size="small">'
                 //                                  : '<input  class="chkStatus" name="chkStatus"   type="checkbox" data-toggle="toggle" data-size="small">') + '</td>';



           /*     html += '<td class="text-center">' + (item.ROW_STATE.trim() == '1' ? '<input   class="chkStatus" name="chkStatus" checked type="checkbox"  data-toggle="toggle" data-size="small">'
                                                     : '<input  class="chkStatus" name="chkStatus"   type="checkbox"  data-toggle="toggle" data-size="small">') + '</td>';*/

                html += '</tr>';
                row++;
            });
            html += '</tbody>';
            html += '</table>';


            $('.divMainTable').append(html);
            // $('#toggle-one').bootstrapToggle();
            $('.chkStatus').bootstrapToggle();
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });


           

            //   LoadEvent();

        },
        error: function (err) {
            alert(err.statusText)
        }
    });

}
