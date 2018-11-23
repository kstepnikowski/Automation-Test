using System.Threading.Tasks;
using AutomationTest.Core.Models.PO;
using AutomationTest.Core.Services;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class PackagesListViewModel : MvxViewModel
    {
        private MvxObservableCollection<PackageListItemPO> _packages;

        public MvxObservableCollection<PackageListItemPO> Packages
        {
            get => _packages;
            set { SetProperty(ref _packages, value); }
        }
        private readonly IPackageService _packageService;

        public PackagesListViewModel(IPackageService packageService)
        {
            _packageService = packageService;
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await UpdatePackagesList();
        }

        private async Task UpdatePackagesList()
        {
            var packages = await _packageService.GetPackageListItems();
            Packages = new MvxObservableCollection<PackageListItemPO>(packages);
        }
    }
}
