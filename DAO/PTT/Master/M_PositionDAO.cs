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
    public class M_PositionDAO : PTTDB
    {

        List<M_PositionDTO> objList = null;
        M_PositionDTO obj = null;

        public override bool Add(object data)
        {


            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Position_Insert", data);
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
            return false;
        }

        public override bool Delete(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Position_Delete", data);
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

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_Position_FindByAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<M_PositionDTO> FindByObjList(object data)
        {

           

            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_PositionDTO>();
            dataTable = null;

            string procName = "sp_M_Position_FindByAll";
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
                    objList = ConvertX.ConvertDataReaderToObjectList<M_PositionDTO>(reader);


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
