//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChittieAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChitTransaction
    {
        public int sno { get; set; }
        public string Chitid { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> modeofpayment { get; set; }
        public Nullable<int> paymentstatus { get; set; }
        public string transactionid { get; set; }
        public Nullable<System.DateTime> Createddate { get; set; }
        public string userid { get; set; }
        public string TermGroupId { get; set; }
    }
}