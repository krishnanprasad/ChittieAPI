using ChittieAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;

namespace ChittieAPI.Controllers
{

    public class CreateChitController : ApiController
    {
        chittiedevEntities _db = new chittiedevEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/CreateChit/AddDateTime")]
        public HttpResponseMessage AddDateTime([FromBody]ChitDateTime[] TempChitDateTime, string ChitGroup)
        {
            try
            {
                List<ChitTermGroup> _ChitTermGroupList = new List<ChitTermGroup>();
                foreach (var ed in TempChitDateTime)
                {
                    ChitTermGroup A = new ChitTermGroup();
                    A.chitid = ChitGroup;
                    A.termgroupid = ChitGroup + "/" + ed.DurationID;
                    A.startdate = ed.StartDate;
                    A.enddate = ed.EndDate;
                    A.termnumber = ed.DurationID;
                    A.createddate = DateTime.Now;
                    A.status = true;
                    _ChitTermGroupList.Add(A);
                }
                _db.ChitTermGroups.AddRange(_ChitTermGroupList);
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
        }


        [HttpPost]
        [Route("api/CreateChit/CreateNewChit")]
        public HttpResponseMessage CreateChit([FromBody]M_CreateChit CreateChit)
        {
            //Creating New Chit First
            try
            {
                ChitDetail NewChit = new ChitDetail
                {
                    chitname = CreateChit.ChitName,
                    tenure = CreateChit.ChitDuration,
                    percentage = 0,
                    membercount = CreateChit.TotalMembers,
                    startdate = CreateChit.StartDate,
                    amount = (CreateChit.ChitEMIAmount * CreateChit.ChitDuration),
                    emi = CreateChit.ChitEMIAmount,
                    createddate = DateTime.Now,
                    updateddate = DateTime.Now,
                    status = 1
                };
                var a = _db.ChitDetails.Add(NewChit);
                _db.SaveChanges();
                //Getting Chit Id from ChitDetails table
                String GetChitId = _db.ChitDetails.Where(s => s.chitname == CreateChit.ChitName).FirstOrDefault().chitid;


                //Create Connection
                ChitConnection NewChitConnection = new ChitConnection();
                NewChitConnection.userid = CreateChit.UserId;
                NewChitConnection.chitid = GetChitId;
                NewChitConnection.organiser = true;
                NewChitConnection.statusid = 1;
                NewChitConnection.createddate = DateTime.Now;
                NewChitConnection.updatedate = DateTime.Now;

                var StatusChitConnection = _db.ChitConnections.Add(NewChitConnection);
                _db.SaveChanges();


                //Creating Chit Table
                List<ChitTermGroup> _ChitTermGroupList = new List<ChitTermGroup>();
                foreach (var ed in CreateChit.UserFinalChitDateTime)
                {
                    ChitTermGroup A = new ChitTermGroup();
                    A.chitid = GetChitId;
                    A.termgroupid = GetChitId + "/" + ed.DurationID;
                    A.startdate = ed.StartDate;
                    A.enddate = ed.EndDate;
                    A.termnumber = ed.DurationID;
                    A.createddate = DateTime.Now;
                    A.status = true;
                    _ChitTermGroupList.Add(A);
                }
                _db.ChitTermGroups.AddRange(_ChitTermGroupList);
                _db.SaveChanges();


                //Creating BID Table
                List<ChitTermGroup> GetTermDetailsList = _db.ChitTermGroups.Where(d => d.chitid == GetChitId).ToList();
                List<ChitBidTimeTable> NewChitBidTimeTableList = new List<ChitBidTimeTable>();
                int CountChitTable = 0;
                foreach (var e in GetTermDetailsList)
                {
                    ChitBidTimeTable NewChitBidTimeTable = new ChitBidTimeTable();
                    NewChitBidTimeTable.chitID = GetChitId;
                    if(GetTermDetailsList[CountChitTable].termnumber == CountChitTable)
                    {
                        NewChitBidTimeTable.Amount = CreateChit.UserBidDateTime[CountChitTable].BidAmount;
                        NewChitBidTimeTable.startDate = e.startdate;
                        NewChitBidTimeTable.endDate = e.enddate;
                        NewChitBidTimeTable.Termid = e.termgroupid;
                        CountChitTable++;
                        NewChitBidTimeTableList.Add(NewChitBidTimeTable);
                    }
                }
                _db.ChitBidTimeTables.AddRange(NewChitBidTimeTableList);
                _db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
            //Updating Bid Table           
             
           
        }


        [HttpPost]
        [Route("api/CreateChit/TempCreateNewChit")]
        public HttpResponseMessage TempCreateChitTemp(string UserId)
        {
            //Creating New Chit First
            try { 
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
            //Updating Bid Table           


        }
    }
}
