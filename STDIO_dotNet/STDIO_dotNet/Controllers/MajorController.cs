using Microsoft.AspNetCore.Mvc;
using STDIO_dotNet.Models;
using System;
using System.Collections.Generic;

namespace STDIO_dotNet.Controllers
{
    public class MajorController : Controller
    {
        public IActionResult Index(string message)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            ViewData["MH"] = MH.MajorList;
            ViewData["msg"] = message;
            return View("~/Views/Major/Index.cshtml");
        }

        public IActionResult Create(Major major)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            if (MH.MajorAvailable(major.MajorID)) return Index("ID Duplicated");
            MH.MajorList.Clear();
            MH.MajorList.Add(major);
            MH.WriteAppendMajorListToFile(MH.MajorList);
            return Index("");
        }

        public IActionResult Edit(string id)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            Major M = MH.MajorList.Find(x => x.ClassID.Equals(id));
            return View(M);
        }

        public IActionResult SubmitEdit(Major M)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            Major major = MH.MajorList.Find(x => x.ClassID == M.ClassID);
            MH.CopyMajorValue(major, M);
            MH.OverWriteMajorListToFile(MH.MajorList);
            return Index("");
        }

        public IActionResult Delete(string id)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            Major M = MH.MajorList.Find(x => x.ClassID.Equals(id));
            MH.MajorList.Remove(M);
            MH.OverWriteMajorListToFile(MH.MajorList);
            return Index("");
        }
        public IActionResult Search(string name)
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            var result = new List<Major>();
            foreach (var M in MH.MajorList)
            {
                if (name != null && M.MajorName.ToLower().Contains(name.ToLower()))
                {
                    result.Add(M);
                }
            }
            ViewData["MH"] = result;
            return View("~/Views/Major/Index.cshtml");
        }
    }
}
