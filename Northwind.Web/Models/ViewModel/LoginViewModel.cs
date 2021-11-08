using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Zorunlu alan!")]
        [EmailAddress(ErrorMessage ="ornek@mail.com şeklinde giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}