﻿using System;
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
        #region Queries
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
        #endregion

        #region CRUD Methods: Add, Update, Delete
        public int Product_Add(Product item)
        {
            using (var context = new NorthwindSystemContext())
            {
                //optionally you may have business rules to implement
                // in this method
                //this would be coded logic to ensure the data is valid
                //in our example there are no additional business rules

                //staging
                //place you entity instance into your DbSet for processing
                // by EntityFramework
                //this data is in memory NOT yet on your SQL database
                //this means that the identity primary key has NOT YET been created
                //the primary key is created WHEN the data is sent to the database
                context.Products.Add(item);

                //commit your transaction to the database
                //if the following command aborts, then your data record is NOT 
                // on the database, the transaction is AUTOMATICALLY Rolled Back
                //after the success of the following command the instance will be
                // loaded with your new primary key identity value
                //  if you have entity VALIDATION ANNOTATION then when the following 
                //  command is executed, the entity validaion annotation will be 
                //  EXECUTED
                context.SaveChanges();

                //if you successfully execute SaveChanges your transaction is committed
                //at this point your entity instance will have the new primary identity value
                //returning the PK value is optional and part of your design process.
                return item.ProductID;
            } //closes the sql connection
        }

        public int Product_Update(Product item)
        {
            //logical code for any business rules

            //stage your update
            //the entire entity on the database will be updated,
            //all fields except the primary key
            using (var context = new NorthwindSystemContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                //commit of update
                //changes the database
                //the returned value of the execution is the RowsAffected on the database
                int rowsaffected = context.SaveChanges();
                //return context.SaveChanges();

                //optional (technically) actions afterwards
                return rowsaffected;
            }
        }

        public int Product_Delete(int productid)
        {
            using (var context = new NorthwindSystemContext())
            {
                int rowsaffected = 0;
                //find the current record by primary key
                Product exists = context.Products.Find(productid);

                //verify that you actually have an instance (object)
                //      of the product entity
                if (exists == null)
                {
                    throw new Exception("Product no longer on file. Refresh your search");
                }
                else
                {
                    //scenario LOGICAL DELETE

                    //you are really probably oing to alter a value on the instance
                    //then do an update
                    //DO NOT rly on the user to actually set the attribute
                    //      indicating "deletion"
                    //INSTEAD do it by the program
                    exists.Discontinued = true;

                    //stage the update
                    //a second technique for updating is to update a specific field
                    // WITHOUT needing to update the entire  entity
                    context.Entry(exists).Property("Discontinued").IsModified = true;

                    //scenario PHYSICAL DELETE

                    //stage the delete
                    //the record is physically removed from the database
                    //context.Products.Remove(exists);

                    //commit
                    //changes save to database
                    //return the value from the update/delete of rowsaffected
                    rowsaffected = context.SaveChanges();

                    //return the value
                    return rowsaffected;
                }
            }
        }
        #endregion
    }
}
