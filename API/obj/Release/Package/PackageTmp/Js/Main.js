
var allValid={};
var isValid = true;
function LoadDropDownList(objControl, tablename,selectValue) {


    var formData = new FormData();
    formData.append("table", tablename);


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                  //  $(objControl).append($("<option></option>").val
                    $(objControl).append("<option value='" + item.Value + "'" + ((selectValue == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");

               // (item.Value).html(item.Name));


                });
            }


        },
        error: function (Result) {
            alert("Error");
        }
    });

}


function LoadRegionDropDownList(objControl, RegionID, PipelineID, AssetOwnerID, RouteID) {


    var formData = new FormData();
    formData.append("DropDrownType", 'Region');
    formData.append("PipelineID", PipelineID);
    formData.append("AssetOwnerID", AssetOwnerID);
    formData.append("RouteID", RouteID);


    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    $(objControl).append("<option value='" + item.Value + "'" + ((RegionID == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");


                });
            }


            objControl.enabled();

        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}



function LoadTypeOfPipelineDropDownList(objControl, RegionID, PipelineID, AssetOwnerID, RouteID,enabled) {


    var formData = new FormData();
    formData.append("DropDrownType", 'TypeOfPipeline');
    formData.append("RegionID", RegionID);
    formData.append("RouteID", RouteID);
    formData.append("AssetOwnerID", AssetOwnerID);

    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    $(objControl).append("<option value='" + item.Value + "'" + ((PipelineID == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");


                });
            }

            if (enabled == null) {
                objControl.enabled();
            } else if (enabled) {
                objControl.enabled();
            }


        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}


function LoadRouteCodeDropDownList(objControl, RegionID, PipelineID, AssetOwnerID, RouteID) {


    var formData = new FormData();
    formData.append("DropDrownType", 'RouteCode');
    formData.append("RegionID", RegionID);
    formData.append("PipelineID", PipelineID);
    formData.append("AssetOwnerID", AssetOwnerID);
    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    //  $(objControl).append($("<option></option>").val
                    $(objControl).append("<option value='" + item.Value + "'" + ((RouteID == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");

                    // (item.Value).html(item.Name));


                });
            }


            objControl.enabled();

        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}


function LoadRouteCodeByRegionAndPipelineDropDownList(objControl, RegionID, PipelineID,AssetOwnerID, selectValue) {


    var formData = new FormData();
    formData.append("DropDrownType", 'RouteCodeByPipeline');
    formData.append("RegionID", RegionID);
    formData.append("PipelineID", PipelineID);
    formData.append("AssetOwnerID", AssetOwnerID);
    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    $(objControl).append("<option value='" + item.Value + "'" + ((selectValue == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");



                });
            }
            objControl.enabled();

        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}




function LoadAssetOwnerDropDownList(objControl, RegionID, PipelineID, AssetOwnerID, RouteID) {


    var formData = new FormData();
    formData.append("DropDrownType", 'AssetOwner');
    formData.append("RegionID", RegionID);
    formData.append("PipelineID", PipelineID);
    formData.append("RouteID", RouteID);

    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    //  $(objControl).append($("<option></option>").val
                    $(objControl).append("<option value='" + item.Value + "'" + ((AssetOwnerID == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");

                    // (item.Value).html(item.Name));


                });
            }

            objControl.enabled();
        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}



function LoadAssetOwnerByRouteCodeDropDownList(objControl,RegionID,PipelineID, RouteID, selectValue) {


    var formData = new FormData();
    formData.append("DropDrownType", 'AssetOwnerByRouteCode');
    formData.append("RegionID", RegionID);
    formData.append("PipelineID", PipelineID);
    formData.append("RouteID", RouteID);

    objControl.disabled();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: DropDownListURL,
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {

            objControl.empty();

            $(objControl).append($("<option></option>").val
                ("").html("Please select"));

            if (result != null && result != "") {
                var obj = JSON.parse(result)
                $.each(obj, function (key, item) {
                    //  $(objControl).append($("<option></option>").val
                    $(objControl).append("<option value='" + item.Value + "'" + ((selectValue == item.Value ? "selected" : "")) + ">" + item.Name + "</option>");

                    // (item.Value).html(item.Name));


                });
            }
            objControl.enabled();

        },
        error: function (Result) {
            objControl.enabled();
            alert("Error");
        }
    });

}



var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? '' : sParameterName[1];
        }
    }
};


//----------------------------- Validate numeric ----------------------------------------------//





(function ($) {

 $.fn.IsError = function (error) 
      {
      var msg =error!='undefined'? error:'Invalid filed';
        var input = $(this);
          input.removeClass("valid").addClass("invalid");
          if(!input.closest("div").find( "span" ).hasClass('error'))
                                {
                                input.closest("div").append("<span class='error'>"+msg+"</span>");  
                                }else{
                                 input.closest("div").find('.error').text(msg);
                                }
                            input.closest("div").find('.error').css("display", "block");
      };


    $.fn.IsNumeric = function (min,max) 
      {
         
      
              //  $(document).on('input', +$(this).attr('class').split(' ')[1], function() {
              $(this).on("input", function() {
              
                      var input = $(this);
                    
                 
                        if (input.val()!="" && !$.isNumeric(input.val())) {
                                input.removeClass("valid").addClass("invalid");
                               
                                if(!input.closest("div").find( "span" ).hasClass('error'))
                                {
                                input.closest("div").append("<span class='error'>This field is numeric</span>");  
                                }else{
                                 input.closest("div").find('.error').text("This field is numeric");
                                }
                            input.closest("div").find('.error').css("display", "block");
                             isValid=false;
                            return isValid;
                     } else if (input.val()!="" && min!=null && max!=null) {
                         var input = $(this);
                       
                           if (parseInt(input.val())<0 || parseInt(input.val())>100  ) {
                                    input.removeClass("valid").addClass("invalid");

                                    if(!input.closest("div").find( "span" ).hasClass('error'))
                                {
                                input.closest("div").append("<span class='error'>This field beetween "+min+"-"+max+"</span>");  
                                }else{
                                 input.closest("div").find('.error').text("This field beetween "+min+"-"+ max);
                                }
                            input.closest("div").find('.error').css("display", "block");
                             isValid=false;
                            return isValid;
                     
                            }else{

                              input.removeClass("invalid").addClass("valid");
                                input.closest("div").find('.error').css("display", "none");
                                isValid=true;
                                  return isValid;
                            
                            }

                     } else if (input.val()!="") {
                                 input.removeClass("invalid").addClass("valid");
                                input.closest("div").find('.error').css("display", "none");
                                isValid=true;
                                  return isValid;
                    } else{
                                 input.removeClass("invalid");
                                   input.closest("div").find('.error').css("display", "none");
                    }

                    });

    };
})(jQuery);




//----------------------------- Validate numeric ----------------------------------------------//


var formErrMsg = '*Please verify input data!';
var requireMsg = 'This field is require';
var numericErrMsg = 'This field is numeric';

function validateFormInput() {
    var isSuccess = true;
    $("form").each(function () {
        var allInput = $(this).find(':input');


        allInput.each(function () {
            var obj = $(this);
            if (!validateInputObj(obj)) {
                isSuccess = false;
            }
        });
    });
    if (isSuccess) {
        $('#main_page_error').html('');
    } else {
        $('#main_page_error').html(formErrMsg);
    }
    return isSuccess;
}

function validateInput(elementID) {
    $('#' + elementID + ' *').filter(':input').each(function () {
        var obj = $(this);
        if (!validateInputObj(obj)) {
            isSuccess = false;
        }
    });
}

function validateInputObj(obj) {
    var isSuccess = true;
    if (obj.hasClass("require")) {
        console.log('obj -->', obj);
        if (obj.attr('type') == 'text') {
            if (!validateText(obj)) {
                isSuccess = false;
            }
        } else if (obj.is("select")) {
            if (!validateSelectOne(obj)) {
                isSuccess = false;
            }
        } else if (obj.is("textarea")) {
            if (!validateTextArea(obj)) {
                isSuccess = false;
            }
        }
    }
    return isSuccess;
}

function validateText(obj) {
    obj.removeClass("invalid");
    obj.closest("div").find('.error').remove();
    if (obj.val() == null || obj.val() == '') {
        obj.addClass("invalid");
        obj.closest("div").append("<br><span class='error'>" + requireMsg + "</span>");
        obj.closest("div").find('.error').css("display", "block");
        return false;
    } else if (obj.hasClass("numeric")) {
        if (!$.isNumeric(obj.val())) {
            obj.addClass("invalid");
            obj.closest("div").append("<br><span class='error'>" + numericErrMsg + "</span>");
            obj.closest("div").find('.error').css("display", "block");
            return false;
        }
    }
    return true;
}

function validateSelectOne(obj) {
    obj.removeClass("invalid");
    obj.closest("div").find('.error').remove();
    if (obj.val() == null || obj.val() == '') {
        obj.addClass("invalid");
        obj.closest("div").append("<br><span class='error'>" + requireMsg + "</span>");
        obj.closest("div").find('.error').css("display", "block");
        return false;
    } 
    return true;
}

function validateTextArea(obj) {
    obj.removeClass("invalid");
    obj.closest("div").find('.error').remove();
    if (obj.val() == null || obj.val() == '') {
        obj.addClass("invalid");
        obj.closest("div").append("<span class='error'>" + requireMsg + "</span>");
        obj.closest("div").find('.error').css("display", "block");
        return false;
    }
    return true;
}

