using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Master;
using System.Data;
using System.Data.SqlClient;

namespace DAO.PTT.Master
{
    public class M_PipeGradDAO : PTTDB
    {

        List<M_PipeGradDTO> objList = null;
        M_PipeGradDTO obj = null;

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_PipeGrad_Insert", data);
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
            isCan = ExcecuteNoneQuery("sp_M_PipeGrad_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_PipeGrad_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_PipeGrad_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<M_PipeGradDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<M_PipeGradDTO>();
            dataTable = null;

            string procName = "sp_M_PipeGrad_FindByColumn";
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

                        obj = new M_PipeGradDTO();
                        obj.PipeGradID = reader["PipeGradID"].ToString();
                        obj.PipeGradCode = reader["PipeGradCode"].ToString();
                        obj.Name = reader["Name"].ToString();
                        obj.GradNumber = reader["GradNumber"].ToString();
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

    }
}
