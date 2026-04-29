using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TaskQLLH.MultiTenancy;

namespace TaskQLLH.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
