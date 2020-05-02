<%@ Page Language="C#" Inherits="StupidBDWebApp.Hello_Customer" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Hello_Customer</title>
       
</head>
<body>
	<form id="form1" runat="server">
             <div>                 <br />              <br />                <asp:Label ID="lbl_cust_mobil" runat="server" Text="New Mobile Number: "></asp:Label>              <asp:TextBox ID="txt_cust_mobil" runat="server" onkeydown = "return (!(event.keyCode>=58) && event.keyCode>47);"></asp:TextBox>              <br />              <br />         <asp:Button ID="btn_cust_mobile" runat="server" Text="Add Mobile" onclick="AddcustPhone" Width="90px"/>          <br />              <br />                  <asp:Button id="btn_products" runat="server" Text="Go To  Products" OnClick="product" />                 <br />              <br />                                  <asp:Button id="btn_GoToWishlist" runat="server" Text="Go To  Wishlist" OnClick="wishlist" />                 <br />              <br />                                   <asp:Button id="btn_cart" runat="server" Text="Go To Cart" OnClick="cart" />                 <br />              <br />                  <asp:Label ID="lbl_number" runat="server" Text="Credit Card Number: "></asp:Label>         <asp:TextBox ID="txt_number" runat="server" MaxLength="20"></asp:TextBox>            <br />              <br />                 <asp:Label ID="lbl_expiry_date" runat="server" Text="Expiry Date (mm-dd-yyyy): "></asp:Label>                 <asp:TextBox ID="txt_expiry_date" runat="server"></asp:TextBox>                                              <br />              <br />                   <asp:Label ID="lbl_cvv_code" runat="server" Text="CVV Code: "></asp:Label>         <asp:TextBox ID="txt_cvv_code" runat="server" MaxLength = "4"></asp:TextBox>
                 <br />
    
        <br />
      
              
             <asp:Button ID="btn_ccr" runat="server" Text="Add Credit Card" onclick="AddCreditCard" Width="90px"/>            <br />              <br />                                       </div> 
	</form>
</body>
</html>
