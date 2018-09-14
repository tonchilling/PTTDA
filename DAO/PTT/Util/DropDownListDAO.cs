using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Util;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;
using DTO.PTT;
namespace DAO.PTT.Util
{
    public class DropDownListDAO : PTTDB
    {

        List<DropDownListDTO> objList = null;
        DropDownListDTO obj = null;

        public override bool Add(object data)
        {

            return true;
        }

        public override bool Update(object data)
        {
            return true;
        }

        public override bool Delete(object data)
        {
            return true;
        }

        public override System.Data.DataTable FindByAll()
        {
            return null;
        }
        

        public List<DropDownListDTO> FindByObjList(DropDownlistType type )
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            switch (type)
            {
                case DropDownlistType.DIGFrom :
                    procName="sp_M_DIGFrom_DropDownList";break;
                case DropDownlistType.ClockPosition: procName = "sp_M_ClockPosition_DropDownList"; break;
                case DropDownlistType.HolidayTest: procName = "sp_M_HolidayTest_DropDownList"; break;
                case DropDownlistType.PipeLine: procName = "sp_M_PipelineLength_DropDownList"; break;
                case DropDownlistType.Region: procName = "sp_M_Region_DropDownList"; break;
                case DropDownlistType.RouteCode: procName = "sp_M_RouteCode_DropDownList"; break;
                case DropDownlistType.AssertOwner: procName = "sp_M_AssertOwner_DropDownList"; break;
                case DropDownlistType.Holiday: procName = "sp_M_Holiday_DropDownList"; break;
            }
          
            try
            {
              
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }



        public List<DropDownListDTO> FindByObjList(string tableName)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_{0}_DropDownList", tableName); 

            try
            {

                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

        public List<DropDownListDTO> FindByObjList(string tableName,string userID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_{0}_DropDownList", tableName);

            try
            {

                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                if (userID != null)
                {

                    parameterList.AddRange(GetParameters(procName, new DropDownListDTO(userID)).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                }
           
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }


        public List<DropDownListDTO> RegionByObjList(string createBy,string PipelineID, string AssetOwnerID, string RouteID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_M_Region_FindBy_DropDownList");

            try
            {

                parameterList.Add(new SqlParameter("@PipelineID", PipelineID));
                parameterList.Add(new SqlParameter("@AssetOwnerID", AssetOwnerID));
                parameterList.Add(new SqlParameter("@RouteID", RouteID));
                parameterList.Add(new SqlParameter("@CreateBy", createBy));
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }




        public List<DropDownListDTO> TypeOfPipelineByObjList(string createBy, string RegionID, string AssetOwnerID, string RouteID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_M_TypeOfPipeline_FindByRegion_DropDownList");

            try
            {

                parameterList.Add(new SqlParameter("@RegionID", RegionID));
                parameterList.Add(new SqlParameter("@AssetOwnerID", AssetOwnerID));
                parameterList.Add(new SqlParameter("@RouteID", RouteID));
                parameterList.Add(new SqlParameter("@CreateBy", createBy));
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }


        public List<DropDownListDTO> AssetOwnerByObjList(string PipelineID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_M_AssertOwner_FindByPipeline_DropDownList");

            try
            {

                parameterList.Add(new SqlParameter("@TypeOfPipelineID", PipelineID));
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }



        public List<DropDownListDTO> AssetOwnerByRouteCodeObjList(string createBy, string RegionID, string PipelineID, string RouteID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_M_AssertOwner_FindByRouteCode_DropDownList");

            try
            {
                parameterList.Add(new SqlParameter("@RegionID", RegionID));
                parameterList.Add(new SqlParameter("@PipelineID", PipelineID));
                parameterList.Add(new SqlParameter("@RouteID", RouteID));
                parameterList.Add(new SqlParameter("@CreateBy", createBy));
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }



        public List<DropDownListDTO> RouteCodeByObjList(string createBy, string RegionID, string PipelineID, string AssetOwnerID)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<DropDownListDTO>();
            dataTable = null;

            string procName = "";

            procName = string.Format("sp_M_RouteCode_FindByRegion_DropDownList");

            try
            {

                parameterList.Add(new SqlParameter("@RegionID", RegionID));
                parameterList.Add(new SqlParameter("@PipelineID", PipelineID));
                parameterList.Add(new SqlParameter("@AssetOwnerID", AssetOwnerID));
                parameterList.Add(new SqlParameter("@CreateBy", createBy));
                adapter = new SqlDataAdapter();
                SqlConnection conn = OpenConnection();
                command = new SqlCommand(procName, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                SqlDataReader reader = command.ExecuteReader();
                objList = ConvertX.ConvertDataReaderToObjectList<DropDownListDTO>(reader);
                reader.Close();


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }


        public List<Select2DTO> Select2ByObjList(string tableName,object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<Select2DTO> select2ObjList = new List<Select2DTO>();
            Select2DTO select2Obj = null;
            dataTable = null;

            string procName = string.Format("sp_{0}_DropDownList", tableName);
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
                        select2Obj.id = reader["Value"].ToString();
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


        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }
    }
}
