using Microsoft.AspNetCore.Mvc;
using STDIO_dotNet.Models;
using System.Collections.Generic;

namespace STDIO_dotNet.Controllers
{
    public class UniversityController : Controller
    {
        public IActionResult Index(string message)
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            ViewData["UH"] = UH.UniversityList;
            ViewData["msg"] = message;
            return View("~/Views/University/Index.cshtml");
        }

        public IActionResult Create(University university)
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            if (UH.UniversityAvailable(university.UniversityAbbr)) return Index("Abbreviation Duplicated");
            UH.UniversityList.Clear();
            UH.UniversityList.Add(university);
            UH.WriteAppendUniversityListToFile(UH.UniversityList);
            return Index("");
        }

        public IActionResult Edit(string id)
        {
            UniversityHandler MH = new UniversityHandler();
            MH.GetUniversityFromFile();

            University U = MH.UniversityList.Find(x => x.UniversityID.Equals(id));
            return View(U);
        }

        public IActionResult SubmitEdit(University U)
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            University university = UH.UniversityList.Find(x => x.UniversityID == U.UniversityID);
            UH.CopyValue(university, U);
            UH.OverWriteUniversityListToFile(UH.UniversityList);
            return Index("");
        }

        public IActionResult Delete(string id)
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            University U = UH.UniversityList.Find(x => x.UniversityID.Equals(id));
            UH.UniversityList.Remove(U);
            UH.OverWriteUniversityListToFile(UH.UniversityList);
            return Index("");
        }
        public IActionResult Search(string name)
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            var result = new List<University>();
            foreach (var U in UH.UniversityList)
            {
                if (name != null && U.UniversityName.ToLower().Contains(name.ToLower()))
                {
                    result.Add(U);
                }
            }
            ViewData["UH"] = result;
            return View("~/Views/University/Index.cshtml");
        }
    }
}
