using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class My_Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void chooseCreditCard(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");

            SqlCommand cmd = new SqlCommand("CCExists", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            String cUsername = (String)Session["user"];
            string creditcardNo = txt_chooseCC.Text;
            int order_no = int.Parse(txt_order_no_forCC.Text);
            cmd.Parameters.Add(new SqlParameter("@customername", cUsername));
            cmd.Parameters.Add(new SqlParameter("@creditcard", creditcardNo));

            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            

            SqlCommand cmd4 = new SqlCommand("orderexists", conn);
            cmd4.CommandType = CommandType.StoredProcedure;


            cmd4.Parameters.Add(new SqlParameter("@orderid", order_no));
            SqlParameter order = cmd4.Parameters.Add("@exists", SqlDbType.Int);
            order.Direction = ParameterDirection.Output;
            

            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            if (order.Value.ToString().Equals("1")) {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                if (success.Value.ToString().Equals("1"))
                {


                    SqlCommand cmd3 = new SqlCommand("orderAlreadyHasCC", conn);
                    cmd3.CommandType = CommandType.StoredProcedure;

                    cmd3.Parameters.Add(new SqlParameter("@orderid", order_no));


                    SqlParameter count2 = cmd3.Parameters.Add("@success", SqlDbType.Int);
                    count2.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    if (count2.Value.ToString().Equals("0"))
                    {
                        SqlCommand cmd2 = new SqlCommand("ChooseCreditCard", conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add(new SqlParameter("@creditcard", creditcardNo));
                        cmd2.Parameters.Add(new SqlParameter("@orderid", order_no));
                        Response.Write("credit card added to order");
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                    }
                    else
                    {
                        Response.Write("cannot pay for same order with more than one credit card SORRY!");
                    }
                }
                else
                {
                    Response.Write("Credit Card not in system");
                }
            }
            else
            {
                Response.Write("Order not in system");
            }


        }
        protected void choosePayment(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");

            SqlCommand cmd = new SqlCommand("SpecifyAmount", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            String cUsername = (String)Session["user"];

            int orderId = int.Parse(txt_orderId.Text);
            decimal cashAmount = decimal.Parse(txt_cash_amount.Text);
            decimal creditAmount = decimal.Parse(txt_credit_amount.Text);

            cmd.Parameters.Add(new SqlParameter("@customername", cUsername));
            cmd.Parameters.Add(new SqlParameter("@orderID", orderId));
            cmd.Parameters.Add(new SqlParameter("@cash", cashAmount));
            cmd.Parameters.Add(new SqlParameter("@credit", creditAmount));

            

            if (cashAmount != 0 && creditAmount != 0)
            {
                Response.Write("Cannot Pay with both at same time, choose either: pay all using cash only or pay all using credit only or partially using cash or partially using credit");
            }
            else
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("payment added!");

            }


        }
        protected void cancelOrder(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("checkStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            String cUsername = (String)Session["user"];
            int cancelledOrder = int.Parse(txt_cancel_order.Text);

            cmd.Parameters.Add(new SqlParameter("@orderID", cancelledOrder));



            SqlParameter count = cmd.Parameters.Add("@success", SqlDbType.Int);
            count.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (count.Value.ToString().Equals("1"))
            {
                SqlCommand cmd3 = new SqlCommand("notObligedToCancel", conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Add(new SqlParameter("@orderid", cancelledOrder));
                cmd3.Parameters.Add(new SqlParameter("@customername", cUsername));
                SqlParameter count2 = cmd3.Parameters.Add("@ok", SqlDbType.Int);
                count2.Direction = ParameterDirection.Output;

                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                if (count2.Value.ToString().Equals("1"))
                {
                    SqlCommand cmd2 = new SqlCommand("cancelOrder", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@orderid", cancelledOrder));
                    cmd2.Parameters.Add(new SqlParameter("@customername", cUsername));

                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("order cancellation successful");
                }
                else
                {
                    Response.Write("order cancellation unsuccessful! this is not your order!!");

                }


                    
            }
            else
            {
                Response.Write("Cannot cancel order");
            }





        }
    }




}

