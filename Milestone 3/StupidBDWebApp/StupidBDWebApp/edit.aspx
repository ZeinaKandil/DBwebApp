<%@ Page Language="C#" Inherits="StupidBDWebApp.edit" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>edit</title>
       
</head>
<body>
    <form id="form1" runat="server">
             <div>
                
                <br />
    
        <br />
               <asp:Label ID="lbl_serial_no" runat="server" Text="Serial number: "></asp:Label>
    
        <asp:TextBox ID="txt_serial_no" runat="server"></asp:TextBox>
    
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
                <asp:Label ID="lbl_price" runat="server" Text="Price: "></asp:Label>
    
        <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_color" runat="server" Text="Color: "></asp:Label>
    
        <asp:TextBox ID="txt_color" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
        <asp:Button ID="btn_EditProduct" runat="server" Text="Edit Product" onclick="EditProduct" Width="90px"/>
         <br />
    
        <br />
               
    
      <br />
    
        <br />
      
              
       
        </div>

    </form>
</body>
</html>

