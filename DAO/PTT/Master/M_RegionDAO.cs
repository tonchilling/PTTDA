using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT;
using DTO.PTT.Master;
using System.Data;
using System.Data.SqlClient;

namespace DAO.PTT.Master
{
    public class M_RegionDAO : PTTDB
    {

        List<M_RegionDTO> objList = null;
        M_RegionDTO obj = null;

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Region_Insert", data);
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
            isCan = ExcecuteNoneQuery("sp_M_Region_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_Region_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_Region_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<M_RegionDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_RegionDTO>();
            dataTable = null;

            string procName = "sp_M_Region_FindByColumn";
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
                    while (reader.Read())
                    {

                        obj = new M_RegionDTO();
                        obj.RegionID = reader["RegionID"].ToString();
                        obj.RegionCode = reader["RegionCode"].ToString();
                        obj.Name = reader["Name"].ToString();
                        obj.Status = reader["Status"].ToString();
                        obj.CreateDate = reader["CreateDate"].ToString();
                        obj.CreateBy = reader["CreateBy"].ToString();
                        obj.UpdateDate = reader["UpdateDate"].ToString();
                        obj.UpdateBy = reader["UpdateBy"].ToString();
                        objList.Add(obj);
                    }


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }


        public List<Select2DTO> Select2ByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<Select2DTO> select2ObjList = new List<Select2DTO>();
            Select2DTO select2Obj = null;
            dataTable = null;

            string procName = "sp_M_Region_FindByColumn";
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
                    while (reader.Read())
                    {


                        select2Obj = new Select2DTO();
                        select2Obj.id = reader["RegionID"].ToString();
                        select2Obj.text = reader["Name"].ToString();

                        select2ObjList.Add(select2Obj);
                    }


                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return select2ObjList;
        }

    }
}
