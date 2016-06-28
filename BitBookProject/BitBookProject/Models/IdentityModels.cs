using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BitBookProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BitBookDbConnectionString")
        {
        }
    }
}