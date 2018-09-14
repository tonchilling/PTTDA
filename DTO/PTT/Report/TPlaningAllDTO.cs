using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DTO.PTT.Report



{


     public class TPlaningAllDTO
     {

         public DataTable T_PlaningDT { get; set; }
         public DataTable T_Planing_FilesDT { get; set; }


         public DataTable T_Planing_SiteSurveyDT { get; set; }
         public DataTable T_Planing_SiteSurvey_File1DT { get; set; }
         public DataTable T_Planing_SiteSurvey_File2DT { get; set; }



         public DataTable T_Planing_SitePreparationDT { get; set; }
         public DataTable T_Planing_SitePreparation_UnderDT { get; set; }
         public DataTable T_Planing_SitePreparation_FileDT { get; set; }



         public DataTable T_Planing_WeatherCollectionDT { get; set; }

        public DataTable T_Planing_BFRemovalDT { get; set; }
        public DataTable T_Planing_BFRemoval_ConditionDT { get; set; }
        public DataTable T_Planing_BFRemoval_File1DT { get; set; }
        public DataTable T_Planing_BFRemoval_File2DT { get; set; }





        public DataTable T_Planing_AFRemovalDT { get; set; }
       public DataTable T_Planing_AFRemoval_DefectDT { get; set; }
        public DataTable T_Planing_AFRemoval_WallThicknessDT { get; set; }



        public DataTable T_Planing_AppliedCoatingDT { get; set; }
        public DataTable T_Planing_AppliedCoating_SurfaceProfileDT { get; set; }
        public DataTable T_Planing_AppliedCoating_InformationDT { get; set; }


        public DataTable T_Planing_AfterAppliedCoatingDT { get; set; }
        public DataTable T_Planing_AfterAppliedCoating_DryFilmThicknessDT { get; set; }
        public DataTable T_Planing_AfterAppliedCoating_File1DT { get; set; }
        public DataTable T_Planing_AfterAppliedCoating_File2DT { get; set; }


        public DataTable T_Planing_SiteRecoveryDT { get; set; }
        public DataTable T_Planing_SiteRecovery_File1DT { get; set; }
        public DataTable T_Planing_SiteRecovery_File2DT { get; set; }

    }



}
