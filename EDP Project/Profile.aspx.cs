using Microsoft.Ajax.Utilities;
using EDP_Project.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EDP_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        static string userid = null;
        string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        protected void LoadUser()
        {
            userid = Session["UserID"].ToString();
            lbl_error.Text = userid;
            string email = CheckEmail(userid);
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User cusObj = client.GetUserById(email);
            if (cusObj != null)
            {

                lbl_name.Text = cusObj.Username;
                lbl_email.Text = cusObj.Email;
            }
            else
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx", false);


        }
        protected void BtnClickUpdate(object sender, EventArgs e)
        {

        }
        protected void UpdateUser()
        {

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User cusObj = client.UpdateUserById(lbl_email.Text, lbl_name.Text);


        }
        protected string CheckEmail(string userid)
        {

            string s = null;

            SqlConnection connection = new SqlConnection(ConnStr);
            string sql = "select Email FROM [User] WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Email"] != null)
                        {
                            if (reader["Email"] != DBNull.Value)
                            {
                                s = reader["Email"].ToString();
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
            }

            finally { connection.Close(); }
            return s;

        }


    }
}