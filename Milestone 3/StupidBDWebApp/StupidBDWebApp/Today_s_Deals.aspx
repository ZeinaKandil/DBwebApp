<%@ Page Language="C#" Inherits="StupidBDWebApp.Today_s_Deals" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Today_s_Deals</title>
</head>
<body>
	<form id="form1" runat="server">
            <div>
            
            <asp:Label ID="lbl_deal_amount" runat="server" Text="Deal Amount: "></asp:Label>
            <asp:TextBox ID="txt_deal_amount" runat="server" onkeydown = "return ((!(event.keyCode>=65) && event.keyCode!=32) || event.keyCode==190);"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbl_date" runat="server" Text="Date (mm-dd-yyyy): "></asp:Label>
            <asp:TextBox ID="txt_date" runat="server" MaxLength="10" onkeydown = "return ((!(event.keyCode>=65) && event.keyCode!=32) || event.keyCode==189);"></asp:TextBox>
            
               
            <br />
            <br />
            <asp:Button ID="btn_CreateDeals" runat="server" Text="Create Deal" onclick="CreateDeal" Width="90px"/>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Deal ID: "></asp:Label>
            <asp:TextBox ID="TextBoxaddDeal" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Serial Number: "></asp:Label>
            <asp:TextBox ID="TextBoxserial_no" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32;"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Btn_Add_deal" runat="server" Text="Add Deal To Product" onclick="AddDeal" Width="90px"/>
            <br />
            <br />
            <asp:Label ID="lbl_deal_id" runat="server" Text="Deal ID: "></asp:Label>
            <asp:TextBox ID="txt_deal_id" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Btn_remove_deal" runat="server" Text="Remove Expired Deal" onclick="RemoveDeal" Width="90px"/>
            <br />
            <br />
        </div>
	</form>
</body>
</html>
