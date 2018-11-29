using MvvmCross.Commands;

namespace AutomationTest.Core.Models.PO
{
    public class PackageListItemPO
    {
        public string Barcode { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }
        public string Dimms => $"{Width} x {Height} x {Depth}";
        public IMvxCommand DeleteCommand { get; set; }
        public IMvxCommand EditCommand { get; set; }

        public void Delete()
        {
            DeleteCommand?.Execute(this);
        }

        public void Edit()
        {
            EditCommand?.Execute(this);
        }
    }
}
