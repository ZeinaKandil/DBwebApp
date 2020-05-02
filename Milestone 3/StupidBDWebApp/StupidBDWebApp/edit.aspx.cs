using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditProduct(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("EditProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {

            string vendorname = (String)Session["user"];
            string y = txt_serial_no.Text;
            int serialnumber = Int32.Parse(y);
            string product_name = txt_product_name.Text;
            string category = txt_category.Text;
            string product_description = txt_product_description.Text;
            String x = txt_price.Text;
            string color = txt_color.Text;


                

                cmd.Parameters.Add(new SqlParameter("@vendorname", vendorname));

                if (serialnumber == 0)
                    Response.Write("ENTER A SERIAL NUMBER");
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@serialnumber", serialnumber));

                }



                if (product_name.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@product_name", DBNull.Value));
                }

                else
                    cmd.Parameters.Add(new SqlParameter("@product_name", product_name));


            if (category.Length==0)
                    cmd.Parameters.Add(new SqlParameter("@category", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@category", category));



            if (product_description.Length == 0)
                    cmd.Parameters.Add(new SqlParameter("@product_description", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@product_description", product_description));


            if (x == "")
                    cmd.Parameters.Add(new SqlParameter("@price", DBNull.Value));
                else
                {
                    double price = double.Parse(x);
                    cmd.Parameters.Add(new SqlParameter("@price", price));

                }


                if (color.Length==0)
                    cmd.Parameters.Add(new SqlParameter("@color", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@color", color));

        
           


            Response.Write("Products were edited successfully.");

            cmd.ExecuteNonQuery();
            conn.Close();


            }
            catch (Exception)
            {
                Response.Write("Unsucessful");
            }

             
        }

    }
}
