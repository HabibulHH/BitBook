using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitBookProject.Models;

namespace BitBookProject.DAL
{
    public class StatusGateway : GateWay
    {

        public int saveStatus(Status status)
        {
            bool isSaved = false;
            Query = "INSERT INTO Status VALUES(@StatusDetail,@PhotoUrl,@LikeNumber,@CommentsId,@UserId)";
            Command.Parameters.Clear();
            Command.Parameters.Add("StatusDetail", SqlDbType.Char);
            Command.Parameters["StatusDetail"].Value = status.StatusDetail;
            Command.Parameters.Add("PhotoUrl", SqlDbType.Char);

            Command.Parameters["PhotoUrl"].Value = "/fhdhj";
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

        public List<Status> GetAllStatus(User user)
        {
            List<Status> statusList = new List<Status>();

            Query = "Select *from Status Where UserId=" + user.UserId;
            Connection.Open();
            Command=new SqlCommand(Query,Connection);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Status status = new Status();
                status.Id = Convert.ToInt32(Reader["Id"]);
                status.StatusDetail = Reader["StatusDetail"].ToString();
                status.PhotoUrl = Reader["PhotoUrl"].ToString();
                status.NumberOfLike = Convert.ToInt32(Reader["LikeNumber"]);
                status.UserId = Convert.ToInt32(Reader["UserId"]);
                statusList.Add(status);

            }
            return statusList;

        }

    }
}