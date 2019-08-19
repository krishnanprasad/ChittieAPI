using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models.User
{
    public class M_UserChitInvitation
    {
        public string chitid { get; set; }
        public string chitname { get; set; }
        public int tenure { get; set; }
        public int MemberCount { get; set; }
        public DateTime startdate { get; set; }
        public int emi { get; set; }
        public Decimal amount { get; set; }
        public string connectionid { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
    }
}