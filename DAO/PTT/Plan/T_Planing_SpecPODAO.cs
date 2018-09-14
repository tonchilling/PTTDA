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
    public class T_Planing_SpecPODAO : PTTDB
    {

        List<T_Planing_SpecPODTO> objList = null;
        T_Planing_SpecPODTO obj = null;

        public override bool Add(object data)
        {

            try
            {
                obj = (T_Planing_SpecPODTO)data;
                OpenConnection();

               /* if (obj.SpecSDate != null && obj.SpecEDate != null)
                {
                    obj.SpecSDate = ConvertX.MMddYY(obj.SpecSDate);
                    obj.SpecEDate = ConvertX.MMddYY(obj.SpecEDate);
                }


                if (obj.POSDate != null && obj.POEDate != null)
                {
                    obj.POSDate = ConvertX.MMddYY(obj.POSDate);
                    obj.POEDate = ConvertX.MMddYY(obj.POEDate);
                }


                if (obj.ActionSDate != null && obj.ActionEDate != null)
                {
                    obj.ActionSDate = ConvertX.MMddYY(obj.ActionSDate);
                    obj.ActionEDate = ConvertX.MMddYY(obj.ActionEDate);
                }*/

               /* if (obj.EventDate != null && obj.EventDate != null)
                {
                    obj.EventDate = ConvertX.MMddYY(obj.EventDate);
                }*/

                isCan = ExcecuteNoneQuery("sp_T_Planing_SpecPO_Insert", obj);
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
            isCan = ExcecuteNoneQuery("sp_T_Planing_SpecPO_Update", data);
            CloseConnection();
            return isCan;
        }

        public  bool UpdateNewPlan(object obj)
        {
            OpenConnection();

            ((T_PlaningDTO)obj).SpecSDate = ConvertX.MMddYY(((T_PlaningDTO)obj).SpecSDate);
            ((T_PlaningDTO)obj).SpecEDate = ConvertX.MMddYY(((T_PlaningDTO)obj).SpecEDate);

            ((T_PlaningDTO)obj).POSDate = ConvertX.MMddYY(((T_PlaningDTO)obj).POSDate);
            ((T_PlaningDTO)obj).POEDate = ConvertX.MMddYY(((T_PlaningDTO)obj).POEDate);


            ((T_PlaningDTO)obj).ActionSDate = ConvertX.MMddYY(((T_PlaningDTO)obj).ActionSDate);
            ((T_PlaningDTO)obj).ActionEDate = ConvertX.MMddYY(((T_PlaningDTO)obj).ActionEDate);


            isCan = ExcecuteNoneQuery("sp_T_Planing_UpdateNewPlan", obj);
            CloseConnection();
            return isCan;
        }



        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_SpecPO_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_SpecPO_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }


        public T_Planing_SpecPODTO FindByCurrentStatus(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            obj = new T_Planing_SpecPODTO();
            dataTable = null;

            string procName = "sp_T_Planing_SpecPO_GetStatus";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_SpecPODTO>(reader).ToList()[0];
                   // obj.SpecSDate = ConvertX.DDMMYY(obj.SpecSDate);
                  //  obj.SpecEDate = ConvertX.DDMMYY(obj.SpecEDate);

                    //obj.POSDate = ConvertX.DDMMYY(obj.POSDate);
                  //  obj.POEDate = ConvertX.DDMMYY(obj.POEDate);


                  //  obj.ActionSDate = ConvertX.DDMMYY(obj.ActionSDate);
                   // obj.ActionEDate = ConvertX.DDMMYY(obj.ActionEDate);

                 

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }

       
        public T_Planing_SpecPODTO FindByObjHistory(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            obj = new T_Planing_SpecPODTO();
            dataTable = null;

            string procName = "sp_T_Planing_SpecPO_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_SpecPODTO>(reader).ToList()[0];
                    obj.SpecSDate = ConvertX.DDMMYY(obj.SpecSDate);
                    obj.SpecEDate = ConvertX.DDMMYY(obj.SpecEDate);
                    obj.ActualSpecEDate = ConvertX.DDMMYY(obj.ActualSpecEDate);

                    obj.POSDate = ConvertX.DDMMYY(obj.POSDate);
                    obj.POEDate = ConvertX.DDMMYY(obj.POEDate);
                    obj.ActualPOEDate = ConvertX.DDMMYY(obj.ActualPOEDate);

                    obj.ActionSDate = ConvertX.DDMMYY(obj.ActionSDate);
                    obj.ActionEDate = ConvertX.DDMMYY(obj.ActionEDate);
                    obj.ActualActionEDate = ConvertX.DDMMYY(obj.ActualActionEDate);

                    reader.NextResult();
                    obj.History = ConvertX.GetListFromDataReader<T_Planing_SpecPO_HistoryDTO>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_SpecPODTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_SpecPODTO>();
            dataTable = null;

            string procName = "sp_T_Planing_SpecPO_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_SpecPODTO>(reader).ToList();

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
