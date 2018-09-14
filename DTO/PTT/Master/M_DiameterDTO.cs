using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_DiameterDTO : BaseDTO
    {
       public M_DiameterDTO()
       { }

       public string DiameterID { get; set; }
       public string DiameterCode { get; set; }
       public string Name { get; set; }
       public string CreateDate { get; set; }
       public string CreateBy { get; set; }
       public string UpdateDate { get; set; }
       public string UpdateBy { get; set; }
       public string Status { get; set; }
    }
}
