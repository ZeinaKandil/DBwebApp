<%@ Page Language="C#" Inherits="StupidBDWebApp.Wishlist" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Wishlist</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
                
                <asp:Label ID="lbl_name" runat="server" Text="Wishlist Name: "></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
    
      <br />
    
        <br />
                <asp:Button id="btn_createWishlist" runat="server" Text="Create a Wishlist" OnClick="createWishlist" />
                <br />
    
        <br />
                
                <asp:Label ID="lbl_wish_name1" runat="server" Text="Wish Name: "></asp:Label>
        <asp:TextBox ID="txt_wish_name1" runat="server" MaxLength="20"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Label ID="lbl_serial_no" runat="server" Text="Serial Number: "></asp:Label>
                 <asp:TextBox ID="txt_serial_no" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Button id="addtowish" runat="server" Text="Add To Wishlist" OnClick="addtoWishlist" />
                 <br />
    
        <br />
                
                <asp:Label ID="lbl_wish_name2" runat="server" Text="Wish Name: "></asp:Label>
        <asp:TextBox ID="txt_wish_name2" runat="server" MaxLength="20"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Label ID="lbl_serial_no2" runat="server" Text="Serial Number: "></asp:Label>
                 <asp:TextBox ID="txt_serial_no2" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Button id="removefromwish" runat="server" Text="Remove From Wishlist" OnClick="removefromWishlist" />
                 <br />
    
        <br />
               
    </div>
    </form>
       
        
</body>
</html>
