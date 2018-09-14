   var editplan="0";
       var createplan="0";
       var PKID= "";

        var planType= "1";
        var TabNo="1";


    $(document).ready(function () {




      var data;
   
      AutorizePage();

     
 setTimeout(function () {
 
   waitingDialog.show('LOADING', {dialogSize: 'lg', progressType: 'primary'});
  LoadTable2(); }, 3000);


      $(".ddlYear").val(currentYear); 




     $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });


           $(document).on('click', '.btnCreateAction', function (e) {

    
       window.location.href = GetUrlByTab(TabNo)+'?Action=View&PID='+PKID;;

    
     });


      
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


  $(document).on('click', '.btnClose', function (e) {

   
       $('.myPlanSpectPO').modal('hide');
        $('.myPlanAction').modal('hide');
       
     
     });


      $(document).on('click', '.bthSearch', function (e) {
      waitingDialog.show('LOADING', {dialogSize: 'lg', progressType: 'primary'});
       LoadTable2();

      });






 $('.myModal').on('hide.bs.modal', function (e) {
                var anim = 'zoomOut';

                ModalAnim(anim);
            })



 $('.datetimepicker').disabled();

 
      
      
       

          $('[data-toggle="tooltip"]').tooltip({ html: true });


           

         

           LoadDropDownList($('#ddlDIGFrom'), "m_digfrom");
    LoadDropDownList($('#ddlRegion'), "m_region");
     LoadDropDownList($('#ddlRegion2'), "m_region");
    LoadDropDownList($('#ddlPipeline'), "m_pipelinelength");
    LoadDropDownList($('#ddlRouteCode'), "m_routecode");
     LoadDropDownList($('#ddlRouteCode2'), "m_routecode");
      LoadDropDownList($('#ddlAssertOwner'), "M_AssertOwner");
    
        $('.pipeline1').collapse('show');
        $('.pipeline2').collapse('show');
          $('.divNote').css("position","absolute");

     $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });

            $('.btnAdd').on("click",function(e){
            
            window.location.href =createPlan;
            });



             $(document).on('click', '.btnSavePlanDate', function (e) {


                var formData = new FormData();




             
               formData.append("StartDate",$(".txtStartDate").val());
       formData.append("EndDate", $(".txtEndDate").val());
         formData.append("EditNote",$(".txtEditNote").val());

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

              $('.divNote').addClass( "invisible" )
                $('.divNote').css("position","absolute");
 $('.btnSavePlanDate').addClass( "invisible" )
                $('.btnClosePlanDate').addClass( "invisible" )    




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

  $(document).on('click', '.btnClosePlanDate', function (e) {
             $('.datetimepicker').disabled();

              $('.divNote').addClass( "invisible" )
               $('.divNote').css("position","absolute");
       $('.btnSavePlanDate').addClass( "invisible" )
                $('.btnClosePlanDate').addClass( "invisible" )    

             });

          

          
          $(document).on('click', '.chkPO100', function (e) {


                if($(this).is(':checked')){
                 $('.divPONumber').removeClass( "invisible" )
                }else{
                  $('.divPONumber').addClass( "invisible" )
                }

       
          
          });
          


               $(document).on('click', '.btnEditPlanDate', function (e) {
            
          
            
            
            
            
            

            
            
             
 $('.datetimepicker').enabled();

 $('.divNote').removeClass( "invisible" )

  $('.divNote').css("position","relative");
 $('.btnSavePlanDate').removeClass( "invisible" )
      $('.btnClosePlanDate').removeClass( "invisible" )        
               
            
            });





             $('.btnConfirm').on("click",function(e){


                        
                    //   $('.modalConfirmInspection').modal('show');

            });

  



  });




       $(document).on('click', '.btnSaveSpecPO', function (e) {

        var curStep;
     var contractType='0'
         
    var isValid = true;
    var formData = new FormData();


        curStep = $(".myPlanSpectPO");
        var curInputs = curStep.find("input[type='text'],input[type='url'],input[type='hidden'],input[type='radio'],select,textarea");
if(planType==3)
{

  formData.append("POSDate",$(".txtStartDate").val());
       formData.append("POEDate", $(".txtEndDate").val());

         if ($(".chkPO100").is(':checked'))
              {
                   $(".txtComplete").val("100");
              }
              else if($(".chkPO90").is(':checked'))
              {
                  $(".txtComplete").val("90");
              
              }
              else if($(".chkPO80").is(':checked'))
              {
                $(".txtComplete").val("80");
              
              }
               else if($(".chkPO70").is(':checked'))
              {
               $(".txtComplete").val("70");
              
              }
               else if($(".chkPO602").is(':checked'))
              {
                $(".txtComplete").val("60");
                contractType='1';
              
              }
               else if($(".chkPO601").is(':checked') )
              {
                $(".txtComplete").val("60");
                  contractType='0';
              
              }
              else if($(".chkPO40").is(':checked'))
              {
                  $(".txtComplete").val("40");
              
              }
               else if($(".chkPO30").is(':checked'))
              {
                   $(".txtComplete").val("30");
              
              }
               else if($(".chkPO10").is(':checked'))
              {
                   $(".txtComplete").val("10");
              
              }



           if($(".chkPO601").is(':checked'))
              {
            
                  contractType='0';
              
              }else  if($(".chkPO602").is(':checked'))
              {
               
                contractType='1';
              
              }



      }else{
       formData.append("SpecSDate",$(".txtStartDate").val());
       formData.append("SpecEDate", $(".txtEndDate").val());
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

       formData.append("Contract",contractType);





    
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

                                 BAlert('Saved', 'Save data successfully!.');

                                 formData = null;

                                 LoadTable2();
                               //  var obj = JSON.parse(result)
                               if(planType!=4)
                                    {
                                 $(".myPlanSpectPO").modal('hide');
                                 }else{

                               
                                      planType="4";
                             LoadAction(PKID,"2");
                                 
                                 }
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
            
  


  
  function ClearControl()
  {
  $(".txtStartDate").val("");
    $(".txtEndDate").val("");

    

      $(".txtActionStartDate").val("");
    $(".txtActionEndDate").val("");


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

  }
     

     function LoadTable(timeline)
     {
     
       

             data = {"Total":28,"rows": [
	{
	    "RouteCode": "RC0650",
	    "PipelineName": "Transmission Pipline",
	    "StartEndPipeline": "BV9-BV20",
	    "KP": "22-339",
	    "RegionCode": "9",
	    "DIGFrom": "Severe Dent",
	    "RiskScore": "1",
	    "Progress": "1",
          "TimeLine": "1",
	    "jan_1": "2",
	    "jan_2": "3",
	    "jan_3": "4",
	    "jan_4": "1",

	    "fab_1": "1",
	    "fab_2": "1",
	    "fab_3": "1",
	    "fab_4": "1",

	    "mar_1": "1",
	    "mar_2": "1",
	    "mar_3": "1",
	    "mar_4": "1",

	    "apr_1": "1",
	    "apr_2": "1",
	    "apr_3": "1",
	    "apr_4": "1",

	    "may_1": "1",
	    "may_2": "1",
	    "may_3": "1",
	    "may_4": "1",

	    "jun_1": "1",
	    "jun_2": "1",
	    "jun_3": "1",
	    "jun_4": "1"

	},
	{
	    "RouteCode": "RC0650",
	    "PipelineName": "Transmission Pipline",
	    "StartEndPipeline": "BV9-BV20",
	    "KP": "22-339",
	    "RegionCode": "9",
	    "DIGFrom": "Severe Dent",
	    "RiskScore": "1",
	    "Progress": "2",
            "TimeLine": "1",
	    "jan_1": "5",
	    "jan_2": "5",
	    "jan_3": "5",
	    "jan_4": "5",

	    "fab_1": "5",
	    "fab_2": "5",
	    "fab_3": "5",
	    "fab_4": "5",

	    "mar_1": "5",
	    "mar_2": "5",
	    "mar_3": "5",
	    "mar_4": "5",

	    "apr_1": "5",
	    "apr_2": "5",
	    "apr_3": "5",
	    "apr_4": "5",

	    "may_1": "5",
	    "may_2": "5",
	    "may_3": "5",
	    "may_4": "6",

	    "jun_1": "6",
	    "jun_2": "5",
	    "jun_3": "5",
	    "jun_4": "5"
	},

	{
	    "RouteCode": "RC0651",
	    "PipelineName": "IPP / SPP Pipline > Gas Transmission Asset (GTA-สทพ)",
	    "StartEndPipeline": "BV9-BV21",
	    "KP": "22-339",
	    "RegionCode": "9",
	    "DIGFrom": "Severe Dent",
	    "RiskScore": "0",
	    "Progress": "1",
         "TimeLine": "0"
	},
	{
	    "RouteCode": "RC0651",
	    "PipelineName": "IPP / SPP Pipline > Gas Transmission Asset (GTA-สทพ)",
	    "StartEndPipeline": "BV9-BV21",
	    "KP": "22-339",
	    "RegionCode": "9",
	    "DIGFrom": "Severe Dent",
	    "RiskScore": "0",
	    "Progress": "2",
            "TimeLine": "1",
          "jan_1": timeline,
	
	}
]
        }

             $(".easyui-datagrid").datagrid({
                rownumbers: true,
                singleSelect: false,
                data: data,
                method: 'get',
                view: groupview,
                groupField: 'rc',
                groupFormatter: groupRow,
                onLoadSuccess: onLoadSuccess
            });
     }



     function LoadTable2()
     {
       var formData = new FormData();
    formData.append("Action", "View");
     formData.append("Year",  $(".ddlYear").val());
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
                minHeight:150,
                rownumbers: true,
                singleSelect: false,
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

                    if(data.rows[i].jan_1!=null)
                     {



                                 if(data.rows[i].jan_1=="2" && !SpecStart)
                                {
                                SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jan_1color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].jan_1=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jan_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].jan_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jan_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                       if(data.rows[i].jan_2!=null)
                     {

                             if(data.rows[i].jan_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jan_2color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].jan_2=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jan_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].jan_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jan_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].jan_3!=null)
                     {
                             if(data.rows[i].jan_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jan_3color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].jan_3=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jan_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].jan_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jan_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                     if(data.rows[i].jan_4!=null)
                     {

                                if(data.rows[i].jan_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jan_4color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].jan_4=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jan_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].jan_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jan_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }


                      /// Feb

                       if(data.rows[i].feb_1!=null)
                     {

                                 if(data.rows[i].feb_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'feb_1color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].feb_1=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'feb_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].feb_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'feb_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }

                    if(data.rows[i].feb_2!=null)
                     {

                             if(data.rows[i].feb_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'feb_2color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].feb_2=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'feb_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].feb_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'feb_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }

                     if(data.rows[i].feb_3!=null)
                     {
                             if(data.rows[i].feb_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'feb_3color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].feb_3=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'feb_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].feb_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'feb_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                     if(data.rows[i].feb_4!=null)
                     {

                                if(data.rows[i].feb_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'feb_4color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].feb_4=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'feb_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].feb_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'feb_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }



                      /// Mar

                       if(data.rows[i].mar_1!=null)
                     {

                                 if(data.rows[i].mar_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'mar_1color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].mar_1=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'mar_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].mar_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'mar_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].mar_2!=null)
                     {

                             if(data.rows[i].mar_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'mar_2color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].mar_2=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'mar_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].mar_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'mar_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].mar_3!=null)
                     {
                             if(data.rows[i].mar_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'mar_3color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].mar_3=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'mar_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].mar_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'mar_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                     if(data.rows[i].mar_4!=null)
                     {

                                if(data.rows[i].mar_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'mar_4color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].mar_4=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'mar_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].mar_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'mar_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }




                       /// Apr

                       if(data.rows[i].apr_1!=null)
                     {

                                 if(data.rows[i].apr_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'apr_1color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].mar_1=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'apr_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].apr_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'apr_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].apr_2!=null)
                     {

                             if(data.rows[i].apr_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'apr_2color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].apr_2=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'apr_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].apr_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'apr_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].apr_3!=null)
                     {
                             if(data.rows[i].apr_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'apr_3color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].apr_3=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'apr_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].apr_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'apr_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                     if(data.rows[i].apr_4!=null)
                     {

                                if(data.rows[i].apr_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'apr_4color', colspan:data.rows[i].SpecWeeks});
                                }else if(data.rows[i].apr_4=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'apr_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 else if(data.rows[i].apr_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'apr_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }



                      /// May

                       if(data.rows[i].may_1!=null)
                     {


                                 if(data.rows[i].may_1=="2" && !SpecStart)
                                {
                              
                                 SpecStart=true;
                                        $(this).datagrid('mergeCells', { index: i, field: 'may_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].may_1=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'may_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].may_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'may_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }

                    if(data.rows[i].may_2!=null)
                     {

                             if(data.rows[i].may_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'may_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].may_2=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'may_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].may_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'may_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].may_3!=null)
                     {
                             if(data.rows[i].may_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'may_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].may_3=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'may_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].may_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'may_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                     if(data.rows[i].may_4!=null)
                     {

                                if(data.rows[i].may_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'may_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].may_4=="3" && !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'may_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].may_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'may_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }



                      // Jun

                       if(data.rows[i].jun_1!=null)
                     {

                                 if(data.rows[i].jun_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jun_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jun_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field:'jun_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jun_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jun_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }

                     if(data.rows[i].jun_1!=null)
                     {

                             if(data.rows[i].jun_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jun_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jun_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jun_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jun_1=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jun_1color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }


                    if(data.rows[i].jun_2!=null)
                     {

                             if(data.rows[i].jun_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jun_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jun_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jun_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jun_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jun_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].jun_3!=null)
                     {
                             if(data.rows[i].jun_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jun_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jun_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jun_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jun_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jun_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].jun_4!=null)
                     {

                                if(data.rows[i].jun_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jun_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jun_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jun_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jun_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jun_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }



                     


                       // Jul

                       if(data.rows[i].jul_1!=null)
                     {

                                 if(data.rows[i].jul_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jul_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jul_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jul_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jul_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jul_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].jul_2!=null)
                     {

                             if(data.rows[i].jul_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jul_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jul_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jul_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jul_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jul_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].jul_3!=null)
                     {
                             if(data.rows[i].jul_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jul_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jul_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jul_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jul_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jul_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].jul_4!=null)
                     {

                                if(data.rows[i].jul_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'jul_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].jul_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'jul_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].jul_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'jul_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }



                        // Aug

                       if(data.rows[i].aug_1!=null)
                     {

                                 if(data.rows[i].aug_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'aug_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].aug_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'aug_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].aug_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'aug_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].aug_2!=null)
                     {

                             if(data.rows[i].aug_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'aug_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].aug_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'aug_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].aug_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'aug_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].aug_3!=null)
                     {
                             if(data.rows[i].aug_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'aug_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].aug_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'aug_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].aug_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'aug_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].aug_4!=null)
                     {

                                if(data.rows[i].aug_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'aug_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].aug_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'aug_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].aug_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'aug_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }


                       // Sep

                       if(data.rows[i].sep_1!=null)
                     {

                                 if(data.rows[i].sep_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'sep_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].sep_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'sep_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].sep_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'sep_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].sep_2!=null)
                     {

                             if(data.rows[i].sep_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'sep_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].sep_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'sep_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].sep_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'sep_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].sep_3!=null)
                     {
                             if(data.rows[i].sep_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'sep_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].sep_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'sep_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].sep_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'sep_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].sep_4!=null)
                     {

                                if(data.rows[i].sep_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'sep_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].sep_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'sep_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].sep_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'sep_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }




                      // Oct

                       if(data.rows[i].oct_1!=null)
                     {

                                 if(data.rows[i].oct_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'oct_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].oct_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'oct_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].oct_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'oct_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].oct_2!=null)
                     {

                             if(data.rows[i].oct_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'oct_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].oct_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'oct_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].oct_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'oct_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].oct_3!=null)
                     {
                             if(data.rows[i].oct_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'oct_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].oct_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'oct_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].oct_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'oct_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].oct_4!=null)
                     {

                                if(data.rows[i].oct_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'oct_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].oct_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'oct_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].oct_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'oct_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }


                      // Nov

                       if(data.rows[i].nov_1!=null)
                     {

                                 if(data.rows[i].nov_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'nov_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].nov_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'nov_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].nov_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'nov_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].nov_2!=null)
                     {

                             if(data.rows[i].nov_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'nov_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].nov_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'nov_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].nov_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'nov_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].nov_3!=null)
                     {
                             if(data.rows[i].nov_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'nov_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].nov_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'nov_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].nov_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'nov_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].nov_4!=null)
                     {

                                if(data.rows[i].nov_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'nov_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].nov_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'nov_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].nov_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'nov_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }


                      // dec

                       if(data.rows[i].dec_1!=null)
                     {

                                 if(data.rows[i].dec_1=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'dec_1color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].dec_1=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'dec_1color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].dec_1=="4"&& !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'dec_1color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }
                    if(data.rows[i].dec_2!=null)
                     {

                             if(data.rows[i].dec_2=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'dec_2color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].dec_2=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'dec_2color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].dec_2=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'dec_2color', colspan:data.rows[i].ActionWeeks});
                                 }


                     }
                     if(data.rows[i].dec_3!=null)
                     {
                             if(data.rows[i].dec_3=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'dec_3color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].dec_3=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'dec_3color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].dec_3=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'dec_3color', colspan:data.rows[i].ActionWeeks});
                                 }

                     }
                        if(data.rows[i].dec_4!=null)
                     {

                                if(data.rows[i].dec_4=="2" && !SpecStart)
                                {
                                 SpecStart=true;
                                         $(this).datagrid('mergeCells', { index: i, field: 'dec_4color', colspan:data.rows[i].SpecWeeks});
                                }
                                 if(data.rows[i].dec_4=="3"&& !POStart)
                                 {
                                 POStart=true;
                                      $(this).datagrid('mergeCells', { index: i, field: 'dec_4color', colspan:data.rows[i].POWeeks});
                                 }
                                 
                                  if(data.rows[i].dec_4=="4" && !ActionStart)
                                {
                                ActionStart=true;
                                     $(this).datagrid('mergeCells', { index: i, field: 'dec_4color', colspan:data.rows[i].ActionWeeks});
                                 }
                     }







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


               $('.lbPlan').text('Spec');
          $('.pbPO').addClass( "invisible" ) 
           $('.pbPO').css("position","absolute");

             $('.divComplete').removeClass( "invisible" )
             $('.divComplete').css("position","relative");

              $('.datetimepicker').disabled();
               $('.txtEventDate').enabled();

                if(lastDate=="") 
               {
                  $('.txtEventDate').val(currentDate);
               $('.txtEventDate').datepicker("update",currentDate);
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

            }else{
            
            $('.btnSaveSpecPO').enabled();
            
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
                                       html+='<td>'+(item.Row_State=='9'?'Edit Plan':"Update Progress")+'</td>';

                                     html+='<td>'+item.Complete+'% '+item.Note+'</td>';

                                        html+='<td>'+item.CreateBy+'</td>';
                                     html+='</tr>';

                              });
            
              $('.tblHistory tbody').append(html);
         //   alert(lastDate)
           

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
                 $('.txtEventDate').val(currentDate);
               $('.txtEventDate').datepicker("update",currentDate);
               }else
               {
              $('.txtEventDate').val(lastDate);
               $('.txtEventDate').datepicker("update",lastDate);

               }
               
              

                 if(obj.IsSaveAction=='0')
            {
               var curInputs =  $(".myPlanSpectPO").find("button[type='button']");
                $('.btnSaveSpecPO').disabled();
                 $('.btnCreateAction').disabled();

            }else{
            
            $('.btnSaveSpecPO').enabled();
              $('.btnCreateAction').enabled();
            
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


               $('.lbPlan').text('PO');

           $('.pbPO').removeClass( "invisible" )
             $('.pbPO').css("position","relative");


              $('.divComplete').addClass( "invisible" ) 
           $('.divComplete').css("position","absolute");

           $('.txtEventDate').enabled();
         
              if(lastDate=="") 
               {
                  $('.txtEventDate').val(currentDate);
               $('.txtEventDate').datepicker("update",currentDate);
               }else
               {
              $('.txtEventDate').val(lastDate);
               $('.txtEventDate').datepicker("update",lastDate);

               }
           

         
               if(obj.IsSavePO=='0')
            {
               var curInputs =  $(".myPlanSpectPO").find("button[type='button']");
                $('.btnSaveSpecPO').disabled();

            }else{
            
            $('.btnSaveSpecPO').enabled();
            
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

       
                      
                    if (value == "" && editplan=='1') {
                        return '<a onclick="Action(\'TimeLine\',' + row.PID + ')" href="#"><span class="btn btn-success btn-lg">Timeline</span></a>';
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
        
        if(createplan=="1" && row.IsSave=="1")
        {
        // if (value == "1") {
               
                return '<a onclick="Action(\'Edit\',' + row.PID + ')" href="#"><span class="btn btn-success btn-lg">Edit</span></a>';

            }

             return "";

        }

         function deleteFormat(value, row, index) {
        
        if(createplan=="1" && row.IsSave=="1")
        {
        // if (value == "1") {
               
                return '<a onclick="Action(\'Delete\',' + row.PID + ')" href="#"><span class="btn btn-danger btn-lg">Delete</span></a>';

            }

             return "";

        }

        

        function weekFormat(value, row, index) {

             var planType=value!=null ? value.split('_')[0] : "";
                var planColor=value!=null ? value.split('_')[1] : "";

            //console.log(index);
            if (planType == "1") {
                return "";
            } else if (planType == "2") {
            return '<a href="#" onclick="Action(\'spec\',' + row.PID + ',' + row.Progress + ')" class="easyui-linkbutton" iconCls="icon-remove" plain="true" >Spec<br>('+row.SpecComplete+'%)</a></center>';
                 //return '<center><a onclick="Action('+index+')" href="#"><span class="btn btn-primary btn-xs"><i class="fa fa-search"></i> PO</span></a>';
                // <a href="' + dhref + '" class="easyui-linkbutton" iconCls="icon-remove" plain="true" >Remove Entry</a></center>';
            } else if (planType == "3") {
                return '<a href="#" onclick="Action(\'po\',' + row.PID + ',' + row.Progress + ')" class="easyui-linkbutton" iconCls="icon-remove" plain="true" >PO<br>('+row.POComplete+'%)</a></center>';
            } else if (planType == "4") {
                  return '<a href="#" onclick="Action(\'action\',' + row.PID + ',' + row.Progress + ')" class="easyui-linkbutton" iconCls="icon-remove" plain="true" >Action<br>('+row.ActionComplete+'%)</a></center>';
            }
             else if (planType == "0") {
                  return '<a onclick="Action(\'timeline\',' + row.PID + ')" href="#"><span class="btn btn-primary btn-xs">Timeline</span></a>';
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
                return "<span style='color:red'>High</span>";
            } else if (value == "0") {
                return "<span style='color:gray'>Low</span>";
            }
        }