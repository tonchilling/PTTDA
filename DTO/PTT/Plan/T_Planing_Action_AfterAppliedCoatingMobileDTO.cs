using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_AfterAppliedCoatingMobileDTO : BaseDTO
    {
        public T_Planing_Action_AfterAppliedCoatingMobileDTO()
        {
            ID = "";
            PID = "";
            DryDFTEquipment = "";
            DryBrand = "";
            DryModel = "";
            DrySN = "";
            HolidayTestMethod = "";
            HolidayBrand = "";
            HolidayModel = "";
            HolidaySN = "";
            HolidayTestVoltage = "";
            HolidayRemark = "";
            CreateBy = "";
            CreateDate = "";
            UpdateBy = "";
            UpdateDate = "";
            Status = "";
        }

        public string TPID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string DryDFTEquipment { get; set; }
        public string DryBrand { get; set; }
        public string DryModel { get; set; }
        public string DrySN { get; set; }
        public string HolidayTestMethod { get; set; }
        public string HolidayBrand { get; set; }
        public string HolidayModel { get; set; }
        public string HolidaySN { get; set; }
        public string HolidayTestVoltage { get; set; }
        public string HolidayRemark { get; set; }
        public string DeleteFiles { get; set; }
        public string DeleteFileNames { get; set; }
        public string MinClockPosition { get; set; }
        public string AvgClockPosition { get; set; }
        public List<T_PlaningFileMobileDTO> UploadFileList { get; set; }
        public List<T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO> DryFilmThicknessList { get; set; }
    }

    public class T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO : BaseDTO
    {
        public T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO()
        {
            ID = "";
            PID = "";
            No = "";
            PositionNo = "";
            RepairType = "";
            ClockPosition1 = "";
            ClockPosition2 = "";
            ClockPosition3 = "";
            ClockPosition4 = "";
            AVGDFT = "";
        }

        public string TPID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string PositionNo { get; set; }
        public string RepairType { get; set; }
        public string ClockPosition1 { get; set; }
        public string ClockPosition2 { get; set; }
        public string ClockPosition3 { get; set; }
        public string ClockPosition4 { get; set; }
        public string AVGDFT { get; set; }
    }
}
