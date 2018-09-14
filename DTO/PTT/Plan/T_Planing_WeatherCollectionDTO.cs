using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Plan
{
    public class T_Planing_WeatherCollectionDTO : BaseDTO
    {

       
        public string ID  { get; set; }
         public string PID { get; set; }   
        public string No  { get; set; }   
      public string CollectDate  { get; set; }
      public string CollectHour { get; set; }
      public string CollectMinute { get; set; }   
      public string WetTemp  { get; set; }   
      public string DryTemp  { get; set; }
      public string SteelSurfaceTemp { get; set; }   
      public string DewPoint  { get; set; }
      public string RelativeHumidity { get; set; }   

     
    }

 

}
