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
    public class Site
    {
        // Define class properties
        public string Nric { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Dept { get; set; }
        public double MthlySalary { get; set; }
        public double EmployeeCPF { get; set; }
        public double EmployerCPF { get; set; }

        public Site()
        {

        }
        // Define a constructor to initialize all the properties
        public Site(string nric, string name, string dob, string dept, double mthlyWage)
        {
            Nric = nric;
            Name = name;
            Birthdate = dob;
            Dept = dept;
            MthlySalary = mthlyWage;
  
        }

        
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Employee (nric, name, birthdate, department, mthlySalary) " +
                "VALUES (@paraNric,@paraName, @paraBirthdate, @paraDept, @paraMthlySalary)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", Nric);
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraBirthdate", Birthdate);
            sqlCmd.Parameters.AddWithValue("@paraDept", Dept);
            sqlCmd.Parameters.AddWithValue("@paraMthlySalary", MthlySalary);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Site SelectByNric(string nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Employee where nric = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNric", nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Site emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string name = row["name"].ToString();
                string dob = row["birthdate"].ToString();
                string dept = row["department"].ToString();
                string payStr = row["mthlySalary"].ToString();
                double pay = Convert.ToDouble(payStr);
                emp = new Site(nric, name, dob, dept, pay);
            }
            return emp;
        }
        public Site UpdateByNric(string nric, string name)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Update Employee Set Name = hellothere where nric = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNric", nric);
            da.SelectCommand.Parameters.AddWithValue("@paraName", name);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Site emp = null;

            return emp;
        }
        public Site DeleteByNric(string nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Delete from Employee where nric = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNric", nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Site emp = null;
            
            return emp;
        }

        public List<Site> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Site> empList = new List<Site>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                string dob = row["birthdate"].ToString();
                string dept = row["department"].ToString();
                string payStr = row["mthlySalary"].ToString();
                double pay = Convert.ToDouble(payStr);
                Site obj = new Site(nric, name, dob, dept, pay);
                empList.Add(obj);
            }
            return empList;
        }
    }
}
