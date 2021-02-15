using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyDBService.Entity
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Account { get; set; }

        public string Delete { get; set; }

        public User()
        {

        }
        // Define a constructor to initialize all the properties
        public User(string username, string email, string passwordHash, string passwordSalt, string account, string delete)
        {
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Account = account;
            Delete = delete;

        }

        public User SelectByEmail(string email)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [User] where nric = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            User emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string username = row["username"].ToString();
                string passwordHash = row["passwordhash"].ToString();
                string passwordSalt = row["passwordsalt"].ToString();
                string account = row["account"].ToString();
                string delete = row["delete"].ToString();

                User obj = new User(username, email, passwordHash, passwordSalt, account, delete);
            }
            return emp;
        }

        public List<User> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from [User]";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<User> empList = new List<User>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string username = row["username"].ToString();
                string email = row["email"].ToString();
                string passwordHash = row["passwordhash"].ToString();
                string passwordSalt = row["passwordsalt"].ToString();
                string account = row["account"].ToString();
                string delete = row["delete"].ToString();


                User obj = new User(username, email, passwordHash, passwordSalt, account, delete);
                empList.Add(obj);
            }
            return empList;
        }
        public User SelectById(string email)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from [User] where email = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            User obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string username = row["username"].ToString();
                string passwordHash = row["passwordhash"].ToString();
                string passwordSalt = row["passwordsalt"].ToString();
                string account = row["account"].ToString();
                string delete = row["delete"].ToString();

                obj = new User(username, email, passwordHash, passwordSalt, account, delete);
            }
            return obj;
        }
        public User DeleteById(string email)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Update [User] set [delete] = @true where email = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", email);
            da.SelectCommand.Parameters.AddWithValue("@true", "True");

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            return null;
        }
        public User UpdateById(string email, string username)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Update [User] set Username = @Username where email = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", email);
            da.SelectCommand.Parameters.AddWithValue("@Username", username);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            return null;
        }
        public User UnDeleteById(string email)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Update [User] set [delete] = @true where email = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", email);
            da.SelectCommand.Parameters.AddWithValue("@true", "False");

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            return null;
        }
    }
}
