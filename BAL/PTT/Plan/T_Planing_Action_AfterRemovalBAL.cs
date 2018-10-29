using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Plan;
using DTO.PTT.Plan;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Plan
{
    public class T_Planing_Action_AfterRemovalBAL : BaseBL
    {
        bool isCan = false;
        T_Planing_Action_AfterRemovalDAO dao = null;

        public T_Planing_Action_AfterRemovalBAL()
        {
            dao = new T_Planing_Action_AfterRemovalDAO();
        }



        public override bool Action()
        {
            dao = new T_Planing_Action_AfterRemovalDAO();

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
                Log((dto as T_Planing_Action_AfterRemovalDTO).Page, "Error", ex.ToString());
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


        public T_Planing_Action_AfterRemovalDTO FindByPK(object dto)
        {


            // return null;
            return dao.FindByPK(dto);


        }


        public  List<T_Planing_Action_AfterRemovalDTO> FindByObjList(object dto) 
        {

           
           // return null;
            return dao.FindByObjList(dto);
        }

        public List<T_Planing_File> FindAllFiles(object dto)
        {
            return dao.FindAllFiles(dto);
        }

        public List<T_Planing_Action_AfterRemoval_DefectDTO> FindAllDefects(object dto)
        {
            return dao.FindAllDefects(dto);
        }

        public List<T_Planing_Action_AfterRemoval_WallThicknessDTO> FindAllWallThickness(object dto)
        {
            return dao.FindAllWallThickness(dto);
        }


        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}