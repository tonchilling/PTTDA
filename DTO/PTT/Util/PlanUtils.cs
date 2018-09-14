using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT.Plan;
using System.Globalization;
using System.Threading;

namespace DTO.PTT.Util
{
   public  class PlanUtils
    {


        public static T_PlaningDTO ShipPlan(T_PlaningDTO dto, string cStartDate, string cEndDate, PlanType type)
        {
            // int moveDay = 0;

            int diffPODay = 0;
            int diffActionDay = 0;

            int diffSpecPODay = 0;
            int diffPOActionDay = 0;

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            // spec
            DateTime SpecSTDate = Convert.ToDateTime(MMddYY(dto.SpecSDate));
            DateTime SpecETDate = Convert.ToDateTime(MMddYY(dto.SpecEDate));


            // po
            DateTime POSTDate = Convert.ToDateTime(MMddYY(dto.POSDate));
            DateTime POETDate = Convert.ToDateTime(MMddYY(dto.POEDate));

            diffPODay = (POETDate - POSTDate).Days;


            // action
            DateTime ActionSTDate = Convert.ToDateTime(MMddYY(dto.ActionSDate));
            DateTime ActionETDate = Convert.ToDateTime(MMddYY(dto.ActionEDate));

            diffActionDay = (ActionETDate - ActionSTDate).Days;



            diffSpecPODay = (POSTDate - SpecETDate).Days;

            diffPOActionDay = (ActionSTDate - POETDate).Days; ;




            // Change
            DateTime ChangeSDate = Convert.ToDateTime(MMddYY(cStartDate));
            DateTime ChangeEDate = Convert.ToDateTime(MMddYY(cEndDate));
            //  moveDay = ChangeSDate.Day - SpecSTDate.Day;




           

             if (type == PlanType.Spec)
            {

                POSTDate = ChangeEDate.AddDays(diffSpecPODay); //15

                POETDate = POSTDate.AddDays(diffPODay);

                ActionSTDate = POETDate.AddDays(diffPOActionDay);

                ActionETDate = ActionSTDate.AddDays(diffActionDay);


            }else if (type == PlanType.PO)
            {
            POSTDate = ChangeSDate;
            POETDate = ChangeEDate;

                 ActionSTDate = POETDate.AddDays(diffPOActionDay);

                 ActionETDate = ActionSTDate.AddDays(diffActionDay);
            }
             else if (type == PlanType.Action)
             { 
                 ActionSTDate =ChangeSDate;
                 ActionETDate = ChangeEDate;
             
             }

            /* if (POETDate.Day >= 25 && POETDate.Day <= 31)
             {
                 POETDate = new DateTime(POETDate.Year, POETDate.Month, 1).AddMonths(1).AddDays(-1);

             } else if (POETDate.Day > 14 && POETDate.Day <25)
             {
                 POETDate = new DateTime(POETDate.Year, POETDate.Month, 21);
             }
             else if (POETDate.Day > 14 && POETDate.Day < 21)
             {
                 POETDate = new DateTime(POETDate.Year, POETDate.Month, 14);
             }
             else if (POETDate.Day > 7 && POETDate.Day <= 13)
             {
                 POETDate = new DateTime(POETDate.Year, POETDate.Month, 7);
             }
             else if (POETDate.Day < 7)
             {
                 POETDate = POETDate.AddDays(-POETDate.Day);
             }*/


         

            /*  if (ActionETDate.Day >= 25 && ActionETDate.Day <= 31)
              {
                  ActionETDate = new DateTime(ActionETDate.Year, ActionETDate.Month, 1).AddMonths(1).AddDays(-1);

              }
              else if (ActionETDate.Day > 14 && ActionETDate.Day < 25)
              {
                  ActionETDate = new DateTime(ActionETDate.Year, ActionETDate.Month, 21);
              }
              else if (POETDate.Day > 14 && POETDate.Day < 21)
              {
                  POETDate = new DateTime(POETDate.Year, POETDate.Month, 14);
              }
              else if (ActionETDate.Day > 7 && ActionETDate.Day <= 13)
              {
                  ActionETDate = new DateTime(ActionETDate.Year, ActionETDate.Month, 7);
              }
              else if (ActionETDate.Day < 7)
              {
                  ActionETDate = ActionETDate.AddDays(-ActionETDate.Day);
              }*/


            if (type == PlanType.Spec)
            {
                dto.SpecSDate = string.Format("{0}/{1}/{2}", ChangeSDate.Day.ToString("##00")
                                                      , ChangeSDate.Month.ToString("##00")
                                                      , ChangeSDate.Year.ToString());
                dto.SpecEDate = string.Format("{0}/{1}/{2}", ChangeEDate.Day.ToString("##00")
                                                      , ChangeEDate.Month.ToString("##00")
                                                      , ChangeEDate.Year.ToString());


                dto.POSDate = string.Format("{0}/{1}/{2}", POSTDate.Day.ToString("##00")
                                                    , POSTDate.Month.ToString("##00")
                                                    , POSTDate.Year.ToString());
                dto.POEDate = string.Format("{0}/{1}/{2}", POETDate.Day.ToString("##00")
                                                      , POETDate.Month.ToString("##00")
                                                      , POETDate.Year.ToString());
              


                dto.ActionSDate = string.Format("{0}/{1}/{2}", ActionSTDate.Day.ToString("##00")
                                                     , ActionSTDate.Month.ToString("##00")
                                                     , ActionSTDate.Year.ToString());
                dto.ActionEDate = string.Format("{0}/{1}/{2}", ActionETDate.Day.ToString("##00")
                                                      , ActionETDate.Month.ToString("##00")
                                                      , ActionETDate.Year.ToString());
              


            }
            else if (type == PlanType.PO)
            {
                dto.POSDate = string.Format("{0}/{1}/{2}", ChangeSDate.Day.ToString("##00")
                                                    , ChangeSDate.Month.ToString("##00")
                                                    , ChangeSDate.Year.ToString());
                dto.POEDate = string.Format("{0}/{1}/{2}", ChangeEDate.Day.ToString("##00")
                                                      , ChangeEDate.Month.ToString("##00")
                                                      , ChangeEDate.Year.ToString());


                dto.ActionSDate = string.Format("{0}/{1}/{2}", ActionSTDate.Day.ToString("##00")
                                                      , ActionSTDate.Month.ToString("##00")
                                                      , ActionSTDate.Year.ToString());
                dto.ActionEDate = string.Format("{0}/{1}/{2}", ActionETDate.Day.ToString("##00")
                                                      , ActionETDate.Month.ToString("##00")
                                                      , ActionETDate.Year.ToString());
              
            }
            else if (type == PlanType.Action)
            {
                dto.ActionSDate = string.Format("{0}/{1}/{2}", ChangeSDate.Day.ToString("##00")
                                                   , ChangeSDate.Month.ToString("##00")
                                                   , ChangeSDate.Year.ToString());
                dto.ActionEDate = string.Format("{0}/{1}/{2}", ChangeEDate.Day.ToString("##00")
                                                      , ChangeEDate.Month.ToString("##00")
                                                      , ChangeEDate.Year.ToString());



               
            }

            return dto;
        }

        public static string MMddYY(string DDMMYY)
        {
            string result = "";


            result = string.Format("{0}/{1}/{2}", DDMMYY.Split('/')[1], DDMMYY.Split('/')[0], DDMMYY.Split('/')[2]);
            return result;

        }


    }
}
