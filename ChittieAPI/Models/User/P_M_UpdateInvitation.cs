using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models.User
{
    public class P_M_UpdateInvitation
    {
        public string UserId { get; set; }
        public String ConnectionId { get; set; }
        public int StatusId { get; set; }
    }
}