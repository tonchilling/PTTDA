using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace DTO.Util
{
    public class ResposeType
    {
        public bool statusCode { get; set; }
        public string statusText { get; set; }
        public object data { get; set; }
        public List<object> dataList { get; set; }
    }
}
