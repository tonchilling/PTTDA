using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Plan;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;


namespace DAO.PTT.Plan
{
    public class T_Planing_WeatherCollectionDAO : PTTDB
    {

        List<T_Planing_WeatherCollectionDTO> objList = null;
        T_Planing_WeatherCollectionDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_WeatherCollection_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
          
            isCan = true;
            try
            {

                obj = (T_Planing_WeatherCollectionDTO)data;
                obj.CollectDate = ConvertX.MMddYY(obj.CollectDate);
                command = new SqlCommand(procName, conn);

                command.CommandType = CommandType.StoredProcedure;



                if (obj != null)
                {

                    parameterList.AddRange(GetParameters(procName, obj).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

             

              


            }
            catch (Exception ex)
            {
                isCan = false;
               
                throw new Exception(ex.Message);

            }
            finally
            {
                CloseConnection();

            }
            return isCan;
        }

        public override bool Update(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_WeatherCollection_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("[sp_T_Planing_Action_WeatherCollection_Delete]", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_WeatherCollection_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_WeatherCollectionDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_WeatherCollectionDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_WeatherCollection_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_WeatherCollectionDTO>(reader).ToList().FirstOrDefault();
                 
                


                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_WeatherCollectionDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_WeatherCollectionDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_WeatherCollection_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_WeatherCollectionDTO>(reader).ToList();

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
