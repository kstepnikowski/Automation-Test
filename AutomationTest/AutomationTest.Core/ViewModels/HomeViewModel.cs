using MvvmCross.Core.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand ShowDimmsCommand { get; }
        public IMvxCommand ShowPackagesCommand { get; }

        public HomeViewModel()
        {
            ShowDimmsCommand = new MvxCommand(() =>
            {
                ShowViewModel<DimmPackagesViewModel>();
            });
            ShowPackagesCommand = new  MvxCommand(() =>
            {
                ShowViewModel<PackagesListViewModel>();
            });
        }
    }
}
