using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Master
{
    public class M_UndergroundMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string PID { get; set; }
        public string UID { get; set; }
        public string ParentUID { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IsInput { get; set; }
        public string Value { get; set; }
    }
}
