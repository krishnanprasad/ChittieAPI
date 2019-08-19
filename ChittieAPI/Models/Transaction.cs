using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class Transaction
    {
      
    }
    public class AddTransaction
    {
        public String ChitId { get; set; }
        public String UserId { get; set; }
        public String TermGroupId { get; set; }
        public int ModeOfPayment { get; set; }
        public int Amount { get; set; }
    }
}