using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_AppliedCoatingMobileDTO : BaseDTO
    {
        public T_Planing_Action_AppliedCoatingMobileDTO()
        {
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

        public string TPID { get; set; }
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
        public List<T_PlaningFileMobileDTO> UploadFileList { get; set; }
        public List<T_Planing_Action_AppliedCoating_InformationMobileDTO> CoatingInfoList { get; set; }
    }

    public class T_Planing_Action_AppliedCoating_InformationMobileDTO : BaseDTO
    {
        public T_Planing_Action_AppliedCoating_InformationMobileDTO()
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
        public string TPID { get; set; }
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
}
