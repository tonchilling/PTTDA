using DAO.PTT.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.PTT.Plan
{
    public class T_PlaningMobileBAL
    {
        T_PlaningMobileDAO dao = null;

        public T_PlaningMobileBAL()
        {
            dao = new T_PlaningMobileDAO();
        }

        public string AddFromMobile(object planObj
                        , object coatingRepairObj
                        , List<object> coatingDefectObj
                        , List<object> pipeDefectObj
                        , List<object> environmentObj)
        {
            string TPID = "";
            try
            {
                TPID = dao.AddFromMobile(planObj, coatingRepairObj, coatingDefectObj, pipeDefectObj, environmentObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TPID;
        }
    }
}
