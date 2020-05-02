<%@ Page Language="C#" Inherits="StupidBDWebApp.My_Orders" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>My_Orders</title>
</head>
<body>
	<form id="form1" runat="server">
          <div>                                                   <asp:Label ID="lbl_chooseCC" runat="server" Text="Credit Card number: "></asp:Label>              <asp:TextBox ID="txt_chooseCC" runat="server"  ></asp:TextBox>                  <br />              <br />                                 <asp:Label ID="lbl_order_no_forCC" runat="server" Text="Credit card for Order_no: "></asp:Label>              <asp:TextBox ID="txt_order_no_forCC" runat="server"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>                                       <br />              <br />               <asp:Button ID="btn_chooseCC" runat="server" Text="Choose Credit Card" onclick="chooseCreditCard" Width="90px"/>         <br />              <br />         
         <asp:Label ID="lbl_orderId" runat="server" Text="Order Id: "></asp:Label>
    
        <asp:TextBox ID="txt_orderId" runat="server"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
    
        <br />
    
        <br />                         <asp:Label ID="lbl_cash_amount" runat="server" Text="Cash amount for order: "></asp:Label>              <asp:TextBox ID="txt_cash_amount" runat="server"  onkeydown = "return ((!(event.keyCode>=65) && event.keyCode!=32)|| event.keyCode==190);"></asp:TextBox>              <br />              <br />                                   <asp:Label ID="lbl_credit_amount" runat="server" Text="credit amount for order: "></asp:Label>              <asp:TextBox ID="txt_credit_amount" runat="server"  onkeydown = "return ((!(event.keyCode>=65) && event.keyCode!=32)|| event.keyCode==190);"></asp:TextBox>              <br />              <br />                  <asp:Button ID="btn_verify_Payment" runat="server" Text="Verify Payment" onclick="choosePayment" Width="90px"/>               <br />              <br />                                      <asp:Label ID="lbl_cancelOrder" runat="server" Text="Cancel Order no: "></asp:Label>              <asp:TextBox ID="txt_cancel_order" runat="server"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>              <br />              <br />                        <asp:Button ID="Cancel_order" runat="server" Text="Verify Cancellation" onclick="cancelOrder" Width="90px"/>                      </div> 
	</form>
</body>
</html>
