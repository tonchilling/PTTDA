using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_SectionDTO : BaseDTO
    {
       public M_SectionDTO()
       { }

       public string SectionID { get; set; }
       public string SectionCode { get; set; }
       public string Name { get; set; }
        public string SectionName { get; set; }
        
       public string CreateDate { get; set; }
       public string CreateBy { get; set; }
       public string UpdateDate { get; set; }
       public string UpdateBy { get; set; }
       public string Status { get; set; }
        public string RouteCode { get; set; }
        public string RouteCodeName { get; set; }
        public string KP { get; set; }
    }
}
