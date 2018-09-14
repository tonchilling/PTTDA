using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public abstract class BaseDTO
    {
       public BaseDTO()
       {
           Row_State = "";
           Status = "";
           Page = "";
           CreateDate = "";
           CreateBy = "";
           UpdateDate = "";
           UpdateBy = "";
       }

       public string Row_State { get; set; }
        public string Status { get; set; }
        public string Page { get; set; }
        public string CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string IsSave { get; set; }
        public string IsDelete { get; set; }
        public string IsView { get; set; }
        public string IsApprove { get; set; }
        public string IsReject { get; set; }
        public string IsSaveSpec { get; set; }
        public string IsSavePO { get; set; }
        public string IsSaveAction { get; set; }
        public string IsConfirm { get; set; }
       // public string UpdateBy { get; set; }
    }
}
