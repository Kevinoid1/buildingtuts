﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BuildingTuts.Configuration.Dto;

namespace BuildingTuts.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BuildingTutsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
