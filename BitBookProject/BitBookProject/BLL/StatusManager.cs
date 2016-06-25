using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookProject.DAL;
using BitBookProject.Models;

namespace BitBookProject.BLL
{
    public class StatusManager
    {
        StatusGateway statusGateway =new StatusGateway();
        public bool saveStatus(Status status)
        {
            return statusGateway.saveStatus(status) > 0;
        }
    }
}