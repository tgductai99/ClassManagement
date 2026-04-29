using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskQLLH.Authorization;
using TaskQLLH.Controllers; 

namespace TaskQLLH.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_ClassRooms)]
    public class ClassRoomController : TaskQLLHControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}