using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Hello_Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddcustPhone(object sender, EventArgs args)
        {
            if (txt_cust_mobil.Text != "")
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd2 = new SqlCommand("dupmobile3", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                string admin_username1 = (String)Session["user"];
                string admin_mobile1 = txt_cust_mobil.Text;
                cmd2.Parameters.Add(new SqlParameter("@username", admin_username1));
                cmd2.Parameters.Add(new SqlParameter("@mobile", admin_mobile1));
                SqlParameter exists = cmd2.Parameters.Add("@exists", SqlDbType.Int);
                exists.Direction = ParameterDirection.Output;
                SqlCommand cmd = new SqlCommand("addMobile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", admin_username1));
                cmd.Parameters.Add(new SqlParameter("@mobile_number", admin_mobile1));
                //Response.Redirect("Companies.aspx", true);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                if (exists.Value.ToString().Equals("1"))
                {
                    Response.Write("You entered this mobile number before.");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("The mobile number has been added successfullly.");

                }
            }
            else
            {
                Response.Write("Enter a mobile number.");
            }
        }
        protected void reviewOrders(object sender, EventArgs e)
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
            else
            {

                Response.Redirect("My_Orders.aspx", true);
                //SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);

            }
                //Executing the SQLCommand
                //conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();
                


            

        }
        protected void wishlist(object sender, EventArgs e)
        {
            Response.Redirect("Wishlist.aspx", true);
        }
        protected void cart(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx", true);


        }
        protected void AddCreditCard(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");

            SqlCommand cmd = new SqlCommand("AddCreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string number = txt_number.Text;
            string expiry_date = txt_expiry_date.Text;
            DateTime x;
            //=DateTime.Parse(expiry_date);
            bool res = DateTime.TryParse(expiry_date, out x);
            
            string cvv_code = txt_cvv_code.Text;
            string customer_name = (String)Session["user"];
            cmd.Parameters.Add(new SqlParameter("@creditcardnumber", number));
            cmd.Parameters.Add(new SqlParameter("@expirydate", x));
            cmd.Parameters.Add(new SqlParameter("@cvv", cvv_code));
            cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
            SqlCommand cmd2 = new SqlCommand("CreditCardExists", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@name", customer_name));
            cmd2.Parameters.Add(new SqlParameter("@cc_num", number));
            SqlParameter exists = cmd2.Parameters.Add("@existsToCust", SqlDbType.Int);
            exists.Direction = ParameterDirection.Output;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            if (exists.Value.ToString().Equals("1"))
            {
                Response.Write("You added this credit card before");

            }
            else
            {
                if (res)
                {
                    Response.Write("The credit card has been added successfully");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    Response.Write("Enter a valid date in the correct format genius");
                }

            }


        }
        protected void product(object sender, EventArgs e)
        {

            Response.Redirect("All_Products.aspx", true);

        }

    }
}
