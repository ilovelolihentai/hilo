using Microsoft.Ajax.Utilities;
using MyDBService.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Pract4
{
    public partial class SiteCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       
        
        
        private bool ValidateInput()
        {
            bool result;
            lbMsg.Text = String.Empty;
            lbMsg.ForeColor = Color.Red;
            if (tbNric.Text == "")
            {
                lbMsg.Text += "Name is required!" + "<br/>";
            }
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Site emp = client.GetEmployeeByNric(tbNric.Text);
            if (emp != null)
            {
                lbMsg.Text += "Name already exists!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbName.Text))
            {
                lbMsg.Text += "Name is required!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbBirthDate.Text))
            {
                lbMsg.Text += "Date is required!" + "<br/>";
            }

            if (String.IsNullOrEmpty(ddlDept.Text))
            {
                lbMsg.Text += "Name is required!" + "<br/>";
            }
            double wage;
            result = double.TryParse(tbMthlySalary.Text, out wage);
            if (!result)
            {
                lbMsg.Text += "Monthly Wage is invalid!" + "<br/>";
            }

            if (String.IsNullOrEmpty(lbMsg.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            bool validInput = ValidateInput();

            if (validInput)
            {
                string dob = tbBirthDate.Text;
                double wage = Convert.ToDouble(tbMthlySalary.Text);

                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int result = client.CreateEmployee(tbNric.Text, tbName.Text, dob, ddlDept.Text, wage);
                if (result == 1)
                {
                    
                    lbMsg.ForeColor = Color.Green;
                    lbMsg.Text = "Record Inserted Successfully!";
                }
                else
                    lbMsg.Text = "SQL Error. Insert Unsuccessful!";
            }
        }

    }
}