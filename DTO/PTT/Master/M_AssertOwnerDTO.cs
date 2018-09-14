using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_AssertOwnerDTO : BaseDTO
    {
       public M_AssertOwnerDTO()
       { }

       public string AssertOwnerID { get; set; }
       public string AssertOwnerCode { get; set; }
       public string Name { get; set; }
       public string CreateDate { get; set; }
       public string CreateBy { get; set; }
       public string UpdateDate { get; set; }
       public string UpdateBy { get; set; }
       public string Status { get; set; }
    }
}
