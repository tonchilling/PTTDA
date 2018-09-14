using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Plan
{
    public class T_Planing_CoatingRepairDTO : BaseDTO
    {

        public string PID { get; set; }
	 public string  RepairUsing { get; set; }
	 public string  RepairLength { get; set; }
	 public string  KPRepairStart { get; set; }
	 public string  GPS_N { get; set; }
	 public string  GPS_E { get; set; }
	 public string  PH { get; set; } 
	 public string  Bacteria { get; set; }
	 public string  DFT { get; set; } 
	 public string  HolidayTest { get; set; } 
	 public string  HolidayTestValue { get; set; } 
	 public string  File1 { get; set; }
	 public string  File2 { get; set; } 
	 public string  File3 { get; set; }
	 public string  File4 { get; set; }

     public string RowState { get; set; }
    }
}
