using AutomationTest.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Properties
        private string _barcode;

        public string Barcode
        {
            get => _barcode;
            set { SetProperty(ref _barcode, value); }
        }

        private string _width;

        public string Width
        {
            get => _width;
            set { SetProperty(ref _width, value); }
        }

        private string _height;

        public string Height
        {
            get => _height;
            set { SetProperty(ref _height, value); }
        }

        private string _depth;

        public string Depth
        {
            get => _depth;
            set { SetProperty(ref _depth, value); }
        }

        #endregion

        #region Commands

        public IMvxCommand ResetCommand { get; }
        public IMvxCommand SaveCommand { get; }

#endregion

        private readonly IPopupService _popupService;

        public MainViewModel(IPopupService popupService)
        {
            _popupService = popupService;
            ResetCommand = new MvxCommand(ResetAction);
            SaveCommand = new MvxCommand(SaveAction);
        }

        private void SaveAction()
        {
            if (!string.IsNullOrEmpty(Barcode) && !string.IsNullOrEmpty(Width) && !string.IsNullOrEmpty(Height) &&
                !string.IsNullOrEmpty(Depth))
            {
                var message = $"Dimm ({Width} x {Height} x {Depth}) {Barcode} saved";
                _popupService.ShowMessage(message);
            }

            else
            {
                _popupService.ShowMessage("Dimm doesn't saved. Please fill all fields.");
            }
        }

        private void ResetAction()
        {
            Barcode = string.Empty;
            Width = string.Empty;
            Height = string.Empty;
            Depth = string.Empty;
        }
    }
}
