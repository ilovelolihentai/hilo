using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using EDP_Project.ServiceReference1;
namespace EDP_Project
{
    public partial class Login : System.Web.UI.Page
    {
        string MyDB = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx", false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string userid = tbName.Text.ToString().Trim();
            string pwd = tbPwd.Text.ToString().Trim();
            SHA512Managed hashing = new SHA512Managed();
            string dbHash = getDBHash(userid);
            string dbSalt = getDBSalt(userid);
            try
            {
                if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
                {
                    string pwdWithSalt = pwd + dbSalt;
                    byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                    string userHash = Convert.ToBase64String(hashWithSalt);
                    lbl_error.Text = CheckDel(userid).ToString();
                    if (CheckDel(userid) == "False")
                    {
                        if (userHash.Equals(dbHash))
                        {

                            Session["UserID"] = userid;

                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            lbl_error.Text = CheckAcc(userid).ToString();
                            if (CheckAcc(userid) == "Seller")
                            {
                                Response.Redirect("SignUp.aspx", false);
                            }
                            else if (CheckAcc(userid) == "Buyer")
                            {
                                Response.Redirect("SignUp.aspx", false);
                            }
                            else if (CheckAcc(userid) == "Admin")
                            {
                                Response.Redirect("Admin.aspx", false);
                            }


                        }
                        else
                        {
                            lbl_error.Text = "Email or password is not valid. Please try again.";
                            lbl_error.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lbl_error.Text = "Account Deleted. Please Contact Admin if this is a mistake.";
                        lbl_error.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            finally { }
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
        protected string CheckDel(string userid)
        {

            string s = null;

            SqlConnection connection = new SqlConnection(MyDB);
            string sql = "select [Delete] FROM [User] WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Delete"] != null)
                        {
                            if (reader["Delete"] != DBNull.Value)
                            {
                                s = reader["Delete"].ToString();
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
        protected string getDBSalt(string userid)
        {

            string s = null;

            SqlConnection connection = new SqlConnection(MyDB);
            string sql = "select PASSWORDSALT FROM [User] WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PASSWORDSALT"] != null)
                        {
                            if (reader["PASSWORDSALT"] != DBNull.Value)
                            {
                                s = reader["PASSWORDSALT"].ToString();
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

        protected string getDBHash(string userid)
        {
            string h = "0";
            SqlConnection connection = new SqlConnection(MyDB);
            string sql = "select PasswordHash FROM [User] WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PasswordHash"] != null)
                        {
                            if (reader["PasswordHash"] != DBNull.Value)
                            {
                                h = reader["PasswordHash"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            finally { connection.Close(); }
            return h;
        }
        protected string getpwd(string id)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MyDB);
            string sql = "select name from Employee where nric=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", id);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"] != null)
                        {
                            if (reader["name"] != DBNull.Value)
                            {
                                s = reader["name"].ToString();
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
