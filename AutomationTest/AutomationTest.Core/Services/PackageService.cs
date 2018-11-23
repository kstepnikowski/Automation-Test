using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.Core.Models.DTO;
using AutomationTest.Core.Models.PO;
using AutoMapper;
using Realms;

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
            var packagesDTO = GetPackages();
            var packagesPO = _mapper.Map<ObservableCollection<PackageListItemPO>>(packagesDTO);

            return await Task.FromResult(packagesPO);
        }

        private ObservableCollection<PackageDTO> GetPackages()
        {
            var realm = Realm.GetInstance();
            var data = realm.All<PackageDTO>();

            return new ObservableCollection<PackageDTO>(data);
        }
    }
}
