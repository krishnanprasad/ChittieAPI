using ChittieAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ChittieAPI.Controllers
{
    public class ChitDescriptionController : ApiController
    {
       
        chittiedevEntities _db = new chittiedevEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public ChitDetail Get(string chitid)
        {
            ChitDetail chitdetails = _db.ChitDetails.Where(d => d.chitid == chitid).FirstOrDefault();
            return chitdetails;
        }

        /// <summary>
        /// List of User Details for a particular Chit
        /// </summary>
        /// <param name="ChitId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ChitDescription/UserDetails")]
        public HttpResponseMessage ChitUserDetails(string ChitId)
        {
            try
            {
                List<ChitUserDetails_Result> result = _db.ChitUserDetails(ChitId).ToList();
                if (result.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);

                }
                else
                {
                    throw new System.ArgumentException("No Data Found");
                    //   return Request.CreateResponse(HttpStatusCode.NotFound, ChitId);
                }

            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, E);
            }
        }

        /// <summary>
        /// Get Temprory Date Time for user confirmation
        /// </summary>
        /// <param name="TotalDuration"></param>
        /// <param name="DurationGap"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ChitDescription/GetTempDateTime")]
        public List<ChitDateTime> GetTempDateTime(int TotalDuration, int DurationGap, DateTime StartDate)
        {
            ChitDateTime _NewList = new ChitDateTime();
            List<ChitDateTime> TermChitCaledner = _NewList.ListofDateofTime(TotalDuration, DurationGap, StartDate);
            return TermChitCaledner;
        }

        /// <summary>
        /// Insert Confirmed Temp Date Time for Particular Chit
        /// </summary>
        /// <param name="TotalDuration"></param>
        /// <param name="DurationGap"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>

        

        /// <summary>
        /// Update The Date Time of Chit
        /// </summary>
        /// <param name="ChangeDateTimeList"></param>
        /// <returns></returns>
        public String UpdateChangeDateTime(List<ChitDateTime> ChangeDateTimeList)
        {
            ChitDateTime _NewList = new ChitDateTime();
            // List<ChitDateTime> ChitCaledner = _NewList.ListofDateofTime(TotalDuration, DurationGap, StartDate);
            return "Success";
        }

        [HttpGet]
        [Route("api/ChitDescription/GetChitDetails")]
        public HttpResponseMessage GetChitDetails(String Chitid,string UserId)
        {
            try
            {
                HomeChitData _HomeChitData = new HomeChitData();
                //var a = _db.GetChitDetails(Chitid);
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[GetChitDetails]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@chitid", Chitid));
                    cmd.Parameters.Add(new SqlParameter("@userid", UserId));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    _HomeChitData.ChitDetails = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitDetail>(reader, "ChitDetails", MergeOption.AppendOnly).FirstOrDefault();

                    // move to next result set
                    reader.NextResult();

                    // Read second model --> Bar
                    _HomeChitData.ChitUserDetails = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitUserDetails>(reader).ToList<ChitUserDetails>();
                    reader.NextResult();


                    _HomeChitData.ChitTermGroupList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<TempChitTermGroup>(reader).ToList();
                    reader.NextResult();




                    _HomeChitData.ChitBidTimeTableList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitBidTimeTable>(reader, "ChitBidTimeTables", MergeOption.AppendOnly).ToList();

                    reader.NextResult();


                    _HomeChitData.IsOrganiser = ((IObjectContextAdapter)db).ObjectContext.Translate<String>(reader).FirstOrDefault().ToString();


                }
                return Request.CreateResponse(HttpStatusCode.OK, _HomeChitData);
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpGet]
        [Route("api/ChitDescription/GetChitUserList")]
        public HttpResponseMessage GetMemberList(string ChitId)
        {
            try
            {

                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[GetChitMembersList]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@chitid", ChitId));
                    
                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Get Current Chit List
                    List<GetChitUserList> _GetChitUserList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<GetChitUserList>(reader).ToList();

                    //move to next result set
                    //reader.NextResult();    

                    
                 

                    return Request.CreateResponse(HttpStatusCode.OK, _GetChitUserList);
                }                
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
        }

        [HttpGet]
        [Route("api/ChitDescription/GetTenureDetails")]
        public HttpResponseMessage GetTenureDetails(string userid,string Chitid, string termgroupid)
        {
            try
            {
                TransactionService _TransactionService = new TransactionService();
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[TermGroupDetails]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@chitid", Chitid));
                    cmd.Parameters.Add(new SqlParameter("@termgroupid", termgroupid));
                    cmd.Parameters.Add(new SqlParameter("@userid", userid));
                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    _TransactionService.TenureTransactionList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitTenureTransaction>(reader).ToList();

                    // move to next result set
                    reader.NextResult();

                    // Read second model --> Bar
                    _TransactionService.TermGroupBidList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<TermGroupBidList>(reader).ToList<TermGroupBidList>();
                    reader.NextResult();


                    _TransactionService.TransactopnChitTermDetails = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitTermGroup>(reader, "ChitTermGroups", MergeOption.AppendOnly).FirstOrDefault();
                    reader.NextResult();

                    _TransactionService.IsTransactionDoneForCurrentTerm = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ChitTransaction>(reader).ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, _TransactionService);
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpPost]
        [Route("api/ChitDescription/SendInvitation")]
        public HttpResponseMessage AddTransaction([FromBody] M_SendInvitation SendInvitation)
        {
            try
            {
                ChitConnection _NewInvitation = new ChitConnection();                
                _NewInvitation.chitid = SendInvitation.ChitId;
                _NewInvitation.userid = SendInvitation.UserId;
                
                _NewInvitation.organiser =false;
                _NewInvitation.statusid = 0;
                _NewInvitation.createddate = DateTime.Now;
                _NewInvitation.updatedate = DateTime.Now;
                _db.ChitConnections.Add(_NewInvitation);
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception E)
            {
                
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed Transaction"+ E.InnerException );
            }
        }
    }
}
