using Realms;

namespace AutomationTest.Core.Models.DTO
{
    public class PackageDTO : RealmObject
    {
        [PrimaryKey]
        public string Barcode { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }
    }
}
