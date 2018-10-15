using DAO.PTT.Plan;
using System;

namespace BAL.PTT.Plan
{
    public class T_Planing_Action_BFRemovalMobileBAL
    {
        T_Planing_Action_BFRemovalMobileDAO dao = null;

        public T_Planing_Action_BFRemovalMobileBAL()
        {
            dao = new T_Planing_Action_BFRemovalMobileDAO();
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
