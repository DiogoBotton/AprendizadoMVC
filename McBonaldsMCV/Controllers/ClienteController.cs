using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login(){
            return View();
        }
    }
}