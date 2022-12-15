using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.UI.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Nama Pengguna")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kata Sandi")]
        public string Password { get; set; }
    }
}