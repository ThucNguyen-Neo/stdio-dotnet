using STDIO_dotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace STDIO_dotNet
{
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public bool StudentGender { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string MajorID { get; set; }
        public string UniversityID { get; set; }
        
        
        public string StudentToString()
        {
            MajorHandler MH = new MajorHandler();
            UniversityHandler UH = new UniversityHandler();
            return $"{this.StudentID}: {this.StudentName}, " + 
                $"{(this.StudentGender ? "Nam" : "Nữ")}, {this.StudentBirthDate.ToString("dd-MM-yyyy")}. " +
                $"{MH.MaCNToTenCN(this.MajorID)}, {UH.UniIDToUniName(this.UniversityID)}";
        }

        public string GetGender()
        {
            return StudentGender ? "Male" : "Female";
        }
    }
}
