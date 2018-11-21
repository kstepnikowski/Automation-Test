using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
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

        public IMvxCommand ResetCommand { get; }
        public IMvxCommand SaveCommand { get; }

        public MainViewModel()
        {
            ResetCommand = new MvxCommand(ResetAction);
            SaveCommand = new MvxCommand(SaveAction);
        }

        private void SaveAction()
        {
            
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
