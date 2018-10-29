using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Plan;
using DTO.PTT.Plan;
using DTO.PTT.Master;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Plan
{
    public class T_Planing_Action_SitePreparationBAL : BaseBL
    {
        bool isCan = false;
        T_Planing_Action_SitePreparationDAO dao = null;

        public T_Planing_Action_SitePreparationBAL()
        {
            dao = new T_Planing_Action_SitePreparationDAO();
        }



        public override bool Action()
        {
            dao = new T_Planing_Action_SitePreparationDAO();

            return isCan;
        }

        public override bool Add(object dto)
        {
            bool isCan = false;

            try {

                isCan = dao.Add(dto);
            }
            catch (Exception ex)
            {
                Log((dto as T_Planing_Action_SitePreparationDTO).Page, "Error", ex.ToString());
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

        public override System.Data.DataTable FindByAll()
        {
            
            return dao.FindByAll();
        }


        public T_Planing_Action_SitePreparationDTO FindByPK(object dto)
        {


            // return null;
            return dao.FindByPK(dto);


        }


        public  List<T_Planing_Action_SitePreparationDTO> FindByObjList(object dto) 
        {

           
           // return null;
            return dao.FindByObjList(dto);
        }


        public List<T_Planing_File> FindAllFiles(object dto)
        {
            return dao.FindAllFiles(dto);
        }

        public List<M_UndergroundDTO> FindAllUndergrounds(object dto)
        {
            return dao.FindAllUndergrounds(dto);
        }

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}