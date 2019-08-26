using ChittieAPI.Models;
using ChittieAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChittieAPI.Controllers
{
    public class UserController : ApiController
    {

        chittiedevEntities _db = new chittiedevEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string SendInvitation(String OrganiserID, String UserId)
        {

            return "";
        }
        public string AcceptInvitaion(String InvitationId, String UserId)
        {

            return "";
        }
        [HttpGet]
        [Route("api/User/GetChits")]
        public HttpResponseMessage ListofChit(String UserId)
        {
            try
            {
                M_GetUserChitList _M_GetUserChitList = new M_GetUserChitList();
                _M_GetUserChitList.CurrentChitList = _db.GetUserChit(UserId).ToList();
                _M_GetUserChitList.UpComingChitList = (_db.GetUpComingUserChit(UserId).ToList());
                _M_GetUserChitList.UserChitInvitationList = (_db.UserChitInvitaion(UserId).ToList());
                return Request.CreateResponse(HttpStatusCode.OK, _M_GetUserChitList);
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Failed" + E);
            }
        }
        [HttpGet]
        [Route("api/User/GetUserTransaction")]
        public HttpResponseMessage GetUserTransaction(string UserId)
        {
            try
            {
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[UserTransaction]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", UserId));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    List<UserTransaction> _UserTransactionList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<UserTransaction>(reader).ToList<UserTransaction>();

                    // move to next result set

                    return Request.CreateResponse(HttpStatusCode.OK, _UserTransactionList);
                }

            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpGet]
        [Route("api/User/GetUserChitInvitaion")]
        public HttpResponseMessage GetUserChitInvitaion(string UserId)
        {
            try
            {
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[UserChitInvitaion]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", UserId));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    List<M_UserChitInvitation> _UserChitInvitation = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<M_UserChitInvitation>(reader).ToList<M_UserChitInvitation>();

                    // move to next result set

                    return Request.CreateResponse(HttpStatusCode.OK, _UserChitInvitation);
                }

            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpPost]
        [Route("api/User/UpdateChitInvitaion")]
        public HttpResponseMessage UpdateInvitation([FromBody] P_M_UpdateInvitation UpdateInvitation)
        {
            try
            {
                var result = _db.UpdateInvitation(UpdateInvitation.UserId, UpdateInvitation.ConnectionId, UpdateInvitation.StatusId);

                return Request.CreateResponse(HttpStatusCode.OK, "Success");

            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpGet]
        [Route("api/User/getDashboardDetails")]
        public HttpResponseMessage getDashboardDetails(string UserId)
        {
            try
            {
                G_M_DashboardDetails _DashboardDetails = new G_M_DashboardDetails();
                //var a = _db.GetChitDetails(Chitid);
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[getDashboardDetails]";
                    cmd.CommandType = CommandType.StoredProcedure;               
                    cmd.Parameters.Add(new SqlParameter("@userid", UserId));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    _DashboardDetails.TotalChits = ((IObjectContextAdapter)db).ObjectContext.Translate<Int32>(reader).FirstOrDefault();
                    // move to next result set
                    reader.NextResult();


                    _DashboardDetails.TotalSavings = ((IObjectContextAdapter)db).ObjectContext.Translate<Int32>(reader).FirstOrDefault();
                    reader.NextResult();


                    _DashboardDetails.TotalLoansAvailed = ((IObjectContextAdapter)db).ObjectContext.Translate<Int32>(reader).FirstOrDefault();


                }
                return Request.CreateResponse(HttpStatusCode.OK, _DashboardDetails);
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpPost]
        [Route("api/User/UpdateProfile")]
        public HttpResponseMessage UpdateProfile([FromBody] P_UserProfile UserProfile)
        {
            try
            {
                var User = _db.UserCredentials.Where(d=>d.userid== UserProfile.UserId).FirstOrDefault();
                if (User != null)
                {
                    User.email = UserProfile.Email;
                    User.phonenumber = UserProfile.PhoneNumber;
                    User.username = UserProfile.UserName;
                    User.Updateddate = DateTime.Now;
                    _db.Entry(User).State = EntityState.Modified;
                    _db.SaveChanges();

                }
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }

        [HttpGet]
        [Route("api/User/getProfileDetails")]
        public HttpResponseMessage GetProfile(string UserId)
        {
            try
            {
                G_UserProfile _UserProfile;
                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[UserProfile]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", UserId));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Read first model --> Foo
                    _UserProfile = ((IObjectContextAdapter)db).ObjectContext.Translate<G_UserProfile>(reader).FirstOrDefault();
                                    
                }
                return Request.CreateResponse(HttpStatusCode.OK, _UserProfile);
            }
            catch(Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed" + E);
            }
        }
    }
}
