using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void addtoWishlist(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            if (!(txt_serial_no.Text.Equals("") && txt_wish_name1.Text.Equals("")))
            {
                SqlCommand cmds = new SqlCommand("wishexists", conn);
                cmds.CommandType = CommandType.StoredProcedure;
                string customer_name = (String)Session["user"];
                string wish_name = txt_wish_name1.Text;
                cmds.Parameters.Add(new SqlParameter("@customername", customer_name));
                cmds.Parameters.Add(new SqlParameter("@wishname", wish_name));
                SqlParameter exists1 = cmds.Parameters.Add("@exists", SqlDbType.Int);
                exists1.Direction = ParameterDirection.Output;
                conn.Open();
                cmds.ExecuteNonQuery();
                conn.Close();
                if (exists1.Value.ToString().Equals("0"))
                {
                    Response.Write("You don't have a wishlist with this name");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("AddtoWishlist", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    int serial_no = int.Parse(txt_serial_no.Text);
                    cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
                    cmd.Parameters.Add(new SqlParameter("@wishlistname", wish_name));
                    cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
                    SqlCommand cmd2 = new SqlCommand("EXISTSinWish", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                    cmd2.Parameters.Add(new SqlParameter("@CNAME", customer_name));
                    cmd2.Parameters.Add(new SqlParameter("@list", wish_name));
                    SqlParameter exists = cmd2.Parameters.Add("@exists", SqlDbType.Int);
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
                            Response.Write("This product is already in this wishlist");

                        }
                        else
                        {
                            conn.Open();
                            cmd4.ExecuteNonQuery();
                            conn.Close();
                            if (availablep.Value.ToString().Equals("1"))
                            {
                                Response.Write("The product has been added to your wishlist successfully");
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

                    }

                }
            }

            else
            {

                Response.Write("enter a serial number.");

            }
            }
        


            protected void removefromWishlist(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            if (!(txt_serial_no.Text.Equals("") && txt_wish_name2.Text.Equals("")))
            {
                SqlCommand cmds = new SqlCommand("wishexists", conn);
                cmds.CommandType = CommandType.StoredProcedure;
                string customer_name = (String)Session["user"];
                string wish_name = txt_wish_name2.Text;
                cmds.Parameters.Add(new SqlParameter("@customername", customer_name));
                cmds.Parameters.Add(new SqlParameter("@wishname", wish_name));
                SqlParameter exists1 = cmds.Parameters.Add("@exists", SqlDbType.Int);
                exists1.Direction = ParameterDirection.Output;
                conn.Open();
                cmds.ExecuteNonQuery();
                conn.Close();
                if (exists1.Value.ToString().Equals("0"))
                {
                    Response.Write("You don't have a wishlist with this name");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("removefromWishlist", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int serial_no = int.Parse(txt_serial_no2.Text);
                    cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
                    cmd.Parameters.Add(new SqlParameter("@wishlistname", wish_name));
                    cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
                    SqlCommand cmd2 = new SqlCommand("EXISTSinWish", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                    cmd2.Parameters.Add(new SqlParameter("@CNAME", customer_name));
                    cmd2.Parameters.Add(new SqlParameter("@list", wish_name));
                    SqlParameter exists = cmd2.Parameters.Add("@exists", SqlDbType.Int);
                    exists.Direction = ParameterDirection.Output;
                    //Executing the SQLCommand
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    if (exists.Value.ToString().Equals("0"))
                    {
                        Response.Write("The product you are trying to remove is not in your wishlist, make sure you are entering the right serial number");

                    }
                    else
                    {
                        Response.Write("The product has been removed from your wishlist successfully");
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            }
            else
            {

                Response.Write("enter a serial number.");

            }


        }
        protected void createWishlist(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            if (!(txt_name.Text.Equals("")))
            {
                SqlCommand cmd = new SqlCommand("createWishlist", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string customer_name = (String)Session["user"];
                string name = txt_name.Text;
                cmd.Parameters.Add(new SqlParameter("@customername", customer_name));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                SqlCommand cmd2 = new SqlCommand("existswish", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@customername", customer_name));
                cmd2.Parameters.Add(new SqlParameter("@wishname", name));
                SqlParameter exists = cmd2.Parameters.Add("@exists", SqlDbType.Int);
                exists.Direction = ParameterDirection.Output;

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                if (exists.Value.ToString().Equals("1"))
                {
                    Response.Write("You already have a wishlist with this name, try another name");

                }
                else
                {
                    Response.Write("Your wishlist has been added. WOHOOO!");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            else
            {

                Response.Write("enter a wishlist name.");

            }

            //Executing the SQLCommand


        }

    }
}
