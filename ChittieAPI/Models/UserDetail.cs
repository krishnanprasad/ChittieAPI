using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
  
    public class UserDetail
    {
        public string username { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string userid { get; set; }

        public UserDetail(UserCredential obj)
        {
            this.phonenumber = obj.phonenumber;
            this.email = obj.email;
            this.userid = obj.userid;
            this.username = obj.username;
            
        }
    }
    public class UserTransaction
    {
        public string chitid { get; set; }
        public int amount { get; set; }
        public DateTime createddate{ get; set; }
        public string userid { get; set; }
        public string termgroupid { get; set; }
        public int termnumber { get; set; }
        public string paymentstatusname { get; set; }
        public string paymentmodename { get; set; }

    }
}