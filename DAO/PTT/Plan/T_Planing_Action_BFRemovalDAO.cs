using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.PTT.Plan;
using System.Data;
using System.Data.SqlClient;
using DTO.Util;


namespace DAO.PTT.Plan
{
    public class T_Planing_Action_BFRemovalDAO : PTTDB
    {

        List<T_Planing_Action_BFRemovalDTO> objList = null;
        T_Planing_Action_BFRemovalDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_BFRemoval_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {

                obj = (T_Planing_Action_BFRemovalDTO)data;
                command = new SqlCommand(procName, conn, transaction);

                command.CommandType = CommandType.StoredProcedure;



                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

                PID = obj.PID;

            


                if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                {
                    procName = "sp_T_Planing_Action_BFRemoval_Files_Delete";
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

                if (obj.DeleteConditionFiles != null && obj.DeleteConditionFiles.Length > 0)
                {
                    procName = "[sp_T_Planing_Action_BFRemoval_ConditionFiles_Delete]";
                    foreach (var fileNo in obj.DeleteConditionFiles.Split(','))
                    {
                        if (fileNo != "")
                        {
                            command = new SqlCommand(procName, conn, transaction);

                            command.CommandType = CommandType.StoredProcedure;
                            if (fileNo != null)
                            {
                                T_Planing_File file = new T_Planing_File();
                                file.PID = PID;
                                file.No = fileNo;
                                file.UploadType = "3";
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                                //  command.Parameters[0].Value = "";
                            }

                            command.ExecuteNonQuery();
                        }


                    }
                }



                procName = "sp_T_Planing_Action_BFRemoval_Files_Insert";
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



                procName = "[sp_T_Planing_Action_BFRemoval_Condition_Insert]";
                if (obj.ConditionList != null && obj.ConditionList.Count > 0)
                {
                    foreach (T_Planing_Action_BFRemoval_ConditionDTO dto in obj.ConditionList)
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
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_BFRemoval_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_BFRemoval_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_BFRemoval_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_Action_BFRemovalDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_Action_BFRemovalDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_BFRemoval_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_Action_BFRemovalDTO>(reader).ToList()[0];

                    reader.NextResult();

                    obj.ConditionList = ConvertX.GetListFromDataReader<T_Planing_Action_BFRemoval_ConditionDTO>(reader).ToList();


                    reader.NextResult();

                    obj.UploadFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();

                    reader.NextResult();
                    obj.UploadDefectFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();

                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_Action_BFRemovalDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_Action_BFRemovalDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_BFRemoval_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_BFRemovalDTO>(reader).ToList();

                }


            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return objList;
        }

        public List<T_Planing_File> FindAllFiles(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<T_Planing_File> list = new List<T_Planing_File>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_BFRemoval_FindAllFiles";
            SqlConnection conn = null;
            try
            {
                if (data != null)
                {
                    dataTable = new DataTable();
                    adapter = new SqlDataAdapter();
                    conn = OpenConnection();
                    parameterList.AddRange(GetParameters(procName, data).ToArray());

                    command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddRange(parameterList.ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        list = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return list;
        }

        public List<T_Planing_Action_BFRemoval_ConditionDTO> FindAllConditions(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<T_Planing_Action_BFRemoval_ConditionDTO> list = new List<T_Planing_Action_BFRemoval_ConditionDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_BFRemoval_FindAllConditions";
            SqlConnection conn = null;
            try
            {
                if (data != null)
                {
                    dataTable = new DataTable();
                    adapter = new SqlDataAdapter();
                    conn = OpenConnection();
                    parameterList.AddRange(GetParameters(procName, data).ToArray());

                    command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddRange(parameterList.ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        list = ConvertX.GetListFromDataReader<T_Planing_Action_BFRemoval_ConditionDTO>(reader).ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return list;
        }

    }
}
