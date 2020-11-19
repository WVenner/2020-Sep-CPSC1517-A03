using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.Data.Entity;
using NorthwindSystem.Entities;
#endregion

namespace NorthwindSystem.DAL
{
    //conect this class to the EntityFramework by inheriting DbContext
    //which is wihin the System.Data.Entity Library
    //we want to restrict access to this class to ONLY other classes in the same project.
    //Therefore the access is internal
    internal class NorthwindSystemContext : DbContext
    {
        //you will need a constructor that passes the connection string name
        //to EntityFramework via the inherited DbContext class
        public NorthwindSystemContext() : base("NWDB")
        {
            //default constructor
        }

        //properties to interact with EntityFramework
        //these properties represent the whole table and all 
        //  data of the sql database
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}
