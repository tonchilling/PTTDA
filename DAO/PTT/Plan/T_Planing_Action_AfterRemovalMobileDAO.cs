using DTO.PTT.Plan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.PTT.Plan
{
    public class T_Planing_Action_AfterRemovalMobileDAO : PTTMobileDB
    {
        public bool AddFromMobile(object data)
        {
            T_Planing_Action_AfterRemovalMobileDTO obj = null;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AfterRemoval_Insert_Mobile";
            string TPID = "";
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            isCan = true;
            try
            {
                if (data != null)
                {
                    conn = OpenConnection();
                    transaction = conn.BeginTransaction();

                    obj = (T_Planing_Action_AfterRemovalMobileDTO)data;
                    command = new SqlCommand(procName, conn, transaction);

                    command.CommandType = CommandType.StoredProcedure;

                    parameterList.AddRange(GetParametersExactly(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();

                    TPID = obj.TPID;
                    
                    if (obj.DeleteDefectFiles != null && obj.DeleteDefectFiles.Length > 0)
                    {
                        procName = "[sp_T_Planing_Action_AfterRemoval_Defect_Delete_Mobile]";
                        foreach (var fileNo in obj.DeleteDefectFiles.Split(','))
                        {
                            if (fileNo != "")
                            {
                                command = new SqlCommand(procName, conn, transaction);

                                command.CommandType = CommandType.StoredProcedure;
                                if (fileNo != null)
                                {
                                    T_PlaningFileMobileDTO file = new T_PlaningFileMobileDTO();
                                    file.PID = TPID;
                                    file.No = fileNo;
                                    file.UploadType = "1";
                                    parameterList = new List<SqlParameter>();
                                    parameterList.AddRange(GetParametersExactly(procName, file, transaction).ToArray());

                                    command.Parameters.AddRange(parameterList.ToArray());
                                }

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    
                    procName = "sp_T_Planing_Action_AfterRemoval_Files_Insert_Mobile";
                    if (obj.UploadFileList != null && obj.UploadFileList.Count > 0)
                    {
                        foreach (T_PlaningFileMobileDTO file in obj.UploadFileList)
                        {
                            file.TPID = TPID;

                            command = new SqlCommand(procName, conn, transaction);

                            command.CommandType = CommandType.StoredProcedure;
                            if (file != null)
                            {
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParametersExactly(procName, file, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                    
                    procName = "[sp_T_Planing_Action_AfterRemoval_Defect_Insert_Mobile]";
                    if (obj.DefectList != null && obj.DefectList.Count > 0)
                    {
                        foreach (T_Planing_Action_AfterRemoval_DefectMobileDTO dto in obj.DefectList)
                        {
                            dto.TPID = TPID;

                            command = new SqlCommand(procName, conn, transaction);

                            command.CommandType = CommandType.StoredProcedure;
                            if (dto != null)
                            {
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParametersExactly(procName, dto, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                    
                    procName = "[sp_T_Planing_Action_AfterRemoval_WallThickness_Insert_Mobile]";
                    if (obj.WallThicknessList != null && obj.WallThicknessList.Count > 0)
                    {
                        foreach (T_Planing_Action_AfterRemoval_WallThicknessMobileDTO dto in obj.WallThicknessList)
                        {
                            dto.TPID = TPID;

                            command = new SqlCommand(procName, conn, transaction);

                            command.CommandType = CommandType.StoredProcedure;
                            if (dto != null)
                            {
                                parameterList = new List<SqlParameter>();
                                parameterList.AddRange(GetParametersExactly(procName, dto, transaction).ToArray());

                                command.Parameters.AddRange(parameterList.ToArray());
                            }

                            command.ExecuteNonQuery();
                        }
                    }
                    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                isCan = false;
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return isCan;
        }
    }
}
