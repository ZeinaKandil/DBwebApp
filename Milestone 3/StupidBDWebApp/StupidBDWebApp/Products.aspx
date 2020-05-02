<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="StupidDBWebApp.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="myText" runat="server" Text="Products are:  "></asp:Label>
                <br/>
                <br/>
                
                 <asp:Button id="btn_editproduct" runat="server" Text="Edit Product" OnClick="EditProduct" Width="90px" />
               
                <br/>
                <br/>
                
                <asp:Button id="btn_offers" runat="server" Text="Offers" OnClick="Offers" Width="90px" />
                
               
    </div>
    </form>
</body>
</html>