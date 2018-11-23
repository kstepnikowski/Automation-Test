using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand ShowDimmsCommand { get; }
        public IMvxCommand ShowPackagesCommand { get; }

        private readonly IMvxNavigationService _navigationService;

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowDimmsCommand = new MvxCommand(() =>
            {
               _navigationService.Navigate<DimmPackagesViewModel>();
            });
            ShowPackagesCommand = new MvxCommand(() =>
            {
                _navigationService.Navigate<PackagesListViewModel>();
            });
        }
    }
}
