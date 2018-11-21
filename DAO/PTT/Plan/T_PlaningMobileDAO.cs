using DTO.PTT.Plan;
using DTO.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.PTT.Plan
{
    public class T_PlaningMobileDAO : PTTMobileDB
    {
        Logger logger = new Logger("T_PlaningMobileDAO");
        public string AddFromMobile(object planObj
                        , object coatingRepairObj
                        , List<object> coatingDefectObj
                        , List<object> pipeDefectObj
                        , List<object> environmentObj)
        {
            string TPID = "";

            if (planObj != null)
            {
                List<SqlParameter> parameterList = new List<SqlParameter>();

                string procName = "sp_T_Planing_Mobile_Insert";

                SqlConnection conn = OpenConnection();
                SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);

                command = new SqlCommand(procName, conn);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    T_PlaningMobileDTO planDTO = (T_PlaningMobileDTO)planObj;
                    planDTO.SpecSDate = ConvertX.MMddYY(planDTO.SpecSDate);
                    planDTO.SpecEDate = ConvertX.MMddYY(planDTO.SpecEDate);

                    planDTO.POSDate = ConvertX.MMddYY(planDTO.POSDate);
                    planDTO.POEDate = ConvertX.MMddYY(planDTO.POEDate);

                    planDTO.ActionSDate = ConvertX.MMddYY(planDTO.ActionSDate);
                    planDTO.ActionEDate = ConvertX.MMddYY(planDTO.ActionEDate);

                    parameterList.AddRange(GetParametersExactly(procName, planDTO, transaction).ToArray());

                    command = new SqlCommand(procName, conn);
                    command.Transaction = transaction;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();

                    TPID = command.Parameters[0].Value.ToString();

                    if (coatingRepairObj != null)
                    {
                        T_PlaningCoatingRepairMobileDTO coatingRepairDTo = (T_PlaningCoatingRepairMobileDTO)coatingRepairObj;

                        procName = "sp_T_Planing_CoatingRepair_Mobile_Insert";

                        parameterList = new List<SqlParameter>();

                        if (coatingRepairDTo != null)
                        {
                            coatingRepairDTo.TPID = TPID;
                            parameterList.AddRange(GetParametersExactly(procName, coatingRepairDTo, transaction).ToArray());

                            command = new SqlCommand(procName, conn);
                            command.Transaction = transaction;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddRange(parameterList.ToArray());

                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    logger.error("AddFromMobile error :" + ex.ToString());
                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            return TPID;
        }

        public List<T_PlaningMobileDTO> FindByObjListV2(object data)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            List<T_PlaningMobileDTO> objList = new List<T_PlaningMobileDTO>();
            dataTable = null;

            string procName = "sp_T_Planing_FindByFindByConditonV2";
            try
            {
                SqlConnection conn = null;
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
                        objList = ConvertX.GetListFromDataReader<T_PlaningMobileDTO>(reader).ToList();
                    }
                }
            }
            catch (Exception ex) {
                logger.error("FindByObjListV2 error :" + ex.ToString());
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return objList;
        }
    }
}
