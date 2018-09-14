using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class UserRoleDTO : BaseDTO
    {
       public UserRoleDTO()
       { }

       public string USERRoleID { get; set; }

       public string Name { get; set; }
       public string Desc { get; set; }
       public string Create_Date { get; set; }
       public string Create_By { get; set; }
       public string Update_Date { get; set; }
       public string Update_By { get; set; }
       public  string Status { get; set; }
    }
}
