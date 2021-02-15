using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDP_Project.ServiceReference1;

namespace EDP_Project
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductCart();
            }
        }
        protected void BindProductCart()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                
                DataTable dt = new DataTable();
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                Int64 CartTotal = 0;
                Int64 Total = 0;
                if (CookieDataArray.Length > 0)
                {
                    for (int i = 0; i<CookieDataArray.Length;i ++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string calenderdate = CookieDataArray[i].ToString().Split('-')[1];
                        string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


                        using (SqlConnection con = new SqlConnection(DBConnect))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from Attractions where Id = (" + PID + ")", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {

                                    sda.Fill(dt);
                                    dt.Columns.Add("Date", typeof(String));
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        //need to set value to NewColumn column
                                        row["Date"] = calenderdate;   // or set it to some other value
                                    }
                                    

                                }
                            }
                        }
                        CartTotal += Convert.ToInt64(dt.Rows[i]["price"]);
                    }



                }
                prtrCartProd.DataSource = dt;
                prtrCartProd.DataBind();
                spanCartTotal.InnerText = CartTotal.ToString();
            }
        }


                    


        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            Button btn = (Button)(sender);
            string PIDSIZE = btn.CommandArgument;
            List<String> CookiePIDList = CookieData.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDList.Remove(PIDSIZE);
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            if (CookiePIDUpdated =="")
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);

            }
            Response.Redirect("~/Cart.aspx");

        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {

        }
    }
}