<%@ Page Language="C#" Inherits="StupidBDWebApp.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>HomePage</title>
</head>
<body>
    <form id="form1" runat="server">
        
            
           <div>    
    
        <asp:Label ID="lbl_usernamelog" runat="server" Text="Username: "></asp:Label>
    
        <asp:TextBox ID="txt_usernamelog" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Label ID="lbl_passwordlog" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_passwordlog" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
    
      <br />
    
        <br />
                 <asp:Button ID="btn_login" runat="server" Text="Login" Onclick="login" Width="90px"/> 
                 <br />
    
        <br />
       
        <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
    
        <asp:TextBox ID="txt_username" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
                <asp:Label ID="lbl_first_name" runat="server" Text="First Name: "></asp:Label>
    
        <asp:TextBox ID="txt_first_name" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
       <asp:Label ID="lbl_last_name" runat="server" Text="Last Name: "></asp:Label>
    
        <asp:TextBox ID="txt_last_name" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
               
                <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
    
      <br />
    
        <br />
                <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
    
        <asp:TextBox ID="txt_email" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                <asp:Button id="button1" runat="server" Text="Register As a Customer" OnClick="registerCust" />
                 <br />
    
        <br />
         <asp:Label ID="lbl_usernamevend" runat="server" Text="Username: "></asp:Label>
    
        <asp:TextBox ID="txt_usernamevend" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
                <asp:Label ID="lbl_first_namevend" runat="server" Text="First Name: "></asp:Label>
    
        <asp:TextBox ID="txt_first_namevend" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
       <asp:Label ID="lbl_last_namevend" runat="server" Text="Last Name: "></asp:Label>
    
        <asp:TextBox ID="txt_last_namevend" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
               
                <asp:Label ID="lbl_passwordvend" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_passwordvend" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
    
      <br />
    
        <br />
                <asp:Label ID="lbl_emailvend" runat="server" Text="Vendor Email: "></asp:Label>
    
        <asp:TextBox ID="txt_emailvend" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                 <asp:Label ID="lbl_company_name" runat="server" Text="Company Name: "></asp:Label>
    
        <asp:TextBox ID="txt_company_name" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                 <asp:Label ID="lbl_bank_acc_no" runat="server" Text="Bank Account Number: "></asp:Label>
    
        <asp:TextBox ID="txt_bank_acc_no" runat="server" MaxLength="20"></asp:TextBox>
    
        <br />
    
        <br />
                
       
                <asp:Button id="button2" runat="server" Text="Register As a Vendor" OnClick="registerVendor" />
    
    </div>
    </form>
</body>
</html>
