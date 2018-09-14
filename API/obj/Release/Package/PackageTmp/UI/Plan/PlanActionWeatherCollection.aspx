<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" 
AutoEventWireup="true" CodeFile="PlanActionWeatherCollection.aspx.cs" Inherits="UI_Plan_PlanActionWeatherCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
      
<style  type="text/css">

.login-signup {
  padding: 0 0 25px;
}



ul {
  list-style-type: none;
}

article[role="login"] {
   background: -webkit-linear-gradient(#ffffff, #f3f2f2);
			 background: -moz-linear-gradient(#ffffff, #f3f2f2);
			background:linear-gradient(#ffffff, #f3f2f2);
			color:#000000;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  -webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 10px rgba(0, 0, 0, 0.24);
  webkit-transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  padding: 30px 50px;
  margin-bottom: 20px;
}

article[role="login"] input[type="submit"] {
  padding: 10px 15px;
  font-size: 16px;
}

article[role="login"]:hover {
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
  -webkit-box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19), 0 1px 15px rgba(0, 0, 0, 0.23);
  webkit-transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
  transition: all 400ms cubic-bezier(0.4, 0, 0.2, 1);
}

article[role="login"] h3 {
  font-size: 26px;
  font-weight: 300;
  color: #23bab5;
  margin-bottom: 20px;
}

article[role="login"] p {
  font-size: 16px;
  padding: 5px 15px;
}

.nav-tab-holder {
  padding: 0 0 0 30px;
  float: right;
}

.nav-tab-holder .nav-tabs {
  border: 0;
  float: none;
  display: table;
  table-layout: fixed;
  width: 100%;
}

.nav-tab-holder .nav-tabs > li {
  margin-bottom: -3px;
  text-align: center;
  padding: 0;
  display: table-cell;
  float: none;
  padding: 1px;
}

.nav-tab-holder .nav-tabs > li > a {
  background: #d9d9d9;
  color: #6c6c6c;
  margin: 0;
  font-size: 18px;
  font-weight: 300;
}

.nav-tab-holder .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
  color: #FFF;
  background-color: #23bab5;
  border: 0;
  border-radius: 0;
}





.mobile-pull {
  float: right;
}

article[role="manufacturer"] {
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  -webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 10px rgba(0, 0, 0, 0.24);
  padding: 0 0 40px;
  max-width: 420px;
  margin: -45px auto 0;
}

article[role="manufacturer"] header {
  background: #23bab5;
  color: #fff;
  padding: 10px;
  font-size: 18px;
  font-weight: 300;
}

article[role="manufacturer"] h1 {
  font-size: 26px;
  font-weight: 300;
  border-bottom: 1px solid #f2f2f2;
  padding: 25px 15px;
}

article[role="manufacturer"] ul {
  padding: 0 25px;
}

article[role="manufacturer"] ul li {
  font-size: 16px;
  border-bottom: 1px solid #eaeaea;
  padding: 20px 15px;
  color:#404040;
}

article[role="manufacturer"] ul li i {
  color: #23bab5;
}

.login-signup {
  padding: 0 0 25px;
}

@media only screen and (max-width: 767px) {
  .mobile-pull {
    float: none;
  }

  .nav-tab-holder {
    float: none;
    overflow: hidden;
  }

  .nav-tabs > li > a {
    font-size: 13px;
    font-weight: 600;
    padding: 10px 5px;
    overflow: hidden;
    text-overflow: ellipsis;
  }

  .nav-tabs > li {
    width: 50%;
  }
}

.dropdown-menu
{
	/* background-color:#17a2b8 !important;*/
	 color:#000;
	}
	
	
	legend:before {
      content: counter(fieldset);
      counter-increment: fieldset;
      position: absolute;
      left: -25px;
      width: 30px;
      height: 30px;
      line-height: 30px;
      border-radius: 15px;
      text-align: center;
      background: $brand-primary;
      color: white;
      font-size: 75%;
      font-weight: bold;
    }
    
    
    
.btn .badge {
    position: relative;
    top: -1px;
    float: right;
}


img.xbox {
    border: 1px solid #ddd;
    border-radius: 4px;
    padding: 5px;
    width: 90%;
     box-shadow: 0 4px 8px 0 #ccc, 0 6px 20px 0 #ccc;
      box-shadow:  0 4px 8px 0 #ccc, 0 6px 20px 0 #ccc;
  -webkit-box-shadow:  0 4px 8px 0 #ccc, 0 6px 20px 0 #ccc;
  -moz-box-shadow:  0 4px 8px 0 #ccc, 0 6px 20px 0 #ccc;
  
}






.btn-circle-lg {
  width: 209px;
  height: 209px;
  text-align: center;
  padding: 13px 0;
  font-size: 30px;
  line-height: 2.00;
  border-radius: 200px;
  position:absolute;
}
 
 
 
 .chk-lg {
    width: 60px;
    height: 60px;
    cursor: pointer;
    color:#333333;
}

    .modal:nth-of-type(even) {
    z-index: 1042 !important;
}
.modal-backdrop.in:nth-of-type(even) {
    z-index: 1041 !important;
}



 .datepicker {
      z-index: 1600 !important; /* has to be larger than 1050 */
    }


    .imgWeather
    {
    	 cursor:pointer;
    	}
    
</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_WeatherCollectionHandler.ashx") %>"; 
 
 </script>

   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_WeatherCollection.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
  <div class="container-fluid">

  <div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i>  Action </div>
     <div class="card-body">


    

     <div class="row">
      <div class="col-sm-12">
     <div class="login-signup">
      <div class="row">
        <div class="col-sm-12 nav-tab-holder">
        <ul class="nav nav-tabs row" role="tablist">
          <li role="presentation" class=" col-sm-2"><a  href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteSurvey.aspx") %>" >Site Survey & Digging Location</a></li>
          <li role="presentation" class=" col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSitePreparation.aspx") %>" >Site Preparation <br>&nbsp;</a></li>
            <li role="presentation" class="active col-sm-2"><a href="#">Weather Collection <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>" >Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>">After Coating Removal<br>&nbsp;</a></li>
                <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAppliedCoating.aspx") %>" >Applied Coating<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterAppliedCoating.aspx") %>">After Applied Coating<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionSiteRecovery.aspx") %>" >Site Reovery<br>&nbsp;</a></li>
        </ul>
      </div>

      </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="CreatingPlan">
          <div class="row ">

            <div class="col-sm-12 mobile-pull ">
              <article role="login" >
                <h3 class="text-center"><i class="fa fa-lock"></i>Weather Collection</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Environment Condition</h4>
                    </div>
    <div class="card-body">

        <div class="row" style="padding-top:10px;">
        <div class="col-sm-12">
                   <input type="button" class="btn btn-lg btn-primary   btnAdd pull-right" style="margin-right:15px;" value="เพิ่ม" style="" />
                 </div>
        </div>

         <div class="row" style="padding-top:10px;">
            
               <div class="col-sm-12">
               
                <div class="table-responsive divMainTable">
            <table class="table table-bordered table-blue" id="Table2" width="100%" cellspacing="0">
              <thead>
                <tr>
                 
             
                   <th>Date Time</th>
                    <th>Wet Temp(&#8451;)</th>
                  <th>Dry Temp(c)</th>
                 
                   <th>Steel Surface Temp(c)</th>
                  <th>Dew Point(c)</th>
                  <th>Relative Humidity(%)</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                  
                
                </tr>
              </thead>
              <tfoot>
                <tr>
                         <th>Date Time</th>
                    <th>Wet Temp( ํc)</th>
                  <th>Dry Temp(c)</th>
                   <th>Steel Surface Temp( ํc)</th>
                  <th>Dew Point( ํc)</th>
                  <th>Relative Humidity(%)</th>
                  <th>EDIT</th>
                  <th>DELETE</th>
                
                </tr>
              </tfoot>
              <tbody>
               

              </tbody>
            </table>
          </div>


               </div>
             </div>
            <div class="row" style="padding-top:10px;">
            <div class="col-sm-3">
           <div class="row"> 
            <div class="col-sm-12">
                 <span class="important-message">Acceptable Condition</span> : Steel Surface Temp -  Dew Point > 5F/ 3C  ; %RH < 85%
                 </div>
                 </div>
           <div class="row">
           <div class="col-sm-12">
           <span class="important-message">Note</span> : Check before, interval and after coating application</div>
            </div>
            </div>
             <div class="col-sm-9 text-right">
               <div class="table-responsive">
          

             <img src="<%=ResolveUrl("~/Img/psychrome.jpg")  %>" class="xbox imgWeather" />


           
          </div>
          
             </div>
             </div>
 

    </div>
    </div>

    </div>
    </div>
     
                   

            

              </article>
            </div>

         
          </div>

        
          <!-- end of row -->
        </div>
        <!-- end of home -->

     
    

       

  </div>
  </div>
  </div>
     </div>


       
     </div>
     </div>
     </div>


<!--Modal-->



 <div class="modal myModal1 fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
   <div class="modal-content">
    
      <div class="modal-header header-blue">
        <h5 class="modal-title" id="H2"> <i class="glyphicon glyphicon-globe  fa-2x " style="color:#1363a7"></i> Enviromment</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body setup-content">
        


        <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
      <div class="col-sm-4">
           
<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span51" >Collect Date</span>
    <input type="text" class="form-control datetimepicker  txtCollectDate" id="txtCollectDate">

    <div class="input-group-addon">
        <span class="glyphicon glyphicon-th"></span>
    </div>
</div>
          </div>
           <div class="col-sm-3">
           
<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span1" >Hour</span>
     <select   class="form-control ddlCollectHour" id="ddlCollectHour"  >
    
  </select>
</div>
          </div>
               <div class="col-sm-3">
           
<div class="input-group date"  data-provide="datepicker">
<span class="input-group-addon" id="Span2" >Minute</span>
     <select   class="form-control ddlCollectMinute" id="ddlCollectMinute"  >
    
  </select>
</div>
          </div>
          </div>



             <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
     <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span34">Dry Temp( &#8451; ) </span>
    <input   class="form-control txtDryTemp  " type='text' id="txtDryTemp"  />
   
</div>
          </div>

    </div>
          <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span35">Wet Temp( &#8451; ) </span>
    <input   class="form-control txtWetTemp" type='text' id="txtWetTemp"  />
   
</div>
          </div>
          </div>

           <div class="row" style="padding-top:10px;">

    <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span36">Steel Surface Temp( &#8451; ) </span>
    <input   class="form-control txtSteelSurfaceTemp" type='text' id="txtSteelSurfaceTemp"  />
   
</div>
          </div>
          </div>

            <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span37" >Dew Point( &#8451; )</span>
     <input   class="form-control txtDewPoint" type="text" id="txtDewPoint"  />
   

</div>
          </div>

            

          
          </div>
             <div class="row" style="padding-top:10px;">

          
           <div  class="col-sm-1"></div>
            <div class="col-sm-10">
           <div class="input-group">
  <span class="input-group-addon" id="Span38" >Relative Humidity(%) :</span>
     <input   class="form-control txtRelativeHumidity" type='text' id="txtRelativeHumidity"  />
   

</div>
          </div>

            

          
          </div>
         
         
          


      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-lg bg-success btnSave">บันทึก</button>
        <button type="button" class="btn btn-lg btn-default" data-dismiss="modal">ปิด</button>
      
      
      </div>
    </div>
  </div>
</div>
<!-- End Modal-->
</asp:Content>

