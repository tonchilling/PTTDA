﻿using System;
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
    public class T_Planing_WeatherCollectionBAL : BaseBL
    {
        bool isCan = false;
        T_Planing_WeatherCollectionDAO dao = null;

        public T_Planing_WeatherCollectionBAL()
        {
            dao = new T_Planing_WeatherCollectionDAO();
        }



        public override bool Action()
        {
            dao = new T_Planing_WeatherCollectionDAO();

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
                Log((dto as T_Planing_WeatherCollectionDTO).Page, "Error", ex.ToString());
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


        public T_Planing_WeatherCollectionDTO FindByPK(object dto)
        {


            // return null;
            return dao.FindByPK(dto);


        }


        public  List<T_Planing_WeatherCollectionDTO> FindByObjList(object dto) 
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