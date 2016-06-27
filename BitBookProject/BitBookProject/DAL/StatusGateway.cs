using System;
using System.Collections.Generic;
using System.Data;
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

        private List<Status> GetAllStatus(User user)
        {
            List<Status> statusList= new List<Status>();

            Query = "Select *form Status Where UserId=" + user.UserId;
            
        }
    }
}