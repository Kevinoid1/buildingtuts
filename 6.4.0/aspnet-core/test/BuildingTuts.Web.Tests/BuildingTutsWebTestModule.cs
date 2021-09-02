using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BuildingTuts.EntityFrameworkCore;
using BuildingTuts.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BuildingTuts.Web.Tests
{
    [DependsOn(
        typeof(BuildingTutsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BuildingTutsWebTestModule : AbpModule
    {
        public BuildingTutsWebTestModule(BuildingTutsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BuildingTutsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BuildingTutsWebMvcModule).Assembly);
        }
    }
}