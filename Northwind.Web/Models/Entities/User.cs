using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class User: BaseClass// Audit
    {
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(12)]
        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        [Required]
        public string Firstname { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
    }
}