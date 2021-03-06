﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Aditional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient; //needed for SqlParameter
using System.ComponentModel; //requried for ODS exposure
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject]
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Supplier> Supplier_ListAll()
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Suppliers.ToList();
            }
        }
    }
}
