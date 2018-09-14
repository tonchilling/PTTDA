using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTO.PTT.Plan
{
    public class T_PlaningDTO : BaseDTO
    {
        public T_PlaningDTO()
       {
           DIGFromID = "";
           AssetOwnerID = "";
           RouteCodeID = "";
           PipelineID = "";
        }


     public int Index { get; set; }
     public string PID { get; set; }

     public string DIGFromID { get; set; }
     public string DIGFrom { get; set; }
     public string DIGFromName { get; set; }
     public string PlanType { get; set; }
	 public string North { get; set; } 
	 public string East{ get; set; } 
	 public string RegionID{ get; set; }
     public string RegionCode { get; set; } 
     public string RegionName { get; set; } 
	 public string PipelineID{ get; set; }
        
     public string PipelineName { get; set; }
     public string StartEndPipeline { get; set; } 
	 public string AssetOwnerID{ get; set; }
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


     public string jan_1 { get; set; }
     public string jan_2 { get; set; }
     public string jan_3 { get; set; }
     public string jan_4 { get; set; }
     public string jan_5 { get; set; }
     public string jan_6 { get; set; }

     public string jan_1color { get; set; }
     public string jan_2color { get; set; }
     public string jan_3color { get; set; }
     public string jan_4color { get; set; }





     public string feb_1 { get; set; }
     public string feb_2 { get; set; }
     public string feb_3 { get; set; }
     public string feb_4 { get; set; }
     public string feb_5 { get; set; }
     public string feb_6 { get; set; }

     public string feb_1color { get; set; }
     public string feb_2color { get; set; }
     public string feb_3color { get; set; }
     public string feb_4color { get; set; }



     public string mar_1 { get; set; }
     public string mar_2 { get; set; }
     public string mar_3 { get; set; }
     public string mar_4 { get; set; }
     public string mar_5 { get; set; }
     public string mar_6 { get; set; }

     public string mar_1color { get; set; }
     public string mar_2color { get; set; }
     public string mar_3color { get; set; }
     public string mar_4color { get; set; }

     public string apr_1 { get; set; }
     public string apr_2 { get; set; }
     public string apr_3 { get; set; }
     public string apr_4 { get; set; }
     public string apr_5 { get; set; }
     public string apr_6 { get; set; }

     public string apr_1color { get; set; }
     public string apr_2color { get; set; }
     public string apr_3color { get; set; }
     public string apr_4color { get; set; }



     public string may_1 { get; set; }
     public string may_2 { get; set; }
     public string may_3 { get; set; }
     public string may_4 { get; set; }
     public string may_5 { get; set; }
     public string may_6 { get; set; }

     public string may_1color { get; set; }
     public string may_2color { get; set; }
     public string may_3color { get; set; }
     public string may_4color { get; set; }


     public string jun_1 { get; set; }
     public string jun_2 { get; set; }
     public string jun_3 { get; set; }
     public string jun_4 { get; set; }
     public string jun_5 { get; set; }
     public string jun_6 { get; set; }

     public string jun_1color { get; set; }
     public string jun_2color { get; set; }
     public string jun_3color { get; set; }
     public string jun_4color { get; set; }

     public string jul_1 { get; set; }
     public string jul_2 { get; set; }
     public string jul_3 { get; set; }
     public string jul_4 { get; set; }
     public string jul_5 { get; set; }
     public string jul_6 { get; set; }

     public string jul_1color { get; set; }
     public string jul_2color { get; set; }
     public string jul_3color { get; set; }
     public string jul_4color { get; set; }



     public string aug_1 { get; set; }
     public string aug_2 { get; set; }
     public string aug_3 { get; set; }
     public string aug_4 { get; set; }
     public string aug_5 { get; set; }
     public string aug_6 { get; set; }

     public string aug_1color { get; set; }
     public string aug_2color { get; set; }
     public string aug_3color { get; set; }
     public string aug_4color { get; set; }



     public string sep_1 { get; set; }
     public string sep_2 { get; set; }
     public string sep_3 { get; set; }
     public string sep_4 { get; set; }
     public string sep_5 { get; set; }
     public string sep_6 { get; set; }

     public string sep_1color { get; set; }
     public string sep_2color { get; set; }
     public string sep_3color { get; set; }
     public string sep_4color { get; set; }


     public string oct_1 { get; set; }
     public string oct_2 { get; set; }
     public string oct_3 { get; set; }
     public string oct_4 { get; set; }
     public string oct_5 { get; set; }
     public string oct_6 { get; set; }

     public string oct_1color { get; set; }
     public string oct_2color { get; set; }
     public string oct_3color { get; set; }
     public string oct_4color { get; set; }


     public string nov_1 { get; set; }
     public string nov_2 { get; set; }
     public string nov_3 { get; set; }
     public string nov_4 { get; set; }
     public string nov_5 { get; set; }
     public string nov_6 { get; set; }

     public string nov_1color { get; set; }
     public string nov_2color { get; set; }
     public string nov_3color { get; set; }
     public string nov_4color { get; set; }


     public string dec_1 { get; set; }
     public string dec_2 { get; set; }
     public string dec_3 { get; set; }
     public string dec_4 { get; set; }
     public string dec_5 { get; set; }
     public string dec_6 { get; set; }

     public string dec_1color { get; set; }
     public string dec_2color { get; set; }
     public string dec_3color { get; set; }
     public string dec_4color { get; set; }




     public string CompleteDate { get; set; }
     public string ReportDate { get; set; }
     public string CostingDefect { get; set; }
     public string PipeDefect { get; set; }
    
     public string Note { get; set; }
     public string EditNote { get; set; }
     public string Confirm { get; set; }
     public string RouteName { get; set; }
   
	
     public string SectionCode { get; set; }
	
     public string DIGFromCode { get; set; } 
	
     public string  Row_State { get; set; }

     public string Year { get; set; }

     public List<T_Planing_File> UploadFileList { get; set; }
     public List<T_Planing_File> DeleteFileList { get; set; }
   

     public List<T_Planing_DefectDTO> CoatingDefectList { get; set; }
     public List<T_Planing_DefectDTO> PipeDefectList { get; set; }
     public List<T_Planing_EnvironmentDTO> EnvironmentList { get; set; }
    }


    public class ExportPlaningDTO : BaseDTO
    {
        public ExportPlaningDTO()
        {
            DIGFromID = "";
            AssetOwnerID = "";
            RouteCodeID = "";
            PipelineID = "";
        }


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



        public string KP { get; set; }
        public string KPCode { get; set; }
        public string RiskScore { get; set; }
        public string RiskOfDetail { get; set; }
        public string RiskScoreName { get; set; }
        public string Progress { get; set; }
        public string DIGFromCode { get; set; }
        public string Year { get; set; }

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




        public string jan_1 { get; set; }
        public string jan_2 { get; set; }
        public string jan_3 { get; set; }
        public string jan_4 { get; set; }







        public string feb_1 { get; set; }
        public string feb_2 { get; set; }
        public string feb_3 { get; set; }
        public string feb_4 { get; set; }


       


        public string mar_1 { get; set; }
        public string mar_2 { get; set; }
        public string mar_3 { get; set; }
        public string mar_4 { get; set; }

      
        public string apr_1 { get; set; }
        public string apr_2 { get; set; }
        public string apr_3 { get; set; }
        public string apr_4 { get; set; }



        public string may_1 { get; set; }
        public string may_2 { get; set; }
        public string may_3 { get; set; }
        public string may_4 { get; set; }



        public string jun_1 { get; set; }
        public string jun_2 { get; set; }
        public string jun_3 { get; set; }
        public string jun_4 { get; set; }
 

        public string jul_1 { get; set; }
        public string jul_2 { get; set; }
        public string jul_3 { get; set; }
        public string jul_4 { get; set; }




        public string aug_1 { get; set; }
        public string aug_2 { get; set; }
        public string aug_3 { get; set; }
        public string aug_4 { get; set; }




        public string sep_1 { get; set; }
        public string sep_2 { get; set; }
        public string sep_3 { get; set; }
        public string sep_4 { get; set; }



        public string oct_1 { get; set; }
        public string oct_2 { get; set; }
        public string oct_3 { get; set; }
        public string oct_4 { get; set; }


        public string nov_1 { get; set; }
        public string nov_2 { get; set; }
        public string nov_3 { get; set; }
        public string nov_4 { get; set; }



        public string dec_1 { get; set; }
        public string dec_2 { get; set; }
        public string dec_3 { get; set; }
        public string dec_4 { get; set; }





    }


    public class T_Planing_File : BaseDTO
    {
       public string PID  { get; set; }
       public string  No  { get; set; }
       public string UploadDate { get; set; }
       public string UploadType { get; set; }
      public string   FileName  { get; set; }
      public string Profile { get; set; }
      public string FileSize { get; set; }
      public HttpPostedFile PostFile { get; set; }
      public string HtmlFile { get; set; }
      public string FullPath { get; set; }
      public string DesPath { get; set; }
    }


    public class T_Planing_DefectDTO : BaseDTO
    {
        public T_Planing_DefectDTO()
        { }

        public string ID { get; set; }
        public string PID { get; set; }
        public int No { get; set; }
        public string Type { get; set; }
        public string KP { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string ClockPostionID { get; set; }
        public string ClockPostionName { get; set; }
        public string RepairByID { get; set; }
        public string RepairByName { get; set; }
        public string FileName1 { get; set; }
        public HttpPostedFile File1 { get; set; }
        public string FileName2 { get; set; }
        public HttpPostedFile File2 { get; set; }
        public string FileName3 { get; set; }
        public HttpPostedFile File3 { get; set; }
        public string FileName4 { get; set; }
        public HttpPostedFile File4 { get; set; }


        public T_Planing_DefectDTO clone()
        {
            T_Planing_DefectDTO obj = new T_Planing_DefectDTO();
            obj.ID = this.ID;
            obj.PID = this.ID;
            obj.No = this.No;
       obj.Type = this.Type;
        obj.KP = this.KP;
        obj.Width = this.Width;
        obj.Length = this.Length;
        obj.ClockPostionID = this.ClockPostionID;
        obj.ClockPostionName = this.ClockPostionName;
        obj.RepairByID = this.RepairByID;
        obj.RepairByName = this.RepairByName;
        obj.FileName1 = this.FileName1;
        obj.File1 = null;
        obj.FileName2 = this.FileName2;
        obj.File2 = null;
        obj.FileName3 = this.FileName3;
        obj.File3 = null;
        obj.FileName4 = this.FileName4;
        obj.File4 = null;

            return obj;
        
        }
      
    }

    public class MonthAndWeek
    {
        public int Week { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class T_Planing_EnvironmentDTO : BaseDTO
    {
        public T_Planing_EnvironmentDTO()
        { }

        public string ID { get; set; }
        public string PID { get; set; }
        public int No { get; set; }
        public string DryTemp { get; set; }
        public string WetTemp { get; set; }
        public string DewTemp { get; set; }
        public string PipeSurface { get; set; }
        public string RelativeHumidity  { get; set; } 
    }


     public class T_Planing_ReportSummaryRepaireDto  : BaseDTO
    {

            public string ID { get; set; }
        public string PID { get; set; }
        public string TypeOfPipelineID { get; set; }
         public string PipelineType { get; set; }
          public string Region { get; set; }
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


                     }

    public enum PlanType
    {
        Spec = 1,
        PO = 2,
        Action = 3
    }
}
