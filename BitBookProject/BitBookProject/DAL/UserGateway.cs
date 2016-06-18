using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BitBookProject.Models;

namespace BitBookProject.DAL
{
    public class UserGateway
    {
        private string Conntection =
            WebConfigurationManager.ConnectionStrings["BitBookDbConnectionString"].ConnectionString;
        public int SaveUser(User user)
        {
           SqlConnection connection=new SqlConnection(Conntection);
           string quary = "Insert Into UserTable VALUES('" + user.Name + "','" + user.Email + "','" + user.Password + "','" + user.UserName + "','" + user.ProfilePicture + "','" + user.CoverPicture + "','" + user.DOB + "','" + user.Gender + "')";
             SqlCommand command=new SqlCommand(quary,connection);
            connection.Open();
            int rowAffctedColumn = command.ExecuteNonQuery();
            return rowAffctedColumn;


        }

        public bool IsEmailExist(User user)
        {
            SqlConnection connection=new SqlConnection(Conntection);
            string quary = "SELECT * FROM UserTable WHERE name='" + user.Email + "'";
            SqlCommand command=new SqlCommand(quary,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hasThisItem=false;
            User UserOne = null;
            while (reader.HasRows)
            {
                reader.Read();
                UserOne= new User();

                UserOne.Email = reader["Email"].ToString();
                
               
            }
            connection.Close();
            reader.Close();
            return hasThisItem=true;


        }

        public bool LoginUser(User user)
        {
            
            SqlConnection conection=new SqlConnection(Conntection);
            string quary="Select Count(*) From UserTable Where Email='"+user.Email+"'";
            SqlCommand command=new SqlCommand(quary,conection);
            conection.Open();
            int Temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            conection.Close();
            if (Temp==1)
            {
                conection.Open();
                string checkPasswordQuary = "Select Password From UserTable Where Password='" + user.Password + "'";
                SqlCommand commandOne=new SqlCommand(checkPasswordQuary,conection);
                string password = commandOne.ExecuteScalar().ToString();
                if (password == user.Password)
                {
                    return true;
                }
                return false;

            }
            return false;

        }

        
    }
}