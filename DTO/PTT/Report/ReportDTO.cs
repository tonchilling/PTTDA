using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT.Plan;
namespace DTO.PTT.Report
{


    public class SummaryRepaireAll
    {
        public List<SummaryRepaireDTO> Table { get; set; }
        public List<ProgressGraphDto> GraphData { get; set; }
        public List<ColumnReportDTO> Graph { get; set; }
    }

    public class SummaryRepaireDTO : BaseDTO
    {

        /* @RegionID nvarchar(50)='',
    @RouteID nvarchar(50)='',
    @Year nvarchar(4)='',
     @PipelineLengthID nvarchar(50)='',
     @AssetID nvarchar(50)='',
    @DIGFromID nvarchar(50)=''*/

        public string PipelineType { get; set; }
        public string PipelineID { get; set; }
        public string AssertOwner { get; set; }
        public string AssertOwnerID { get; set; }
        public string No { get; set; }
        public string Note { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string TypeOfPipelineID { get; set; }
        public string Region { get; set; }
        public string RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RouteCode { get; set; }
        public string RC { get; set; }
        public string PipelineSection { get; set; }
        public string PipelineSectionCode { get; set; }
        public string KP { get; set; }
        public string RepairLength { get; set; }
        public string Digfrom { get; set; }
        public string CoatingType { get; set; }
        public string CoatingDMGType { get; set; }
        public string CoatingPoint { get; set; }
        public string PipelineDMGType { get; set; }
        public string PipelinePoint { get; set; }
        public string RiskLevel { get; set; }

        public string PipelineLengthID { get; set; }
        public string DIGFromID { get; set; }
        public string QuaterID { get; set; }
        public string Year { get; set; }


    }


    public class QuaterlyReportDTO
    {



        
        public string PID { get; set; }
        public string No { get; set; }
        public string AssertOwnerID { get; set; }
        public string AssertOwner { get; set; }
        public string TypeOfPipelineID { get; set; }
        public string PipelineID { get; set; }
        public string PipelineType { get; set; }
        public string Region { get; set; }
        public string RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RouteCode { get; set; }
        public string RouteID { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }

        public string RC { get; set; }
        public string PipelineSection { get; set; }
        public string RiskLevel { get; set; }
        public string PipelineSectionCode { get; set; }
        public string KP { get; set; }
        public string RepairLength { get; set; }
        public string Digfrom { get; set; }
        public string DIGFromID { get; set; }
        public string SpecDesc { get; set; }
        public string PODesc { get; set; }
        public string ActionDesc { get; set; }
        public string FinishDesc { get; set; }
        public string Progress { get; set; }
        public string CoatingType { get; set; }
        public string CoatingDMGType { get; set; }
        public string CoatingPoint { get; set; }
        public string PipelineDMGType { get; set; }
        public string PipelinePoint { get; set; }
        public string RepaireMethod { get; set; }
        public string Note { get; set; }
        
        public string Review { get; set; }
        
    }



    public class SummaryRepairReportExportDTO
    {

        public string PipelineType { get; set; }


        public string AssertOwner { get; set; }



        public string No { get; set; }
        public string Region { get; set; }
        public string RC { get; set; }
        public string PipelineSection { get; set; }
        public string KP { get; set; }
        public string RepairLength { get; set; }
        public string Digfrom { get; set; }
        public string RiskLevel { get; set; }
        public string CoatingType { get; set; }
        public string CoatingDMGType { get; set; }
        public string CoatingPoint { get; set; }
        public string PipelineDMGType { get; set; }
        public string PipelinePoint { get; set; }
        public string Note { get; set; }
    }


    public class ExportPlanHeader
    {





        public string ID { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public string Subject { get; set; }
        public string SubjectName  { get; set; }
    public string No { get; set; }
    public string Text { get; set; }
    public string Color { get; set; }
        public string StyleID { get; set; }

    }



    public class ExportPlanReport
    {
        public List<ExportPlanHeader> Header { get; set; }
        public List<ExportPlaningDTO> Data { get; set; }
    }

}
