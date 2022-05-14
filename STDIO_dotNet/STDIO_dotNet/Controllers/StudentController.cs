using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using STDIO_dotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace STDIO_dotNet.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(string message)
        {
            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            ViewData["SH"] = SH.GetStudentList();
            ViewData["MH"] = MH.GetMajorList();
            ViewData["UH"] = UH.GetUniversityList();
            ViewData["msg"] = message;
            return View("~/Views/Student/Index.cshtml");
        }

        public IActionResult Create(Student student)
        {
            StudentHandler SH = new StudentHandler();
            if (SH.ContainStudentID(student.StudentID)) return Index("ID is duplicated");
            SH.StudentList.Clear();
            SH.StudentList.Add(student);
            SH.WriteAppendStudentListToFile(SH.StudentList);
            return Index("");
        }

        public IActionResult Edit(string id)
        {
            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();

            Student S = SH.StudentList.Find(x => x.StudentID.Equals(id));
            ViewData["MH"] = MH.GetMajorList();
            ViewData["UH"] = UH.GetUniversityList();
            return View(S);
        }

        public IActionResult SubmitEdit(Student S)
        {
            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            Student student = SH.StudentList.Find(x => x.StudentID.Equals(S.StudentID));
            SH.CopyStudentValue(student, S);
            SH.OverWriteStudentListToFile(SH.StudentList);

            return Index("");
        }

        public IActionResult Delete(string id)
        {
            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            Student S = SH.StudentList.Find(x => x.StudentID.Equals(id));
            SH.StudentList.Remove(S);
            SH.OverWriteStudentListToFile(SH.StudentList);
            return Index("");
        }
        public IActionResult Search(string name)
        {
            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            var result = new List<Student>();
            foreach (var S in SH.StudentList)
            {
                if (name != null && S.StudentName.ToLower().Contains(name.ToLower()))
                {
                    result.Add(S);
                }
            }
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            ViewData["SH"] = result;
            ViewData["MH"] = MH.GetMajorList();
            ViewData["UH"] = UH.GetUniversityList();
            return View("~/Views/Student/Index.cshtml");
        }
    }
}
