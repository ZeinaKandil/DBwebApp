using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Offers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
           
        }
        protected void checkOfferonProduct(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("checkOfferonProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int serial_no = int.Parse(txt_serial_no.Text);
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));
            SqlParameter activeoffer = cmd.Parameters.Add("@activeoffer", SqlDbType.Int);

            activeoffer.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (activeoffer.Value.ToString().Equals("1")){

                //Session["serial"] = serial_no;
                Response.Write("Offer is active.");
            }
            if (activeoffer.Value.ToString().Equals("0")) {
                //Session["serial"] = serial_no;
                Response.Write("Offer is not active.");
            }
           

        }

        protected void addOffer(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("addOffer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int offeramount = int.Parse(txt_offeramount.Text);
            cmd.Parameters.Add(new SqlParameter("@offeramount", offeramount));
            string expiry_date = txt_expiry_date.Text;
            DateTime x;
            //=DateTime.Parse(expiry_date);
            bool res = DateTime.TryParse(expiry_date, out x);
            if (expiry_date.Length == 0)
                Response.Write("Please enter the offer's expiry date.");

            else
            {
                cmd.Parameters.Add(new SqlParameter("@expiry_date", expiry_date));

                Response.Write("Offer was added.");

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        protected void applyOffer(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("applyOffer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string vendorname = txt_vendorname.Text;
            cmd.Parameters.Add(new SqlParameter("@vendorname", vendorname));
            int offerid = int.Parse(txt_offerid.Text);
            cmd.Parameters.Add(new SqlParameter("@offerid", offerid));
            int serial_no = int.Parse(txt_serial_no2.Text);
            cmd.Parameters.Add(new SqlParameter("@serial", serial_no));

            SqlCommand cmd2 = new SqlCommand("checkOfferonProduct", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@serial", serial_no));
            SqlParameter success = cmd2.Parameters.Add("@activeoffer", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString().Equals("1"))
            {
                Response.Write("There is already an active offer on this product.");
            }

            else
            {
                Response.Write("Offer applied.");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void checkandremoveExpiredOffer(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
            SqlCommand cmd = new SqlCommand("checkandremoveExpiredOffer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int offerid = int.Parse(txt_offerid2.Text);
            cmd.Parameters.Add(new SqlParameter("@offerid", offerid));

            SqlParameter success = cmd.Parameters.Add("@expired", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString().Equals("0"))
            {
                Response.Write("Offer is not expired.");
            }


            else
            {
                Response.Write("Expired offer removed.");
                
            }

        }
    }
}
