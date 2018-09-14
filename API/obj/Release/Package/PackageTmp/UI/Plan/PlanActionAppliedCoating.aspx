<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PlanActionAppliedCoating.aspx.cs" Inherits="UI_Plan_PlanActionAppliedCoating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="<%= ResolveUrl("~/Css/bootstrap.fd.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Js/bootstrap.fd.js") %>" type="text/javascript"></script>
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



</style>
    <link href="<%= ResolveUrl("~/Css/datepicker.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%= ResolveUrl("~/Js/bootstrap-datepicker.js") %>" type="text/javascript"></script>

  <script src="<%= ResolveUrl("~/Js/ui/Plan/T_Planing_Action_AppliedCoating.js") %>" type="text/javascript"></script>
<script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/Plan/T_Planing_Action_AppliedCoatingHandler.ashx") %>"; 
     var fileList1,fileList2;
    var fileAll1,fileAll2;
    var realFiles1=[];
      var realFiles2=[];
    
   
    </script>


   

 <script src="<%= ResolveUrl("~/Js/ui/Plan/PlanEdit.js") %>" type="text/javascript"></script>
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
          <li role="presentation" class=" col-sm-2"><a href="#" >Site Preparation <br>&nbsp;</a></li>
            <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionWeatherCollection.aspx") %>"  >Weather Collection <br>&nbsp;</a></li>
             <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionBeforeCoatingRemoval.aspx") %>" >Before Coating Removal<br>&nbsp;</a></li>
              <li role="presentation" class="col-sm-2"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAfterCoatingRemoval.aspx") %>">After Coating Removal<br>&nbsp;</a></li>
                <li role="presentation" class="col-sm-2 active"><a href="<%= ResolveUrl("~/UI/Plan/PlanActionAppliedCoating.aspx") %>">Applied Coating<br>&nbsp;</a></li>
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
                <h3 class="text-center"><i class="fa fa-lock"></i>Applied Coating</h3>
   
                    <div class="row ">
                   
                    <div class="col-sm-11">
                    

                    <div class="card">
                    <div class="card-header">
                     <h4 class="text-left">Surface Profile</h4>
                    </div>
    <div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
           <h5 class="text-left">Surface Profile Equipment</h5>
          </div>

           <div class="col-sm-3">
             <div class="input-group">
  <span class="input-group-addon" id="Span1">Brand</span>
     <input type="text"    class="form-control txtSurfaceBrand" placeholder="Brand " id="txtSurfaceBrand"  />
</div>
           </div>
             <div class="col-sm-3">
              <div class="input-group">
  <span class="input-group-addon" id="Span2">Model</span>
     <input type="text"    class="form-control txtSurfaceModel" placeholder="Model" id="txtSurfaceModel"  />
</div>
           </div>
           
          </div>

      

       <div class="row" style="padding-top:10px; ">

          <div class="col-sm-4 funkyradio">
        
              <div class="funkyradio">
        
   
        <div class="funkyradio-primary">
            <input type="radio" class="chkSurface" name="radio" value="1" id="chkSurface1"/>
            <label for="chkSurface1">Replica</label>
        </div>
        <div class="funkyradio-success">
            <input type="radio"  class="chkSurface"name="radio" value="2" id="chkSurface2" />
            <label for="chkSurface2">Digital Surface Profile Guage</label>
        </div>
        <div class="funkyradio-info">
            <input type="radio" class="chkSurface" name="radio" value="3" id="chkSurface3" />
            <label for="chkSurface3">Surface Profile Guage</label>
        </div>
    </div>

       
          </div>
</div>
 <div class="row" style="padding-top:10px; ">
<div class="col-sm-8">

 <table class="table table-bordered table-blue tblSurfaceTable">
   <thead>
      <tr>
         <th class="text-center">Item</th>
         <th class="text-center"><span class="lbSurface">Replica</span></th>
           <th  class="text-center">Profile (&#181m)</th>
  </tr>
  </thead>
  <tbody>
  <tr>
  <td width="8%"><input class="form-control   txtItemNo " disabled type="text" value="1"/></td>
  <td><input class="form-control   txtFile " type="file"/></td>
  <td><input class="form-control   txtProfile" type="text"/></td>
  </tr>
   <tr>
  <td><input class="form-control   txtItemNo " disabled type="text" value="2"/></td>
  <td><input class="form-control   txtFile" type="file"/></td>
  <td><input class="form-control   txtProfile" type="text"/></td>
  </tr>
   <tr>
  <td><input class="form-control   txtItemNo " disabled type="text" value="3"/></td>
  <td><input class="form-control   txtFile" type="file"/></td>
  <td><input class="form-control   txtProfile" type="text"/></td>
  </tr>
  
  </tbody>

  </table>
   

</div>

<div class="col-sm-4">

  <div class="row">
   <div class="col-sm-12">
   <h4>Number of surface profile testing : </h4>
   </div>
   </div>
      <div class="row" style="padding-top:10px;">
      <div class="col-sm-12">- Repair length < 0.5 m = 1 Position</div>
      </div>
       <div class="row" style="padding-top:10px;">
      <div class="col-sm-12">- Repair length 0.5-5 m = 2 Position</div>
      </div>
         <div class="row" style="padding-top:10px;">
      <div class="col-sm-12">- Repair length > 5 m = 3 Position</div>
      </div>

       <div class="row" style="padding-top:10px;">
   <div class="col-sm-12">
   <h4>Surface profile requirement :  </h4>
   </div>
   </div>
      <div class="row" style="padding-top:10px;">
      <div class="col-sm-12">-  50-125 &#181m or coating specification</div>
      </div>

</div>
</div>

<div class="row"  style="padding-top:20px;">

</div>


<div class="card">
   
   <div class="card-header">
    <h5 class="text-left">Coating Infomation</h5>
   </div>
<div class="card-body">

       <div class="row" style="padding-top:10px;">

          <div class="col-sm-4">
             <div class="input-group">
  <span class="input-group-addon" id="Span5" >Coating Type</span>
    <select   class="form-control ddlCoatingTypeID" id="ddlCoatingTypeID"  >
      <option value="1">1</option>
  </select>
  </div>
          </div>

           <div class="col-sm-4">
             <div class="input-group">
  <span class="input-group-addon" id="Span3">Brand</span>
     <input type="text"    class="form-control txtCoatingBrand" placeholder="Brand" id="txtCoatingBrand"  />
</div>
           </div>
             <div class="col-sm-4">
              <div class="input-group">
  <span class="input-group-addon" id="Span4">Model</span>
     <input type="text"    class="form-control txtCoatingModel" placeholder="Model" id="txtCoatingModel"  />
</div>
           </div>
           
          </div>

           <div class="row" style="padding-top:10px; ">
<div class="col-sm-12">

 <table class="table table-bordered table-blue tblCoatingInfoTable invisible">
   <thead>
      <tr>
         <th class="text-center">Description</th>
         <th class="text-center">Part A</th>
           <th  class="text-center">Part B</th>
               <th  class="text-center">Solvent</th>
                   <th  class="text-center">Remark</th>
  </tr>
  </thead>
  <tbody>
  <tr>
  <td>Model</td>
  <td><input class="form-control   txtPartA" type="text"/></td>
  <td><input class="form-control   txtPartB" type="text"/></td>
   <td><input class="form-control   txtSolvent" type="text"/></td>
    <td><input class="form-control   txtRemark" type="text"/></td>
  </tr>
   <tr>
  <td>Color</td>
  <td><input class="form-control   txtPartA" type="text"/></td>
  <td><input class="form-control   txtPartB" type="text"/></td>
   <td><input class="form-control   txtSolvent" type="text"/></td>
    <td><input class="form-control   txtRemark" type="text"/></td>
  </tr>
   <tr>
  <td>ExpireDate</td>
  <td>
        <div class="input-group">
             <input class="form-control  datetimepicker  txtPartA" type="text"/>
          <div class="input-group-addon">
             <span class="glyphicon glyphicon-th"></span>
          </div>
       </div>
  </td>
  <td>
   <div class="input-group">
             <input class="form-control  datetimepicker  txtPartB" type="text"/>
          <div class="input-group-addon">
             <span class="glyphicon glyphicon-th"></span>
          </div>
       </div>
       </td>
   <td>
   
    <div class="input-group">
             <input class="form-control  datetimepicker  txtSolvent" type="text"/>
          <div class="input-group-addon">
             <span class="glyphicon glyphicon-th"></span>
          </div>
       </div>
   </td>
    <td>
   <input class="form-control   txtRemark" type="text"/>
    
    </td>
  </tr>
  
  </tbody>

  </table>
   

</div>
</div>

</div>
</div>

    <div class="row" style="padding-top:10px;">

          <div class="col-sm-5">
       
        <button type="button" class="btn btn-lg bg-success btnSave ">บันทึก</button>
       
        <button type="button" class="btn btn-lg btn-default">ยกเลิก</button>
        
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
     </div>


<!--Modal-->


<!-- End Modal-->
</asp:Content>

