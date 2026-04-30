using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskQLLH.Authorization;
using TaskQLLH.ClassRooms;
using TaskQLLH.Controllers;

namespace TaskQLLH.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_ClassRooms)]
    public class ClassRoomsController : TaskQLLHControllerBase
    {
        private readonly IClassRoomAppService _classRoomAppService;

        public ClassRoomsController(IClassRoomAppService classRoomAppService)
        {
            _classRoomAppService = classRoomAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditModal(int classRoomId)
        {
            var classRoom = await _classRoomAppService.Get(
                new EntityDto(classRoomId)
            );
            return PartialView("_EditModal", classRoom);
        }
    }
}