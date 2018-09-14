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
    public class T_Planing_Action_AppliedCoatingDAO : PTTDB
    {

        List<T_Planing_Action_AppliedCoatingDTO> objList = null;
        T_Planing_Action_AppliedCoatingDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AppliedCoating_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {

                obj = (T_Planing_Action_AppliedCoatingDTO)data;

                //obj.DateINstalled = ConvertX.MMddYY(obj.DateINstalled);

                command = new SqlCommand(procName, conn, transaction);

                command.CommandType = CommandType.StoredProcedure;



                if (data != null)
                {

                    parameterList.AddRange(GetParameters(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());
                }

                command.ExecuteNonQuery();

                PID = obj.PID;

                /*  if (((T_PlaningDTO)obj).DeleteFiles != null && ((T_PlaningDTO)obj).DeleteFiles.Length > 0)
                  {
                      procName = "sp_T_Planing_Files_Delete";
                      foreach (var fileNo in ((T_PlaningDTO)planObj).DeleteFiles.Split(','))
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
                  }*/


             /*   if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                {
                    procName = "sp_T_Planing_Action_AppliedCoating_Files_Delete";
                    foreach (var fileNo in obj.DeleteFiles.Split(','))
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
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                                //  command.Parameters[0].Value = "";
                            }

                            command.ExecuteNonQuery();
                        }


                    }
                }*/


                procName = "sp_T_Planing_Action_AppliedCoating_SurfaceProfile_Insert";
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


                procName = "sp_T_Planing_Action_AppliedCoating_Information_Insert";
                if (obj.CoatingInfoList != null && obj.CoatingInfoList.Count > 0)
                {
                    foreach (T_Planing_Action_AppliedCoating_InformationDTO dto in obj.CoatingInfoList)
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
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_AppliedCoating_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("[sp_T_Planing_Action_AppliedCoating_Delete]", data);
            CloseConnection();
            return isCan;
        }

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_AppliedCoating_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_Action_AppliedCoatingDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_Action_AppliedCoatingDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_AppliedCoating_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_Action_AppliedCoatingDTO>(reader).ToList().FirstOrDefault();
                    reader.NextResult();
                    obj.UploadFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();
                    reader.NextResult();
                    obj.CoatingInfoList = ConvertX.GetListFromDataReader<T_Planing_Action_AppliedCoating_InformationDTO>(reader).ToList();
                


                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_Action_AppliedCoatingDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_Action_AppliedCoatingDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AppliedCoating_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_AppliedCoatingDTO>(reader).ToList();

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
