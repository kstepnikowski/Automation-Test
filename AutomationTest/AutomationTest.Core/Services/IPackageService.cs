using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationTest.Core.Models.DTO;
using AutomationTest.Core.Models.PO;

namespace AutomationTest.Core.Services
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageListItemPO>> GetPackageListItems();
        void AddPackage(PackageDTO package);
        void EditPackage(PackageDTO package);
        void DeletePackage(PackageListItemPO package);
        PackageDTO GetPackage(PackageListItemPO package);
    }
}