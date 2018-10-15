using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PTT.Master
{
    public class M_RegionPipelineDTO
    {
        public string RouteID { get; set; }
        public string RouteName { get; set; }
        public string AssertOwnerID { get; set; }
        public string AssertOwnerName { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string TypeOfPipelineID { get; set; }
        public string TypeOfPipelineName { get; set; }

    }
}
