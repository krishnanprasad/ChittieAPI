﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class chittiedevEntities : DbContext
    {
        public chittiedevEntities()
            : base("name=chittiedevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChitBidTimeTable> ChitBidTimeTables { get; set; }
        public virtual DbSet<ChitConnection> ChitConnections { get; set; }
        public virtual DbSet<ChitDetail> ChitDetails { get; set; }
        public virtual DbSet<ChitInvitation> ChitInvitations { get; set; }
        public virtual DbSet<ChitTermGroup> ChitTermGroups { get; set; }
        public virtual DbSet<ChitTransaction> ChitTransactions { get; set; }
        public virtual DbSet<CodeModeOfPayment> CodeModeOfPayments { get; set; }
        public virtual DbSet<CodePaymentStatu> CodePaymentStatus { get; set; }
        public virtual DbSet<ErrorHandling> ErrorHandlings { get; set; }
        public virtual DbSet<smsusercredential> smsusercredentials { get; set; }
        public virtual DbSet<smswarehouse> smswarehouses { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; }
        public virtual DbSet<ChitBidTransaction> ChitBidTransactions { get; set; }
        public virtual DbSet<SubsrciptionTest> SubsrciptionTests { get; set; }
    
        [DbFunction("chittiedevEntities", "CurrentTermGroupOfChit")]
        public virtual IQueryable<CurrentTermGroupOfChit_Result> CurrentTermGroupOfChit(string chitid)
        {
            var chitidParameter = chitid != null ?
                new ObjectParameter("Chitid", chitid) :
                new ObjectParameter("Chitid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CurrentTermGroupOfChit_Result>("[chittiedevEntities].[CurrentTermGroupOfChit](@Chitid)", chitidParameter);
        }
    
        public virtual ObjectResult<ChitUserDetails_Result> ChitUserDetails(string chitid)
        {
            var chitidParameter = chitid != null ?
                new ObjectParameter("Chitid", chitid) :
                new ObjectParameter("Chitid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ChitUserDetails_Result>("ChitUserDetails", chitidParameter);
        }
    
        public virtual ObjectResult<GetChitDetails_Result> GetChitDetails(string chitid, string userid)
        {
            var chitidParameter = chitid != null ?
                new ObjectParameter("chitid", chitid) :
                new ObjectParameter("chitid", typeof(string));
    
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetChitDetails_Result>("GetChitDetails", chitidParameter, useridParameter);
        }
    
        public virtual ObjectResult<GetChitMembersList_Result> GetChitMembersList(string chitId)
        {
            var chitIdParameter = chitId != null ?
                new ObjectParameter("ChitId", chitId) :
                new ObjectParameter("ChitId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetChitMembersList_Result>("GetChitMembersList", chitIdParameter);
        }
    
        public virtual ObjectResult<GetUpComingUserChit_Result> GetUpComingUserChit(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUpComingUserChit_Result>("GetUpComingUserChit", useridParameter);
        }
    
        public virtual ObjectResult<GetUserChit_Result> GetUserChit(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserChit_Result>("GetUserChit", useridParameter);
        }
    
        public virtual ObjectResult<IsTransactionDoneForCurrentTerm_Result> IsTransactionDoneForCurrentTerm(string userid, string chitid, string termgroupid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            var chitidParameter = chitid != null ?
                new ObjectParameter("chitid", chitid) :
                new ObjectParameter("chitid", typeof(string));
    
            var termgroupidParameter = termgroupid != null ?
                new ObjectParameter("termgroupid", termgroupid) :
                new ObjectParameter("termgroupid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IsTransactionDoneForCurrentTerm_Result>("IsTransactionDoneForCurrentTerm", useridParameter, chitidParameter, termgroupidParameter);
        }
    
        public virtual ObjectResult<TermGroupDetails_Result> TermGroupDetails(string chitid, string termgroupid, string userid)
        {
            var chitidParameter = chitid != null ?
                new ObjectParameter("chitid", chitid) :
                new ObjectParameter("chitid", typeof(string));
    
            var termgroupidParameter = termgroupid != null ?
                new ObjectParameter("termgroupid", termgroupid) :
                new ObjectParameter("termgroupid", typeof(string));
    
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TermGroupDetails_Result>("TermGroupDetails", chitidParameter, termgroupidParameter, useridParameter);
        }
    
        public virtual ObjectResult<UserTransaction_Result> UserTransaction(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserTransaction_Result>("UserTransaction", useridParameter);
        }
    
        public virtual ObjectResult<SearchUser_Result> SearchUser(string searchterm)
        {
            var searchtermParameter = searchterm != null ?
                new ObjectParameter("searchterm", searchterm) :
                new ObjectParameter("searchterm", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchUser_Result>("SearchUser", searchtermParameter);
        }
    
        public virtual ObjectResult<UserChitInvitaion_Result> UserChitInvitaion(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserChitInvitaion_Result>("UserChitInvitaion", useridParameter);
        }
    
        public virtual int UpdateInvitation(string userid, string connectionid, Nullable<int> statusid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            var connectionidParameter = connectionid != null ?
                new ObjectParameter("connectionid", connectionid) :
                new ObjectParameter("connectionid", typeof(string));
    
            var statusidParameter = statusid.HasValue ?
                new ObjectParameter("statusid", statusid) :
                new ObjectParameter("statusid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateInvitation", useridParameter, connectionidParameter, statusidParameter);
        }
    }
}
