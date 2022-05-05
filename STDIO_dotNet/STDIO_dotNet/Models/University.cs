using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STDIO_dotNet
{
    public class University
    {
        public string UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string UniversityAbbr { get; set; }
        
        public string UniversityToString()
        {
            return $"{this.UniversityID}, {this.UniversityName}, {this.UniversityAbbr}";
        }
    }
}
