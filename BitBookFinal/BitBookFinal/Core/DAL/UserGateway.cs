using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BitBookFinal.Models;

namespace BitBookFinal.Core.DAL
{
    public class UserGateway
    {
        private string ConnectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDbConnection"].ConnectionString;

        public int SaveUser(User user)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            

            string quary = "Insert into UserTable Values ('" + user.Name + "','" + user.Email + "','" + user.Password +
                           "','" + user.UserName + "','" + user.ProfilePicture + "','" + user.CoverPicture + "','" +
                           user.DOB + "','" + user.Gender + "')";
            SqlCommand command=new SqlCommand();

            connection.Open();
            int rowAffectedCoumn = command.ExecuteNonQuery();
            connection.Close();
            return rowAffectedCoumn;

        }

        public bool IsUserExist(String Email)
        {

            bool hasUser = false;
            SqlConnection connection=new SqlConnection(ConnectionString);
            string quary = "select * from UserTable Where Email='" + Email + "'";

            SqlCommand command=new SqlCommand(quary);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            hasUser = reader.HasRows;
            if (hasUser)
            {
                reader.Close();
                connection.Close();
                return hasUser;
            }
            else
            {
                return hasUser;
            }


        }
    }
}
