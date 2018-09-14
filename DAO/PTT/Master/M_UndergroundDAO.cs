using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Master;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;

namespace DAO.PTT.Master
{
    public class M_UndergroundDAO : PTTDB
    {

        List<M_UndergroundDTO> objList = null;
        M_UndergroundDTO obj = null;

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Underground_Insert", data);
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
            isCan = ExcecuteNoneQuery("sp_M_Underground_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_Underground_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_Underground_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<M_UndergroundDTO> FindByObjList()
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_UndergroundDTO>();
            dataTable = null;

            string procName = "sp_M_Underground_FindAll";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
       
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
         



                using (SqlDataReader reader = command.ExecuteReader())
                {
                    objList = ConvertX.GetListFromDataReader<M_UndergroundDTO>(reader).ToList();


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
