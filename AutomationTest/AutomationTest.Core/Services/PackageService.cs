using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly Realm _realm;

        public PackageService(IMapper mapper)
        {
            _mapper = mapper;
            _realm = Realm.GetInstance();
        }

        public async Task<IEnumerable<PackageListItemPO>> GetPackageListItems()
        {
            var packagesDTO = GetPackages();
            var packagesPO = _mapper.Map<ObservableCollection<PackageListItemPO>>(packagesDTO);

            return await Task.FromResult(packagesPO);
        }

        public void AddPackage(PackageDTO package)
        {
            _realm.Write(() => _realm.Add(package));
        }

        public void DeletePackage(PackageListItemPO package)
        {
            var packageDTO = _realm.All<PackageDTO>().First(x => x.Barcode.Equals(package.Barcode));

            using (var trans = _realm.BeginWrite())
            {
                _realm.Remove(packageDTO);
                trans.Commit();
            }  
        }

        private ObservableCollection<PackageDTO> GetPackages()
        {
            var data = _realm.All<PackageDTO>().OrderByDescending(x=>x.Barcode);
           
            return new ObservableCollection<PackageDTO>(data);
        }
    }
}
