using DAO.PTT.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.PTT.Plan
{
    public class T_Planing_Action_SiteSurveyMobileBAL
    {
        T_Planing_Action_SiteSurveyMobileDAO dao = null;

        public T_Planing_Action_SiteSurveyMobileBAL()
        {
            dao = new T_Planing_Action_SiteSurveyMobileDAO();
        }

        public bool AddFromMobile(object data)
        {
            bool success;
            try
            {
                success = dao.AddFromMobile(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }
    }
}
