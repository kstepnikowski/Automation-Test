using System.Linq;
using System.Threading.Tasks;
using AutomationTest.Core.Models.PO;
using AutomationTest.Core.PlatformServices;
using AutomationTest.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class PackagesListViewModel : MvxViewModel
    {
#region Properties
        private bool _isInfoVisible;

        public bool IsInfoVisible
        {
            get => _isInfoVisible;
            set => SetProperty(ref _isInfoVisible, value);
        }

        private MvxObservableCollection<PackageListItemPO> _packages;

        public MvxObservableCollection<PackageListItemPO> Packages
        {
            get => _packages;
            set => SetProperty(ref _packages, value);
        }
#endregion

        public IMvxCommand DeletePackageCommand { get; }

        private readonly IPackageService _packageService;
        private readonly IPopupService _popupService;
        private readonly IMvxNavigationService _navigationService;

        public PackagesListViewModel(IPackageService packageService, IPopupService popupService, IMvxNavigationService navigationService)
        {
            _packageService = packageService;
            _popupService = popupService;
            _navigationService = navigationService;
            DeletePackageCommand = new MvxCommand<PackageListItemPO>(DeletePackageAction);
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await UpdatePackagesList();
        }

        private async Task UpdatePackagesList()
        {
            var packages = await _packageService.GetPackageListItems();
            foreach (var packageListItemPo in packages)
            {
                packageListItemPo.DeleteCommand = new MvxCommand<PackageListItemPO>(SwipeToDeletePackageAction);
                packageListItemPo.EditCommand = new MvxCommand<PackageListItemPO>(SwipeToEditPackageAction);
            }

            Packages = new MvxObservableCollection<PackageListItemPO>(packages);
            IsInfoVisible = !Packages.Any();
        }

        private async void SwipeToEditPackageAction(PackageListItemPO package)
        {
            await _navigationService.Navigate<DimmPackagesViewModel,PackageListItemPO>(package);
        }

        private async void SwipeToDeletePackageAction(PackageListItemPO package)
        {
            _packageService.DeletePackage(package);
            await UpdatePackagesList();
        }

        private void DeletePackageAction(PackageListItemPO package)
        {
            _popupService.Show("Delete package", $"Are you sure want to delete {package.Barcode}?", "Yes", async () =>
                {
                    _packageService.DeletePackage(package);
                    await UpdatePackagesList();
                },
                "No", async () => { await UpdatePackagesList(); });
        }
    }
}