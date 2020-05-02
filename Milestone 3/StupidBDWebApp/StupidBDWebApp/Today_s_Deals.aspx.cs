using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace StupidBDWebApp
{

    public partial class Today_s_Deals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CreateDeal(object sender, EventArgs args)
        {
            if (txt_deal_amount.Text != "" && txt_date.Text != "")
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd = new SqlCommand("createTodaysDeal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int deal_amount = int.Parse(txt_deal_amount.Text);
                string admin_username = (String)Session["user"];
                //DateTime expire = DateTime.Parse(txt_date.Text);
                DateTime expire;
                bool res = DateTime.TryParse(txt_date.Text, out expire);
                if (res)
                {
                    cmd.Parameters.Add(new SqlParameter("@deal_amount", deal_amount));
                    cmd.Parameters.Add(new SqlParameter("@admin_username", admin_username));
                    cmd.Parameters.Add(new SqlParameter("@expiry_date", expire));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("New Today's Deal has been created successfully.");
                }
                else
                {
                    Response.Write("Enter a valid date in the correct format genius");
                }
            }
            else
            {
                Response.Write("Fill in all fields.");
            }
        }
        public void AddDeal(object sender, EventArgs args)
        {
            if (!TextBoxaddDeal.Text.Equals("") && !TextBoxserial_no.Text.Equals(""))
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd = new SqlCommand("addTodaysDealOnProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int tdeal_id = int.Parse(TextBoxaddDeal.Text);
                int serial_no = int.Parse(TextBoxserial_no.Text);
                cmd.Parameters.Add(new SqlParameter("@deal_id", tdeal_id));
                cmd.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                SqlCommand cmddeal = new SqlCommand("ValidDeal", conn);
                cmddeal.CommandType = CommandType.StoredProcedure;
                cmddeal.Parameters.Add(new SqlParameter("@deal_id", tdeal_id));
                SqlParameter validdeal = cmddeal.Parameters.Add("@validd", SqlDbType.Int);
                validdeal.Direction = ParameterDirection.Output;
                conn.Open();
                cmddeal.ExecuteNonQuery();
                conn.Close();
                if (validdeal.Value.ToString().Equals("0"))
                {
                    Response.Write("No deal with that deal_id, Enter Valid deal_id");
                }
                else
                {
                    SqlCommand cmdser = new SqlCommand("ValidProduct", conn);
                    cmdser.CommandType = CommandType.StoredProcedure;
                    cmdser.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                    SqlParameter validserial = cmdser.Parameters.Add("@validp", SqlDbType.Int);
                    validserial.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmdser.ExecuteNonQuery();
                    conn.Close();
                    if (validserial.Value.ToString().Equals("0"))
                    {
                        Response.Write("No product with that serial_no, Enter Valid serial_no");
                    }
                    else
                    {
                        SqlCommand cmddp = new SqlCommand("checkDealOnProduct", conn);
                        cmddp.CommandType = CommandType.StoredProcedure;
                        cmddp.Parameters.Add(new SqlParameter("@serial_no", serial_no));
                        SqlParameter alreadyhas = cmddp.Parameters.Add("@exist", SqlDbType.Int);
                        alreadyhas.Direction = ParameterDirection.Output;
                        conn.Open();
                        cmddp.ExecuteNonQuery();
                        conn.Close();
                        if (alreadyhas.Value.ToString().Equals("0"))
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Response.Write("Today's Deal added to product successfully!");
                        }
                        else { Response.Write("This product already has a deal on it."); }
                    }
                }
            }
            else
            {
                Response.Write("Fill in all fields.");
            }
        }
        public void RemoveDeal(object sender, EventArgs args)
        {
            if (!txt_deal_id.Text.Equals(""))
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=DBSucks;User Id=sa;Password=Password123");
                SqlCommand cmd = new SqlCommand("removeExpiredDeal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int deal_id = int.Parse(txt_deal_id.Text);
                cmd.Parameters.Add(new SqlParameter("@deal_id", deal_id));
                SqlCommand cmd2 = new SqlCommand("ValidDeal", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@deal_id", deal_id));
                SqlParameter validdeal = cmd2.Parameters.Add("@validd", SqlDbType.Int);
                validdeal.Direction = ParameterDirection.Output;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                if (validdeal.Value.ToString().Equals("0"))
                {
                    Response.Write("No deal with that deal_id, Enter Valid deal_id");
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("checkExpiryOfDeal", conn);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.Add(new SqlParameter("@deal_id", deal_id));
                    SqlParameter expire = cmd3.Parameters.Add("@expired", SqlDbType.Int);
                    expire.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    if (expire.Value.ToString().Equals("0"))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Expired Today's Deal removed successfully. Or so I hope");
                    }
                    else
                    {
                        Response.Write("Today's Deal is not expired and can not be removed. BOOHOOO FOR YOU!");
                    }
                }
            }
            else
            {
                Response.Write("Fill in all fields.");
            }
        }

    }
}
