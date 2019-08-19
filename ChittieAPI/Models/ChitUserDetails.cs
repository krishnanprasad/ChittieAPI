using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class ChitUserDetails
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string phonenumber { get; set; }
    }

    public class ChitTenureTransaction
    {
        public string username { get; set; }
        public string userid { get; set; }
        public string transactionid { get; set; }
        public int amount { get; set; }
        public DateTime createddate { get; set; }
        public string paymentmodename { get; set; }
        public string paymentstatusname { get; set; }
    }

    public class TransactionService
    {
        public List<ChitTenureTransaction> TenureTransactionList { get; set; }

        public List<ChitTransaction> IsTransactionDoneForCurrentTerm{ get; set; }

        public ChitTermGroup TransactopnChitTermDetails { get; set; }

        public List<TermGroupBidList> TermGroupBidList { get; set; }
    }

    public class TermGroupBidList
    {
        public int sno { get; set; }
        public string userid { get; set; }
        public string chitid { get; set; }
        public string termgroupid { get; set; }
        public Nullable<int> amount { get; set; }
        public string bidID { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> BidStatus { get; set; }

        public string username { get; set; }
    }

    public class TempChitTermGroup
    {
        public int sno { get; set; }
        public string chitid { get; set; }
        public Nullable<int> termnumber { get; set; }
        public string termgroupid { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
        public Nullable<System.DateTime> updateddate { get; set; }
        public Nullable<bool> status { get; set; }

        public string DiffDate { get; set; }
    }
}