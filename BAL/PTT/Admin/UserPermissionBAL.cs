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
    public class UserPermissionBAL : BaseBL
    {
        bool isCan = false;
        UserPermissionDAO dao = null;

        public UserPermissionBAL()
        {
            dao = new UserPermissionDAO();
        }



        public override bool Action()
        {
            dao = new UserPermissionDAO();

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

        public  bool Add(object[] dtoList)
        {
            bool isCan = false;

            try
            {

                isCan = dao.Add(dtoList);
            }
            catch (Exception ex)
            {
               // Log((dto as UserDTO).Page, "Error", ex.ToString());
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
            dao = new UserPermissionDAO();
            return dao.FindByAll();
        }

        public List<UserPermissionDTO> FindByObjList(object dto) 
        {

            dao = new UserPermissionDAO();
           // return null;
            return dao.FindByObjList(dto);
        }

      
        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}