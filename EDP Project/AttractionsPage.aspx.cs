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
                    Prod_Image2.ImageUrl = Imagevar;
                    Prod_Image2.Visible = true;
                }
                else
                {
                }

            }
            else
            {

            }
        }
    }
}