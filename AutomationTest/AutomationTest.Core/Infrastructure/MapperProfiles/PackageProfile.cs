using AutomationTest.Core.Models.DTO;
using AutomationTest.Core.Models.PO;
using AutoMapper;

namespace AutomationTest.Core.Infrastructure.MapperProfiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<PackageDTO, PackageListItemPO>();
        }
    }
}
