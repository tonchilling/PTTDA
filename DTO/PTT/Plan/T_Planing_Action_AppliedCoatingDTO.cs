using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_AppliedCoatingDTO : BaseDTO
    {

        public T_Planing_Action_AppliedCoatingDTO() {

            ID = "";
            PID = "";
            SurfaceType = "";
            SurfaceBrand = "";
            SurfaceModel = "";
            CoatingTypeID = "";
            CoatingBrand = "";
            CoatingModel = "";
            CreateBy = "";
            CreateDate = "";
            UpdateBy = "";
            UpdateDate = "";
            Status = "";
            CoatingTypeName = "";
        
        }

        public string ID { get; set; }
          public string PID { get; set; }
        public string SurfaceType { get; set; }
         public string SurfaceBrand { get; set; }
         public string SurfaceModel { get; set; }
         public string CoatingTypeID { get; set; }
         public string CoatingTypeName { get; set; }
        
          public string CoatingBrand { get; set; }
          public string CoatingModel { get; set; }
          public string DeleteFiles { get; set; }
          public string DeleteFileNames { get; set; }
       
          public List<T_Planing_File> UploadFileList { get; set; }
          public List<T_Planing_Action_AppliedCoating_InformationDTO> CoatingInfoList { get; set; }
    }



    public class T_Planing_Action_AppliedCoating_InformationDTO : BaseDTO
{

        public T_Planing_Action_AppliedCoating_InformationDTO()
        {

            PID = "";
            No = "";
            InfoType = "";
            InfoDate = "";
            PartA = "";
            PartB = "";
            Solvent = "";
            Remark = "";
            FileSize = "";


        }
        public string PID { get; set; }
        public string No { get; set; }
        public string InfoType { get; set; }
        public string InfoDate { get; set; }
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string Solvent { get; set; }
        public string Remark { get; set; }
        public string FileSize { get; set; }
}

    /*
     
     SELECT 
	[PID], 
	[No], 
	[InfoType], 
	[InfoDate], 
	[PartA], 
	[PartB], 
	[Solvent], 
	[Remark], 
	[CreateDate], 
	[CreateBy], 
	[UpdateDate], 
	[UpdateBy], 
	[Row_State], 
	[FileSize] 
FROM [T_Planing_Action_AppliedCoating_Information] 
     */
}
