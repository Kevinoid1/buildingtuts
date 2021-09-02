using System.Threading.Tasks;
using BuildingTuts.Configuration.Dto;

namespace BuildingTuts.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
