using ChittieAPI.Models;
using ChittieAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChittieAPI.Controllers
{
    public class CommonController : ApiController
    {
        chittiedevEntities _db = new chittiedevEntities();
        [HttpGet]
        [Route("api/Common/GetUserSearch")]
        public HttpResponseMessage GetMemberList(string SearchTerm)
        {
            try
            {

                using (var db = new chittiedevEntities())
                {
                    // Create a SQL command and add parameter
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandText = "[SearchUser]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@searchterm", SearchTerm));

                    // execute your command
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // Get Current Chit List
                    List<M_SearchUser> _SearchUserList = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<M_SearchUser>(reader).ToList();

                    //move to next result set
                    //reader.NextResult();    




                    return Request.CreateResponse(HttpStatusCode.OK, _SearchUserList);
                }
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
        }
    }
}
