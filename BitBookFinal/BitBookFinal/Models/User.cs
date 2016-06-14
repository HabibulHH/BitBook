using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BitBookFinal.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public string CoverPicture { get; set; }

        public DateTime DOB { get; set; }

        public int Gender { get; set; }
    
    }
}