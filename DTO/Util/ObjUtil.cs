using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Util
{
    public class ObjUtil
    {
        public static bool isEmpty(String obj)
        {
            if(obj == null || obj.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isEmpty(Object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isEmpty(List<Object> obj)
        {
            if (obj == null || obj.ToArray().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
