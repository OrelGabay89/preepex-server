using Microsoft.AspNetCore.Mvc;


namespace Preepex.Presentation.Framework.Controllers
{
    public abstract class BaseApiController : Controller
    {
        protected virtual IActionResult InvokeHttp404()
        {
            Response.StatusCode = 404;
            return new EmptyResult();
        }
    }
}
