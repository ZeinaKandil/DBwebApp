<%@ Page Language="C#" Inherits="StupidBDWebApp.Hello_Admin" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Hello_Admin</title>
</head>
<body>
	<form id="form1" runat="server">
            <div> 
           <asp:Label ID="lbl_vendor_username" runat="server" Text="Vendor Username: "></asp:Label>
    
        <asp:TextBox ID="txt_vendor_username" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Button ID="btn_activate" runat="server" Text="Activate Vendor" onclick="ActivateVendor" Width="90px"/>
        <br />
    
        <br />        
        <asp:Label ID="lbl_admin_mobile" runat="server" Text="New Mobile Number: "></asp:Label>
    
        <asp:TextBox ID="txt_admin_mobile" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Button ID="btn_admin_mobile" runat="server" Text="Add Mobile" onclick="AddAdminPhone" Width="90px"/>
         <br />
    
        <br />
        <asp:Button ID="Orders" runat="server" Text="View Orders" onclick="ViewOrders" Width="90px"/>
        <br />
            <br />
            <asp:Label ID="lbl_order_no" runat="server" Text="Order Number: "></asp:Label>
            <asp:TextBox ID="txt_order_no" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength = "10"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_update" runat="server" Text="Order In Process" onclick="UpdateOrders" Width="90px"/>
            <br />
            <br />
            <asp:Button ID="btn_toDeals" runat="server" Text="Today's Deals" onclick="goToToday" Width="90px"/>
            <br />
            <br />   
	</div>
        </form>
</body>
</html>
