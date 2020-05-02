<%@ Page Language="C#" Inherits="StupidBDWebApp.Loging" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Loging</title>
</head>
<body>
	<form id="form1" runat="server">
            <div>
    
        <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
    
        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Button ID="btn_login" runat="server" Text="Login" onclick="login" Width="90px"/>
    
    </div>
	</form>
</body>
</html>
