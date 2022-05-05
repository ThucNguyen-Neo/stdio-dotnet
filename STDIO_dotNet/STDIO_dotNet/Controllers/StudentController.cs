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
        public IActionResult Index()
        {

            StudentHandler SH = new StudentHandler();
            SH.GetStudentFromFile();
            return View(SH);
        }
    }
}
