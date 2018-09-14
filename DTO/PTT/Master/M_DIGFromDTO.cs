using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_DIGFromDTO : BaseDTO
    {
        public M_DIGFromDTO()
       {
           DIGFromID = "";
           DIGFromCode = "";
           Name = "";
           CreateDate = "";
           CreateBy = "";
           UpdateDate = "";
           UpdateBy = "";
           Status = "";
       }

       public string DIGFromID { get; set; }
       public string DIGFromCode { get; set; }
       public string Name { get; set; }
     
    }
}
