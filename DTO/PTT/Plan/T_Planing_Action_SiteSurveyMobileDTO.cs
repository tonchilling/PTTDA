using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_SiteSurveyMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string ID  { get; set; }
        public string PID { get; set; }   
        public string RouteCode { get; set; }
        public string Pipegrade { get; set; }
        public string Diameter { get; set; }
        public string WallThickness { get; set; }
        public string MAOP { get; set; }
        public string DateINstalled { get; set; }
        public string Digfrom { get; set; }
        public string RiskScore { get; set; }
        public string Note { get; set; }
        public string RiskDetail { get; set; }
        public string MoreDetail { get; set; }
        public string DeleteFiles { get; set; }
        public string DeleteFileNames { get; set; }
        public string North { get; set; }
        public string East { get; set; }
        public string KP { get; set; }
        public string KPCode { get; set; }
        public string PipelineID { get; set; }
        public string Section { get; set; }
        public List<T_PlaningFileMobileDTO> UploadFileList { get; set; }
        public List<T_PlaningFileMobileDTO> PlanFileList { get; set; }
     
    }
}
