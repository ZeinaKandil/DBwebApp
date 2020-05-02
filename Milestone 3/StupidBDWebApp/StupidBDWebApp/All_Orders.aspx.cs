using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StupidBDWebApp
{

    public partial class All_Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("reviewOrders", connection);

                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[1]));

                    Label lbl_order_no = new Label();
                    lbl_order_no.Text = String.Format("{0}", "Order: ") + reader[0] + "  ";
                    form1.Controls.Add(lbl_order_no);

                    Label lbl_date = new Label();
                    lbl_date.Text = String.Format("{0}", "on: ") + reader[1] + "  ";
                    form1.Controls.Add(lbl_date);

                    Label lbl_price = new Label();
                    lbl_price.Text = String.Format("{0}", ", paid ") + reader[2] + "  ";
                    form1.Controls.Add(lbl_price);

                    Label lbl_cash = new Label();
                    lbl_cash.Text = String.Format("{0}", ", ") + reader[3] + "  in cash and ";
                    form1.Controls.Add(lbl_cash);

                    Label lbl_credit = new Label();
                    lbl_credit.Text = String.Format("{0}", "") + reader[4] + "  in credit. ";
                    form1.Controls.Add(lbl_credit);

                    Label lbl_pay = new Label();
                    lbl_pay.Text = String.Format("{0}", "Payment type: ") + reader[5] + ". ";
                    form1.Controls.Add(lbl_pay);

                    Label lbl_stat = new Label();
                    lbl_stat.Text = String.Format("{0}", "Order is ") + reader[6] + " ";
                    form1.Controls.Add(lbl_stat);

                    Label lbl_rem = new Label();
                    lbl_rem.Text = String.Format("{0}", "") + reader[7] + " days remaining. ";
                    form1.Controls.Add(lbl_rem);

                    Label lbl_time = new Label();
                    lbl_time.Text = String.Format("{0}", "Time limit: ") + reader[8] + ", ";
                    form1.Controls.Add(lbl_time);

                    Label lbl_gc = new Label();
                    lbl_gc.Text = String.Format("{0}", "Giftcard used: ") + reader[9] + ". ";
                    form1.Controls.Add(lbl_gc);

                    Label lbl_cus = new Label();
                    lbl_cus.Text = String.Format("{0}", "Order by ") + reader[10] + ". ";
                    form1.Controls.Add(lbl_cus);

                    Label lbl_del = new Label();
                    lbl_del.Text = String.Format("{0}", "Delivery: ") + reader[11] + ". ";
                    form1.Controls.Add(lbl_del);

                    Label lbl_cc = new Label();
                    lbl_cc.Text = String.Format("{0}", "creditCard: ") + reader[11] + ". </br> </br>";
                    form1.Controls.Add(lbl_cc);



                }

                connection.Close();
            }

        }



    }
}
