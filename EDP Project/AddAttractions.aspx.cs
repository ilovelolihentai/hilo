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
    public partial class AddAttractions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategory();


        }
        private void BindCategory()
        {
            List<Category> cList = new List<Category>();

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            cList = client.SelectCategoryAll()?.ToList<Category>();
            if (cList != null)
            {

                ddlCategory.DataSource = cList;
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0")); 
            }
            else
            {
                ddlCategory.Visible = false;
            }
          /*  using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }*/
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            int value = int.Parse(ddlCategory.SelectedItem.Value);
            int value2 = value + 1;

            Category selected = client.SelectCategory(value2.ToString());
            var list = new List<Category>();
            list.Add(selected);

            ddlCategory.DataSource = list;
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            

                
            
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool validInput = true;
            string image = "";

            if (validInput)
            {
                if (FileUpload1.HasFile == true)
                {
                    image = "Images\\" + FileUpload1.FileName;
                }
                int value = int.Parse(ddlCategory.SelectedItem.Value);
                int value2 = value + 1;
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                int result = client.CreateAttractions(tbID.Text, tbName.Text, tbDescription.Text, decimal.Parse(tbunitprice.Text), FileUpload1.FileName,value2.ToString());
                if (result == 1)
                {
                    string saveimg = Server.MapPath(" ") + "\\" + image;
                    lbl_Result.Text = saveimg.ToString();
                    FileUpload1.SaveAs(saveimg);
                    lbMsg.Text = "Attraction Record Inserted Successfully!";
                }
                else
                    lbMsg.Text = "SQL Error. Insert Unsuccessful!";
            }
        }
   
        
    }
}
