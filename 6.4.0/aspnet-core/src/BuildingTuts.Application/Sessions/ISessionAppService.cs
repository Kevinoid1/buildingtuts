using System.Threading.Tasks;
using Abp.Application.Services;
using BuildingTuts.Sessions.Dto;

namespace BuildingTuts.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
