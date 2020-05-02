<%@ Page Language="C#" Inherits="StupidBDWebApp.Offers" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Offers</title>
       
</head>
<body>
    <form id="form1" runat="server">
             <div>
                <br />
    
        <br />
               <asp:Button ID="btn_checkOfferonProduct" runat="server" Text="Check offer" onclick="checkOfferonProduct" Width="90px"/>
                
               <asp:Label ID="lbl_serial_no" runat="server" Text="Serial Number: "></asp:Label>
               <asp:TextBox ID="txt_serial_no" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
                 <!--check this-->
               <asp:Button ID="btn_addOffer" runat="server" Text="Add offer" onclick="addOffer" />
                <!--this button-->
                
               <asp:Label ID="lbl_offeramount" runat="server" Text="Offer Amount: "></asp:Label>
                
               <asp:TextBox ID="txt_offeramount" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_expiry_date" runat="server" Text="Expiry Date: "></asp:Label>
    
                <asp:TextBox ID="txt_expiry_date" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Button ID="btn_applyOffer" runat="server" Text="Apply offer" onclick="applyOffer" />
                
                
               <asp:Label ID="lbl_vendorname" runat="server" Text="Vendor Name: "></asp:Label>
                
               <asp:TextBox ID="txt_vendorname" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
               <asp:Label ID="lbl_offerid" runat="server" Text="Offer ID: "></asp:Label>
                
               <asp:TextBox ID="txt_offerid" runat="server"></asp:TextBox>
         <br />
    
        <br />
                
                 <asp:Label ID="lbl_serial_no2" runat="server" Text="Serial Number: "></asp:Label>
                
               <asp:TextBox ID="txt_serial_no2" runat="server"></asp:TextBox>
               
    
      <br />
    
        <br />
               <asp:Button ID="btn_checkandremoveExpiredOffer" runat="server" Text="Remove Expired offer" onclick="checkandremoveExpiredOffer" />
                
                
               <asp:Label ID="lbl_offerid2" runat="server" Text="Offer ID: "></asp:Label>
                
               <asp:TextBox ID="txt_offerid2" runat="server"></asp:TextBox>
              
       
        </div>

    </form>
</body>
</html>
