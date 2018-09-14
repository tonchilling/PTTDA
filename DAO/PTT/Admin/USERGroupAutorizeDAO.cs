using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;
namespace DAO.PTT.Admin
{
    public class USERGroupAutorizeDAO : PTTDB
    {
        List<USERGroupAutorizeDTO> objList = null;
        USERGroupAutorizeDTO obj = null;


        public override bool Add(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_UserGroup_Autorize_Insert", data);
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
                    USERGroupAutorizeDTO objJson = (USERGroupAutorizeDTO)obj;
                    objJson.VIEW = Convert.ToBoolean(objJson.VIEW) == true ? "1" : "0";
                    objJson.EDIT = Convert.ToBoolean(objJson.EDIT) == true ? "1" : "0";
                    objJson.DELETE = Convert.ToBoolean(objJson.DELETE) == true ? "1" : "0";
                    objJson.Row_State = Convert.ToBoolean(objJson.Row_State) == true ? "1" : "0";
                    
                    isCan = ExcecuteNoneQuery("sp_M_UserGroup_Autorize_Insert", objJson);
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
                isCan = ExcecuteNoneQuery("sp_M_UserGroup_Autorize_Delete", data);
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
        public List<USERGroupAutorizeDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<USERGroupAutorizeDTO>();
            dataTable = null;

            string procName = "sp_M_UserGroup_Autorize_FindByColumn";
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

                        obj = new USERGroupAutorizeDTO();
                        obj.USERGROUP_Autorize_OID = reader["UserGroup_Autorize_OID"].ToString();
                        obj.USERGROUPID = reader["USERGroupID"].ToString();
                        obj.MENU_OID = reader["MENU_OID"].ToString();
                        obj.MENUName = reader["MENUName"].ToString();
                        obj.Icon = reader["Icon"].ToString();
                        obj.MENUGROUP_OID = reader["MENUGroup_OID"].ToString();
                        obj.MENUGROUPName = reader["MENUGroupName"].ToString();
                        
      obj.VIEW = reader["VIEW"].ToString();
      obj.EDIT = reader["EDIT"].ToString();
      obj.DELETE = reader["DELETE"].ToString();
      obj.APPROVE = reader["APPROVE"].ToString();
      obj.Row_State = reader["ROW_STATE"].ToString();
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
