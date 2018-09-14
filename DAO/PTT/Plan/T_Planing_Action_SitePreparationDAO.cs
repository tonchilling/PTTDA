using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Plan;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;
using DTO.PTT.Master;


namespace DAO.PTT.Plan
{
    public class T_Planing_Action_SitePreparationDAO : PTTDB
    {

        List<T_Planing_Action_SitePreparationDTO> objList = null;
        T_Planing_Action_SitePreparationDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_SitePreparation_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {

                obj = (T_Planing_Action_SitePreparationDTO)data;
                command = new SqlCommand(procName, conn, transaction);

                command.CommandType = CommandType.StoredProcedure;



                if (obj != null)
                {

                    parameterList.AddRange(GetParameters(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

                PID = obj.PID;



                procName = "sp_T_Planing_Action_SitePreparation_UnderGround_Insert";
                if (obj.underGroundList != null && obj.underGroundList.Count > 0)
                {
                    foreach (M_UndergroundDTO dto in obj.underGroundList)
                    {
                        dto.PID = PID;

                        command = new SqlCommand(procName, conn, transaction);

                        command.CommandType = CommandType.StoredProcedure;
                        if (dto != null)
                        {
                            parameterList = new List<SqlParameter>();
                            parameterList.AddRange(GetParameters(procName, dto, transaction).ToArray());

                            command.Parameters.AddRange(parameterList.ToArray());
                            //  command.Parameters[0].Value = "";
                        }

                        command.ExecuteNonQuery();
                    }
                }




                if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                {
                    procName = "sp_T_Planing_Action_SitePreparation_Files_Delete";
                    foreach (var fileNo in obj.DeleteFiles.Split(','))
                    {
                        if(fileNo!="")
                        {
                             command = new SqlCommand(procName, conn, transaction);

                             command.CommandType = CommandType.StoredProcedure;
                             if (fileNo != null)
                                 {
                                     T_Planing_File file = new T_Planing_File();
                                     file.PID = PID;
                                        file.No = fileNo;
                                      parameterList = new List<SqlParameter>();
                                        parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                                         command.Parameters.AddRange(parameterList.ToArray());
                            //  command.Parameters[0].Value = "";
                        }

                        command.ExecuteNonQuery();
                        }


                    }
                }


                procName = "sp_T_Planing_Action_SitePreparation_Files_Insert";
                if (obj.UploadFileList != null && obj.UploadFileList.Count > 0)
                {
                    foreach (T_Planing_File file in obj.UploadFileList)
                    {
                        file.PID = PID;

                        command = new SqlCommand(procName, conn, transaction);

                        command.CommandType = CommandType.StoredProcedure;
                        if (file != null)
                        {
                            parameterList = new List<SqlParameter>();
                            parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                            command.Parameters.AddRange(parameterList.ToArray());
                            //  command.Parameters[0].Value = "";
                        }

                        command.ExecuteNonQuery();
                    }
                }

                transaction.Commit();


            }
            catch (Exception ex)
            {
                isCan = false;
                transaction.Rollback();
                throw new Exception(ex.Message);

            }
            finally
            {
                CloseConnection();

            }
            return isCan;
        }

        public override bool Update(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_SitePreparation_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_SitePreparation_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_SitePreparation_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_Action_SitePreparationDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_Action_SitePreparationDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_SitePreparation_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_Action_SitePreparationDTO>(reader).ToList()[0];

                    reader.NextResult();

                    obj.UploadFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();

                    reader.NextResult();

                    obj.underGroundList = ConvertX.GetListFromDataReader<M_UndergroundDTO>(reader).ToList();
                  


                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_Action_SitePreparationDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_Action_SitePreparationDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_SitePreparation_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_SitePreparationDTO>(reader).ToList();

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
