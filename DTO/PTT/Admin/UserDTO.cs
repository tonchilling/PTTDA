using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class UserDTO : BaseDTO
    {

       public UserDTO() { }

       public string UserID { get; set; }
       public string UserLogin { get; set; }
       public string UserGroupType { get; set; }
       public string UserGroupID { get; set; }
       public string UserGroupName { get; set; }
        
       public string USERRoleID { get; set; }
       public string USERRoleName { get; set; }
       public string Password { get; set; }
       public string Company { get; set; }
       public string Title { get; set; }
       public string TitleName { get; set; }
       public string NickName { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string UserType { get; set; }
       public string UserTypeName { get; set; }
       public string UserRegion { get; set; }
       public string AssertOwner { get; set; }
       public string UserPlan { get; set; }
       public string Department { get; set; }
       public string DepartmentName { get; set; }
       public string Position { get; set; }
       public string PositionName { get; set; }
       public string RoleLevel { get; set; }
       public string PositionPSI { get; set; }
       public string PositionPSIName { get; set; }
       public string Email { get; set; }
       public string Tel { get; set; }
       public string Ext { get; set; }
        public string CreatePlan { get; set; }
        public string ExportPlan { get; set; }  
   public string ConfirmPlan { get; set; }
   public string ApprovePlan { get; set; }
   public string EditPlanDate { get; set; }
   public string EditTimeline { get; set; }
       public string SetDefaultUserGroup { get; set; }
        public bool LDAP { get; set; }


    }


    public class PTTUserInfoDTO
    { 
     public string  CODE  { get; set; }
      public string  INAME { get; set; }
      public string  TitleID { get; set; }
     public string  INAME1 { get; set; }
      public string  INAME2 { get; set; }
     public string  INAME3 { get; set; }
       public string  INAME4 { get; set; }
       public string  INAME5 { get; set; }
       public string  FNAME { get; set; }
      public string  MNAME { get; set; }
       public string  LNAME2 { get; set; }
        public string  LNAME { get; set; }
       public string  FNAME_ENG { get; set; }
       public string  LNAME_ENG { get; set; }
        public string  BIRTHDATE { get; set; }
        public string  ADDRESS { get; set; }
       public string  HOMETEL { get; set; }
        public string  OFFICETEL { get; set; }
       public string  SEX { get; set; }
        public string  ENTRYDATE { get; set; }
        public string  WSTCODE { get; set; }
       public string  POSNAME { get; set; }
       public string  MGMT { get; set; }
       public string  UNITCODE { get; set; }
        public string  WGRPCODE { get; set; }
       public string  SALCODE { get; set; }
       public string  JOBGROUP { get; set; }
       public string  OFFICECODE { get; set; }
        public string  STPOSDATE { get; set; }
       public string  STJGDATE { get; set; }
       public string  JGAGE1 { get; set; }
       public string  JGAGE2 { get; set; }
        public string  AGE1 { get; set; }
        public string  AGE2 { get; set; }
       public string  POSAGE1 { get; set; }
       public string  POSAGE2 { get; set; }
        public string  JOBAGE1 { get; set; }
        public string  JOBAGE2 { get; set; }
       public string  RETIREYEAR { get; set; }
        public string  QUADRANT { get; set; }
        public string  RETIREDATE { get; set; }
        public string  POSCODE { get; set; }
        public string  TAXCODE { get; set; }
        public string  PERSCODE { get; set; }
       public string  TIMEST { get; set; }
        public string  HIRINGDATE { get; set; }
       public string  ASSIGNDATE { get; set; }
        public string  EmailAddr { get; set; }
       public string  INAME_ENG { get; set; }
       public string FULLNAMETH { get; set; }
        public string POSITION { get; set; }
        public string EXT { get; set; }
        public string DEPARTMENT { get; set; }

    }

     public class UserAndMenuAutorize
    {
         public UserDTO UserLogin { get; set; }
       public List<MenuDTO> MenuAll { get; set; }
      
    }


   
}
