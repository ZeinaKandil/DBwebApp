using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace StupidDBWebApp
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123"))

            {
                conn.Open();


                SqlCommand command = new SqlCommand("vendorviewProducts", conn);
                command.CommandType = CommandType.StoredProcedure;
                string vendor_name = (String)Session["user"];
                command.Parameters.Add(new SqlParameter("@vendorname", vendor_name));





                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[1]));

                    Label lbl_serial_no = new Label();
                    lbl_serial_no.Text = " Serial Number: " + String.Format("{0}", reader[0]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_serial_no);


                    Label lbl_product_name = new Label();
                    lbl_product_name.Text = "Product Name: " + String.Format("{0}", reader[1]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_product_name);

                    Label lbl_category = new Label();
                    lbl_category.Text = "Category: " + String.Format("{0}", reader[2]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_category);

                    Label lbl_product_description = new Label();
                    lbl_product_description.Text = "Product Description: " + String.Format("{0}", reader[3]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_product_description);

                    Label lbl_price = new Label();
                    lbl_price.Text = "Price: " + String.Format("{0}", reader[4]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_price);

                    Label lbl_final_price = new Label();
                    lbl_final_price.Text = "Final Price: " + String.Format("{0}", reader[5]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_final_price);


                    Label lbl_color = new Label();
                    lbl_color.Text = "Color: " + String.Format("{0}", reader[6]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_color);

                    Label lbl_available = new Label();
                    lbl_available.Text = "Available: " + String.Format("{0}", reader[7]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_available);

                    Label lbl_rate = new Label();
                    lbl_rate.Text = "Rate: " + String.Format("{0}", reader[8]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_rate);

                    Label lbl_vendor_username = new Label();
                    lbl_vendor_username.Text = "Vendor Username: " + String.Format("{0}", reader[9]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_vendor_username);

                    Label lbl_customer_username = new Label();
                    lbl_customer_username.Text = "Customer Username: " + String.Format("{0}", reader[10]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_customer_username);


                    Label lbl_customer_order_id = new Label();
                    lbl_customer_order_id.Text = "Customer order ID: " + String.Format("{0}", reader[11]) + "  <br /> <br />";
                    form1.Controls.Add(lbl_customer_order_id);


                    //Button clickMe = new Button();
                    //clickMe.Attributes.Add("OnClick", "btn_Click");
                    //clickMe.Attributes.Add("product", );

                    //Button clickMe = new Button();
                    //clickMe.Text = "Edit";
                    ////clickMe.Attributes.Add("OnClick", "EditProduct");
                    //clickMe.Click += new EventHandler(EditProduct);
                    //clickMe.ID = String.Format("{0}", reader[0]);
                    //form1.Controls.Add(clickMe);

                    //Label seperate = new Label();
                    //seperate.Text = "  <br /> <br />" + "  <br /> <br />";
                    //form1.Controls.Add(seperate);

                }

                conn.Close();
            }
        }

        public void EditProduct(object sender, EventArgs e)
        {
            //Console.WriteLine("Edit Product number: " + ((Button)sender).ID);
            Response.Redirect("edit.aspx", true);

        }

        protected void Offers(object sender, EventArgs e)
        {
            Response.Redirect("Offers.aspx", true);
        }

    }
}