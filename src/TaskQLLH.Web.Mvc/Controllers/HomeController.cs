using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TaskQLLH.Controllers;

namespace TaskQLLH.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TaskQLLHControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
