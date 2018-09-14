using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Master;
using DTO.PTT.Master;


/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Master
{
    public class M_TypeOfRouteCodeBAL : BaseBL
    {
        bool isCan = false;
        M_TypeOfRouteCodeDAO dao = null;

        public M_TypeOfRouteCodeBAL()
        {
            dao = new M_TypeOfRouteCodeDAO();
        }



        public override bool Action()
        {
            dao = new M_TypeOfRouteCodeDAO();

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
                Log((dto as M_TypeOfRouteCodeDTO).Page, "Error", ex.ToString());
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

        public  List<M_TypeOfRouteCodeDTO> FindByObjList(object dto) 
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