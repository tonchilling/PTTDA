﻿using DTO.PTT.Plan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.PTT.Plan
{
    public class T_Planing_Action_AppliedCoatingMobileDAO : PTTMobileDB
    {
        public bool AddFromMobile(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();

            string procName = "sp_T_Planing_Action_AppliedCoating_Insert_Mobile";
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

                    T_Planing_Action_AppliedCoatingMobileDTO obj = (T_Planing_Action_AppliedCoatingMobileDTO)data;
                    
                    command = new SqlCommand(procName, conn, transaction);

                    command.CommandType = CommandType.StoredProcedure;

                    parameterList.AddRange(GetParametersExactly(procName, obj, transaction).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();

                    TPID = obj.TPID;
                    
                    procName = "sp_T_Planing_Action_AppliedCoating_SurfaceProfile_Insert_Mobile";
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
                    
                    procName = "sp_T_Planing_Action_AppliedCoating_Information_Insert_Mobile";
                    if (obj.CoatingInfoList != null && obj.CoatingInfoList.Count > 0)
                    {
                        foreach (T_Planing_Action_AppliedCoating_InformationMobileDTO dto in obj.CoatingInfoList)
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
