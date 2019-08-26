using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models.ChitDescription
{
    public class G_ChitTimeTable
    {
        public List<ChitBidTimeTable> ChitBidTimeTablesList { get; set; }
        public List<ChitTermGroup> ChitTermGroupsList { get; set; }
    }
}