using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT.Master;
namespace DTO.PTT.Util
{
    public class SearchDTO:BaseDTO
    {


        public string AssetOwnerID { get; set; } //        : "stackedColumn100",
        public string DIGFromID { get; set; }
        public string RegionID { get; set; }
        public string RouteCodeID { get; set; }
        public string LicenseID { get; set; }
        public string Quarter { get; set; }//: "รอดำเนินการ",
        public string Year { get; set; } //: "true",
        public string STMonth { get; set; } //: "true",
        public string ENMonth { get; set; } //: "true",
        public string TypeOfPipelineID { get; set; }
        public string AssetOwnerName { get; set; } //        : "stackedColumn100",
        public string CoatingTypeID { get; set; }
        public string LocationClassID { get; set; }
        /*   @CustomerTypeID nvarchar(50)='',
   @TypeOfRouteID nvarchar(50)='',
   @RegionID nvarchar(50)='',
   @Queter nvarchar(3)='',
   @STMonth nvarchar(3)='',
   @ENMonth nvarchar(3)='',
   @Year nvarchar(4)=''*/

    }



    public class ProgressGraphDto
    {

        public string status { get; set; } 
      
        public string type { get; set; } //        : "stackedColumn100",
        public string name { get; set; }//: "รอดำเนินการ",
        public string markerType { get; set; }//: "รอดำเนินการ",
        public string markerColor { get; set; }//: "รอดำเนินการ",
        public string markerSize { get; set; }//: "รอดำเนินการ",
        public string showInLegend { get; set; } //: "true",
        public string yValueFormatString { get; set; }  //: "#0'%'",
          public string  RegionID { get; set; }
          public string  RegionCode { get; set; }
       public string  RegionName { get; set; }
       public string color { get; set; }
     public int Complete { get; set; }
    
    }

   public class ColumnReportDTO
   {


    
       public string Year { get; set; }
       public string markerType { get; set; }//: "รอดำเนินการ",
       public string markerColor { get; set; }//: "รอดำเนินการ",
       public string markerSize { get; set; }//: "รอดำเนินการ",
        public string type  { get; set; } //        : "stackedColumn100",
         public string  name  { get; set; }//: "รอดำเนินการ",
            public string  showInLegend   { get; set; } //: "true",
            public string color { get; set; } //: "true",
            public string indexLabel { get; set; }
            public string  yValueFormatString  { get; set; }  //: "#0'%'",
           // public string toolTipContent { get; set; }  //: "#0'%'",
            public string startAngle { get; set; }  //: "#0'%'",
           public string innerRadius { get; set; }  //: "#0'%'",
            public List<DataPoint> dataPoints { get; set; }
       
      
      
   }


   public class DonutGraphReportDTO
   {



       public string Year { get; set; }
       public string markerType { get; set; }//: "รอดำเนินการ",
       public string markerColor { get; set; }//: "รอดำเนินการ",
       public string markerSize { get; set; }//: "รอดำเนินการ",
       public string type { get; set; } //        : "stackedColumn100",
       public string name { get; set; }//: "รอดำเนินการ",
       public string showInLegend { get; set; } //: "true",
       public string color { get; set; } //: "true",
       public string indexLabel { get; set; }
       public string yValueFormatString { get; set; }  //: "#0'%'",
       public string toolTipContent { get; set; }  //: "#0'%'",
       public string startAngle { get; set; }  //: "#0'%'",
       public string innerRadius { get; set; }  //: "#0'%'",
       public List<DataPoint> dataPoints { get; set; }



   }



   public class SummaryPlanRiskDto
   {

       public string RegionID { get; set; }
       public string RegionCode { get; set; }
       public string RegionName { get; set; }
       public string Low { get; set; }
       public string Medium { get; set; }
       public string High { get; set; }
       public string Q1Low { get; set; }
       public string Q2Low { get; set; }
       public string Q3Low { get; set; }
       public string Q4Low { get; set; }
       public string Q1Medium { get; set; }
       public string Q2Medium { get; set; }
       public string Q3Medium { get; set; }
       public string Q4Medium { get; set; }
       public string Q1High { get; set; }
       public string Q2High { get; set; }
       public string Q3High { get; set; }
       public string Q4High { get; set; }
   }


    public class SummaryCompletelyByRegionDto
    {

        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string Actual { get; set; }
        public string PostPone { get; set; }
        public string Plan { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
    }


        public class SummaryPlanByAssetOwnerDto
   {

       public string AssetOwnerCode { get; set; }
       public string AssetOwner { get; set; }
       public string PM { get; set; }
       public string Total { get; set; }
       public string EstimateYear { get; set; }
       public string PostPone { get; set; }
       public string Q1 { get; set; }
       public string Q2 { get; set; }
       public string Q3 { get; set; }
       public string Q4 { get; set; }
       public string R001 { get; set; }
       public string R002 { get; set; }
       public string R003 { get; set; }
       public string R004 { get; set; }
       public string R005 { get; set; }
       public string R006 { get; set; }
       public string R007 { get; set; }
       public string R008 { get; set; }
       public string R009 { get; set; }
       public string R010 { get; set; }
       public string R011 { get; set; }
       public string R012 { get; set; }
        public string R013 { get; set; }
        public string R014 { get; set; }
        public string R015 { get; set; }
        public string R016 { get; set; }
        public string R017 { get; set; }
        public string R018 { get; set; }
        public string R019 { get; set; }
        public string R020 { get; set; }
    }




     public class SummaryPlanReport
     {

        public List<M_RegionDTO> regionList { get; set; }
        public List<ProgressGraphDto> RawGraphReport { get; set; }
         public List<DonutGraphReportDTO> DonutGraphReport { get; set; }

         public List<ProgressGraphDto> RawRiskGraphBeforeReport { get; set; }
         public List<ProgressGraphDto> RawRiskGraphAfterReport { get; set; }
         public List<ProgressGraphDto> RawRiskGraphCoatingTypeReport { get; set; }
         public List<ProgressGraphDto> RawRiskGraphPipelineTypeReport { get; set; }

         public List<ColumnReportDTO> GraphReport { get; set; }
       

         public List<ColumnReportDTO> GraphRiskReport { get; set; }

         public List<DonutGraphReportDTO> DonutGraphRiskBeforeReport { get; set; }
         public List<DonutGraphReportDTO> DonutGraphRiskAfterReport { get; set; }
         public List<DonutGraphReportDTO> DonutGraphCoatingTypeReport { get; set; }
         public List<DonutGraphReportDTO> DonutGraphPipelineTypeReport { get; set; }

         public List<SummaryPlanByAssetOwnerDto> TableReport { get; set; }
        public List<SummaryCompletelyByRegionDto> SumaryCompletelyByRegionTable { get; set; }
        
         public List<SummaryPlanRiskDto> RiskTableReport { get; set; }
         public List<SummaryPlanOverAllProgressDto> OverAllTableReport { get; set; }

       
      
       
     }



     public class SummaryPlanOverAllProgressDto
     {


       


             public string PID { get; set; }
        public string AssetOwner { get; set; }
        public string InspectionDate { get; set; }
        public string RouteCode { get; set; }
        public string RouteCodeName { get; set; }
        public string Section { get; set; }
        public string KP { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string DigFrom { get; set; }
        public string PlanDate { get; set; }
        public string CoatingDefectType { get; set; }
        public string CoatingServerity { get; set; }
        public string PipelineDefectType { get; set; }
        public string PipelineServerity { get; set; }
        public string Status { get; set; }
    }




   public class DataPoint
   {

       public DataPoint(int y, string label)
       {
           this.y = y;
           this.label = label;

       }
       public DataPoint(int y, string label,string color)
       {
           this.y = y;
           this.label = label;
           this.color = color;
       }
       public int y { get; set; } //        : "stackedColumn100",
       public string label { get; set; }//: "รอดำเนินการ",
       public string color { get; set; } //        : "stackedColumn100",
   }
}
