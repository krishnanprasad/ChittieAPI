using ChittieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChittieAPI.Controllers
{
    public class UserCredentialsController : ApiController

    {
        chittiedevEntities _db = new chittiedevEntities();
        [HttpGet]
        [Route("api/Login/VerifyOTP")]
        public HttpResponseMessage VerifyOTP(string Phonenumber, int OTP)
        {
            try
            {
                UserRegistration User = _db.UserRegistrations.Where(d => d.phonenumber == Phonenumber && d.randomnnumber == OTP).First();


                UserCredential _UserDetails = _db.UserCredentials.Where(d => d.phonenumber == User.phonenumber).FirstOrDefault();
                if (_UserDetails == null)
                {
                    try
                    {
                        UserCredential _NewUser = new UserCredential();
                        _NewUser.phonenumber = Phonenumber;

                        _NewUser.Updateddate = DateTime.Now;
                        _NewUser.email = "com";
                        _NewUser.password = "pass";

                        _db.UserCredentials.Add(_NewUser);
                        _db.SaveChanges();
                    }
                    catch (Exception E)
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, E);
                    }
                }
                _UserDetails = _db.UserCredentials.Where(d => d.phonenumber == User.phonenumber).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, _UserDetails);
            }
            catch
            {
                int _NewRandomNumber = GenerateRandomNo();
                var result = _db.UserRegistrations.SingleOrDefault(b => b.phonenumber == Phonenumber);
                if (result != null)
                {
                    result.randomnnumber = _NewRandomNumber;
                    _db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK, _NewRandomNumber);
            }
        }
        [HttpGet]
        [Route("api/Login/GetOTP")]
        public HttpResponseMessage GetOTP(string Phonenumber)
        {
            try
            {
                var _IsUserRegistered = _db.UserRegistrations.Where(d => d.phonenumber == Phonenumber).FirstOrDefault();
                if (_IsUserRegistered != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _IsUserRegistered.randomnnumber.ToString());
                }
                else
                {
                    int _RandomNumber = GenerateRandomNo();

                    UserRegistration _NewUser = new UserRegistration();
                    _NewUser.phonenumber = Phonenumber;
                    _NewUser.randomnnumber = _RandomNumber;
                    _NewUser.status = false;
                    _NewUser.updateddate = DateTime.Now;
                    _NewUser.createddate = DateTime.Now;

                    _db.UserRegistrations.Add(_NewUser);
                    _db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, _RandomNumber);
                }
            }
            catch (Exception E)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Failed" + E);
            }

        }

        public int GenerateRandomNo()
        {
            
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
