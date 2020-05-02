<%@ Page Language="C#" Inherits="StupidBDWebApp.Cart" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Cart</title>
</head>
<body>
	<form id="form1" runat="server">
            <div>
	
                <asp:Label ID="lbl_serial_no" runat="server" Text="Serial Number: "></asp:Label>
                 <asp:TextBox ID="txt_serial_no" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Button id="addtocart" runat="server" Text="Add To Cart" OnClick="addtoCart" />
                 <br />
    
        <br />
              
                <asp:Label ID="lbl_serial_no1" runat="server" Text="Serial Number: "></asp:Label>
                 <asp:TextBox ID="txt_serial_no1" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Button id="removefromcart" runat="server" Text="Remove From Cart" OnClick="removefromCart" />
                 <br />
    
        <br />
                 <br />
    
        <br />
               
             <asp:Button ID="btn_makeOrder" runat="server" Text="Make Order" onclick="makeOrder" Width="90px"/>
                 <asp:Button ID="btn_myorder" runat="server" Text="My Order" onclick="myOrder" Width="90px"/>
              </div>        </form>
</body>
</html>
