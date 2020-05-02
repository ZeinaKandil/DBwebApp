using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Hello_Vendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void postProduct(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("postProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            string vendorUsername = (String)Session["user"];
            string product_name = txt_product_name.Text;
            string category = txt_category.Text;
            string product_description = txt_product_description.Text;
            Decimal price = System.Convert.ToDecimal(txt_price.Text);
            string color = txt_color.Text;

            cmd.Parameters.Add(new SqlParameter("@vendorUsername", vendorUsername));
            cmd.Parameters.Add(new SqlParameter("@product_name", product_name));
            cmd.Parameters.Add(new SqlParameter("@category", category));
            cmd.Parameters.Add(new SqlParameter("@product_description", product_description));
            cmd.Parameters.Add(new SqlParameter("@price", price));
            cmd.Parameters.Add(new SqlParameter("@color", color));

            Response.Write("Your Product has been posted successfully.");

            
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void vendorviewProduct(Object sender, EventArgs e) {
            Response.Redirect("Products.aspx", true);
        }
        public void AddPhone(object sender, EventArgs args)
        {
            if (txt_dv_mobile.Text != "")
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd2 = new SqlCommand("dupmobile3", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                string admin_username1 = (String)Session["user"];
                string admin_mobile1 = txt_dv_mobile.Text;
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
    }

 }

