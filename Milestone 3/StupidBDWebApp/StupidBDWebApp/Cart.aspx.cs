using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void addtoCart(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            if(!(txt_serial_no.Text.Equals(""))){
                SqlCommand cmd = new SqlCommand("addToCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string customer_name = (String)Session["user"];
            int serial_no = int.Parse(txt_serial_no.Text);
            cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
            SqlCommand cmd2 = new SqlCommand("EXISTSinCart", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@serial_no", serial_no));
            cmd2.Parameters.Add(new SqlParameter("@CNAME", customer_name));
            SqlParameter exists = cmd2.Parameters.Add("@existsCart", SqlDbType.Int);
            exists.Direction = ParameterDirection.Output;
            SqlCommand cmd3 = new SqlCommand("ValidProduct", conn);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add(new SqlParameter("@serial_no", serial_no));
            SqlParameter valid = cmd3.Parameters.Add("@validp", SqlDbType.Int);
            valid.Direction = ParameterDirection.Output;
            SqlCommand cmd4 = new SqlCommand("availablep", conn);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add(new SqlParameter("@serial_no", serial_no));
            SqlParameter availablep = cmd4.Parameters.Add("@available", SqlDbType.Int);
            availablep.Direction = ParameterDirection.Output;
           
            
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                if (valid.Value.ToString().Equals("1"))
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    //Executing the SQLCommand
                    if (exists.Value.ToString().Equals("1"))
                    {
                        Response.Write("This product is already in your cart");

                    }
                    else
                    {
                        conn.Open();
                        cmd4.ExecuteNonQuery();
                        conn.Close();
                        if (availablep.Value.ToString().Equals("1"))
                        {
                            Response.Write("The product has been added to your cart successfully");
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        else
                        {
                            Response.Write("This product is out of stock, try to add an available product");
                        }

                    }
                }
                else
                {
                    Response.Write("This product is not available, enter another serial number.");

                } }
            else
            {

                Response.Write("enter a serial number.");

            }

        }
        


    
        protected void removefromCart(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            if (!(txt_serial_no.Text.Equals("")))
            {
                SqlCommand cmd = new SqlCommand("removefromCart", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string customer_name = (String)Session["user"];
                int serial_no = int.Parse(txt_serial_no1.Text);
                cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
                cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
                SqlCommand cmd2 = new SqlCommand("EXISTSinCart", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                cmd2.Parameters.Add(new SqlParameter("@CNAME", customer_name));
                SqlParameter exists = cmd2.Parameters.Add("@existsCart", SqlDbType.Int);
                exists.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                if (exists.Value.ToString().Equals("0"))
                {
                    Response.Write("The product you are trying to remove is not in your cart, make sure you are entering the right serial number");

                }
                else
                {
                    Response.Write("The product has been removed from your cart successfully");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            else
            {

                Response.Write("enter a serial number.");

            }


        }
        protected void makeOrder(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");

            SqlCommand cmd = new SqlCommand("isEmptyCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            String cUsername = (String)Session["user"];
            cmd.Parameters.Add(new SqlParameter("@cutomername", cUsername));


            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString().Equals("0"))
            {

                Response.Write("go put stuff in your cart");
            }
            else
            {
                
                SqlCommand cmd2 = new SqlCommand("makeOrder", conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add(new SqlParameter("@customername", cUsername));

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd3 = new SqlCommand("maxId", conn);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.Add(new SqlParameter("@customerName", cUsername));

                SqlParameter order = cmd3.Parameters.Add("@orderID", SqlDbType.Int);
                SqlParameter totalAmount = cmd3.Parameters.Add("@totalAmount", SqlDbType.Decimal);
                order.Direction = ParameterDirection.Output;
                
                totalAmount.Direction = ParameterDirection.Output;

                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                Response.Write("Your order id is : " + order.Value.ToString() + " total amount is: " + totalAmount.Value.ToString());




                //SqlDataReader rdr2 =cmd2.ExecuteReader(CommandBehavior.CloseConnection);

            }

        }
        protected void myOrder(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");

            SqlCommand cmd = new SqlCommand("hasOrders", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            String cUsername = (String)Session["user"];
            cmd.Parameters.Add(new SqlParameter("@customername", cUsername));


            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString().Equals("0"))
            {

                Response.Write("You have no orders to view");
            }
            if(!(success.Value.ToString().Equals("0")))
            {
                //Response.Write("You have  orders to view");
                Response.Redirect("My_Orders.aspx", true);

                //SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);

            }
        }

        }
}
