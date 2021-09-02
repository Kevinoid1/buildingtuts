using System.Threading.Tasks;
using Abp.Application.Services;
using BuildingTuts.Authorization.Accounts.Dto;

namespace BuildingTuts.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
