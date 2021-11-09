using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{

    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Category name must have maximum 15 chracters.")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}