using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookProject.DAL;
using BitBookProject.Models;

namespace BitBookProject.BLL
{
    public class UserManager
    {
        UserGateway userGateway=new UserGateway();

        public string SaveUser(User user)
        {
           if (userGateway.IsEmailExist(user))
            {
               int isSave=userGateway.SaveUser(user);
                if (isSave > 0)
                {
                    return "Save succssfully";
                }
              
                return "Save Failed";
            }
            return "This Email Already Exist";



        }

        public bool Login(User user)
        {
            bool isLogin=false;
            if (userGateway.LoginUser(user))
            {
                return isLogin = true;
            }
            return isLogin;

        }

        public User GetUserByUsername(string userName)
        {
            return userGateway.GetuserByUserName(userName);
        }

     
        public string UpdateUser(User user)
        {
            

            if (userGateway.IsEmailExist(user))
            {
                return "Email Address Already Exist.";
            }
            else
            {
               
                if (userGateway.GetUserById(user))
                {
                    return "Update successful.";
                }
                else
                {
                    return "Update failed.";
                }
            }
        
        }
    }
}