using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Errors;
using Preepex.Presentation.Framework.Controllers;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}