using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;

namespace DAO.PTT.Admin
{
    public class UserRoleDAO : PTTDB
    {

        List<UserRoleDTO> objList = null;
        UserRoleDTO obj = null;

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();

                isCan = ExcecuteNoneQuery("sp_M_USERRole_Insert", data);
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
            isCan = ExcecuteNoneQuery("sp_M_USERRole_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_USERRole_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_M_USERRole_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<UserRoleDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<UserRoleDTO>();
            dataTable = null;

            string procName = "sp_M_USERRole_FindByColumn";
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

                        obj = new UserRoleDTO();
                        obj.USERRoleID = reader["USERRoleID"].ToString();
                        obj.Desc = reader["Desc"].ToString();
                        obj.Name = reader["Name"].ToString();
                        obj.Status = reader["Status"].ToString();
                        obj.Create_Date = reader["Create_Date"].ToString();
                        obj.Create_By = reader["Create_By"].ToString();
                        obj.Update_Date = reader["Update_Date"].ToString();
                        obj.Update_By = reader["Update_By"].ToString();
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
