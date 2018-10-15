using DAO.PTT.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.PTT.Plan
{
    public class T_Planing_Action_SitePreparationMobileBAL
    {
        T_Planing_Action_SitePreparationMobileDAO dao = null;

        public T_Planing_Action_SitePreparationMobileBAL()
        {
            dao = new T_Planing_Action_SitePreparationMobileDAO();
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
