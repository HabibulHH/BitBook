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
    }
}