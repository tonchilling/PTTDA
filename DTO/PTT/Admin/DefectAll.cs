using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Admin
{
    public class DefectAll
    {
          public DefectAll() { }

          public List<DefectLevel1> defectLevel1List { get; set; }
    }

    public class DefectLevel1
    {
        public string Id { get; set; }
        public string Name { get; set; }
      public List<DefectLevel2> defectLevel2List;
    }
    public class DefectLevel2
    {
        public string Level1ID { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

     public List<DefectLevel3> defectLevel3List;
    }
    public class DefectLevel3
    {
        public string LevelID { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
