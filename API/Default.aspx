<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="API.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

     <script src="<%= ResolveUrl("~/js/jquery.min.js") %>"></script>
    <script  type="text/javascript">



        $(document).ready(function () {


            $('.btnGetGPS').on('click', function () {

               
;            });
        });

    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Print" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="LDAP" />
         <asp:Button ID="Button3" runat="server" Text="Export Excel" OnClick="Button3_Click" />

            <asp:Button ID="Button4" runat="server" Text="Export Open XML" OnClick="Button4_Click" />
    <input type="button" class="btnGetGPS" value="GetGPS" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="GPS" />

         <asp:Button ID="Button6" runat="server" Text="ReadExcel Open.XML" OnClick="Button6_Click"  />
    </div>
   Domain: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   User: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
   Password: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </form>
</body>
</html>


/*sss*/