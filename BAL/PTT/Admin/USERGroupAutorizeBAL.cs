﻿using System;
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
    public class USERGroupAutorizeBAL : BaseBL
    {
        bool isCan = false;
        USERGroupAutorizeDAO dao = null;

        public USERGroupAutorizeBAL()
        {
            dao = new USERGroupAutorizeDAO();
        }



        public override bool Action()
        {
            dao = new USERGroupAutorizeDAO();

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
                Log((dto as USERGroupAutorizeDTO).Page, "Error", ex.ToString());
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
            dao = new USERGroupAutorizeDAO();
            return dao.FindByAll();
        }

        public List<USERGroupAutorizeDTO> FindByObjList(object dto) 
        {

            dao = new USERGroupAutorizeDAO();
           // return null;
            return dao.FindByObjList(dto);
        }

      
        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}