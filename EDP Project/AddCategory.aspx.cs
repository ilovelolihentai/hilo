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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryReapter1();
        }
        
        private void BindCategoryReapter1()
        {
            List<Category> cList = new List<Category>();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            cList = client.SelectCategoryAll()?.ToList<Category>();
            if (cList != null)
            {

                gvCategory.Visible = true;
                gvCategory.DataSource = cList;
                gvCategory.DataBind();
            }
            else
            {
                gvCategory.Visible = false;
            }
        }

protected void btnAddtxtCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Category(CatName) Values('" + txtCategory.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Category Added Successfully ');  </script>");
                txtCategory.Text = string.Empty;

                con.Close();
                //lblMsg.Text = "Registration Successfully done";
                //lblMsg.ForeColor = System.Drawing.Color.Green;
                txtCategory.Focus();


            }
        }

    }
}