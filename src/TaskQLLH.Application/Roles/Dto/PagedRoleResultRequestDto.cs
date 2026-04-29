using Abp.Application.Services.Dto;

namespace TaskQLLH.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

