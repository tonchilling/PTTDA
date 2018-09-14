using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PersonalDetail
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}