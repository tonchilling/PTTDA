using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Report
{
    public class QuarterlyReportDTO
    {

       public string PipelineType { get; set; }
       public string PipelineID { get; set; }

       public string AssertOwner { get; set; }
       public string AssertOwnerID { get; set; }

     
       public string No{get;set;}
       public string Region{get;set;}
      public string RC{get;set;}
      public string Pipeline { get; set; }
     public string PipelineSection{get;set;}
     public string KP{get;set;}
     public string RepairLength{get;set;}
      public string Digfrom{get;set;}
     public string RiskLevel{get;set;}
public string CoatingType{get;set;}
    public string CoatingDMGType{get;set;}
        public string CoatingPoint{get;set;}
            public string PipelineDMGType{get;set;}
                public string PipelinePoint{get;set;}
                public string Actual { get; set; }
                public string Note { get; set; }
                public string PlanStatus { get; set; }
    }



   public class QuarterlyReportDTOExportDTO
   {

     

     
       public string Region { get; set; }
       public string RCKP { get; set; }
       public string PipelineSection { get; set; }
       public string Digfrom { get; set; }
       public string RepairLength { get; set; }
       public string Actual { get; set; }
       public string PlanStatus { get; set; }
      
      
   }
}
