using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Admin;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;
namespace DAO.PTT.Admin
{
    /// <summary>
    /// Summary description for CustomerDAO
    /// </summary>
    public class UserDAO : PTTDB
    {

        List<UserDTO> objList = null;
        UserDTO obj = null;
        public UserDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override bool Add(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_Account_Insert", data);
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally { 
            
            }
            return isCan;
        }


        public bool SetDefaultUerGroup(object data)
        {

            try
            {

                OpenConnection();
                isCan = ExcecuteNoneQuery("sp_M_USERRole_Autorize_SetByUserGroup", data);
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
            isCan = ExcecuteNoneQuery("sp_Account_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_M_Account_Delete", data);
            
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_Account_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<UserDTO>();
            dataTable = null;
            
            string procName = "sp_M_Account_FindByColumn";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
              SqlConnection conn =  OpenConnection();
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

                    objList = ConvertX.GetListFromDataReader<UserDTO>(reader).ToList();

                 /*   while (reader.Read())
                    {
                       
                        obj=new UserDTO();
                       obj.UserID= reader["UserID"].ToString();
                       obj.UserLogin = reader["UserLogin"].ToString();
                       obj.Password = reader["Password"].ToString();
                       obj.Company = reader["Company"].ToString();
                       obj.Title = reader["Title"].ToString();
                       obj.NickName = reader["NickName"].ToString();
                       obj.FirstName = reader["FirstName"].ToString();
                       obj.LastName = reader["LastName"].ToString();
                       obj.UserType = reader["UserType"].ToString();
                       obj.UserTypeName = reader["UserTypeName"].ToString(); 
                       obj.UserRegion = reader["UserRegion"].ToString();
                       obj.AssertOwner = reader["AssertOwner"].ToString();
                       obj.UserPlan = reader["UserPlan"].ToString();
                       obj.Department = reader["Department"].ToString();
                       obj.DepartmentName = reader["DepartmentName"].ToString();
                       obj.Position = reader["Position"].ToString();
                       obj.PositionName = reader["PositionName"].ToString();
                       obj.PositionPSI = reader["PositionPSI"].ToString();
                       obj.PositionPSIName = reader["PositionPSIName"].ToString();
                       obj.Email = reader["Email"].ToString();
                       obj.Tel = reader["Tel"].ToString();
                       obj.Ext = reader["Ext"].ToString();
                       obj.Status = reader["Status"].ToString();
                       obj.CreateDate = reader["CreateDate"].ToString();
                       obj.CreateBy = reader["CreateBy"].ToString();
                       obj.UpdateDate = reader["UpdateDate"].ToString();
                       obj.UpdateBy = reader["UpdateBy"].ToString();
                       obj.USERRoleID = reader["USERRoleID"].ToString();
                       obj.USERRoleName = reader["USERRoleName"].ToString();
                       obj.UserGroupID = reader["USERGroupID"].ToString();
                       obj.UserGroupName = reader["UserGroupName"].ToString();
                        obj.CreatePlan = reader["CreatePlan"].ToString();
                         obj.EditPlanDate = reader["EditPlanDate"].ToString();
                          obj.ExportPlan = reader["ExportPlan"].ToString();
                           obj.ConfirmPlan = reader["ConfirmPlan"].ToString();
                          obj.ApprovePlan = reader["ApprovePlan"].ToString();
                          obj.EditTimeline = reader["EditTimeline"].ToString();
                       objList.Add(obj);
                    }*/

                   
                }


            }
            catch (Exception ex) { }
            finally {
                CloseConnection();
            }
            return objList;
        }

         public UserDTO UserLogin(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
         
            dataTable = null;

            string procName = "sp_UserLOGIN";
            try
            {
                dataTable = new DataTable();
                adapter = new SqlDataAdapter();
              SqlConnection conn =  OpenConnection();
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
                    obj = ConvertX.GetListFromDataReader<UserDTO>(reader).FirstOrDefault();
                   // if (reader.Read())
                  //  {

                       // obj = ConvertX.GetListFromDataReader<UserDTO>(reader).FirstOrDefault();
                    /*    obj=new UserDTO();
                       obj.UserID= reader["UserID"].ToString();
                       obj.UserLogin = reader["UserLogin"].ToString();
                       obj.Password = reader["Password"].ToString();
                       obj.Company = reader["Company"].ToString();
                       obj.Title = reader["Title"].ToString();
                       obj.NickName = reader["NickName"].ToString();
                       obj.FirstName = reader["FirstName"].ToString();
                       obj.LastName = reader["LastName"].ToString();
                       obj.UserType = reader["UserType"].ToString();
                       obj.UserTypeName = reader["UserTypeName"].ToString(); 
                       obj.UserRegion = reader["UserRegion"].ToString();
                       obj.AssertOwner = reader["AssertOwner"].ToString();
                       obj.UserPlan = reader["UserPlan"].ToString();
                       obj.Department = reader["Department"].ToString();
                       obj.DepartmentName = reader["DepartmentName"].ToString();
                       obj.Position = reader["Position"].ToString();
                       obj.PositionName = reader["PositionName"].ToString();
                       obj.PositionPSI = reader["PositionPSI"].ToString();
                       obj.PositionPSIName = reader["PositionPSIName"].ToString();
                       obj.Email = reader["Email"].ToString();
                       obj.Tel = reader["Tel"].ToString();
                       obj.Ext = reader["Ext"].ToString();
                       obj.Status = reader["Status"].ToString();
                       obj.CreateDate = reader["CreateDate"].ToString();
                       obj.CreateBy = reader["CreateBy"].ToString();
                       obj.UpdateDate = reader["UpdateDate"].ToString();
                       obj.UpdateBy = reader["UpdateBy"].ToString();
                       obj.USERRoleID = reader["USERRoleID"].ToString();
                       obj.USERRoleName = reader["USERRoleName"].ToString();
                       obj.UserGroupID = reader["USERGroupID"].ToString();
                       obj.UserGroupName = reader["UserGroupName"].ToString();
                       obj.CreatePlan = reader["CreatePlan"].ToString();
                       obj.EditTimeline = reader["EditTimeline"].ToString();
                       obj.ApprovePlan = reader["ApprovePlan"].ToString();
                       obj.ConfirmPlan = reader["ConfirmPlan"].ToString();
                       obj.ExportPlan = reader["ExportPlan"].ToString();
                       obj.EditPlanDate = reader["EditPlanDate"].ToString();*/
                        
                      
                 //   }

                   
                }


            }
            catch (Exception ex) { }
            finally {
                CloseConnection();
            }
            return obj;
        }

     
    }
}