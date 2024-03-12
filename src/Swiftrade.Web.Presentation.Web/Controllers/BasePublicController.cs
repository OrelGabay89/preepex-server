using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swiftrade.Web.Presentation.Web.Controllers
{
    public abstract class BasePublicController : Controller
    {
        protected virtual IActionResult InvokeHttp404()
        {
            Response.StatusCode = 404;
            return new EmptyResult();
        }
    }
}
