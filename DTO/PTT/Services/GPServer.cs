using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PTT.Services
{
   public class GPServer
    {

       /*  { "geometryType": "esriGeometryPoint",
"spatialReference": {
"wkid": 32647 },
"features":
[{ "geometry": {
"x":748874.9600000003,
"y":1425623.8499999999} }] }
       */

       public string geometryType {get;set;}
       public spatialReference spatialReference { get; set; }
       public List<features> features { get; set; }

    }

   public class spatialReference
   {
       public string wkid { get; set; }
   }

   public class features
   {
       public geometry geometry { get; set; }
   }

   public class geometry
   {
       public string x { get; set; }
       public string y { get; set; }
   }
}
