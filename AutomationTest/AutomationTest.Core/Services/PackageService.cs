using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutomationTest.Core.Models.DTO;
using AutomationTest.Core.Models.PO;
using AutoMapper;

namespace AutomationTest.Core.Services
{
    public class PackageService : IPackageService
    {
        private readonly IMapper _mapper;

        public PackageService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<PackageListItemPO>> GetPackageListItems()
        {
            var packagesDTO = GetPackagesMock();
            var packagesPO = _mapper.Map<ObservableCollection<PackageListItemPO>>(packagesDTO);

            return await Task.FromResult(packagesPO);
        }

        private ObservableCollection<PackageDTO> GetPackagesMock()
        {
            var packages = new ObservableCollection<PackageDTO>
            {
                new PackageDTO
                {
                    Barcode = "1ZW201410442765344",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765345",
                    Width = "13",
                    Height = "8",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765346",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765344",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765345",
                    Width = "13",
                    Height = "8",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765346",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765344",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765345",
                    Width = "13",
                    Height = "8",
                    Depth = "10"
                },
                new PackageDTO
                {
                    Barcode = "1ZW201410442765346",
                    Width = "10",
                    Height = "5",
                    Depth = "10"
                }
            };

            return packages;
        }
    }
}
