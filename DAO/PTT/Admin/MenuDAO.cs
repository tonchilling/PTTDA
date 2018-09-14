using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;
namespace DAO.PTT.Admin
{
    public class MenuDAO : PTTDB
    {
        List<MenuDTO> objList = null;
        MenuDTO obj = null;


        public override bool Add(object data)
        {
            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_MENU_Insert", data);
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
                isCan = ExcecuteNoneQuery("sp_M_MENU_Delete", data);
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
            List<MenuGroupDTO> objMGList = new List<MenuGroupDTO>();
            MenuGroupDTO objMG=null;
            string procName = "sp_M_MENUGROUP_FindAll";
            SqlConnection conn = OpenConnection();
            command = new SqlCommand(procName, conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    // objList = DTO.Util.ConvertX.GetListFromDataReader<MenuDTO>(reader) as List<MenuDTO>;
                    while (reader.Read())
                    {

                        objMG = new MenuGroupDTO();
                        objMG.MENU_OID = reader["MENU_OID"].ToString();
                        objMG.OrderNo = reader["OrderNo"].ToString();
                        objMG.Name = reader["Name"].ToString();
                        objMGList.Add(objMG);
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objMGList;
        }
        public List<MenuDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<MenuDTO>();
            dataTable = null;

            string procName = "sp_M_MENU_FindByColumn";
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

                        obj = new MenuDTO();
                        obj.MENU_OID = reader["MENU_OID"].ToString();
                        obj.OrderNo = reader["OrderNo"].ToString();
                        obj.MENUGROUP_OID = reader["MENUGROUP_OID"].ToString();
                        obj.MENUGROUPName = reader["MENUGROUPName"].ToString();
                        obj.Name = reader["Name"].ToString();
                        obj.DESC = reader["DESC"].ToString();
                        obj.SCREEN = reader["SCREEN"].ToString();
                        obj.LINK = reader["LINK"].ToString();
                        obj.Icon = reader["Icon"].ToString();
                        obj.Position = reader["Position"].ToString();
                        obj.PMENU_OID = reader["PMENU_OID"].ToString();
                        obj.CREATE_BY = reader["CREATE_BY"].ToString();
                        obj.CREATE_DATE = reader["CREATE_DATE"].ToString();
                        obj.UPDATE_BY = reader["UPDATE_BY"].ToString();
                        obj.UPDATE_DATE = reader["UPDATE_DATE"].ToString();
                        obj.ROW_STATE = reader["ROW_STATE"].ToString();
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

        public List<MenuDTO> FindByObjLoginList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<MenuDTO>();
            dataTable = null;

            string procName = "sp_M_MENU_FindByLogin";
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

                        obj = new MenuDTO();
                        obj.MENU_OID = reader["MENU_OID"].ToString();
                        obj.OrderNo = reader["OrderNo"].ToString();
                        obj.MENUGROUP_OID = reader["MENUGROUP_OID"].ToString();
                        obj.MENUGROUPName = reader["MENUGROUPName"].ToString();
                        obj.Name = reader["Name"].ToString();
                        obj.DESC = reader["DESC"].ToString();
                        obj.SCREEN = reader["SCREEN"].ToString();
                        obj.LINK = reader["LINK"].ToString();
                        obj.Icon = reader["Icon"].ToString();
                        obj.Position = reader["Position"].ToString();
                        obj.PMENU_OID = reader["PMENU_OID"].ToString();
                        obj.CREATE_BY = reader["CREATE_BY"].ToString();
                        obj.CREATE_DATE = reader["CREATE_DATE"].ToString();
                        obj.UPDATE_BY = reader["UPDATE_BY"].ToString();
                        obj.UPDATE_DATE = reader["UPDATE_DATE"].ToString();
                        obj.ROW_STATE = reader["ROW_STATE"].ToString();
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
