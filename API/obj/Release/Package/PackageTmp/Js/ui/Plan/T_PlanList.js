   var editplan="0";
       var createplan="0";
       var PKID= "";

        var planType= "1";
        var TabNo="1";
        var lastWeek = 0;

        var regionID = '', pipelineID = '', assetOwnerID = '', routeCodeID = '';


        window.onresize = function () {
          
            checkForChanges();
        }



    $(document).ready(function () {




      var data;
   
      AutorizePage();

      LoadEvent();

      LoadCaption();

      $('.lblError').text();

      $(".ddlYear").val(currentYear); 

     $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });

 $('.myModal').on('hide.bs.modal', function (e) {
                var anim = 'zoomOut';

                ModalAnim(anim);
            })

 $('.datetimepicker').disabled();


          $('[data-toggle="tooltip"]').tooltip({ html: true });


          

          $('.txtComplete').IsNumeric(0,100);


          LoadDropDownList($('#ddlDIGFrom'), "m_digfrom");
          LoadRegionDropDownList($("#ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
          LoadTypeOfPipelineDropDownList($("#ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
          LoadRouteCodeDropDownList($("#ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);
          LoadAssetOwnerDropDownList($("#ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);


        //  LoadRegionDropDownList($("#ddlRegion2"), regionID, pipelineID, assetOwnerID, routeCodeID);
         // LoadRouteCodeDropDownList($("#ddlRouteCode2"), regionID, pipelineID, assetOwnerID, routeCodeID);


        $('.pipeline1').collapse('show');
        $('.pipeline2').collapse('show');
          $('.divNote').css("position","absolute");

     $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });







            setTimeout(function () {

                waitingDialog.show('LOADING - PLAN', { dialogSize: 'lg', progressType: 'primary' });
                LoadTable2();
              
            }, 3500);


         //   setTimeout(checkForChanges, 500);

        });




    var $element = $(window), lastWidth = $element.width(), lastHeight = $element.height();
    function checkForChanges() {

        if ($element.width()!=lastWidth||$element.height()!=lastHeight){	
            $('.easyui-datagrid ').datagrid('resize');
            lastWidth = $element.width(); lastHeight = $element.height();
        }
       // setTimeout(checkForChanges, 50);

     //   
    }



        $(document).on('change', '#ddlRegion', function (e) {

            AssignDropDownToData();
            regionID = $(this).val();
            LoadTypeOfPipelineDropDownList($("#ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($("#ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($("#ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);

        });


        $(document).on('change', '#ddlRouteCode', function (e) {

           
            AssignDropDownToData();
            routeCodeID = $(this).val();

            LoadRegionDropDownList($("#ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadTypeOfPipelineDropDownList($("#ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($("#ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
        });



        $(document).on('change', '#ddlAssertOwner', function (e) {

            AssignDropDownToData();
            assetOwnerID = $(this).val();
            LoadRegionDropDownList($("#ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadTypeOfPipelineDropDownList($("#ddlPipeline"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($("#ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);
        });



        $(document).on('change', '#ddlPipeline', function (e) {

         

            AssignDropDownToData();

            pipelineID = $(this).val();

            LoadRegionDropDownList($("#ddlRegion"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadAssetOwnerDropDownList($("#ddlAssertOwner"), regionID, pipelineID, assetOwnerID, routeCodeID);
            LoadRouteCodeDropDownList($("#ddlRouteCode"), regionID, pipelineID, assetOwnerID, routeCodeID);

           
        });





        function AssignDropDownToData(tregionID, tassetOwnerID, tpipelineID, trouteCodeID) {
            regionID = (tregionID != null ? tregionID : $("#ddlRegion").val());
            assetOwnerID = (tassetOwnerID != null ? tassetOwnerID : $("#ddlAssertOwner").val());
            pipelineID = (tpipelineID != null ? tpipelineID : $("#ddlPipeline").val());
            routeCodeID = (trouteCodeID != null ? trouteCodeID : $("#ddlRouteCode").val());
        }


  function LoadEvent()
  {
  



      
      $('.myPlanSpectPO').on('shown.bs.modal', function() {

        var anim = 'zoomIn';
           //     ModalAnim(anim);

       $('.datetimepicker').datepicker({
    format: "dd/mm/yyyy",
    todayBtn: "linked",
    autoclose: true,
    todayHighlight: true,
    container: '.myPlanSpectPO modal-body'
  });
 
});

      
      $('.myPlanAction').on('shown.bs.modal', function() {

        var anim = 'zoomIn';
           //     ModalAnim(anim);

       $('.datetimepicker').datepicker({
    format: "dd/mm/yyyy",
    todayBtn: "linked",
    autoclose: true,
    todayHighlight: true,
    container: '.myPlanAction modal-body'
  });


 
});


$(".chkPO30").on('change', function () {
    if (this.checked) {

        $(".chkPO602").prop('checked', false);
    }

});



$(".chkPO40").on('change', function () {
    if (this.checked) {

        $(".chkPO602").prop('checked', false);
    }

});



$(".chkPO40").on('change', function () {
    if (this.checked) {

        $(".chkPO602").prop('checked', false);
    }

});


  $(".chkPO601").on('change', function () {
       if(this.checked) {

        $(".chkPO602").prop('checked', false);
       }
  });

    $(".chkPO602").on('change', function () {
       if(this.checked) {

        $(".chkPO601").prop('checked', false);
          $(".chkPO40").prop('checked', false);
            $(".chkPO30").prop('checked', false);
       }
  });





}



  

  $(document).on('click', '.btnExport', function (e) {

      var h = screen.height;
      var w = screen.width;
      var param = '';
      var PID = '';
      var dataGrid = $(".easyui-datagrid").datagrid('getChecked');

      for(var i=0;i<dataGrid.length;i++)
      {
          PID = PID + dataGrid[i].PID+",";
      }

      if (PID.length > 0)
      {
          PID = PID.substring(0, PID.length-1);
      }


      if (PID.length == 0)
      {

          
          setTimeout(function () {
              swal({
                  title: "Export Plan",
                  text: "Please select plan",
                  type: "warning",
                  showCancelButton: false,
                  confirmButtonClass: "btn-warning",
                  confirmButtonText: "Yes",
                  closeOnConfirm: false
              })
          }, 300);


          return;
      }

     



      param = param + "&PID=" + PID;

      param = param + "&AssetOwnerID=" + $('#ddlAssertOwner').val();
      param = param + "&RegionID=" + $('#ddlRegion').val();
      param = param + "&DIGFromID=" + $('#ddlDIGFrom').val();
      param = param + "&PipelineID=" + $('#ddlPipeline').val();
      param = param + "&RouteCodeID=" + $('#ddlRouteCode').val();
      param = param + "&Year=" + $('#ddlYear').val();

      window.open(exportPlan + "&RPTType=exportplan" + param, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=200,height=200");
  });



$(document).on('click', '.btnSearch', function (e) {

    setTimeout(function () {

        waitingDialog.show('LOADING', { dialogSize: 'lg', progressType: 'primary' });
        LoadTable2();
        checkForChanges();
    }, 500);

});

$(document).on('click', '.btnAdd', function (e) {

    window.location.href = createPlan;
});



$(document).on('click', '.btnSavePlanDate', function (e) {


    var formData = new FormData();





    formData.append("StartDate", $(".txtStartDate").val());
    formData.append("EndDate", $(".txtEndDate").val());
    formData.append("EditNote", $(".txtEditNote").val());

    formData.append("Action", "UpdatePlan");
    formData.append("PlanType", planType);
    formData.append("PID", PKID);


    $.confirm({
        icon: 'fa fa-warning',
        title: 'Confirm',
        content: 'Do you want to confirm?',
        type: 'green',
        animation: "RotateX",
        typeAnimated: true,
        buttons: {

            tryAgain: {
                text: 'Confrim',
                btnClass: 'btn-green',
                action: function () {


                    $.ajax({
                        url: planSpecPOURL,
                        type: "POST",
                        data: formData,
                        contentType: false,
                        processData: false,
                        success: function (result) {

                            BAlert('Saved', 'Save data successfully!.');

                            formData = null;

                            LoadTable2();


                            $('.datetimepicker').disabled();

                            $('.divNote').addClass("invisible")
                            $('.divNote').css("position", "absolute");
                            $('.btnSavePlanDate').addClass("invisible")
                            $('.btnClosePlanDate').addClass("invisible")




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




$(document).on('click', '.btnClose', function (e) {


    $('.myPlanSpectPO').modal('hide');
    $('.myPlanAction').modal('hide');


});


$(document).on('click', '.bthSearch', function (e) {
    waitingDialog.show('LOADING', { dialogSize: 'lg', progressType: 'primary' });
    LoadTable2();



});


$(document).on('click', '.btnCreateAction', function (e) {


    window.location.href = GetUrlByTab(TabNo) + '?Action=View&PID=' + PKID; ;




});

$(document).on('click', '.btnClosePlanDate', function (e) {
    $('.datetimepicker').disabled();

    $('.divNote').addClass("invisible")
    $('.divNote').css("position", "absolute");
    $('.btnSavePlanDate').addClass("invisible")
    $('.btnClosePlanDate').addClass("invisible")

});




$(document).on('click', '.chkPO100', function (e) {


    if ($(this).is(':checked')) {
        $('.divPONumber').removeClass("invisible")
    } else {
        $('.divPONumber').addClass("invisible")
    }



});




$(document).on('click', '.btnEditPlanDate', function (e) {

    $('.datetimepicker').enabled();

    $('.divNote').removeClass("invisible")

    $('.divNote').css("position", "relative");
    $('.btnSavePlanDate').removeClass("invisible")
    $('.btnClosePlanDate').removeClass("invisible")


});



$(document).on('click', '.btnSaveSpecPO', function (e) {

    var curStep;
    var contractType = '0'


    var formData = new FormData();






    curStep = $(".myPlanSpectPO");
    var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");
    if (planType == 3) {

        formData.append("POSDate", $(".txtStartDate").val());
        formData.append("POEDate", $(".txtEndDate").val());

        if ($(".chkPO100").is(':checked')) {


            $(".txtComplete").val("100");



        }
        else if ($(".chkPO90").is(':checked')) {
            $(".txtComplete").val("90");

        }
        else if ($(".chkPO80").is(':checked')) {
            $(".txtComplete").val("80");

        }
        else if ($(".chkPO70").is(':checked')) {
            $(".txtComplete").val("70");

        }
        else if ($(".chkPO602").is(':checked')) {
            $(".txtComplete").val("60");
            contractType = '1';

        }
        else if ($(".chkPO601").is(':checked')) {
            $(".txtComplete").val("60");
            contractType = '0';

        }
        else if ($(".chkPO40").is(':checked')) {
            $(".txtComplete").val("40");

        }
        else if ($(".chkPO30").is(':checked')) {
            $(".txtComplete").val("30");

        }
        else if ($(".chkPO10").is(':checked')) {
            $(".txtComplete").val("10");

        }



        if ($(".chkPO601").is(':checked')) {

            contractType = '0';

        } else if ($(".chkPO602").is(':checked')) {

            contractType = '1';

        }



    } else {
        formData.append("SpecSDate", $(".txtStartDate").val());
        formData.append("SpecEDate", $(".txtEndDate").val());
    }


    isValid = validateFormInput();

    if (isValid) {

        if ($(".chkPO100").is(':checked')
          || $(".chkPO70").is(':checked')
         || $(".chkPO80").is(':checked')
         || $(".chkPO90").is(':checked')) {

            if (!$(".chkPO602").is(':checked') && !$(".chkPO601").is(':checked')) {

                $(".lbPO60").removeClass("invisible");

                isValid = false;
            } else {
                $(".lbPO60").addClass("invisible");
            }


        }

    }


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
    formData.append("PlanType", planType);
    formData.append("PID", PKID);

    formData.append("Contract", contractType);






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
                            url: planSpecPOURL,
                            type: "POST",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (result) {
                                var errorList;


                                if (result != "") {
                                    errorList = JSON.parse(result);

                                    if (errorList != null) {

                                        $.each(errorList, function (index, item) {

                                            $('.lblError').text(item.text);
                                        });
                                    }
                                } else {


                                    BAlert('Saved', 'Save data successfully!.');

                                    formData = null;

                                    LoadTable2();
                                    //  var obj = JSON.parse(result)
                                    if (planType != 4) {
                                        $(".myPlanSpectPO").modal('hide');
                                    } else {


                                        planType = "4";
                                        LoadAction(PKID, "2");

                                    }
                                }
                                // ClearControl();

                            },
                            error: function (err, result) {

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



function LoadCaption()
{
    var formData = new FormData();
    formData.append("Action", "GetCaptionPlan");

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {


            var data = JSON.parse(result);

            objList = $.grep(data, function (element, item) {

                return (element.Subject == "Note");
            });


            $('.divtxtNote').empty();
            var html = '';
            var index = 1;
            $.each(objList, function (key, item) {
                html += index+"."+item.Text + "<br>";
                index++;
                
            });
            $('.divtxtNote').append(html);



            index = 1;
            objList = $.grep(data, function (element, item) {

                return (element.Subject == "Reference");
            });


            $('.divReference').empty();
            var html = '';
            $.each(objList, function (key, item) {
                html += index + "." + item.Text + "<br>";

            });
            $('.divReference').append(html);

            

        }
    });
}
  
  function ClearControl()
  {
  $(".txtStartDate").val("");
    $(".txtEndDate").val("");

    $('.divPONumber').addClass("invisible");

   // $(".lbPO60").addClass("invisible");
      $(".txtActionStartDate").val("");
    $(".txtActionEndDate").val("");

    $('.lblError').text("");
      $(".txtNote").val("");
       $(".txtEditNote").val("");
      
     $(".txtComplete").val("");
       $(".txtComplete").val("");
       $(".chkPO").prop("checked", false);
         $('.tblHistory tbody').empty();
          $('.Progress').empty();

           $('.datetimepicker').disabled();
              $('.divNote').addClass( "invisible" )
                $('.divNote').css("position","absolute");
 $('.btnSavePlanDate').addClass( "invisible" )
                $('.btnClosePlanDate').addClass( "invisible" )    

                  $('.btnCreateAction').addClass( "invisible" ) 
           $('.btnCreateAction').css("position","absolute");

             $(".modal-content").find('input').removeClass("invalid");
             $(".modal-content").find('.error').remove();

             $('.btnCreateAction').removeClass("btn-info").addClass("btn-success")

  }
     

     function LoadTable(timeline)
     {
     
       

     }



     function LoadTable2()
     {
       var formData = new FormData();
       formData.append("Action", "View");


      


       formData.append("AssetOwnerID", $('#ddlAssertOwner').val());
       formData.append("RegionID", $('#ddlRegion').val());
       formData.append("DIGFromID", $('#ddlDIGFrom').val());
       formData.append("PipelineID", $('#ddlPipeline').val());
       formData.append("RouteCodeID", $('#ddlRouteCode').val());
       formData.append("Year", $('.ddlYear').val());


   // formData.append("Year",($(".ddlYear").val() == null ? currentYear : $(".ddlYear").val()));
     //  waitingDialog.show('LOADING', {dialogSize: 'lg', progressType: 'primary'});


  
        $.ajax({
            url: currentURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {
            
           
              var data = JSON.parse(result);

        

                $(".easyui-datagrid").datagrid({
                minHeight:500,
                rownumbers: true,
                singleSelect: false,
               
                fit: true,
                data: data,
                method: 'get',
                view: groupview,
                groupField: 'PipelineName',
                groupFormatter: groupRow,
                onLoadSuccess: onLoadSuccess2

            });
          
            



             setTimeout(function () { waitingDialog.hide(); }, 1000);
              },
              error:function (ex) {
              alert(ex)
              }

              });

               
     
     }


      function displayList() {
            var result=$("#listForDisplay");
            var checked = $("#demo1").jstree("get_checked", null, true);
            var selectedNodes="";
            result.text(selectedNodes);
            $(checked).each(function (i, node) {
                var id = $(node).attr("id");
                var text = $("#"+id).text();
                var parentId = $(node).attr("parentId");
                if (selectedNodes!=="") selectedNodes+=",";
                selectedNodes+=text;
            });
            result.text(selectedNodes);



        }

          function AutorizePage()
  {
  
  var formData = new FormData();
    formData.append("Action", "GetUserSession");

               $.ajax({
                       url: userAutorizeURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {
            
         
              var obj = JSON.parse(result);
              
                $('.btnEditPlanDate').disabled();

              if(obj.EditPlanDate=="1")
                    {
                  
                      $('.btnEditPlanDate').enabled();
                    }

                    
                   
              if(obj.EditTimeline=="1")
                    {
                    editplan="1";
                      $('.btnEditPlanDate').enabled();
                    }

                  
              

              
               if(obj.CreatePlan=="0")
                    {

                     $('.btnAdd').disabled();

                   
                    }
                    else{

                    createplan="1";
                     $('.btnAdd').enabled(); 
                     

                    }

                      if(obj.ExportPlan=="0")
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
                    }

                    //LoadTable2();
                    //  LoadTable(editplan);
            
            }
            });
  }



        function groupRow(value, rows) {
            return rows[0].PipelineName
        }

          function onLoadSuccess2(data) {

          var SpecStart=false;
          var POStart=false;
          var ActionStart=false;
   
            for (var i = 0; i < data.rows.length; i++) {
             
                SpecStart=false;
           POStart=false;
           ActionStart=false;

                 if(i%2==0)
                    {
             
                    $(this).datagrid('mergeCells', { index:  i, field: 'ck', rowspan: 2 });
                    $(this).datagrid('mergeCells', { index:  i, field: 'Edit', rowspan: 2 });
                     $(this).datagrid('mergeCells', { index:  i, field: 'Delete', rowspan: 2 });
                      $(this).datagrid('mergeCells', { index:  i, field: 'RouteCode', rowspan: 2 });
                    $(this).datagrid('mergeCells', { index: i, field: 'StartEndPipeline', rowspan: 2 });
                  $(this).datagrid('mergeCells', { index: i, field: 'KP', rowspan: 2 });
                  $(this).datagrid('mergeCells', { index: i, field: 'RegionCode', rowspan: 2 });
                  $(this).datagrid('mergeCells', { index: i, field: 'DIGFrom', rowspan: 2 });
                     $(this).datagrid('mergeCells', { index: i, field: 'RiskScore', rowspan: 2 });
                    $(this).datagrid('mergeCells', { index:  i, field: 'TimeLine', rowspan: 2 });
               
                     }

                     /// Jan

               
               }




               var dg = $(this);
            var opts = $(dg).datagrid('options');
               opts.finder.getTr(dg[0], -1, 'allbody').css('min-height', '50px');

}

       

        function Action(status,PID,progressPlan)
        {

        PKID=PID;
        ClearControl();
        if(status=="spec")
        {
        planType="2";
        LoadSpec(PID,progressPlan);
         
       
        }else if(status=="po")
        {
          planType="3";
         LoadPO(PID,progressPlan);
           $('.myPlanSpectPO').modal({show:true});

           }else  if(status=="action")
        {
         planType="4";
           LoadAction(PID,progressPlan);
         //LoadAction(PID);
       //  $('.myPlanAction').modal({show:true});
      //  window.location.href = planAtion+'?Action=View&PID='+PID;;

        }else  if(status=="TimeLine")
        {
        window.location.href = createPlan+'?Action='+status+'&PID='+PID;
        }

        else  if(status=="Edit")
        {
          
        window.location.href = createPlan+'?Action='+status+'&PID='+PID;
        }
         else  if(status=="Delete")
        {
          
      Delete(PID,progressPlan);
        }
       
         
           // alert('ss');
     //   alert(status)
          // window.location.href = planAtion;
        }


         function Delete(PID,progressPlan)
        {

        var progress="";
        var html="";
          var lastDate="";

            var formData = new FormData();
    formData.append("Action", "Delete");
     formData.append("PID", PID);
       formData.append("progressPlan", progressPlan);

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



                                        $.ajax({
                                          url: currentURL,
                                            type: "POST",
                                                 data: formData,
                                             contentType: false,
                                             processData: false,
                                                 success: function (result) {

                                                               LoadTable2();

                                                                          }


                                             });

                                             }
                        },
                        close: function () {}
                   }
                });
        }

        function LoadSpec(PID,progressPlan)
        {

        var progress="";
        var html="";
          var lastDate="";
          $('.txtComplete').attr("placeholder", "กรุณาระบุ % ความคืบหน้าของ Spec");
          ClearControl();

            var formData = new FormData();
    formData.append("Action", "GetPlan");
     formData.append("PlanType", planType);
     formData.append("PID", PID);
       formData.append("progressPlan", progressPlan);

               $.ajax({
              url: planSpecPOURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

               var obj = JSON.parse(result)

             

               if(obj!=null)
               {


               TabNo=obj.TabNo;
              

               $('.txtStartDate').val(obj.SpecSDate);
              $('.txtEndDate').val(obj.SpecEDate);

             $('.txtStartDate').datepicker("update",obj.SpecSDate);
               $('.txtEndDate').datepicker("update",obj.SpecEDate);


                 progress += '<div class="progress-bar progress-bar-success " role="progressbar" aria-valuenow="'+obj.Complete+'" aria-valuemin="0" aria-valuemax="100" style="width:'+obj.Complete+'%">';
                 progress += '<h4>  '+obj.Complete+'% </h4>';
                 progress += '</div>';
               
               $('.Progress').empty();
             $('.Progress').append(progress);


              $('.tblHistory tbody').empty();

           
                 if(obj.History!=null)
                     {
                              $.each(obj.History, function (key, item) {   

                               if(lastDate=="") 
                              {
                              lastDate=item.CreateDate;
                              }

                                    html+='<tr>';
                                    html+='<td>'+item.CreateDate+'</td>';
                                     html+='<td>'+item.Complete+'</td>';
                                      html+='<td>'+item.Note+'</td>';
                                       html+='<td>'+item.CreateBy+'</td>';
                                     html+='</tr>';

                              });
            
              $('.tblHistory tbody').append(html);
                     }



                     if(lastDate=="")
                     {
                       lastDate=obj.SpecSDate;
                     }else{
                      lastDate=obj.ActualSpecEDate;
                     }

               $('.lbPlan').text('Spec');
          $('.pbPO').addClass( "invisible" ) 
           $('.pbPO').css("position","absolute");

             $('.divComplete').removeClass( "invisible" )
             $('.divComplete').css("position","relative");

              $('.datetimepicker').disabled();
               $('.txtEventDate').enabled();

                if(lastDate=="") 
               {
              //    $('.txtEventDate').val(currentDate);
              // $('.txtEventDate').datepicker("update",currentDate);
               }else
               {
              $('.txtEventDate').val(lastDate);
               $('.txtEventDate').datepicker("update",lastDate);

               }


            //  alert(obj.IsSaveSpec)

            if(obj.IsSaveSpec=='0')
            {
               var curInputs =  $(".myPlanSpectPO").find("button[type='button']");
                $('.btnSaveSpecPO').disabled();
                  $('.btnEditPlanDate').disabled();

            }else{
            
            $('.btnSaveSpecPO').enabled();
               $('.btnEditPlanDate').enabled();
            }
          

              $('.myPlanSpectPO').modal({show:true});
              }

            }
          });
        }

  


        function LoadAction(PID,progressPlan)
        {

       
         var progress="";
        var html="";
        var lastDate="";
        $('.txtComplete').attr("placeholder", "กรุณาระบุ % ความคืบหน้าของ Action");
        
        ClearControl();
            var formData = new FormData();
    formData.append("Action", "GetPlan");
     formData.append("PlanType", planType);
     formData.append("PID", PID);
      formData.append("progressPlan", progressPlan);

               $.ajax({
              url: planSpecPOURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

               var obj = JSON.parse(result)

             

               if(obj!=null)
               {
                TabNo=obj.TabNo;

               $('.txtStartDate').val(obj.ActionSDate);
              $('.txtEndDate').val(obj.ActionEDate);

             $('.txtStartDate').datepicker("update",obj.ActionSDate);
               $('.txtEndDate').datepicker("update",obj.ActionEDate);


                 progress += '<div class="progress-bar progress-bar-success " role="progressbar" aria-valuenow="'+obj.Complete+'" aria-valuemin="0" aria-valuemax="100" style="width:'+obj.Complete+'%">';
                 progress += '<h4>  '+obj.Complete+'% </h4>';
                 progress += '</div>';
               
               $('.Progress').empty();
             $('.Progress').append(progress);


              $('.tblHistory tbody').empty();

           
                 if(obj.History!=null)
                     {
                              $.each(obj.History, function (key, item) {  
                              
                              if(lastDate=="") 
                              {
                              lastDate=item.CreateDate;
                              }
                                    html+='<tr>';
                                    html+='<td>'+item.CreateDate+'</td>';
                                    html += '<td>' + (item.Row_State == '9' ? 'Edit Plan' : item.Note) + '</td>';

                                     html+='<td>'+item.Complete+'%</td>';

                                        html+='<td>'+item.CreateBy+'</td>';
                                     html+='</tr>';

                              });
            
              $('.tblHistory tbody').append(html);
         //   alert(lastDate)
           

                     }
               if(lastDate=="")
                     {
                       lastDate=obj.ActionSDate;
                     } else{
                       lastDate=obj.ActualActionEDate;
                     }
 
                     
  $('.btnCreateAction').removeClass( "invisible" )
             $('.btnCreateAction').css("position","relative");

                 $('.divPONumber').addClass( "invisible" )

               $('.lbPlan').text('Action');
          $('.pbPO').addClass( "invisible" ) 
           $('.pbPO').css("position","absolute");

             $('.divComplete').removeClass( "invisible" )
             $('.divComplete').css("position","relative");

              $('.datetimepicker').disabled();
               $('.txtEventDate').enabled();

               if(lastDate=="") 
               {
              //   $('.txtEventDate').val(currentDate);
             //  $('.txtEventDate').datepicker("update",currentDate);
               }else
               {
              $('.txtEventDate').val(lastDate);
               $('.txtEventDate').datepicker("update",lastDate);

               }
               
              

                 if(obj.IsSaveAction=='0')
            {
               var curInputs =  $(".myPlanSpectPO").find("button[type='button']");
                $('.btnSaveSpecPO').disabled();
                 $('.btnCreateAction').removeClass("btn-success").addClass("btn-info").text('View')
                     $('.btnEditPlanDate').disabled();

            }else{
            
            $('.btnSaveSpecPO').enabled();
              $('.btnCreateAction').enabled();
              $('.btnEditPlanDate').enabled();
              $('.btnCreateAction').removeClass("btn-info").addClass("btn-success").text('เรียกดู/แก้ไข')
            
            }

                 if (obj.IsView == '0') {
                     $('.btnCreateAction').css("position", "absolute").addClass("invisible")
                 } else {

                 }
                 

              $('.myPlanSpectPO').modal({show:true});
              }

            }
          });
        
        }

        function GetUrlByTab(tabNo)
        {
           var url=planAtion1;

           switch(tabNo)
                  {
                     case "1" :url =planAtion1; break;
                       case "2" :url =planAtion2; break;
                         case "3" :url =planAtion3; break;
                           case "4" :url =planAtion4; break;
                             case "5" :url =planAtion5; break;
                               case "6" :url =planAtion6; break;
                                 case "7" :url =planAtion7; break;
                                   case "8" :url =planAtion8; break;
                     }

                     return url;
        
        }



        function LoadPO(PID,progressPlan)
        {


         var progress="";
        var html="";
         var lastDate="";
 ClearControl();
 $('.txtComplete').attr("placeholder", "กรุณาระบุ % ความคืบหน้าของ PO");

 $(".lbPO60").addClass("invisible");
            var formData = new FormData();
    formData.append("Action", "GetPlan");
     formData.append("PlanType", planType);
     formData.append("PID", PID);
       formData.append("progressPlan", progressPlan);

               $.ajax({
              url: planSpecPOURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

               var obj = JSON.parse(result)

             

               if(obj!=null)
               {


               $('.txtStartDate').val(obj.POSDate);
              $('.txtEndDate').val(obj.POEDate);
               $('.txtStartDate').datepicker("update",obj.POSDate);
               $('.txtEndDate').datepicker("update",obj.POEDate);



switch(obj.Complete)
{
case "100" :
    $('.chkPO').prop('checked', true);

    if (obj.Contract == '0') {
        $('.chkPO602').prop('checked', false);

    

    } else if (obj.Contract == '1') {
        $('.chkPO30').prop('checked', false);
        $('.chkPO40').prop('checked', false);
        $('.chkPO601').prop('checked', false);
    }

  $('.divPONumber').removeClass( "invisible" );

 
   $('.txtPONumber').val(obj.PONumber);
  break;
 case "90" : 
 
               $('.chkPO10').prop('checked', true);
                   

                   if(obj.Contract=='0')
                   {
                     $('.chkPO30').prop('checked', true);
                      $('.chkPO40').prop('checked', true);
                       $('.chkPO601').prop('checked', true);
                       
                    }else   if(obj.Contract=='1'){
                         $('.chkPO602').prop('checked', true);
                         }
                          $('.chkPO70').prop('checked', true);
                           $('.chkPO80').prop('checked', true);
                             $('.chkPO90').prop('checked', true);
   break;

  break;
  case "80" : 
                         $('.chkPO10').prop('checked', true);


                    if(obj.Contract=='0')
                   {
                     $('.chkPO30').prop('checked', true);
                      $('.chkPO40').prop('checked', true);
                       $('.chkPO601').prop('checked', true);
                       
                    }else   if(obj.Contract=='1'){
                         $('.chkPO602').prop('checked', true);
                         }


                          $('.chkPO70').prop('checked', true);
                           $('.chkPO80').prop('checked', true);
   break;
   case "70" :
                        $('.chkPO10').prop('checked', true);
                     
                      if(obj.Contract=='0')
                      {
                          $('.chkPO30').prop('checked', true);
                         $('.chkPO40').prop('checked', true);
                         $('.chkPO601').prop('checked', true);
                       
                         }else   if(obj.Contract=='1'){
                         $('.chkPO602').prop('checked', true);
                        }
                          $('.chkPO70').prop('checked', true);
   
     break;
    case "60" : 
    
                      $('.chkPO10').prop('checked', true);
                        if(obj.Contract=='0')
                             {
                                 $('.chkPO30').prop('checked', true);
                             $('.chkPO40').prop('checked', true);
                                 $('.chkPO601').prop('checked', true);
                       
                                }else   if(obj.Contract=='1'){
                              $('.chkPO602').prop('checked', true);
                             }
     break;
     case "40" : 
                       $('.chkPO10').prop('checked', true);
                     $('.chkPO30').prop('checked', true);
                      $('.chkPO40').prop('checked', true);
     
         break;
      case "30" :
                    $('.chkPO10').prop('checked', true);
                     $('.chkPO30').prop('checked', true);
                         break;
       case "10" :   $('.chkPO10').prop('checked', true);  break;
}


                 progress += '<div class="progress-bar progress-bar-success " role="progressbar" aria-valuenow="'+obj.Complete+'" aria-valuemin="0" aria-valuemax="100" style="width:'+obj.Complete+'%">';
                 progress += '<h4>  '+obj.Complete+'% </h4>';
                 progress += '</div>';
               
               $('.Progress').empty();
             $('.Progress').append(progress);


              $('.tblHistory tbody').empty();

           
                 if(obj.History!=null)
                     {
                              $.each(obj.History, function (key, item) {   

                                if(lastDate=="") 
                              {
                              lastDate=item.CreateDate;
                              }

                                    html+='<tr>';
                                    html+='<td>'+item.CreateDate+'</td>';
                                     html+='<td>'+item.Complete+'%' +'</td>';
                                       html+='<td>'+item.Note+'</td>';
                                      html+='<td>'+item.CreateBy+'</td>';
                                     html+='</tr>';

                              });
            
              $('.tblHistory tbody').append(html);
                     }


                       if(lastDate=="")
                     {
                       lastDate=obj.POSDate;
                     }else{
                      lastDate=obj.ActualPOEDate;
                     } 

               $('.lbPlan').text('PO');

           $('.pbPO').removeClass( "invisible" )
             $('.pbPO').css("position","relative");


              $('.divComplete').addClass( "invisible" ) 
           $('.divComplete').css("position","absolute");

           $('.txtEventDate').enabled();
         
              if(lastDate=="") 
               {
              //    $('.txtEventDate').val(currentDate);
              // $('.txtEventDate').datepicker("update",currentDate);
               }else
               {
              $('.txtEventDate').val(lastDate);
               $('.txtEventDate').datepicker("update",lastDate);

               }
           

         
               if(obj.IsSavePO=='0')
            {
               var curInputs =  $(".myPlanSpectPO").find("button[type='button']");
                $('.btnSaveSpecPO').disabled();
                  $('.btnEditPlanDate').disabled();

            }else{
            
            $('.btnSaveSpecPO').enabled();
              $('.btnEditPlanDate').enabled();
            
            }



              $('.myPlanSpectPO').modal({show:true});
              }

            }
          });


       
        
        }





       function Search() {

    var html = '';
       var formData = new FormData();
  

    formData.append("Action", "Search");
    formData.append("AssertOwnerCode", $(".txtAssertOwnerCodeSearch").val());
    formData.append("Name", $(".txtAssertOwnerNameSearch").val());
     formData.append("Year", $(".ddlYear").val());
    formData.append("Status", $("input[name=chkStatusSearch]:checked").val());
    // formData.append("MENUGROUP_OID", selectMenuGroup);

   
    $('.divMainTable').empty();

    html += '';
    html += '<table class="table table-bordered table-blue" id="dataTable" width="100%" cellspacing="0">';
     html += '<thead>';
     html += '<tr>';
     html += '<th>Region</th>';
     html += '<th>RC</th>';
      html += '<th>Section</th>';
      html += '<th>KP</th>';
       html += '<th>DIG From</th>';
       html += '<th>Risk</th>';
        html += '<th>Plan Date</th>';
       html += '<th>Complete</th>';
       html += '<th>Report</th>';
       html += '<th>No.Costing Defect</th>';
       html += '<th>No.Pipe Defect</th>';
        html += '<th>Repair Lenght</th>';
        html += '<th>Note</th>';
        html += ' <th>Confirm</th>';
         html += '<th>VIEW</th>';
          html += ' <th>DELETE</th>';
           html += '</tr>';
           html += '</thead>';
           html += '<tfoot>';
           html += '<tr>';
           html += '<th>Region</th>';
          html += '<th>RC</th>';
           html += '<th>Section</th>';
            html += '<th>KP</th>';
            html += '<th>DIG From</th>';
             html += '<th>Risk</th>';
            html += '<th>Plan Date</th>';
             html += '<th>Complete</th>';
             html += '<th>Report</th>';
             html += '<th>No.Costing Defect</th>';
             html += ' <th>No.Pipe Defect</th>';
              html += '<th>Repair Lenght</th>';
              html += '<th>Note</th>';
              html += '<th>Confirm</th>';
              html += '<th>VIEW</th>';
             html += '<th>DELETE</th>';
               html += '</tr>';
               html += '</tfoot>';

    $.ajax({
        url: currentURL,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {



            var obj = JSON.parse(result)
            

            html += '<tbody>';

            $.each(obj, function (key, item) {

                html += '<tr class="TRow" data="' + item.RegionCode + '">';
                 html += '<td>' + item.RegionCode + '</td>';
                html += '<td>' + "RouteCode" + '</td>';
                html += '<td>' + item.SectionCode + '</td>';
                html += '<td>' + item.KPCode + '</td>';
                html += '<td>' + item.DIGFromCode + '</td>';
                html += '<td><i class="fa-2x glyphicon glyphicon-stop" aria-hidden="true" style="color: red;"></i></td>';
                html += '<td>' + item.CreateDate + '</td>';
                html += '<td>' + item.CompleteDate + '</td>';
                html += '<td>' + item.ReportDate + '</td>';
                html += '<td>' + item.CostingDefect + '</td>';
                 html += '<td>' + item.PipeDefect + '</td>';
                 html += '<td>' + item.RepairLength + '</td>';
                 html += '<td>' + item.Note + '</td>';
                html += '<td class="text-center">' + (item.Status == '1' ? '<input   class="chkStatusView"  disabled   checked type="checkbox" data-toggle="toggle"   data-size="small">'
                : '<input  class="chkStatusView"   type="checkbox" data-toggle="toggle" disabled    data-size="small">') + '</td>';

               

                   html += '<td><a class="fa-2x glyphicon glyphicon-zoom-in btnEdit" aria-hidden="true" style=" color:#2c97e9"></a></td>';
                  html += '<td><i class="fa-2x glyphicon glyphicon-remove btnDelete" aria-hidden="true" style=" color:red"></i></td>';
             
                html += '</tr>';
            });
            html += '</tbody>';
            html += '</table>';

            $('.divMainTable').append(html);
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });

         
            $('.chkStatusView').bootstrapToggle()
           


          

          //  event.stopPropagation();
        },
        error: function (err) {
            html += '</table>';

            $('.divMainTable').append(html);
            $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });
        }
    });

}


          function timelineFormat(value, row, index) {

              var Status = (row.IsSaveSpec == '0' && row.IsSavePO == '0' && row.IsSaveAction == '0') ? 0 : 1;
              var btnCaption = '';

              if (value == "" && editplan == '1') {

                  if (row.IsSave == "1") {
                      return '<a onclick="Action(\'TimeLine\',' + row.PID + ')" ><span class="btn btn-success btn-lg">Timeline</span></a>';
                  } else {
                      return "";
                  }
                        }
                        else{
                        return "";
                        }
               
          }

        function progressFormat(value, row, index) {

      
            if (value == "1") {
                return "<span   class='btnPlan'>Plan</span>";
            } else if (value == "2") {
                return "<span   class='btnActual'>Actual</span>";
            }
        }

        function editFormat(value, row, index) {

            var Status = (row.IsSaveSpec == '0' && row.IsSavePO == '0' && row.IsSaveAction == '0') ? 0 : 1;
            var btnCaption = '';

            if (createplan == "1") {
                // if (value == "1") {

                if (row.IsSave == "1") {

                    btnCaption = '<a onclick="Action(\'Edit\',' + row.PID + ')" ><span class="btn btn-success btn-lg">Edit</span></a>';
                } else {
                    btnCaption = '<a onclick="Action(\'Edit\',' + row.PID + ')" ><span class="btn btn-info btn-lg">View</span></a>';

                }

               // btnCaption = '<a onclick="Action(\'Edit\',' + row.PID + ')" ><span class="btn btn-success btn-lg">Edit</span></a>';
                return btnCaption;

            }

            return "";

        }

         function deleteFormat(value, row, index) {

             var Status = (row.IsSaveSpec == '0' && row.IsSavePO == '0' && row.IsSaveAction == '0') ? 0 : 1;
             var btnCaption = '';

        if(createplan=="1")
        {
        // if (value == "1") {

            if (row.IsSave == "1") {
                return '<a onclick="Action(\'Delete\',' + row.PID + ')" ><span class="btn btn-danger btn-lg">Delete</span></a>';
            } else {
                return "";
            }

            }

             return "";

        }

        

        function weekFormat(value, row, index) {

             var planType=value!=null ? value.split('_')[0] : "";
                var planColor=value!=null ? value.split('_')[1] : "";

            //console.log(index);
            if (planType == "1") {
                return "";
            } 
            
            if (planType == "2"  && (row.SpecWeeks-1) == lastWeek) {
            lastWeek=0;
            return '<span  onclick="Action(\'spec\',' + row.PID + ',' + row.Progress + ')" class="btn easyui-linkbutton" iconCls="icon-remove" plain="true" >Spec<br>(' + row.SpecComplete + '%)</span></center>';
            }else  if (planType == "2") {
              lastWeek++;
            
            }

               if (planType == "3"  && (row.POWeeks-1) == lastWeek ) {
                lastWeek=0;
                return '<span onclick="Action(\'po\',' + row.PID + ',' + row.Progress + ')" class="btn easyui-linkbutton" iconCls="icon-remove" plain="true" >PO<br>(' + row.POComplete + '%)</span></center>';
             }else  if (planType == "3"){
              lastWeek++;
            
            
            }
             if (planType == "4"  && (row.ActionWeeks-1) == lastWeek) {
             lastWeek=0;
             return '<span  onclick="Action(\'action\',' + row.PID + ',' + row.Progress + ')" class="btn easyui-linkbutton" iconCls="icon-remove" plain="true" >Action<br>(' + row.ActionComplete + '%)</span></center>';
             }else  if (planType == "4"){
              lastWeek++;
            
            }
            
             if (planType == "0") {
                 return '<span onclick="Action(\'timeline\',' + row.PID + ')" ><span class="btn btn-primary btn-xs">Timeline</span></span>';
            }

          

            
        }


        function weekStyle(value, row, index) {
              var planType=value!=null ? value.split('_')[0] : "";
                var planColor=value!=null ? value.split('_')[1] : "";
           
                var bg="background:"+planColor
                  return bg
           /* if (value == 21 &&  row.Progress=='1') {
                return "background:#7ac0ec;"
            } else if (value == 22 &&  row.Progress=='2') {
                return "background:#72e181;"
            } 
            
            else if (value == 31 &&  row.Progress=='1') {
                return "background:#55b4f0;"
            }else if (value == 32 &&  row.Progress=='2') {
                return "background:#4fdb62;"
            }  
            
            else if (value == 41 &&  row.Progress=='1') {
                return "background:#329fe4;"
            }else if (value == 42 &&  row.Progress=='2') {
                return "background:#26c83d;"
            }*/


         //  return "background:"+planColor+";"  
           /* if (value == 2 &&  row.Progress=='1') {
                return "background:#7ac0ec;"
            } else if (value == 2 &&  row.Progress=='2') {
                return "background:#72e181;"
            } 
            
            else if (value == 3 &&  row.Progress=='1') {
                return "background:#55b4f0;"
            }else if (value == 3 &&  row.Progress=='2') {
                return "background:#4fdb62;"
            }  
            
            else if (value == 4 &&  row.Progress=='1') {
                return "background:#329fe4;"
            }else if (value == 4 &&  row.Progress=='2') {
                return "background:#26c83d;"
            }*/
            
           /*  else if (value == 5) {
                return "background:#80D8FF;"
            } else if (value == 6) {
                return "background:#80D8FF;"
            } else if (value == 7) {
                return "background:#80D8FF;"
            } else if (value == 8) {
                return "background:#80D8FF;"
            }
            */
            // 69F0AE blue
            //35d54b green

        }

        function serFormat(value, row, index) {
            if (value == "1") {
                return "<span style='color:gray'>Low</span>"; 
            } else if (value == "2") {
                return "<span style='color:blue'>Medium</span>";
            }
            else if (value == "3") {
                return "<span style='color:red'>High</span>";
            }
            
        }