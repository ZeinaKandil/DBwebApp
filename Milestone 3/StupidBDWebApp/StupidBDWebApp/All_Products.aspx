<%@ Page Language="C#" Inherits="StupidBDWebApp.All_Products" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>All_Products</title>
</head>
<body>
	<form id="form1" runat="server">
             <div>
        <asp:Label ID="myText" runat="server" Text="Products List:"></asp:Label>
                <br/>
                <br/>
                 <asp:Button ID="btn_cart2" runat="server" Text="Go To Cart" OnClick="cart"/>
                
         <br />
    
        <br />
    </div>
	</form>
</body>
</html>
