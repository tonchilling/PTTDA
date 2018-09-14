<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ActivityFlow.aspx.cs" Inherits="UI_Plan_ActivityFlow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


   <!-- <script src="<%= ResolveUrl("~/Js/ui/MenuPage.js") %>" type="text/javascript"></script>-->



    <script language="javascript">
    var currentURL= "<%= ResolveUrl("~/ASHX/MenuHandler.ashx") %>"; 

    $(document).ready(function () {


     $('.divMainTable table').DataTable({

                dom: 'Bfrtip',
                searching: false

            });

            $('.btnAdd').on("click",function(e){
            
            window.location.href =' <%= ResolveUrl("~/UI/Plan/PlanEdit.aspx") %>';
            });

  });

    </script>

     <style type="text/css">
    .modal-dialog 
    {
    	
    width: 800px;
    margin: 30px auto;
      
}

</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#007bff" ></i> Work Flow </div>
     <div class="card-body">


      <div class="row">
      <div class="col-sm-3"></div>
          <div class="col-sm-9">
          
    <img src="<%=ResolveUrl("~/Img/Plan/ActiviyFlow.jpg")  %>" />
         
        </div>
          </div>
        
        </div>

     </div>
         
<!--- Content --->
</div> 
    </div>








</asp:Content>

