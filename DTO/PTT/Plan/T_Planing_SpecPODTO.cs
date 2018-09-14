using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Plan
{
    public class T_Planing_SpecPODTO : BaseDTO
    {

        public string Type { get; set; }
        public string ID  { get; set; }
       public string PID { get; set; }
       public string No  { get; set; }
       public string PlanType { get; set; }
       public string Complete { get; set; }
       public string Note { get; set; }
       public string StartDate { get; set; }
       public string EndDate { get; set; }

       public string POComplete { get; set; }
       public string POSDate { get; set; }
       public string POEDate { get; set; }
        public string ActualPOEDate { get; set; }
        public string SpecComplete { get; set; }
       public string SpecSDate { get; set; }
       public string SpecEDate { get; set; }
        public string ActualSpecEDate { get; set; }
        public string ActionComplete { get; set; }
       public string ActionSDate { get; set; }
       public string ActionEDate { get; set; }
        public string ActualActionEDate { get; set; }
        public string Contract { get; set; }
       public string EditNote { get; set; }
       public string ProgressPlan { get; set; }
       public string EventDate { get; set; }
       public string PONumber { get; set; }
       public string TabNo { get; set; }
        public List<T_Planing_SpecPO_HistoryDTO> History { get; set; }
    }

    public class T_Planing_SpecPO_HistoryDTO : BaseDTO
    {

        public string Type { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public string No { get; set; }
        public string PlanType { get; set; }
        public string Complete { get; set; }
        public string Note { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string POSDate { get; set; }
        public string POEDate { get; set; }
        public string SpecSDate { get; set; }
        public string SpecEDate { get; set; }
        public string ActionSDate { get; set; }
        public string ActionEDate { get; set; }
        public string Contract { get; set; }
        public string RowRow_State { get; set; }

    }

}
