using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TaskQLLH.Authorization
{
    public class TaskQLLHAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            
            var classRooms = context.CreatePermission(
                PermissionNames.Pages_ClassRooms, 
                L("ClassRooms")
            );
            classRooms.CreateChildPermission(
                PermissionNames.Pages_ClassRooms_Create, L("CreatingClassRoom"));
            classRooms.CreateChildPermission(
                PermissionNames.Pages_ClassRooms_Edit, L("EditingClassRoom"));
            classRooms.CreateChildPermission(
                PermissionNames.Pages_ClassRooms_Delete, L("DeletingClassRoom"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaskQLLHConsts.LocalizationSourceName);
        }
    }
}
