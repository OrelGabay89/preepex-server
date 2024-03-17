using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swiftrade.Core.Application.Interfaces.Factories;


namespace Swiftrade.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/Home")]
    [AutoValidateAntiforgeryToken]
    public class HomeController : BaseApiController
    {

        public HomeController()
        {
        }




    }
}
