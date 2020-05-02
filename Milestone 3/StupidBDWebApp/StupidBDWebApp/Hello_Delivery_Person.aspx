<%@ Page Language="C#" Inherits="StupidBDWebApp.Hello_Delivery_Person" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Hello_Delivery_Person</title>
</head>
<body>
	<form id="form1" runat="server">
            <div>
                <br />
    
        <br />        
        <asp:Label ID="lbl_dv_mobile" runat="server" Text="New Mobile Number: "></asp:Label>
    
        <asp:TextBox ID="txt_dv_mobile" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Button ID="dvPhone" runat="server" Text="Mobile number" onclick="AddPhone" Width="90px"/>
                 <br />
    
        <br />
                
                </div>
	</form>
</body>
</html>
