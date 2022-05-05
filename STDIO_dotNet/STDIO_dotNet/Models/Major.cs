using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STDIO_dotNet
{
    public class Major
    {
        public string ClassID { get; set; }
        public string MajorName { get; set; }
        public string MajorID { get; set; }

        public string MajorToString()
        {
            return $"{this.ClassID}, {this.MajorName}, {this.MajorID}";
        }
    }
}
