using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class M_CreateChit
    {
        public string UserId { get; set; }
        public string ChitName { get; set; }
        public int ChitDuration { get; set; }
        public int ChitEMIAmount { get; set; }
        public int TotalMembers { get; set; }
        public DateTime StartDate { get; set; }
        public ChitDateTime[] UserFinalChitDateTime { get; set; }
        public BidDateTime[] UserBidDateTime { get; set; }
    }
}