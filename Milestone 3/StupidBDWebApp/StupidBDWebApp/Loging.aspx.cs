using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;




namespace StupidBDWebApp
{

    public partial class Loging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Server=localhost;Database=DBSucks;User_Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = txt_username.Text;
            string password = txt_password.Text;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = ParameterDirection.Output;
            SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString().Equals("1"))
            {
                Response.Write("Passed");
                Session["field1"] = "HIIII";
                if (type.Value.ToString().Equals("0"))
                {
                    Response.Write("Hello Customer");

                }
                if (type.Value.ToString().Equals("1"))
                {
                    Response.Write("Hello Vendor");

                }
                if (type.Value.ToString().Equals("2"))
                {
                    Response.Write("Hello Admin");

                }
                if (type.Value.ToString().Equals("3"))
                {
                    Response.Write("Hello Admin");

                }

            }
            if (success.Value.ToString().Equals("0"))
            {

                Response.Write("You are not registered, try again!");
            }

        }
    }
}
