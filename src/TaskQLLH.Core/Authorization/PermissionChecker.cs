using Abp.Authorization;
using TaskQLLH.Authorization.Roles;
using TaskQLLH.Authorization.Users;

namespace TaskQLLH.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
