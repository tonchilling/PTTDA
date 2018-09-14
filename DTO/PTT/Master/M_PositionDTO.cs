using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Master
{
    public class M_PositionDTO : BaseDTO
    {
        public M_PositionDTO()
       {
          
       }



       public string PositionID { get; set; }
       public string Name { get; set; }
       public string NameEng { get; set; }
       public string Role { get; set; }
        public string Status { get; set; }

    }
}
