using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Boş geçilemez!")]
        [StringLength(50, ErrorMessage = "max 50 min 2 giriş yapılabilir", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [StringLength(50, ErrorMessage = "max 100 min 2 giriş yapılabilir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [EmailAddress(ErrorMessage = "ornek@mail.com şeklinde giriş yapınız.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Boş geçilemez!")]
        [StringLength(50, ErrorMessage = "max 12 min 4 giriş yapılabilir", MinimumLength = 2)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        [StringLength(50, ErrorMessage = "max 12 min 4 giriş yapılabilir", MinimumLength = 2)]
        [Compare(nameof(Password), ErrorMessage ="Şifreler uyuşmuyor!")]
        [DisplayName("Password Confirm")]
        public string PasswordConfirm { get; set; }
    }
}