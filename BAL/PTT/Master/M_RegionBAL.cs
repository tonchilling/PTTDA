﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT;
using DAO.PTT.Master;
using DTO.PTT.Master;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
namespace BAL.PTT.Master
{
    public class M_RegionBAL : BaseBL
    {
        bool isCan = false;
        M_RegionDAO dao = null;

        public M_RegionBAL()
        {
            dao = new M_RegionDAO();
        }



        public override bool Action()
        {
            dao = new M_RegionDAO();

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
                Log((dto as M_RegionDTO).Page, "Error", ex.ToString());
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

        public  List<M_RegionDTO> FindByObjList(object dto) 
        {

           
           // return null;
            return dao.FindByObjList(dto);
        }


        public List<Select2DTO> Select2ByObjList(object dto)
        {


            // return null;
            return dao.Select2ByObjList(dto);
        }

     

        public override System.Data.DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}