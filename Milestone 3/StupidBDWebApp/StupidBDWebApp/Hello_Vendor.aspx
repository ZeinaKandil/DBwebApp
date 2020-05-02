<%@ Page Language="C#" Inherits="StupidBDWebApp.Hello_Vendor" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Hello_Vendor</title>
       
</head>
<body>
    <form id="form1" runat="server">
             <div>
                <br />
    
        <br />
                <asp:Label ID="lbl_dv_mobile" runat="server" Text="New Mobile Number: "></asp:Label>
    
        <asp:TextBox ID="txt_dv_mobile" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Button ID="dvPhone" runat="server" Text="Mobile number" onclick="AddPhone" Width="90px"/>
                 <br />
    
        <br />
               <asp:Label ID="lbl_product_name" runat="server" Text="Product Name: "></asp:Label>
    
        <asp:TextBox ID="txt_product_name" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br /> 
        
        <asp:Label ID="lbl_category" runat="server" Text="Category: "></asp:Label>
    
        <asp:TextBox ID="txt_category" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_product_description" runat="server" Text="Product Description: "></asp:Label>
    
        <asp:TextBox ID="txt_product_description" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_price" runat="server" Text="Pice: "></asp:Label>
    
        <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_color" runat="server" Text="Color: "></asp:Label>
    
        <asp:TextBox ID="txt_color" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
        <asp:Button ID="btn_postProduct" runat="server" Text="Post Product" onclick="postProduct" Width="90px"/>
         <br />
    
        <br />
                
                 <asp:Button id="btn_viewProduct" runat="server" Text="View Product" OnClick="vendorviewProduct" />
               
    
      <br />
    
        <br />
      
              
       
        </div>

    </form>
</body>
</html>
