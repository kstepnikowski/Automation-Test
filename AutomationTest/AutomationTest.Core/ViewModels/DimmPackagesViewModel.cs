using AutomationTest.Core.Common;
using AutomationTest.Core.Models.DTO;
using AutomationTest.Core.Models.PO;
using AutomationTest.Core.PlatformServices;
using AutomationTest.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmValidation;

namespace AutomationTest.Core.ViewModels
{
    public class DimmPackagesViewModel : MvxViewModel, IMvxViewModel<PackageListItemPO>
    {
#region Properties
        private string _barcode;
        public string Barcode
        {
            get => _barcode;
            set => SetProperty(ref _barcode, value);
        }

        private string _width;
        public string Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private string _height;
        public string Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _depth;
        public string Depth
        {
            get => _depth;
            set => SetProperty(ref _depth, value);
        }

        private ObservableDictionary<string, string> _errors;
        public ObservableDictionary<string, string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }
#endregion

#region Commands

        public IMvxCommand ResetCommand { get; }
        public IMvxCommand SaveCommand { get; }

        #endregion

        private readonly IPopupService _popupService;
        private readonly IPackageService _packageService;
        private readonly IMvxNavigationService _navigationService;

        private PackageListItemPO _packageListItemPo;

        public DimmPackagesViewModel(IPopupService popupService, IPackageService packageService, IMvxNavigationService navigationService)
        {
            _popupService = popupService;
            _packageService = packageService;
            _navigationService = navigationService;
            ResetCommand = new MvxCommand(ResetAction);
            SaveCommand = new MvxCommand(SaveAction);
        }

        private void SaveAction()
        {
            if (!Validate())
            {
                return;
            }

            var package = _packageService.GetPackage(_packageListItemPo);
            if (package == null)
            {
                _packageService.AddPackage(new PackageDTO { Barcode = Barcode, Width = Width, Height = Height, Depth = Depth });
                _popupService.ShowMessage($"Dimm ({Width} x {Height} x {Depth}) {Barcode} saved");

            }
            else
            {
                _packageService.EditPackage(new PackageDTO { Barcode = Barcode, Width = Width, Height = Height, Depth = Depth });
                _popupService.ShowMessage($"Dimm ({Width} x {Height} x {Depth}) {Barcode} updated");
                _navigationService.Close(this);
            }
        }

        private void ResetAction()
        {
            Barcode = string.Empty;
            Width = string.Empty;
            Height = string.Empty;
            Depth = string.Empty;
        }

        private bool Validate()
        {
            var validator = new ValidationHelper();
            validator.AddRequiredRule(() => Barcode, "Barcode is required.");
            validator.AddRequiredRule(() => Width, "Width is required.");
            validator.AddRequiredRule(() => Height, "Height is required.");
            validator.AddRequiredRule(() => Depth, "Depth is required.");

            var result = validator.ValidateAll();
            Errors = result.AsObservableDictionary();

            return result.IsValid;
        }

        //Invoke when package can be edited
        public void Prepare(PackageListItemPO parameter)
        {
            if (parameter != null)
            {
                _packageListItemPo = parameter;
                Barcode = _packageListItemPo.Barcode;
                Width = _packageListItemPo.Width;
                Height = _packageListItemPo.Height;
                Depth = _packageListItemPo.Depth;
            }
        }
    }
}
