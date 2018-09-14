using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Util
{
    public class Student
    {
        public string Name { get; set; }
        public byte[] Values { get; set; }
    }

    public struct Months
    {
        public static string[] Short = {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun"
        };
    }
}
