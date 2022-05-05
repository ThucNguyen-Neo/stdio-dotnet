using Microsoft.AspNetCore.Mvc;
using STDIO_dotNet.Models;

namespace STDIO_dotNet.Controllers
{
    public class MajorController : Controller
    {
        public IActionResult Index()
        {
            MajorHandler MH = new MajorHandler();
            MH.GetMajorFromFile();
            return View(MH);
        }
    }
}
