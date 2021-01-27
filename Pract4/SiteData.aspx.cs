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
    public partial class SiteData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }
        protected void btnGetEmp_Click(object sender, EventArgs e)
        {
            LoadEmp();
        }
        protected void btnDelEmp_Click(object sender, EventArgs e)
        {
            DeleteEmp();
        }
        protected void LoadEmp()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Site obj = client.GetEmployeeByNric(tbEmpId.Text);
            if(obj != null)
            {
                PanelErrorResult.Visible = false;
                PanelCust.Visible = true;
                Lbl_nric.Text = obj.Name;
                Lbl_name.Text = obj.Dept;
                Lbl_birthday.Text = Convert.ToString(obj.Birthdate);
                Lbl_mthlySalary.Text = Convert.ToString(obj.MthlySalary);
                Lbl_err.Text = String.Empty;

                HyplinkAdd.Visible = true;

            }
            else
            {
                Lbl_err.Text = "Attraction not found!";
                PanelErrorResult.Visible = true;
                PanelCust.Visible = false;
                Lbl_nric.Text = String.Empty;
                Lbl_name.Text = String.Empty;
                Lbl_birthday.Text = String.Empty;
                Lbl_mthlySalary.Text = String.Empty;
                HyplinkAdd.Visible = false;
            }
        }
        protected void DeleteEmp()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Site obj = client.DeleteEmployeeByNric(tbEmpId.Text);
            if (obj != null)
            {
                PanelErrorResult.Visible = false;
                PanelCust.Visible = true;
                Lbl_nric.Text = obj.Name;
                Lbl_name.Text = obj.Dept;
                Lbl_birthday.Text = Convert.ToString(obj.Birthdate);
                Lbl_mthlySalary.Text = Convert.ToString(obj.MthlySalary);
                Lbl_err.Text = String.Empty;

                HyplinkAdd.Visible = true;

            }
            else
            {
                Lbl_err.Text = "Attraction Deleted";
                PanelErrorResult.Visible = true;
                PanelCust.Visible = false;
                Lbl_nric.Text = String.Empty;
                Lbl_name.Text = String.Empty;
                Lbl_birthday.Text = String.Empty;
                Lbl_mthlySalary.Text = String.Empty;
                HyplinkAdd.Visible = false;
            }
        }
        protected void UpdateEmp()
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Site obj = client.UpdateEmployeeByNric(tbEmpId.Text);
            if (obj != null)
            {
                PanelErrorResult.Visible = false;
                PanelCust.Visible = true;
                Lbl_nric.Text = obj.Name;
                Lbl_name.Text = obj.Dept;
                Lbl_birthday.Text = Convert.ToString(obj.Birthdate);
                Lbl_mthlySalary.Text = Convert.ToString(obj.MthlySalary);
                Lbl_err.Text = String.Empty;

                HyplinkAdd.Visible = true;

            }
            else
            {
                Lbl_err.Text = "Attraction Deleted";
                PanelErrorResult.Visible = true;
                PanelCust.Visible = false;
                Lbl_nric.Text = String.Empty;
                Lbl_name.Text = String.Empty;
                Lbl_birthday.Text = String.Empty;
                Lbl_mthlySalary.Text = String.Empty;
                HyplinkAdd.Visible = false;
            }
        }
        private void RefreshGridView()
        {
            List<Site> eList = new List<Site>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            eList = client.GetAllEmployee().ToList<Site>();

            // using gridview to bind to the list of employee objects
            gvEmployee.Visible = true;
            gvEmployee.DataSource = eList;
            gvEmployee.DataBind();
        }
        
        

    }
}