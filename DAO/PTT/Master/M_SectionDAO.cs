﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Master;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;
namespace DAO.PTT.Master
{
    public class M_SectionDAO : PTTDB
    {

        List<M_SectionDTO> objList = null;
        M_SectionDTO obj = null;

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Section_Insert", data);
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {

            }
            return isCan;
        }

        public override bool Update(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_Section_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_Section_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_Section_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }


        public M_SectionDTO FindByRouteCode(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_SectionDTO>();
            dataTable = null;

            string procName = "sp_M_Section_FindByRouteCode";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    obj = ConvertX.GetListFromDataReader<M_SectionDTO>(reader).ToList().FirstOrDefault();


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<M_SectionDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_SectionDTO>();
            dataTable = null;

            string procName = "sp_M_Section_FindByColumn";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, data).ToArray());
                }
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (data != null)
                {



                    command.Parameters.AddRange(parameterList.ToArray());
                }



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    objList = ConvertX.GetListFromDataReader<M_SectionDTO>(reader).ToList();


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

    }
}