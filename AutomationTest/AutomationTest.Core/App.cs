using AutomationTest.Core.Infrastructure;
using AutomationTest.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace AutomationTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            CreatableTypes().EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton(MapperConfigurator.InitializeProfiles().CreateMapper());
            RegisterAppStart<MainContainerViewModel>();
        }
    }
}
