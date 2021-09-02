using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BuildingTuts.Configuration;
using BuildingTuts.EntityFrameworkCore;
using BuildingTuts.Migrator.DependencyInjection;

namespace BuildingTuts.Migrator
{
    [DependsOn(typeof(BuildingTutsEntityFrameworkModule))]
    public class BuildingTutsMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BuildingTutsMigratorModule(BuildingTutsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(BuildingTutsMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BuildingTutsConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BuildingTutsMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
