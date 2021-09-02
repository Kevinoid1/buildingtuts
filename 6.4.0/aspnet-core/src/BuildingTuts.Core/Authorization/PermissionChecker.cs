using Abp.Authorization;
using BuildingTuts.Authorization.Roles;
using BuildingTuts.Authorization.Users;

namespace BuildingTuts.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
