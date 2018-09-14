using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_TypeOfRouteCodeDTO : BaseDTO
    {
       public M_TypeOfRouteCodeDTO()
       { }

       public string TypeOfRouteID { get; set; }
       public string TypeOfRouteCode { get; set; }
       public string Name { get; set; }
       public string CreateDate { get; set; }
       public string CreateBy { get; set; }
       public string UpdateDate { get; set; }
       public string UpdateBy { get; set; }
       public string Status { get; set; }
    }
}
