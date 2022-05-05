using Microsoft.AspNetCore.Mvc;
using STDIO_dotNet.Models;

namespace STDIO_dotNet.Controllers
{
    public class UniversityController : Controller
    {
        public IActionResult Index()
        {
            UniversityHandler UH = new UniversityHandler();
            UH.GetUniversityFromFile();
            return View(UH);
        }
    }
}
