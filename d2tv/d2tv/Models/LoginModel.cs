using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace d2tv.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
