using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  BitBookProject.Models
{

    public class Status
    {
        public int Id { get; set; }
        public string StatusDetail { get; set; }
        public string PhotoUrl { get; set; }
        public int NumberOfLike { get; set; }
        public int UserId { get; set; }
        public List<Comments> UsersCommentsList { get; set; }
    }

}
   