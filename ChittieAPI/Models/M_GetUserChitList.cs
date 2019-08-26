using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class M_GetUserChitList
    {
        public List<GetUserChit_Result> CurrentChitList { get; set; }
        public List<GetUpComingUserChit_Result> UpComingChitList { get; set; }

        public List<UserChitInvitaion_Result> UserChitInvitationList { get; set; }
    }
}