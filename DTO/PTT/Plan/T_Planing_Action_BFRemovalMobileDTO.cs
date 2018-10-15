using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_BFRemovalMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string CoatingTypeID { get; set; }
        public string FieldJoinTypeID { get; set; }
        public string RepairLength { get; set; }
        public string CoatingThickness { get; set; }
        public string WaterCondense { get; set; }
        public string HolidayTest { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Degree { get; set; }
        public string DegreeLength { get; set; }
        public string DeleteFiles { get; set; }
        public string DeleteFileNames { get; set; }
        public string DeleteConditionFiles { get; set; }
        public string DefectImg { get; set; }
        public string DefectImgUrl { get; set; }
        public List<T_PlaningFileMobileDTO> UploadFileList { get; set; }
        public List<T_PlaningFileMobileDTO> UploadDefectFileList { get; set; }
        public List<T_Planing_Action_BFRemoval_ConditionMobileDTO> ConditionList { get; set; }
    }

    public class T_Planing_Action_BFRemoval_ConditionMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string DefectTypeID { get; set; }
        public string DisWidth { get; set; }
        public string DisLength { get; set; }
        public string DegreeFrom { get; set; }
        public string DegreeLength { get; set; }
        public string DegreePosition { get; set; }
        public string RiskScore { get; set; }
        public string Remark { get; set; }
        public string UploadType { get; set; }
        public string HtmlFile { get; set; }
        public string FileName { get; set; }
    }
}
