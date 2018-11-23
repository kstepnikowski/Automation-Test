using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationTest.Core.Models.PO;

namespace AutomationTest.Core.Services
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageListItemPO>> GetPackageListItems();
    }
}