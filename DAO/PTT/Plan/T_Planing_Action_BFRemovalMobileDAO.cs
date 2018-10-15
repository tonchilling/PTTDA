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
    public class T_Planing_Action_BFRemovalMobileDAO : PTTMobileDB
    {
        public bool AddFromMobile(object data)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            T_Planing_Action_BFRemovalMobileDTO obj = null;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_BFRemoval_Insert_Mobile";
            string TPID = "";
            isCan = true;
            try
            {
                obj = (T_Planing_Action_BFRemovalMobileDTO)data;
                if (obj != null)
                {
                    conn = OpenConnection();
                    transaction = conn.BeginTransaction();
                    command = new SqlCommand(procName, conn, transaction);

                    command.CommandType = CommandType.StoredProcedure;

                    parameterList.AddRange(GetParametersExactly(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();

                    TPID = obj.TPID;
                    
                    if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                    {
                        procName = "sp_T_Planing_Action_BFRemoval_Files_Delete_Mobile";
                        foreach (var fileNo in obj.DeleteFiles.Split(','))
                        {
                            if (fileNo != "")
                            {
                                command = new SqlCommand(procName, conn, transaction);

                                command.CommandType = CommandType.StoredProcedure;
                                if (fileNo != null)
                                {
                                    T_PlaningFileMobileDTO file = new T_PlaningFileMobileDTO();
                                    file.TPID = TPID;
                                    file.No = fileNo;
                                    parameterList = new List<SqlParameter>();
                                    parameterList.AddRange(GetParametersExactly(procName, file, transaction).ToArray());

                                    command.Parameters.AddRange(parameterList.ToArray());
                                }

                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    if (obj.DeleteConditionFiles != null && obj.DeleteConditionFiles.Length > 0)
                    {
                        procName = "[sp_T_Planing_Action_BFRemoval_ConditionFiles_Delete_Mobile]";
                        foreach (var fileNo in obj.DeleteConditionFiles.Split(','))
                        {
                            if (fileNo != "")
                            {
                                command = new SqlCommand(procName, conn, transaction);

                                command.CommandType = CommandType.StoredProcedure;
                                if (fileNo != null)
                                {
                                    T_PlaningFileMobileDTO file = new T_PlaningFileMobileDTO();
                                    file.TPID = TPID;
                                    file.No = fileNo;
                                    file.UploadType = "3";
                                    parameterList = new List<SqlParameter>();
                                    parameterList.AddRange(GetParametersExactly(procName, file, transaction).ToArray());

                                    command.Parameters.AddRange(parameterList.ToArray());
                                }

                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    procName = "sp_T_Planing_Action_BFRemoval_Files_Insert_Mobile";
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

                    procName = "[sp_T_Planing_Action_BFRemoval_Condition_Insert_Mobile]";
                    if (obj.ConditionList != null && obj.ConditionList.Count > 0)
                    {
                        foreach (T_Planing_Action_BFRemoval_ConditionMobileDTO dto in obj.ConditionList)
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
