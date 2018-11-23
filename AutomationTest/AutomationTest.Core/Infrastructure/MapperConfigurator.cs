using AutomationTest.Core.Infrastructure.MapperProfiles;
using AutoMapper;

namespace AutomationTest.Core.Infrastructure
{
    public class MapperConfigurator
    {
        public static MapperConfiguration InitializeProfiles()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PackageProfile());
            });
        }
    }
}
