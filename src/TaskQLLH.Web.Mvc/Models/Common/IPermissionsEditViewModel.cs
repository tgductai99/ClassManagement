using System.Collections.Generic;
using TaskQLLH.Roles.Dto;

namespace TaskQLLH.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}