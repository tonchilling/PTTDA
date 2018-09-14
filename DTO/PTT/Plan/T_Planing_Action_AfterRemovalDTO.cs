using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_AfterRemovalDTO : BaseDTO
    {

       
        public string ID  { get; set; }
         public string PID { get; set; }   

        public string PH { get; set; }
        public string DefectNumber { get; set; }   
       public string Brand{ get; set; }   
      public string Model{ get; set; }   
       public string SN{ get; set; }   
       public string Guage{ get; set; }   
       public string CreatedBy{ get; set; }   
       public string CreatedDate{ get; set; }   
       public string UpdatedBy{ get; set; }   
       public string UpdatedDate{ get; set; }
       public string WallThicknessNumber { get; set; }
       public string Degree { get; set; }
       public string DegreeLength { get; set; }   
       public string RepairLength { get; set; }   
       public string DeleteDefectFiles { get; set; }
        public string DefectImgUrl { get; set; }
        public string DefectImgBase64 { get; set; }
        public string MinClockPosition { get; set; }
        public string  AvgClockPosition { get; set; }

        public string WallThicknessImgUrl { get; set; }
        public string WallThicknessImgBase64 { get; set; }

        public List<T_Planing_File> UploadFileList { get; set; }
        public List<T_Planing_Action_AfterRemoval_DefectDTO> DefectList { get; set; }
        public List<T_Planing_Action_AfterRemoval_WallThicknessDTO> WallThicknessList { get; set; }
        
    }


    public class T_Planing_Action_AfterRemoval_DefectDTO : BaseDTO

    {
       


       public string ID { get; set; }
        public string PID { get; set; }
        public string ItemNo { get; set; }
        public string UploadType { get; set; }
        public string DefectTypeID{ get; set; }
        public string DegreePosition { get; set; }
        public string SizeW { get; set; }
        public string SizeL { get; set; }
        public string SizeD { get; set; }
        public string PipeDefect1 { get; set; }
        public string PipeDefect2 { get; set; }
        public string PipeDefect3 { get; set; }
        public string PipeDefect4 { get; set; }
        public string FromDistance { get; set; }
        public string Length { get; set; }
        public string RiskScore { get; set; }
        public string Remark { get; set; }
        public string RepaireMethod { get; set; }
        public string HtmlFile { get; set; }
        public string FileName { get; set; }
       

    }


    public class T_Planing_Action_AfterRemoval_WallThicknessDTO : BaseDTO
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string ItemNo { get; set; }
        public string PositionNo { get; set; }
        public string ClockPosition0 { get; set; }
        public string ClockPosition90 { get; set; }
        public string ClockPosition135 { get; set; }
        public string ClockPosition180 { get; set; }
        public string ClockPosition225 { get; set; }
        public string ClockPosition270 { get; set; }
        public string Remark { get; set; }



     /*    tableObj.PID = PKID;
            tableObj.ItemNo = row.attr('ItemNo');
            tableObj.PositionNo = row.find('.txtPositionNo').val();
            tableObj.Position0 = row.find('.txtClockPosition0').val();
            tableObj.Position90 = row.find('.txtClockPosition90').val();
            tableObj.Position135 = row.find('.txtClockPosition135').val();
            tableObj.Position180 = row.find('.txtClockPosition180').val();
            tableObj.Position225 = row.find('.txtClockPosition225').val();

            tableObj.Position270 = row.find('.txtClockPosition270').val();*/
    }

 

}
