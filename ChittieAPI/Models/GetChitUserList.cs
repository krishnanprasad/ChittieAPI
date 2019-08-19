using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class GetChitUserList
    {
        public String Connectionid { get; set; }
        public String userid { get; set; }
        public Int32 statusid { get; set; }
        public bool organiser { get; set; }
        public String username { get; set; }
        public String phonenumber { get; set; }
    }
}