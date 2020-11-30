using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient; //needed for sqlparameter
using System.ComponentModel; //required for ODS exposure
#endregion

namespace NorthwindSystem.BLL
{
    //expose this class to the ObjectDataSource wizard
    //this will allow for easy selection of values for 
    //the wizard, and the wizard will generate my code
    [DataObject]
    public class ProductController
    {
        public List<Product> Product_ListAll()
        {

            using (var context = new NorthwindSystemContext())
            {

                return context.Products.ToList();
            }
        }
        //lookup by primary key
        public Product Product_FindByID(int productid)
        {
            
            using (var context = new NorthwindSystemContext())
            {
                
                return context.Products.Find(productid);
            }
        }

        //lookup using a non primary key field
        //expose the method you wish the wizard to know about
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Product> Product_GetByPartialProductName(string productname)
        {
            using(var context = new NorthwindSystemContext())
            {
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByPartialProductName @PartialName",
                    new SqlParameter("PartialName", productname));
                return results.ToList();
            }
        }
    }
}
