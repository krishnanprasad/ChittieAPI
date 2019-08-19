using ChittieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChittieAPI.Controllers
{
    public class PaymentController : ApiController
    {
        chittiedevEntities _db = new chittiedevEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: Payment
        [HttpGet]
        [Route("api/Payment/GetEMIPaymentInfo")]
        public HttpResponseMessage GetEMIPaymentInfo(string userid, string chitid, string termgroupid)
        {
            try
            {
                var result = _db.ChitTermGroups.SingleOrDefault(b => b.chitid == chitid && b.termgroupid == termgroupid);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "No Results");
            }
        }

    }
}