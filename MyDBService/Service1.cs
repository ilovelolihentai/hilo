using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyDBService.Entity;

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
        //Attractions
        public List<Attractions> SelectAttractionsAll()
        {
            Attractions emp = new Attractions();
            return emp.GetAttractionsAll();
        }
        public Attractions SelectAttractions(string ID)
        {
            Attractions emp = new Attractions();
            return emp.GetAttractions(ID);
        }
        public int CreateAttractions(string ID, string Name, string Desc,
                       decimal unitPrice, string Image,string ProdCat)
        {
            Attractions emp = new Attractions(ID, Name, Desc, unitPrice, Image, ProdCat);
            return emp.Insert();
        }
        //Category
        public int CreateCategory(string ID, string Name)
        {
            Category emp = new Category(ID, Name);
            return emp.Insert();
        }

        public List<Category> SelectCategoryAll()
        {
            Category emp = new Category();
            return emp.GetCategoryAll();
        }
        public Category SelectCategory(string ID)
        {
            Category emp = new Category();
            return emp.GetCategory(ID);
        }
        public Attractions SelectAttractionsView(string ID)
        {
            Attractions emp = new Attractions();
            return emp.GetAttractionsView(ID);
        }
    }
}
