using Microsoft.AspNetCore.Mvc;

namespace GroupWork.Controllers
{
    public class BranchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
