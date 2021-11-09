using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40,ErrorMessage ="Product name can have maximum 40 characters")]
        public string ProductName { get; set; }


        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [StringLength(20, ErrorMessage = "Use maximum 20 characters")]
        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }


    }
}