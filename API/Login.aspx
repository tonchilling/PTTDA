<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<link href="<%= ResolveUrl("~/css/bootstrap.min.css") %>" rel="stylesheet">


   
  <!-- Custom fonts for this template-->
  <link href="<%= ResolveUrl("~/css/font-awesome.min.css") %>" rel="stylesheet" type="text/css">

    <link href="<%= ResolveUrl("~/css/bootstrap-glyphicons.css") %>" rel="stylesheet" type="text/css">
  <!-- Page level plugin CSS-->
  <link href="<%= ResolveUrl("~/css/dataTables.bootstrap4.css") %>" rel="stylesheet">
  <!-- Custom styles for this template-->
  <link href="<%= ResolveUrl("~/css/sb-adminNew.css") %>" rel="stylesheet">
   
    <link href="<%= ResolveUrl("~/Css/boostrap-confirm.css") %>" rel="stylesheet" type="text/css" />

<!-- Latest compiled and minified JavaScript -->
  <link href="<%= ResolveUrl("~/Css/bootstrap2.3.1.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Css/boostrap-selectpicker.css") %>" rel="stylesheet" type="text/css" />
     <link href="<%= ResolveUrl("~/Css/boostrap.select2.css") %>" rel="stylesheet" type="text/css" />
   
    <link href="<%= ResolveUrl("~/Css/ModalAnimation.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Css/bootstrap-treemenu.css") %>" rel="stylesheet" type="text/css" />
   
  <script src="<%= ResolveUrl("~/js/jquery.min.js") %>"></script>
        <script src="<%= ResolveUrl("~/Js/boostrap-select.js") %>" type="text/javascript"></script>
         <script src="<%= ResolveUrl("~/js/bootstrap.bundle.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Js/boostrap-confirm.js") %>" type="text/javascript"></script>
        <script src="<%= ResolveUrl("~/Js/bootstrap-waitingDialog.js") %>" type="text/javascript"></script>

    

    <script src="Js/boostrap.validation.js" type="text/javascript"></script>
        <script type="text/javascript">
            var index = '<%= ResolveUrl("~/UI/Index.aspx") %>';
              var currentURL= "<%= ResolveUrl("~/ASHX/Admin/AccountEditHandler.ashx") %>"; 

              var userType='1';
            $(document).ready(function () {


                $('#radioBtn a').on('click', function () {
                    var sel = $(this).data('title');
                    var tog = $(this).data('toggle');
                    $('#' + tog).prop('value', sel);

                    userType=sel;
                    $('a[data-toggle="' + tog + '"]').not('[data-title="' + sel + '"]').removeClass('active').addClass('notActive');
                    $('a[data-toggle="' + tog + '"][data-title="' + sel + '"]').removeClass('notActive').addClass('active');
                })
             



            });






     

            $(document).on("click", ".toggle-group", function (e) {
                var hasErrors = $('#form1').validator('validate').has('.has-error').length;


                if (hasErrors) {
                    e.stopPropagation();
                }
            });

            $(document).on("change", ".chkStatus", function (e) {

                if ($(this).prop('checked')) {
                    
                    waitingDialog.show('Access to System', { dialogSize: 'lg', progressType: 'primary' });

                       var form = $('form:first'); // You need to use standard javascript object here
                        var formData = new FormData(form);
                         formData.append("UserLogin",$('.txtUserLogin').val());
                           formData.append("Password",$('.txtPassword').val());
                           formData.append("UserType",userType)
                           formData.append("Action", "Login");
                           formData.append("PTTDAToken", $('#antiforgery').val());


                    $.ajax({
                        url: currentURL,
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {

               if (result != "") {
                                    var obj = JSON.parse(result);
                            
                                    if (obj != null)
                                    {
                                        console.log("LDAP:" + obj.LDAP + " UserLogin" + obj.UserLogin)
                                       // alert("LDAP:" + obj.LDAP + " UserLogin" + obj.UserLogin);
                                    }
                                    console.log("LDAP:" + obj.LDAP )
                                    
                                    if (obj.UserLogin != null && obj.LDAP) {
                                        $.post(index, $('#frmLogin').serialize())
                                        setTimeout(function () {
                                            $('#frmLogin').attr('action', index);
                                            $('#frmLogin').submit();
                                           
                                          //  window.location.href = index;
                                        }, 3000);
                                    } else {
                                      

                                        $.alert({
                                            title: "LOGIN",
                                            content: "Invalid UserName/Password",
                                            type: 'red',
                                            animation: "RotateX",
                                            typeAnimated: true,
                                        });
                                        setTimeout(function () {
                                            $('.chkStatus').bootstrapToggle('off')
                                            waitingDialog.hide();
                                        }, 1000);

                                      


                                    }

                           }
                           else{

                   $.alert({
                       title: "LOGIN",
                       content: "Invalid UserName/Password",
                       type: 'red',
                       animation: "RotateX",
                       typeAnimated: true,
                   });
                   setTimeout(function () {
                       $('.chkStatus').bootstrapToggle('off')
                       waitingDialog.hide();
                   }, 1000);

               

                           }
                           
                    },

          error: function (response, a, b) {
                             $.alert({
                               title: "LOGIN",
                               content: response.statusText,
                                  type: 'red',
            animation: "RotateX",
            typeAnimated: true,
                                        });
                                        setTimeout(function () {
                                            $('.chkStatus').bootstrapToggle('off')
                                            waitingDialog.hide();
                                        }, 1000);
                                       
      //  alert(response.status + " " + response.statusText);
    }
         });


                }

            });
        </script>


        <style type="text/css">
        
        
        .login-block{
    background: #29b7ec;  /* fallback for old browsers */
background: -webkit-linear-gradient(to bottom, #b6e2fe, #3e96ce);  /* Chrome 10-25, Safari 5.1-6 */
background: linear-gradient(to bottom, #b6e2fe, #3e96ce); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
float:left;
width:100%;
 min-height: 100vh;
 padding:80px 0;

}
.banner-sec{background:url(https://static.pexels.com/photos/33972/pexels-photo.jpg)  no-repeat left bottom; background-size:cover; min-height:500px; border-radius: 0 10px 10px 0; padding:0;}

           
           .loginSection
           {
           	
           	 background: #208fd5;  /* fallback for old browsers */
            background: -webkit-linear-gradient(to bottom, #0a6aa6, #208fd5);  /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to bottom, #0a6aa6, #208fd5); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
           
           	}
.carousel-inner{border-radius:0 10px 10px 0;
               
                }
.carousel-caption{text-align:left; left:5%;}
.login-sec{padding: 50px 30px; position:relative; color:#ffffff;}
.login-sec .copy-text{position:absolute; width:80%; bottom:20px; font-size:13px; text-align:center;}
.login-sec .copy-text i{color:#FEB58A;}
.login-sec .copy-text a{color:#E36262;}
.login-sec h2{margin-bottom:30px; font-weight:800; font-size:40px; color: #ffffff;}

.login-sec h2:after{content:" "; width:100px; height:5px; background:#FEB58A; display:block; margin-top:20px; border-radius:3px; margin-left:auto;margin-right:auto}
.btn-login{background: #DE6262; color:#fff; font-weight:600;}
.banner-text{width:70%; position:absolute; bottom:40px; padding-left:20px;}
.banner-text h2{color:#fff; font-weight:600;}
.banner-text span.headerText {color:#29b7ec; font-size:26px; margin-top:10;}
.banner-text h2:after{content:" "; width:100px; height:5px; background:#FFF; display:block; margin-top:20px; border-radius:3px;}
.banner-text p{color:#fff;}
      
      
        
        input.form-control:focus
        {
        	-webkit-box-shadow: -1px -1px 74px 0px rgba(255,255,255,1);
-moz-box-shadow: -1px -1px 74px 0px rgba(255,255,255,1);
box-shadow: -1px -1px 74px 0px rgba(255,255,255,1);
        	}
        	
        	.banner-text
        	{
        		 background-color: rgba(98, 191, 52, 0.4);
        		 right:20%;
        		 left:0;
        		 width:100%;
        		}
        		
        		
 #radioBtn .notActive{
    color: #3276b1;
    background-color: #fff;
}


#radioBtn a
{
	font-size:20px;
	}
        </style>

</head>
<body>
    <form id="frmLogin"   method="post"  runat="server">
   
   <div class="login-block">
       <div class="container loginSection">
	<div class="row">
		<div class="col-md-4 login-sec">
		    <h2 class="text-center">LOGIN</h2>
		    <form class="login-form" method="post">
            <div class="row">
            
                <div class="form-group input-group ">
  <span class="input-group-addon" id="Span3">USER TYPE</span>
  <div id="radioBtn" class="btn-group">
 	               <a class="btn btn-success btn-sm active" data-toggle="fun" aria-describedby="basic-addon1" data-title="1">PTT PLC</a>
                        <a class="btn btn-success btn-sm notActive" data-toggle="fun" aria-describedby="basic-addon1" data-title="2">BSA</a>
    					<a class="btn btn-success btn-sm notActive" data-toggle="fun" aria-describedby="basic-addon1" data-title="3">Other</a>
                        </div>
                        <input type="hidden" name="fun" id="Hidden1">
</div>
            </div>
          
          
            <div class="row">
              <div class="form-group input-group ">
  <span class="input-group-addon" id="basic-addon1" style="width:110px">USER</span>
  <input id="txtUserLogin" type="text" required class="form-control txtUserLogin" data="" placeholder="User Name" aria-label="Menu"
   aria-describedby="basic-addon1">
</div>
            </div>

   <div class="row">
              <div class="form-group input-group ">
  <span class="input-group-addon" id="Span1">PASSWORD</span>
  <input id="txtPassword" type="password" required class="form-control txtPassword" AUTOCOMPLETE="off" data="" placeholder="Password"
   aria-label="Menu"  aria-describedby="basic-addon1">
</div>
            </div>
  
  
    <div class="form-check row">
    <div class="col-sm-8">
    <label class="form-check-label">
     
      <a href="#">Forget Password</a>
    </label>
    </div>
    <div class="col-sm-4">
    <input type="checkbox" id="chkStatus" class="chkStatus" style="width:100px;" data-toggle="toggle" data-on="LOGIN" data-off="LOGIN">


 </div>
  </div>
               </form>

<div class="copy-text"></div>
		</div>
		<div class="col-md-8 banner-sec">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                 
            <div class="carousel-inner" role="listbox">
    <div class="carousel-item active">
    <div>
      <img class="img-fluid" src="<%= ResolveUrl("~/Img/ptt0.jpg") %>" >
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text pull-right">
            
    <img src="Img/pttlogo.png" /> <span class="headerText">PTT Direct Accessment</span>
            <p>คือระบบบริหารและจัดการรายการขุดซ่อม Coating และท่อส่งก๊าซ สามารถรวบรวมข้อมูลการขุดซ่อมโดยจัดกลุ่มตามรายท่อส่งก๊าซ</p>
        </div>	
  </div>

    </div>
    </div>

    <!--
    <div class="carousel-item">
     <img class="img-fluid" src="<%= ResolveUrl("~/Img/ptt1.jpg") %>" >
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text">
           <img src="Img/pttlogo.png" /> <span class="headerText">PTT Direct Accessment</span>
            <p>ปรับปรุงระบบการจัดการงานขุดซ่อมท่อส่งก๊าซ ให้มีรูปแบบที่ทันสมัยและใช้งานง่าย เพื่อเพิ่มความสะดวกรวดเร็วในการรวบรวมเอกสารให้มีประสิทธิภาพ</p>
           
        </div>	
    </div>
    </div>
    <div class="carousel-item">
     <img class="img-fluid" src="<%= ResolveUrl("~/Img/ptt2.jpg") %>" >
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text">
         <img src="Img/pttlogo.png" /> <span class="headerText">PTT Direct Accessment</span>
            <p>เชื่อมต่อกับฐานข้อมูลท่อของฝ่ายวิศวกรรมและบำรุงรักษาระบบท่อส่งก๊าซธรรมชาติ</p>
        </div>	
    </div>
  </div>

  -->
            </div>	   
		    
		</div>
	</div>
</div>
</div>
          <asp:HiddenField ID="antiforgery" runat="server"/>
       </div>
    </form>
</body>
</html>
