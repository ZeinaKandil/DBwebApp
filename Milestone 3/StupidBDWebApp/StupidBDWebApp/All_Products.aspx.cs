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

    public partial class All_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(
              "Server=localhost;Database=DBSucks;User Id=sa;Password=Password123"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("showProductsbyPrice", connection);
              
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[1]));

                   


                    Label lbl_product_name = new Label();
                    lbl_product_name.Text = String.Format("{0}", "Product Name: ") + reader[0] + "  ";
                    form1.Controls.Add(lbl_product_name);

                    Label lbl_product_description = new Label();
                    lbl_product_description.Text = String.Format("{0}", "Product Description: ") + reader[1] + "  ";
                    form1.Controls.Add(lbl_product_description);

                    Label lbl_price = new Label();
                    lbl_price.Text = String.Format("{0}", "Price: ") + reader[2] + "  ";
                    form1.Controls.Add(lbl_price);

                    

                    Label lbl_color = new Label();
                    lbl_color.Text = String.Format("{0}", "color: ") + reader[3] + " </br> </br>";
                    form1.Controls.Add(lbl_color);
                    Button clickMe = new Button();

                }

                connection.Close();
            }
        }
        protected void cart(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx", true);


        }

    }
}
