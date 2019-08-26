using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class HomeChitData
    {
        public ChitDetail ChitDetails { get; set; }
        //public List<ChitConnection> ChitConnection { get; set; }
        public List<ChitUserDetails> ChitUserDetails { get; set; }
        public List<TempChitTermGroup> ChitTermGroupList { get; set; }
        public List<ChitBidTimeTable> ChitBidTimeTableList { get; set; }
        public ChitConnection ConnectionDetails { get; set; }
    }
}