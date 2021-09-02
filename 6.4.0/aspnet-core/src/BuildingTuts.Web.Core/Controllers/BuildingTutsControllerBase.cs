using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BuildingTuts.Controllers
{
    public abstract class BuildingTutsControllerBase: AbpController
    {
        protected BuildingTutsControllerBase()
        {
            LocalizationSourceName = BuildingTutsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
