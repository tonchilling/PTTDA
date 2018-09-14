using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class MenuDTO: BaseDTO
    {

        public MenuDTO() { }

       public string MENU_OID {get;set;}
      public string OrderNo {get;set;}
     public string MENUGROUP_OID {get;set;}
     public string MENUGROUPName { get; set; }
      public string Name {get;set;}
     public string DESC {get;set;}
     public string SCREEN {get;set;}
     public string LINK {get;set;}
     public string Icon {get;set;}
     public string Position { get; set; }
     public string PMENU_OID {get;set;}
     public string CREATE_BY {get;set;}
     public string CREATE_DATE {get;set;}
     public string UPDATE_BY {get;set;}
    public string UPDATE_DATE {get;set;}
     public string ROW_STATE {get;set;}
    }

    public class MenuGroupDTO : BaseDTO
    {

        public MenuGroupDTO() { }

        public string MENU_OID { get; set; }
          public string Name {get;set;}
        public string OrderNo { get; set; }
    }
}
