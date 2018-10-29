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
    public class T_Planing_Action_AfterRemovalDAO : PTTDB
    {

        List<T_Planing_Action_AfterRemovalDTO> objList = null;
        T_Planing_Action_AfterRemovalDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AfterRemoval_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {

                obj = (T_Planing_Action_AfterRemovalDTO)data;
                command = new SqlCommand(procName, conn, transaction);

                command.CommandType = CommandType.StoredProcedure;



                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

                PID = obj.PID;



              




                if (obj.DeleteDefectFiles != null && obj.DeleteDefectFiles.Length > 0)
                {
                    procName = "[sp_T_Planing_Action_AfterRemoval_Defect_Delete]";
                    foreach (var fileNo in obj.DeleteDefectFiles.Split(','))
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
                                file.UploadType = "1";
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                                //  command.Parameters[0].Value = "";
                            }

                            command.ExecuteNonQuery();
                        }


                    }
                }




                procName = "sp_T_Planing_Action_AfterRemoval_Files_Insert";
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


                procName = "[sp_T_Planing_Action_AfterRemoval_Defect_Insert]";
                if (obj.DefectList != null && obj.DefectList.Count > 0)
                {
                    foreach (T_Planing_Action_AfterRemoval_DefectDTO dto in obj.DefectList)
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


                procName = "[sp_T_Planing_Action_AfterRemoval_WallThickness_Insert]";
                if (obj.WallThicknessList != null && obj.WallThicknessList.Count > 0)
                {
                    foreach (T_Planing_Action_AfterRemoval_WallThicknessDTO dto in obj.WallThicknessList)
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
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_AfterRemoval_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_AfterRemoval_Delete", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_AfterRemoval_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_Action_AfterRemovalDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_Action_AfterRemovalDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterRemoval_FindByPK";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemovalDTO>(reader).ToList();

                    if (objList.Count==0)
                    {
                        obj = new T_Planing_Action_AfterRemovalDTO();
                        obj.RepairLength = command.Parameters["@repairLength2"].SqlValue.ToString();


                    }
                    else {
                        obj = objList.FirstOrDefault();
                    }

                    reader.NextResult();
                   
                    if( reader.Read())
                    {

                        obj.WallThicknessNumber = reader[0].ToString();


                    }


                    reader.NextResult();

                    if (reader.Read())
                    {

                        obj.RepairLength = reader[0].ToString();
                    }
                    reader.NextResult();

                    obj.DefectList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemoval_DefectDTO>(reader).ToList();




                    reader.NextResult();
                    obj.WallThicknessList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemoval_WallThicknessDTO>(reader).ToList();

                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_Action_AfterRemovalDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_Action_AfterRemovalDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterRemoval_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemovalDTO>(reader).ToList();

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
            List<T_Planing_File> fileList = new List<T_Planing_File>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterRemoval_FindAllFiles";
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
                        fileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();
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
            return fileList;
        }

        public List<T_Planing_Action_AfterRemoval_DefectDTO> FindAllDefects(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<T_Planing_Action_AfterRemoval_DefectDTO> list = new List<T_Planing_Action_AfterRemoval_DefectDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterRemoval_FindAllDefects";
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
                        list = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemoval_DefectDTO>(reader).ToList();
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

        public List<T_Planing_Action_AfterRemoval_WallThicknessDTO> FindAllWallThickness(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<T_Planing_Action_AfterRemoval_WallThicknessDTO> list = new List<T_Planing_Action_AfterRemoval_WallThicknessDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterRemoval_FindAllWallThickness";
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
                        list = ConvertX.GetListFromDataReader<T_Planing_Action_AfterRemoval_WallThicknessDTO>(reader).ToList();
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
