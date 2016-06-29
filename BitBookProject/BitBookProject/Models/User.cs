using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BitBookProject.Models
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


        public User(string Email, string UserName, string Password):this()
        {
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
        }
        public User() { }
        public List<BascInfo> UsersBasicInfoList { get; set; }

        public List<Status> UsersStautusList { get; set; }
        public List<FriendList> UsersFriendList { get; set; } 
    }
}