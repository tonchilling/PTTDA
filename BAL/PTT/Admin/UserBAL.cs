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
    public class UserBAL : BaseBL
    {
        bool isCan = false;
        UserDAO dao = null;

        public UserBAL()
        {
            dao = new UserDAO();
        }



        public override bool Action()
        {
            dao = new UserDAO();

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



        public bool SetDefaultUerGroup(object dto)
        {
            bool isCan = false;

            try
            {

                isCan = dao.SetDefaultUerGroup(dto);
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
            dao = new UserDAO();
            return dao.FindByAll();
        }

        public  List<UserDTO> FindByObjList(object dto) 
        {
          
            dao = new UserDAO();
            return dao.FindByObjList(dto);
        }

        public UserDTO UserLogin(object dto)
        {

            dao = new UserDAO();
            return dao.UserLogin(dto);
        }


        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}