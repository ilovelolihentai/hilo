using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using EDP_Project.ServiceReference1;

namespace EDP_Project
{
    public partial class Admin : System.Web.UI.Page
    {
        static string userid = null;
        string MyDB = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            userid = Session["UserID"].ToString();
            if (CheckAcc(userid) != "Admin")
            {
                Response.Redirect("~/CustomError/403.html", false);
            }
            RefreshGridView();

        }
        protected void btnGetUser_Click(object sender, EventArgs e)
        {
            LoadUser();

        }
        protected void btnDelUser_Click(object sender, EventArgs e)
        {
            DeleteUser();

        }
        protected void btnUnDelUser_Click(object sender, EventArgs e)
        {
            UnDeleteUser();

        }
        protected void LoadUser()
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User cusObj = client.GetUserById(tbUserName.Text);
            if (cusObj != null)
            {
                PanelCust.Visible = true;
                Lbl_username.Text = cusObj.Username;
                Lbl_Email.Text = cusObj.Email;
                Lbl_Delete.Text = cusObj.Delete;
                Lbl_err.Text = String.Empty;

            }
            else
            {
                Lbl_err.Text = "User record not found!";
                PanelCust.Visible = false;
                Lbl_username.Text = String.Empty;
                Lbl_Email.Text = String.Empty;
                Lbl_Delete.Text = String.Empty;

            }
        }
        protected void DeleteUser()
        {

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User cusObj = client.DeleteUserById(tbUserName.Text);
            Lbl_err.Text = "User Deleted!";
            PanelCust.Visible = false;

        }
        protected void UnDeleteUser()
        {

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User cusObj = client.UnDeleteUserById(tbUserName.Text);

            Lbl_err.Text = "User re-added!";
            PanelCust.Visible = false;



        }

        private void RefreshGridView()
        {
            List<User> eList = new List<User>();
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            eList = client.GetAllUser().ToList<User>();

            // using gridview to bind to the list of user objects
            gvUser.Visible = true;
            gvUser.DataSource = eList;
            gvUser.DataBind();
        }
        protected string CheckAcc(string userid)
        {

            string s = null;

            SqlConnection connection = new SqlConnection(MyDB);
            string sql = "select Account FROM [User] WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["ACCOUNT"] != null)
                        {
                            if (reader["ACCOUNT"] != DBNull.Value)
                            {
                                s = reader["ACCOUNT"].ToString();
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
