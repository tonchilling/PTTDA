using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Plan;
using DTO.PTT.Plan;
using DTO.PTT.Util;
using DTO.Util;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Plan
{
    public class T_Planing_SpecPOBAL : BaseBL
    {
        bool isCan = false;
        T_Planing_SpecPODAO dao = null;

        public T_Planing_SpecPOBAL()
        {
            dao = new T_Planing_SpecPODAO();
        }



        public override bool Action()
        {
            dao = new T_Planing_SpecPODAO();

            return isCan;
        }

        public override bool Add(object dto)
        {
            bool isCan = false;

            try {

                T_Planing_SpecPODTO obj = dto as T_Planing_SpecPODTO;

                if (obj.SpecSDate != null && obj.SpecEDate != null)
                {
                    obj.SpecSDate = ConvertX.MMddYY(obj.SpecSDate);
                    obj.SpecEDate =ConvertX.MMddYY(obj.SpecEDate) ;
                }


                if (obj.POSDate != null && obj.POEDate != null)
                {
                    obj.POSDate = ConvertX.MMddYY(obj.POSDate);
                    obj.POEDate = ConvertX.MMddYY(obj.POEDate) ;
                }


                if (obj.ActionSDate != null && obj.ActionEDate != null)
                {
                    obj.ActionSDate = ConvertX.MMddYY(obj.ActionSDate);
                    obj.ActionEDate =  ConvertX.MMddYY(obj.ActionEDate) ;
                }

                if (obj.EventDate != null && obj.EventDate != null)
                {
                    obj.EventDate = ConvertX.MMddYY(obj.EventDate);
                }

                isCan = dao.Add(obj);
            }
            catch (Exception ex)
            {
                Log((dto as T_Planing_SpecPODTO).Page, "Error", ex.ToString());
            }
            return isCan;
        }

        public override bool Update(object dto)
        {
            return dao.Update(dto);
        }

        public override bool Delete(object dto)
        {
            return dao.Delete(dto);
        }

        public  bool UpdateNewPlan(object dto)
        {
            T_PlaningDAO planDAO = new T_PlaningDAO();
            T_Planing_SpecPODTO planSpecPODTO = new T_Planing_SpecPODTO();
            T_PlaningDTO newPlanDTO = new T_PlaningDTO();
            PlanType type=new PlanType();
            bool isCanupdate = false;
            try
            {
                planSpecPODTO = (T_Planing_SpecPODTO)dto;

            newPlanDTO.PID = planSpecPODTO.PID;
         
            newPlanDTO = planDAO.FindByPK(newPlanDTO);

            if(planSpecPODTO.PlanType=="2")
            {
            type= PlanType.Spec;
            }
            else if (planSpecPODTO.PlanType == "3")
            {
              type= PlanType.PO;
            }
            else if (planSpecPODTO.PlanType == "4")
            {
                type = PlanType.Action;
            }
            newPlanDTO = PlanUtils.ShipPlan(newPlanDTO, planSpecPODTO.StartDate, planSpecPODTO.EndDate, type);

            newPlanDTO.PlanType = planSpecPODTO.PlanType;
            newPlanDTO.EditNote = planSpecPODTO.EditNote;
            newPlanDTO.UpdateBy = planSpecPODTO.UpdateBy;
                isCanupdate= dao.UpdateNewPlan(newPlanDTO);
            }
            catch (Exception ex)
            {
                Log((dto as T_Planing_SpecPODTO).Page, "Error", ex.ToString());
            }
            return isCanupdate;
        }


        public override System.Data.DataTable FindByAll()
        {
            
            return dao.FindByAll();
        }

        public T_Planing_SpecPODTO FindByObjHistory(object dto)
        {


            // return null;
            return dao.FindByObjHistory(dto);
        }



        public T_Planing_SpecPODTO FindByCurrentStatus(object dto)
        {


            // return null;
            return dao.FindByCurrentStatus(dto);
        }


        public  List<T_Planing_SpecPODTO> FindByObjList(object dto) 
        {

           
           // return null;
            return dao.FindByObjList(dto);
        }

     

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}