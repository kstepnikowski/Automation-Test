﻿using System.Linq;
using System.Threading.Tasks;
using AutomationTest.Core.Models.PO;
using AutomationTest.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class PackagesListViewModel : MvxViewModel
    {
        private bool _isInfoVisible;

        public bool IsInfoVisible
        {
            get => _isInfoVisible;
            set { SetProperty(ref _isInfoVisible, value); }
        }
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
            IsInfoVisible = !Packages.Any();
        }
    }
}