using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;
namespace DAO.PTT.Admin
{
    public class USERRoleAutorizeDAO : PTTDB
    {
        List<USERRoleAutorizeDTO> objList = null;
        USERRoleAutorizeDTO obj = null;


        public override bool Add(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_USERRole_Autorize_Insert", data);
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

        public  bool Add(object[] dataArray)
        {
            try
            {

                OpenConnection();

                foreach(object obj in dataArray)
                {
                    USERRoleAutorizeDTO objJson = (USERRoleAutorizeDTO)obj;
                    objJson.VIEW = Convert.ToBoolean(objJson.VIEW) == true ? "1" : "0";
                    objJson.EDIT = Convert.ToBoolean(objJson.EDIT) == true ? "1" : "0";
                    objJson.DELETE = Convert.ToBoolean(objJson.DELETE) == true ? "1" : "0";
                    objJson.ROW_STATE = Convert.ToBoolean(objJson.ROW_STATE) == true ? "1" : "0";
                    
                    isCan = ExcecuteNoneQuery("sp_M_USERRole_Autorize_Insert", objJson);
                }
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
            throw new NotImplementedException();
        }

        public override bool Delete(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_USERRole_Autorize_Delete", data);
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

        public override DataTable FindByAll()
        {
            throw new NotImplementedException();
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<MenuGroupDTO> FindMenuGroupAll(object data)
        {
            throw new NotImplementedException();
        }
        public List<USERRoleAutorizeDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<USERRoleAutorizeDTO>();
            dataTable = null;

            string procName = "sp_M_USERRole_Autorize_FindByColumn";
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

                   // objList = DTO.Util.ConvertX.GetListFromDataReader<MenuDTO>(reader) as List<MenuDTO>;
                    while (reader.Read())
                    {

                        obj = new USERRoleAutorizeDTO();
                        obj.USERRole_Autorize_OID = reader["USERRole_Autorize_OID"].ToString();
                        obj.MENU_OID = reader["MENU_OID"].ToString();
                        obj.USERRoleID = reader["USERRoleID"].ToString();
                        obj.USERRoleName = reader["USERRoleName"].ToString();
      obj.VIEW = reader["VIEW"].ToString();
      obj.EDIT = reader["EDIT"].ToString();
      obj.DELETE = reader["DELETE"].ToString();
      obj.APPROVE = reader["APPROVE"].ToString();
      obj.ROW_STATE = reader["ROW_STATE"].ToString();
      obj.Screen = reader["Screen"].ToString();
                        objList.Add(obj);
                       // ReadSingleRow((IDataRecord)reader);

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
