using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Plan
{
    public class T_Planing_ApprovalHistoryDTO : BaseDTO
    {

       
        public string ID  { get; set; }
         public string PID { get; set; }   
        public string No  { get; set; }   
      public string ApproveStatus  { get; set; }
      public string Remark { get; set; }
      public string Comment { get; set; }   



    }

 

}
