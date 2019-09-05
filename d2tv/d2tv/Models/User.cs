using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d2tv.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }
}
