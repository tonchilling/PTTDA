using DTO.PTT.Master;
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
    public class T_Planing_Action_SiteSurveyMobileDAO : PTTMobileDB
    {
        public bool AddFromMobile(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_SiteSurvey_Mobile_Insert";
            string TPID = "";
            SqlConnection conn = OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();
            isCan = true;
            try
            {
                T_Planing_Action_SiteSurveyMobileDTO obj = (T_Planing_Action_SiteSurveyMobileDTO)data;
                command = new SqlCommand(procName, conn, transaction);

                command.CommandType = CommandType.StoredProcedure;

                if (obj != null)
                {
                    parameterList.AddRange(GetParametersExactly(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();

                    TPID = obj.TPID;
                    
                    if (obj.DeleteFiles != null && obj.DeleteFiles.Length > 0)
                    {
                        procName = "sp_T_Planing_Action_SiteSurvey_Files_Delete_Mobile";
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
                                    //  command.Parameters[0].Value = "";
                                }

                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    procName = "sp_T_Planing_Action_SiteSurvey_Files_Insert_Mobile";
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
                                //  command.Parameters[0].Value = "";
                            }

                            command.ExecuteNonQuery();
                        }
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
    }
}
