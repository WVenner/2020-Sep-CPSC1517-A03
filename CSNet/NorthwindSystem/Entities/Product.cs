using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Entities
{
    //annotations are used to assist EntityFramework in the mapping of 
    // your class to the sql table

    // annotations for properties are placed before the property and link to the next immediate property

    [Table("Products")]
    public class Product
    {
        //prvate data member
        private string _QuantityPerUnit;
        //if you use the same name as the sql attribute
        //for your property name, order of the properties does not matter
        // however if your names are different then order is required

        //[Key] is a single attribute primary identity key
        //[Key, Column(Order=n)] if compound primary key
        //    required in front of each property of the key
        //    n represents the physical order as found on the sql table
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.xxxx)]
        //    where .xxxx -> Identity: Primary key on sql is 
        //      an identity key (default)
        //      -> None: primary key is NOT identity, user entered
        [Key]
        public int ProductID { get; set; }

        //validation annotations (sql constraints and null/not null)
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40, ErrorMessage = "Product Name is limited o 20 characters")]
        public string ProductName { get; set; }

        //foreignkeys
        //these foreign keys are nullable on the sql table (don't forget the ?)
        //You may be tempted to use the [ForeigKey] annotation
        //      DON'T
        //the [ForeignKey] annotation is only required if the 
        //  sql table does not use the same name for it's 
        //  foreign key as it's parent primary key
        //OR
        //  if your property name does not match he sql attribute name

        //? makes the property nullable
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        //you can use fully implemented properties in mapping
        [StringLength(20, ErrorMessage = "Quantity per unit is limited to 20 characters")]
        public string QuantityPerUnit 
        {
            get { return _QuantityPerUnit}
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value;
            } 
        }

        //money requires the use of decimal, if it complains use double
        //UnitPrice is nullable
        //nullable numerics DO NOT need to be fully implemented
        [Range(0.00, double.MaxValue, ErrorMessage = "Unit prcie must be more than 0.00")]
        public decimal? UnitPrice { get; set; }
        //Int16 is equivalent to smallint
        [Range(0.00, 32767, ErrorMessage = "Units in stock must be more than 0.00")]
        public Int16? UnitsInStock { get; set; }

        [Range(0.00, 32767, ErrorMessage = "Units on order must be more than 0")]
        public Int16? UnitsOnOrder{ get; set; }

        [Range(0.00, 32767, ErrorMessage = "Reorder Level must be more than 0")]
        public Int16? ReorderLevel{ get; set; }
        public bool Discontinued{ get; set; }

    }
}
