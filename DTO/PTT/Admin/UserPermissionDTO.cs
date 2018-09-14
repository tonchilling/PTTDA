using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class UserPermissionDTO: BaseDTO
    {

        public UserPermissionDTO() { }

        public string USER_PERMISSION_OID { get; set; }
       public string MENU_OID {get;set;}
      public string UserID {get;set;}
      public string UserLogin {get;set;}
      public string Password {get;set;}
      public string Title {get;set;}
      public string NickName {get;set;}
      public string FirstName {get;set;}
      public string LastName {get;set;}
      public string UserType {get;set;}
      public string UserTypeName {get;set;} 
      public string UserRegion {get;set;}
      public string UserPlan {get;set;}
      public string Department {get;set;}
      public string Position {get;set;}
      public string Company {get;set;}
      public string PositionPSI {get;set;}
      public string Screen { get; set; }
      public string VIEW {get;set;}
	public string EDIT {get;set;}
	public string DELETE {get;set;}
	public string APPROVE {get;set;}
    public string ROW_STATE {get;set;}

    }


    public class UserPermissionJsonList
    {

        public List<UserPermissionJson> data { get; set; }
    }

    public class UserPermissionJson
    {
        public string USER_PERMISSION_OID { get; set; }
        public string UserID { get; set; }
        public string MENU_OID { get; set; }
        public string View { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
        public string ROW_STATE { get; set; }
    }

}
