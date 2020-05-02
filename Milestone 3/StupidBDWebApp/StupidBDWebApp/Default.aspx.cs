
        using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

namespace StupidBDWebApp
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void login(object sender, EventArgs args)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = txt_usernamelog.Text;
            string password = txt_passwordlog.Text;
            if (txt_usernamelog.Text != "" && txt_passwordlog.Text != "")
            {
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Bit);
                success.Direction = ParameterDirection.Output;
                SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
                type.Direction = ParameterDirection.Output;

                SqlCommand cmdPASS = new SqlCommand("checkpass", conn);
                cmdPASS.CommandType = CommandType.StoredProcedure;
                cmdPASS.Parameters.Add(new SqlParameter("@username", username));
                cmdPASS.Parameters.Add(new SqlParameter("@password", password));
                SqlParameter VALIDp = cmdPASS.Parameters.Add("@check", SqlDbType.Int);
                VALIDp.Direction = ParameterDirection.Output;
                conn.Open();
                cmdPASS.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd2 = new SqlCommand("usernameTaken", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@username", username));
                SqlParameter validU = cmd2.Parameters.Add("@taken", SqlDbType.Int);
                validU.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                if (validU.Value.ToString().Equals("0"))
                {
                    Response.Write("You are not registered!");
                }
                else
                {
                    if (VALIDp.Value.ToString().Equals("0"))
                    {
                        Response.Write("Wrong Password");
                    }
                    else
                    {
                        if (success.Value.ToString().Equals("True"))
                        {



                            Session["user"] = username;
                            type.Direction = ParameterDirection.Output;
                            if (type.Value.ToString().Equals("0"))
                            {
                                Response.Redirect("Hello_Customer.aspx", true);

                            }
                            else if (type.Value.ToString().Equals("1"))
                            {
                                Response.Redirect("Hello_Vendor.aspx", true);

                            }
                            else if (type.Value.ToString().Equals("2"))
                            {
                                Response.Redirect("Hello_Admin.aspx", true);

                            }
                            else if (type.Value.ToString().Equals("3"))
                            {
                                Response.Redirect("Hello_Delivery_Person.aspx", true);

                            }


                        }
                        else
                        {

                            Response.Write("You are not registered, try again!");
                        }
                    }
                }
            }
            else
            {
                Response.Write("Fill in username and password u big disgrace!");
            }
        }
        public void registerCust(object sender, EventArgs args)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("customerRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (txt_password.Text != "" && txt_username.Text != "")
            {
                string username = txt_username.Text;

                SqlCommand cmd2 = new SqlCommand("usernameTaken", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@username", username));
                SqlParameter taken = cmd2.Parameters.Add("@taken", SqlDbType.Int);
                taken.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                Session["user"] = username;
                string first_name = txt_first_name.Text;
                string last_name = txt_last_name.Text;
                string password = txt_password.Text;
                string email = txt_email.Text;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@first_name", first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", last_name));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                if (taken.Value.ToString().Equals("0"))
                {
                    

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Hello_Customer.aspx", true);
                }
                else
                {
                    Response.Write("This username is already taken. Please try another one.");
                }

            }
            else
            {
                Response.Write("Fill in both username and password at the very least.");
            }

        }
            public void registerVendor(object sender, EventArgs args)
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd = new SqlCommand("vendorRegister", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            if (txt_passwordvend.Text != "" && txt_usernamevend.Text != "") { 
                string username = txt_usernamevend.Text;
            SqlCommand cmd2 = new SqlCommand("usernameTaken", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter taken = cmd2.Parameters.Add("@taken", SqlDbType.Int);
            taken.Direction = ParameterDirection.Output;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            Session["user"] = username;
                string first_name = txt_first_namevend.Text;
                string last_name = txt_last_namevend.Text;
                string password = txt_passwordvend.Text;
                string email = txt_email.Text;
                string company_name = txt_company_name.Text;
                string bank_acc_no = txt_bank_acc_no.Text;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@first_name", first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", last_name));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@company_name", company_name));
                cmd.Parameters.Add(new SqlParameter("@bank_acc_no", bank_acc_no));
                if (taken.Value.ToString().Equals("0"))
                {


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Hello_Vendor.aspx", true);
                }
                else
                {
                    Response.Write("This username is already taken. Please try another one.");
                }
            }
            else
            {
                Response.Write("Fill in both username and password at the very least.");
            }

        }

        }
}

    
