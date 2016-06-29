using System;
using System.Collections.Generic;
using System.Data;
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
            SqlConnection connection = new SqlConnection(Conntection);
            string quary = "Insert Into UserTable VALUES('" + user.Name + "','" + user.Email + "','" + user.Password + "','" + user.UserName + "','" + user.ProfilePicture + "','" + user.CoverPicture + "','" + user.DOB + "','" + user.Gender + "')";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            int rowAffctedColumn = command.ExecuteNonQuery();
            return rowAffctedColumn;


        }

        public bool IsEmailExist(User user)
        {
            SqlConnection connection = new SqlConnection(Conntection);
            string quary = "SELECT * FROM UserTable WHERE name='" + user.Email + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hasThisItem = false;
            User UserOne = null;
            while (reader.HasRows)
            {
                reader.Read();
                UserOne = new User();

                UserOne.Email = reader["Email"].ToString();


            }
            connection.Close();
            reader.Close();
            return hasThisItem = true;


        }

        public bool LoginUser(User user)
        {

            SqlConnection conection = new SqlConnection(Conntection);
            string quary = "Select Count(*) From UserTable Where UserName='" + user.UserName + "'";
            SqlCommand command = new SqlCommand(quary, conection);
            conection.Open();
            int Temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            conection.Close();
            if (Temp == 1)
            {
                conection.Open();
                string checkPasswordQuary = "Select Password From UserTable Where Password='" + user.Password + "'";
                SqlCommand commandOne = new SqlCommand(checkPasswordQuary, conection);
                string password = commandOne.ExecuteScalar().ToString();
                if (password == user.Password)
                {
                    return true;
                }
                return false;

            }
            return false;

        }

        public User GetuserByUserName(string UserName)
        {
            SqlConnection connection = new SqlConnection(Conntection);
            string quary = "Select * from UserTable Where UserName='" + UserName + "'";
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            User userModel = new User();
            while (reader.Read())
            {
                User model = new User();
                model.UserId = (int)reader["Id"];
                model.Name = reader["Name"].ToString();
                model.Email = reader["Email"].ToString();
                model.Password = reader["Password"].ToString();
                model.UserName = reader["UserName"].ToString();
                model.ProfilePicture = reader["ProfilePicture"].ToString();
                model.CoverPicture = reader["CoverPicture"].ToString();
                model.DOB = Convert.ToDateTime(reader["DOB"]);
                model.Gender = (int)reader["Gender"];
                userModel = model;
            }
            connection.Close();
            reader.Close();
            return userModel;

        }
        public bool GetUserById(User user)
        {
            SqlConnection connection = new SqlConnection(Conntection);


            string query = "UPDATE UserTable SET Name='" + user.Name + "', Email='" + user.Email + "', Password='" + user.Password + "', UserName='" + user.UserName + "', ProfilePicture='" + user.ProfilePicture + "', CoverPicture='" + user.CoverPicture + "', DOB='" + user.DOB + "', Gender='" + user.Gender + "' WHERE ID=" + user.UserId;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                return true;
            }
            return false;

        }

        public User GetuserByUserId(int  Id)
        {
            SqlConnection connection = new SqlConnection(Conntection);
            string quary = "Select * from UserTable Where Id="+Id;
            SqlCommand command = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            User userModel = new User();
            while (reader.Read())
            {
                User model = new User();
                model.UserId = (int)reader["Id"];
                model.Name = reader["Name"].ToString();
                model.Email = reader["Email"].ToString();
                model.Password = reader["Password"].ToString();
                model.UserName = reader["UserName"].ToString();
                model.ProfilePicture = reader["ProfilePicture"].ToString();
                model.CoverPicture = reader["CoverPicture"].ToString();
                model.DOB = Convert.ToDateTime(reader["DOB"]);
                model.Gender = (int)reader["Gender"];
                userModel = model;
            }
            connection.Close();
            reader.Close();
            return userModel;

        }

        public bool UploadProfilePicture(User user)
        {
            SqlConnection connection = new SqlConnection(Conntection);


            string query = "UPDATE UserTable SET ProfilePicture=@ProfilePicture where Id=" + user.UserId;
           
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("ProfilePicture", SqlDbType.Char);
            command.Parameters["ProfilePicture"].Value = user.ProfilePicture;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public  User GetProfilePic(User user)
        {
            SqlConnection connecton =new SqlConnection(Conntection);
            string quary = "Select ProfilePicture from UserTable Where Id=" + user.UserId;
            SqlCommand command=new SqlCommand(quary,connecton);

            connecton.Open();
            SqlDataReader reader = command.ExecuteReader();
            User userModel = new User();
            while (reader.Read())
            {
                User model = new User();
                model.UserId = user.UserId;

                //model.Name = reader["Name"].ToString();
                //model.Email = reader["Email"].ToString();
                //model.Password = reader["Password"].ToString();
                //model.UserName = reader["UserName"].ToString();
                model.ProfilePicture = reader["ProfilePicture"].ToString();
                //model.CoverPicture = reader["CoverPicture"].ToString();
                //model.DOB = Convert.ToDateTime(reader["DOB"]);
                //model.Gender = (int)reader["Gender"];
   
                userModel = model;
            }
            connecton.Close();
            reader.Close();

            return userModel;
        }
    }
}