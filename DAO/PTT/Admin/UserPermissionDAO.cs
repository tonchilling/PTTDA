using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;
namespace DAO.PTT.Admin
{
    public class UserPermissionDAO : PTTDB
    {
        List<UserPermissionDTO> objList = null;
        UserPermissionDTO obj = null;


        public override bool Add(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_MENU_PERMISSION_Insert", data);
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
                    UserPermissionJson objJson = (UserPermissionJson)obj;
                    objJson.View = Convert.ToBoolean(objJson.View) == true ? "1" : "0";
                    objJson.Edit = Convert.ToBoolean(objJson.Edit) == true ? "1" : "0";
                    objJson.Delete = Convert.ToBoolean(objJson.Delete) == true ? "1" : "0";
                    objJson.ROW_STATE = Convert.ToBoolean(objJson.ROW_STATE) == true ? "1" : "0";
                    isCan = ExcecuteNoneQuery("sp_M_USER_PERMISSION_Insert", objJson);
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
                isCan = ExcecuteNoneQuery("sp_M_MENU_PERMISSION_Delete", data);
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
        public List<UserPermissionDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<UserPermissionDTO>();
            dataTable = null;

            string procName = "sp_M_USER_PERMISSION_FindByColumn";
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

                        obj = new UserPermissionDTO();
                        obj.USER_PERMISSION_OID = reader["USER_PERMISSION_OID"].ToString();
                        obj.MENU_OID = reader["MENU_OID"].ToString();
                        obj.UserID= reader["UserID"].ToString();
      obj.UserLogin= reader["UserLogin"].ToString();
      obj.Password = reader["Password"].ToString();
      obj.Title = reader["Title"].ToString();
      obj.NickName = reader["NickName"].ToString();
      obj.FirstName = reader["FirstName"].ToString();
      obj.LastName = reader["LastName"].ToString();
      obj.UserType = reader["UserType"].ToString();
      obj.UserTypeName = reader["UserTypeName"].ToString();
      obj.UserRegion = reader["UserRegion"].ToString();
      obj.UserPlan = reader["UserPlan"].ToString();
      obj.Department = reader["Department"].ToString();
      obj.Position = reader["Position"].ToString();
      obj.Company = reader["Company"].ToString();
      obj.PositionPSI = reader["PositionPSI"].ToString();
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
