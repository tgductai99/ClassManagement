using System.Collections.Generic;
using TaskQLLH.Roles.Dto;

namespace TaskQLLH.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
