using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Util
{
   public class DropDownListDTO: BaseDTO
    {
       public DropDownListDTO()
       { }

       public DropDownListDTO(string CreateBy)
       {
           this.CreateBy = CreateBy;
       }

       public string Value { get; set; }
       public string Name { get; set; }
    


     
    }
   public  enum DropDownlistType
   {
       DIGFrom,
       Region,
       PipeLine,
       RouteCode,
       HolidayTest,
       ClockPosition,
       AssertOwner,
       Holiday
   }

}
