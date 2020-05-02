using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Hello_Delivery_Person : System.Web.UI.Page
    {
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
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd = new SqlCommand("addMobile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", admin_username1));
                cmd.Parameters.Add(new SqlParameter("@mobile_number", admin_mobile1));
                //Response.Redirect("Companies.aspx", true);
                
                if (exists.Value.ToString().Equals("0"))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("The mobile number has been added successfullly.");

                }
                else
                {
                    Response.Write("You entered this mobile number before.");
                }
            }
            else
            {
                Response.Write("Enter a mobile number.");
            }
        }
    }
}
