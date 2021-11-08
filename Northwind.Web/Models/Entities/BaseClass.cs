using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class BaseClass
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int CreatedById { get; set; } // kim oluşturdu
        public int? UpdatedById { get; set; } // kim güncelledi. delete de bir update işlemi...
        public bool IsActive { get; set; } // hard delete yapmamak için; soft delete yapmak için ekledik

        // struct tipler ram'in stack kısmında tutulur. value types... int bool  decimal datetime struct

        // classlar heap'de tutulur... string, class.. value typelar
    }
}