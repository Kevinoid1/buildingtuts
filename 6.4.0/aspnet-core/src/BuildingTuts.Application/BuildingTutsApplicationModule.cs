using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BuildingTuts.Authorization;

namespace BuildingTuts
{
    [DependsOn(
        typeof(BuildingTutsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BuildingTutsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BuildingTutsAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BuildingTutsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
