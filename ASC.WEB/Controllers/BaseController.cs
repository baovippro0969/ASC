using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASC.WEB.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
