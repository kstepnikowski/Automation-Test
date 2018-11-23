using AutomationTest.Core.Infrastructure;
using AutomationTest.Core.ViewModels;
using AutoMapper;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace AutomationTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterSingleton(MapperConfigurator.InitializeProfiles().CreateMapper());
            RegisterAppStart<HomeViewModel>();
        }
    }
}
