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
    public class PTTUserInfoDAO : PTTDB
    {

        List<PTTUserInfoDTO> objList = null;
        PTTUserInfoDTO obj = null;
        public PTTUserInfoDAO()
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
                isCan = ExcecuteNoneQuery("sp_PTT_PersonalInfo_Insert", data);
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


 

        public override bool Update(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_PTT_PersonalInfo_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_PTT_PersonalInfo_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_PTT_PersonalInfo_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public List<PTTUserInfoDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<PTTUserInfoDTO>();
            dataTable = null;
            
            string procName = "sp_PTT_PersonalInfo_FindByColumn";
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
                    objList = ConvertX.GetListFromDataReader<PTTUserInfoDTO>(reader).ToList();

                   
                }


            }
            catch (Exception ex) { }
            finally {
                CloseConnection();
            }
            return objList;
        }

     

     
    }
}