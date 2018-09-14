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
    public class T_Planing_Action_AfterAppliedCoatingDAO : PTTDB
    {

        List<T_Planing_Action_AfterAppliedCoatingDTO> objList = null;
        T_Planing_Action_AfterAppliedCoatingDTO obj = null;

        public override bool Add(object data)
        {


            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AfterAppliedCoating_Insert";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {

                obj = (T_Planing_Action_AfterAppliedCoatingDTO)data;

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

                if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                  {
                      procName = "sp_T_Planing_Action_AfterAppliedCoating_Files_Delete";
                      foreach (var fileNo in obj.DeleteFiles.Split(','))
                      {
                          if (fileNo != null && fileNo != "")
                          {
                          command = new SqlCommand(procName, conn, transaction);

                          command.CommandType = CommandType.StoredProcedure;
                         
                              T_Planing_File file = new T_Planing_File();
                              file.PID = PID;
                              file.No = fileNo;
                              parameterList = new List<SqlParameter>();
                              parameterList.AddRange(GetParameters(procName, file, transaction).ToArray());

                              command.Parameters.AddRange(parameterList.ToArray());
                              //  command.Parameters[0].Value = "";
                        

                          command.ExecuteNonQuery();

                          }
                      }
                  }




                procName = "sp_T_Planing_Action_AfterAppliedCoating_Files_Insert";
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
                

                procName = "sp_T_Planing_Action_AfterAppliedCoating_DryFilmThickness_Insert";
                if (obj.DryFilmThicknessList != null && obj.DryFilmThicknessList.Count > 0)
                                {
                                    foreach (T_Planing_Action_AfterAppliedCoating_DryFilmDTO dto in obj.DryFilmThicknessList)
                                    {
                                        dto.PID = PID;

                                        dto.ClockPosition1 = dto.ClockPosition1 == "" ? null: dto.ClockPosition1;
                                        dto.ClockPosition2 = dto.ClockPosition2 == "" ? null : dto.ClockPosition2;
                                        dto.ClockPosition3 = dto.ClockPosition3 == "" ? null : dto.ClockPosition3;
                                        dto.ClockPosition4 = dto.ClockPosition4 == "" ? null : dto.ClockPosition4;
                                        command = new SqlCommand(procName, conn, transaction);

                                        command.CommandType = CommandType.StoredProcedure;
                                        if (dto != null)
                                        {
                                            parameterList = new List<SqlParameter>();
                                            parameterList.AddRange(GetParameters(procName, dto, transaction).ToArray());

                                            command.Parameters.AddRange(parameterList.ToArray());
                          
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
            isCan = ExcecuteNoneQuery("sp_T_Planing_Action_AfterAppliedCoating_Update", data);
            CloseConnection();
            return isCan;
        }

        public override bool Delete(object data)
        {
            OpenConnection();
            isCan = ExcecuteNoneQuery("[sp_T_Planing_Action_AfterAppliedCoating_Delete]", data);
            CloseConnection();
            return isCan;
        }

        public bool DeleteDryFilm(List<T_Planing_Action_AfterAppliedCoating_DryFilmDTO> dataList)
        {

            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AfterAppliedCoating_DryFilmThickness_Delete";
            string PID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            SqlParameter sqlP = null;
            try
            {

             

                //obj.DateINstalled = ConvertX.MMddYY(obj.DateINstalled);


              
                foreach (T_Planing_Action_AfterAppliedCoating_DryFilmDTO dto in dataList)
                {

                    PID = dto.PID;

                    command = new SqlCommand(procName, conn, transaction);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;


                    parameterList = new List<SqlParameter>();
                    sqlP = new SqlParameter("@PID_1", PID);
                    parameterList.Add(sqlP);

                    sqlP = new SqlParameter("@PositionNo", dto.PositionNo);
                    parameterList.Add(sqlP);

                    command.Parameters.AddRange(parameterList.ToArray());
                    //  command.Parameters[0].Value = "";


                    command.ExecuteNonQuery();


                }


              



                transaction.Commit();

                T_Planing_Action_AfterAppliedCoating_DryFilmDTO renewDto = new T_Planing_Action_AfterAppliedCoating_DryFilmDTO();
                renewDto.PID = PID;
                procName = "sp_T_Planing_Action_AfterAppliedCoating_DryFilmThickness_RePosition";
                command = new SqlCommand(procName, conn);

                command.CommandType = CommandType.StoredProcedure;
                parameterList = new List<SqlParameter>();
                parameterList.AddRange(GetParameters(procName, renewDto).ToArray());

                command.Parameters.AddRange(parameterList.ToArray());
                //  command.Parameters[0].Value = "";


                command.ExecuteNonQuery();


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

        public override System.Data.DataTable FindByAll()
        {
            OpenConnection();
            dataTable = ExcecuteToDataTable("sp_T_Planing_Action_AfterAppliedCoating_FindAll", null);
            CloseConnection();
            return dataTable;
        }

        public override DataTable FindByColumn(object data)
        {
            throw new NotImplementedException();
        }

        public T_Planing_Action_AfterAppliedCoatingDTO FindByPK(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            var obj = new T_Planing_Action_AfterAppliedCoatingDTO();


            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterAppliedCoating_FindByPK";
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

                    obj = ConvertX.GetListFromDataReader<T_Planing_Action_AfterAppliedCoatingDTO>(reader).ToList().FirstOrDefault();
                    reader.NextResult();
                    obj.UploadFileList = ConvertX.GetListFromDataReader<T_Planing_File>(reader).ToList();
                    reader.NextResult();
                    obj.DryFilmThicknessList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterAppliedCoating_DryFilmDTO>(reader).ToList();
                


                }




            }
            catch (Exception ex) { }
            finally
            {
                CloseConnection();
            }
            return obj;
        }


        public List<T_Planing_Action_AfterAppliedCoatingDTO> FindByObjList(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            objList = new List<T_Planing_Action_AfterAppliedCoatingDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_Action_AfterAppliedCoating_FindByColumn";
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

                    objList = ConvertX.GetListFromDataReader<T_Planing_Action_AfterAppliedCoatingDTO>(reader).ToList();

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
