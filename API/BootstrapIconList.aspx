<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="BootstrapIconList.aspx.cs" Inherits="BootstrapIconList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script language=javascript>
    $(document).ready(function () {
        $('[data-toggle="popover"]').popover({
            html: true,
            title:"Select Icon",
            content: function () {
                return $('.divIcon').html();
            }
        });


        $(document).on('click', '.fontawesome-icon-list .fa-hover', function (event) {

            var $item = $(this).find("i:first");

           // alert($item.attr('data'))
        });
    });

   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<a href="#" data-toggle="popover" >Toggle popover</a>
   <div id="divIcon" class="divIcon" style="display: none"  class="container">
   <div class="row fontawesome-icon-list">
    
      <div class="fa-hover  col-sm-3"><a><i class="fa fa-users fa-2x " aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-file-pdf-o fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-calendar fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-file-text fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-address-book fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-cog fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-window-maximize fa-2x" aria-hidden="true" data="fa fa-window-maximize"></i></a></div>
      <div class="fa-hover  col-sm-3"><a><i class="fa fa-user fa-2x " aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-folder-open fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="fa fa-sitemap fa-2x" aria-hidden="true" data="fa fa-address-book"></i></a></div>
      <div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-phone fa-2x" aria-hidden="true" data="glyphicon glyphicon-phone"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-globe fa-2x" aria-hidden="true" data="glyphicon glyphicon-globe"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-file fa-2x" aria-hidden="true" data="glyphicon glyphicon-file"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa  fa-wrench fa-2x" aria-hidden="true" data="fa fa-wrench"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-internet-explorer fa-2x" aria-hidden="true" data="fa fa-internet-explorer"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-time fa-2x" aria-hidden="true" data="glyphicon glyphicon-time"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-signal fa-2x" aria-hidden="true" data="glyphicon glyphicon-signal"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="glyphicon glyphicon-list-alt fa-2x" aria-hidden="true" data="glyphicon glyphicon-list-alt"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-calculator fa-2x" aria-hidden="true" data="fa fa-calculator"></i></a></div>
<div class="fa-hover  col-sm-3"><a ><i class="fa fa-laptop fa-2x" aria-hidden="true" data="fa fa-laptop"></i></a></div>

  </div>
</div>




    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="Button" />




</asp:Content>

