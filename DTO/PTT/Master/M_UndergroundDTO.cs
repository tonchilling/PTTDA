using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_UndergroundDTO : BaseDTO
    {
       public M_UndergroundDTO()
       { }

       public string PID { get; set; }
       public string UID { get; set; }
       public string ParentUID { get; set; }
       public string ParentCode { get; set; }
        public string ParentName { get; set; }
       public string Code { get; set; }
       public string Name { get; set; }
      public string IsInput { get; set; }
      public string Value { get; set; }
      public string CreateDate { get; set; }
      public string CreateBy { get; set; }
      public string UpdateDate { get; set; }
      public string UpdateBy { get; set; }
      public string Status { get; set; }


     
    }
}
