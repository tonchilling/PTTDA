using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Plan
{
    public class T_Planing_ApprovalHistoryMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string ApproveStatus { get; set; }
        public string Remark { get; set; }
        public string Comment { get; set; }
    }
}
