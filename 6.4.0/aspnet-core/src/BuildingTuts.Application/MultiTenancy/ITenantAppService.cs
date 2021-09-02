using Abp.Application.Services;
using BuildingTuts.MultiTenancy.Dto;

namespace BuildingTuts.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

