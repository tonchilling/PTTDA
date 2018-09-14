using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class USERRoleAutorizeDTO: BaseDTO
    {

        public USERRoleAutorizeDTO() { }

        public string USERRole_Autorize_OID { get; set; }
       public string MENU_OID {get;set;}
       public string USERRoleID { get; set; }
       public string USERRoleName { get; set; }
      public string Screen { get; set; }
      public string VIEW {get;set;}
	public string EDIT {get;set;}
	public string DELETE {get;set;}
	public string APPROVE {get;set;}
    public string ROW_STATE {get;set;}

    }


    public class USERRoleAutorizeJsonList
    {

        public List<USERRoleAutorizeDTO> data { get; set; }
    }



}
