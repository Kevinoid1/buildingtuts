using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BuildingTuts.Configuration;

namespace BuildingTuts.Web.Host.Startup
{
    [DependsOn(
       typeof(BuildingTutsWebCoreModule))]
    public class BuildingTutsWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BuildingTutsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BuildingTutsWebHostModule).GetAssembly());
        }
    }
}
