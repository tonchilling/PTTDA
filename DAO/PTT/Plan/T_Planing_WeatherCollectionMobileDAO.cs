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
    public class T_Planing_WeatherCollectionMobileDAO : PTTMobileDB
    {
        public bool AddFromMobile(object data)
        {
            try
            {
                T_Planing_WeatherCollectionMobileDTO obj = (T_Planing_WeatherCollectionMobileDTO)data;
                if (obj != null)
                {
                    List<SqlParameter> parameterList = new List<SqlParameter>();

                    string procName = "sp_T_Planing_Action_WeatherCollection_Insert_Mobile";
                    SqlConnection conn = OpenConnection();

                    isCan = true;
                    obj.CollectDate = ConvertX.MMddYY(obj.CollectDate);
                    command = new SqlCommand(procName, conn);

                    command.CommandType = CommandType.StoredProcedure;
                    
                    parameterList.AddRange(GetParametersExactly(procName, obj).ToArray());
                    command.Parameters.AddRange(parameterList.ToArray());

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                isCan = false;

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
