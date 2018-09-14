using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api/MobileAPI")]
    public class MobileAPIController : ApiController
    {
        List<PersonalDetail> results = new List<PersonalDetail>();

        public MobileAPIController()
        {
            results.Add(new PersonalDetail {
                RegNo = "001",
                Name = "Piyaphon",
                Address = "BKK",
                AdmissionDate=DateTime.Now
            });

            results.Add(new PersonalDetail
            {
                RegNo = "002",
                Name = "Narathorn",
                Address = "BKK",
                AdmissionDate = DateTime.Now
            });

        }

        [HttpGet]
        [Route("GetAllPersons")]
        public List<PersonalDetail> GetAllPersons()
        {
            return results;
        }
    }
}
