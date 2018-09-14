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
    public class MenuBAL : BaseBL
    {
        bool isCan = false;
        MenuDAO dao = null;

        public MenuBAL()
        {
            dao = new MenuDAO();
        }



        public override bool Action()
        {
            dao = new MenuDAO();

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
            dao = new MenuDAO();
            return dao.FindByAll();
        }

        public  List<MenuDTO> FindByObjList(object dto) 
        {

            dao = new MenuDAO();
           // return null;
            return dao.FindByObjList(dto);
        }

        public List<MenuDTO> FindByObjLoginList(object dto)
        {

            dao = new MenuDAO();
            // return null;
            return dao.FindByObjLoginList(dto);

        }

        public List<MenuGroupDTO> FindMenuGroupAll(object dto)
        {

            dao = new MenuDAO();
            // return null;
            return dao.FindMenuGroupAll(dto);
        }

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}