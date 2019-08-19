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
    public class TransactionController : ApiController
    {
        chittiedevEntities _db = new chittiedevEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/Transaction/AddTransaction")]
        public HttpResponseMessage AddTransaction([FromBody] AddTransaction AddTransaction)
        {
            try
            {
                ChitTransaction _NewTransaction = new ChitTransaction();
                _NewTransaction.amount = AddTransaction.Amount;
                _NewTransaction.Chitid = AddTransaction.ChitId;
                _NewTransaction.userid = AddTransaction.UserId;
                _NewTransaction.TermGroupId = AddTransaction.TermGroupId;
                _NewTransaction.modeofpayment = AddTransaction.ModeOfPayment;
                _NewTransaction.paymentstatus = 1;
                _NewTransaction.Createddate = DateTime.Now;
                _db.ChitTransactions.Add(_NewTransaction);
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed Transaction");
            }
        }
        [HttpGet]
        [Route("api/Transaction/UpdateTransaction")]
        public HttpResponseMessage UpdateTransaction(string TransactionId,int? Amount=null,int? PaymentStatus=null)
        {
            try
            {
                var result = _db.ChitTransactions.SingleOrDefault(b => b.transactionid == TransactionId);
                if (result != null)
                {
                    if(Amount !=null)
                    { 
                    result.amount = Amount;
                    }
                    if (PaymentStatus != null)
                    {
                        result.paymentstatus = PaymentStatus;
                    }
                    
                    _db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Update Failed");
            }
        }

       
    }
}
