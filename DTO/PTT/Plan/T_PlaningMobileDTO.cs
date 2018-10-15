using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO.PTT.Plan
{
    public class T_PlaningMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public int Index { get; set; }
        public string PID { get; set; }
        public string DIGFromID { get; set; }
        public string DIGFrom { get; set; }
        public string DIGFromName { get; set; }
        public string PlanType { get; set; }
        public string North { get; set; }
        public string East { get; set; }
        public string RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string PipelineID { get; set; }
        public string PipelineName { get; set; }
        public string StartEndPipeline { get; set; }
        public string AssetOwnerID { get; set; }
        public string AssetOwner { get; set; }
        public string RouteCodeID { get; set; }
        public string RouteCode { get; set; }
        public string Section { get; set; }
        public string TabNo { get; set; }
        public string Review { get; set; }
        public string Remark { get; set; }
        public string KP { get; set; }
        public string KPCode { get; set; }
        public string RiskScore { get; set; }
        public string RiskOfDetail { get; set; }
        public string RiskScoreName { get; set; }
        public string Progress { get; set; }
        public string ChangeSDate { get; set; }
        public string ChangeEDate { get; set; }
        public string POComplete { get; set; }
        public int POWeeks { get; set; }
        public string POSDate { get; set; }
        public string POEDate { get; set; }
        public string POOrgSDate { get; set; }
        public string POOrgEDate { get; set; }
        public string SpecComplete { get; set; }
        public int SpecWeeks { get; set; }
        public string SpecSDate { get; set; }
        public string SpecEDate { get; set; }
        public string SpecOrgSDate { get; set; }
        public string SpecOrgEDate { get; set; }
        public string ActionComplete { get; set; }
        public int ActionWeeks { get; set; }
        public string ActionSDate { get; set; }
        public string ActionEDate { get; set; }
        public string ActionOrgSDate { get; set; }
        public string ActionOrgEDate { get; set; }
        public string RepairUsing { get; set; }
        public string RepairLength { get; set; }
        public string KPRepairStart { get; set; }
        public string GPSKPStartN { get; set; }
        public string GPSKPStartE { get; set; }
        public string pH { get; set; }
        public string Bacteria { get; set; }
        public string DFT { get; set; }
        public string HolidayTestID { get; set; }
        public string HolidayTestValue { get; set; }
        public string FileName1 { get; set; }
        public string FileName2 { get; set; }
        public string FileName3 { get; set; }
        public string FileName4 { get; set; }
        public string TimeLine { get; set; }
        public string DeleteFiles { get; set; }
        public string DeleteFileNames { get; set; }
    }

    public class T_PlaningFileMobileDTO : BaseDTO
    {
        public string TPID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string UploadDate { get; set; }
        public string UploadType { get; set; }
        public string FileName { get; set; }
        public string Profile { get; set; }
        public string FileSize { get; set; }
        public HttpPostedFile PostFile { get; set; }
        public string HtmlFile { get; set; }
        public string FullPath { get; set; }
        public string DesPath { get; set; }
    }
}
