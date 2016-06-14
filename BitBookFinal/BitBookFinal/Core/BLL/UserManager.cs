using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookFinal.Core.DAL;
using BitBookFinal.Models;

namespace BitBookFinal.Core.BLL
{
    public class UserManager
    {
        public bool SaveUser(User user)
        {
            bool isSaved = false;
            UserGateway aUserGateway=new UserGateway();
            if (aUserGateway.IsUserExist(user.Email))
            {
                isSaved = aUserGateway.SaveUser(user) > 0;
            }
            else
            {
                throw new Exception("Data is not saved. Because " + user.Name + " has already been added to list before.");
            }
            return isSaved;
        }
    }
}