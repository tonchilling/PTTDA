using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.PTT.Admin;
using DTO.PTT.Admin;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Admin
{
    public class PTTUserInfoBAL : BaseBL
    {
        bool isCan = false;
        PTTUserInfoDAO dao = null;

        public PTTUserInfoBAL()
        {
            dao = new PTTUserInfoDAO();
        }



        public override bool Action()
        {
            dao = new PTTUserInfoDAO();

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
                Log((dto as UserDTO).Page, "Error", ex.ToString());
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
            dao = new PTTUserInfoDAO();
            return dao.FindByAll();
        }

        public  List<PTTUserInfoDTO> FindByObjList(object dto) 
        {

            dao = new PTTUserInfoDAO();
           // return null;
            return dao.FindByObjList(dto);
        }

        

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}