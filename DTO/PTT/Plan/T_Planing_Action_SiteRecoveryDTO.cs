using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_SiteRecoveryDTO : BaseDTO
    {

        public T_Planing_Action_SiteRecoveryDTO()
        {
            ID = "";
            PID = "";
            IssueDate = "";
            Remark = "";
            Approval1 = "";
            Approval2 = "";
            Approval3 = "";
         
 
            Status = "";
        }
        public String ID { get; set; }
        public String PID { get; set; }
        public String IssueDate { get; set; }
        public String Remark { get; set; }
        public String Approval1 { get; set; }
        public String ApprovalDate1 { get; set; }
        public String ApprovalName1 { get; set; }
        public String ApprovalPosition1 { get; set; }
        public String Approval2 { get; set; }
        public String ApprovalDate2 { get; set; }
        public String ApprovalName2 { get; set; }
        public String ApprovalPosition2 { get; set; }
        public String Approval3 { get; set; }
        public String ApprovalDate3 { get; set; }
        public String ApprovalName3 { get; set; }
        public String ApprovalPosition3 { get; set; }
        public String Rejecter { get; set; }
        public String RejectStatus { get; set; }
        public String ApproveStatus { get; set; }
        public String IsApprove { get; set; }
        public String IsReject { get; set; }
        public String Status { get; set; }
          public string DeleteFiles { get; set; }
          public string DeleteFileNames { get; set; }
          public String Comment { get; set; }
          public List<T_Planing_File> UploadFileList { get; set; }

          public List<T_Planing_ApprovalHistoryDTO> LogApporveHistorys { get; set; }
        
    }


}
