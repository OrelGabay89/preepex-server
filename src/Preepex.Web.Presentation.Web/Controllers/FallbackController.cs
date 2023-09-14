using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Preepex.Web.Presentation.Web.Controllers
{
    public class FallbackController : Controller
    {
        public IActionResult Index()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
            return PhysicalFile(path, "text/HTML");
        }
    }
}