using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class USERGroupAutorizeDTO : BaseDTO
    {

        public USERGroupAutorizeDTO() { }

        public string USERGROUP_Autorize_OID { get; set; }
        public string USERGROUPID { get; set; }
        public string MENU_OID { get; set; }
        public string MENUName { get; set; }
        public string Icon { get; set; }
        public string MENUGROUP_OID { get; set; }
        public string MENUGROUPName { get; set; } 
      public string VIEW {get;set;}
	public string EDIT {get;set;}
	public string DELETE {get;set;}
	public string APPROVE {get;set;}
    //public string ROW_STATE {get;set;}
      


    }


    public class UserGroupAutorizeDTOJsonList
    {

        public List<USERGroupAutorizeDTO> data { get; set; }
    }



}
