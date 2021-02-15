using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDP_Project.ServiceReference1;

namespace EDP_Project
{
    public partial class AttractionsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                if (!IsPostBack)
                {
                    BindProductDetails();
                }
            }
            else
            {
                Response.Redirect("~/ViewAttractions1.aspx");
            }
        }

        private void BindProductDetails()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["Id"]);
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            Attractions cusObj = client.SelectAttractionsView(Request.QueryString["Id"]);

            if (cusObj != null)
            {
               
                Product_Desc.Text = cusObj._Desc;
                Product_Name.Text = cusObj._Name;
                Product_Price.Text = cusObj._unitPrice.ToString();
                Prod_Category.Text = cusObj._AttCategory;
                string Imagevar = "Images/"+ cusObj._Image;
                if (!string.IsNullOrEmpty(cusObj._Image))
                {
                    Prod_Image1.ImageUrl = Imagevar;
                    Prod_Image1.Visible = true;
    
                }
                else
                {
                }

            }
            else
            {

            }
        }
        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["Id"]);
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                CookiePID = CookiePID + "," + PID ;
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = CookiePID;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = PID.ToString();
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("AttractionsPage.aspx?Id =" + PID);
        }
    }
}