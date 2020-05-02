using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Hello_Admin : System.Web.UI.Page
    {


public void ActivateVendor(object sender, EventArgs args)
        {
            if (txt_vendor_username.Text != "")
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd = new SqlCommand("activateVendors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string admin_username = (String)Session["user"];
                string vendor_username = txt_vendor_username.Text;
                cmd.Parameters.Add(new SqlParameter("@admin_username", admin_username));
                cmd.Parameters.Add(new SqlParameter("@vendor_username", vendor_username));

                SqlCommand cmd2 = new SqlCommand("ValidVendor", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@vendor_username", vendor_username));
                SqlParameter valid = cmd2.Parameters.Add("@valid", SqlDbType.Int);
                valid.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                if (valid.Value.ToString().Equals("0"))
                {
                    Response.Write("Vendor is invalid, enter an existing vendor name.");
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("activeVendor", conn);
                    cmd3.Parameters.Add(new SqlParameter("@vendor_username", vendor_username));
                    cmd3.CommandType = CommandType.StoredProcedure;
                    SqlParameter active = cmd3.Parameters.Add("@active", SqlDbType.Int);
                    active.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    if (active.Value.ToString().Equals("0"))
                    {
                        Response.Write("Vendor is active");
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        Response.Write("Vendor has been activated before. Cannot activate activated vendors.");
                    }
                }
            }
            else
            {
                Response.Write("Enter Vendor Username.");
            }
        }
        public void ViewOrders(object sender, EventArgs args)
        {
            Response.Redirect("All_Orders.aspx", true);
        }
        public void AddAdminPhone(object sender, EventArgs args)
        {
            if (txt_admin_mobile.Text != "")
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd2 = new SqlCommand("dupmobile3 ", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                string admin_username1 = (String)Session["user"];
                string admin_mobile1 = txt_admin_mobile.Text;
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
        public void UpdateOrders(object sender, EventArgs args)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("updateOrderStatusInProcess", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (txt_order_no.Text == "")
            {
                Response.Write("Enter Order Number");
            }
            else
            {
                int order_no = int.Parse(txt_order_no.Text);
                SqlCommand cmd2 = new SqlCommand("ValidOrder", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@order_no", order_no));
                SqlParameter valid = cmd2.Parameters.Add("@valid", SqlDbType.Int);
                valid.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                if (valid.Value.ToString().Equals("0"))
                {
                    Response.Write("Order Number is invalid, enter an existing order number.");
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@order_no", order_no));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("Order is in process");
                }
            }
        }
        public void goToToday(object sender, EventArgs args)
        {
            Response.Redirect("Today_s_Deals.aspx", true);
        }

    }
}
