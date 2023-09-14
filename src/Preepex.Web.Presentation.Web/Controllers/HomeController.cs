using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Presentation.Framework.Controllers;


namespace Preepex.Web.Presentation.Web.Controllers
{
    [Route("api/Home")]
    [AutoValidateAntiforgeryToken]
    public class HomeController : BaseApiController
    {

        public HomeController(ICatalogModelFactory catalogModelFactory)
        {
        }

    }
}
