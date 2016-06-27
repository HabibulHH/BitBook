using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitBookProject.Models;

namespace BitBookProject.DAL
{
    public class StatusGateway :GateWay
    {

        public  int saveStatus(Status status)
        {
            bool isSaved = false;
            Query = "INSERT INTO Status VALUES(@StatusDetail,@PhotoUrl,@LikeNumber,@CommentsId,@UserId)";
            Command.Parameters.Clear();
            Command.Parameters.Add("StatusDetail", SqlDbType.Char);
            Command.Parameters["StatusDetail"].Value = status.StatusDetail;
            Command.Parameters.Add("PhotoUrl", SqlDbType.Char);
           
            Command.Parameters["PhotoUrl"].Value ="/fhdhj";
            Command.Parameters.Add("LikeNumber", SqlDbType.Int);
            Command.Parameters["LikeNumber"].Value = status.NumberOfLike;
            Command.Parameters.Add("CommentsId", SqlDbType.Int);
            Command.Parameters["CommentsId"].Value = 1;
            Command.Parameters.Add("UserId", SqlDbType.Int);
            Command.Parameters["UserId"].Value = status.UserId;
            Command.CommandText = Query;
            Connection.Open();
            int numberOfRow = Command.ExecuteNonQuery();
            return numberOfRow;

        }

        public bool DeleteStatus(Status status)

        {
            bool IsDelete = false;
            Query = "Delete StatusDetail from Status where Id='" + status.Id + "'";
            SqlCommand command = new SqlCommand();
            command.CommandText = Query;
           

            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            Connection.Close();

            if (rowAffected > 0)
            {
                return IsDelete = true;
            }
            return IsDelete;
        }
    }
}