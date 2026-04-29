using System.Collections.Generic;
using TaskQLLH.Roles.Dto;

namespace TaskQLLH.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
