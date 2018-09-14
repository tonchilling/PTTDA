using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_KPDTO : BaseDTO
    {
       public M_KPDTO()
       {
           KPID = "";
           KPCode = "";
           Name = "";
           CreateDate = "";
           CreateBy = "";
           UpdateDate = "";
           UpdateBy = "";
           Status = "";
       }

       public string KPID { get; set; }
       public string KPCode { get; set; }
       public string Name { get; set; }
       public string CreateDate { get; set; }
       public string CreateBy { get; set; }
       public string UpdateDate { get; set; }
       public string UpdateBy { get; set; }
       public string Status { get; set; }
    }
}
