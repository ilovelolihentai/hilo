using MyDBService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Site> GetAllEmployee()
        {
            Site emp = new Site();
            return emp.SelectAll();
        }
        public Site GetEmployeeByNric(string nric)
        {
            Site emp = new Site();
            return emp.SelectByNric(nric);
        }
        public Site DeleteEmployeeByNric(string nric)
        {
            Site emp = new Site();
            return emp.DeleteByNric(nric);
        }
        public int CreateEmployee(string nric, string name, string dob, string dept, double wage)
        {
            Site emp = new Site(nric, name, dob, dept, wage);
            return emp.Insert();
        }
       
    }
}
