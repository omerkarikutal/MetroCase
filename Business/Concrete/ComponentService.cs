using Business.Abstract;
using Core.Model;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ComponentService : IComponentService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IWasteKindRepository _kindRepository;
        private readonly IWasteTypeRepository _typeRepository;
        public ComponentService(IStoreRepository storeRepository,
            IUnitRepository unitRepository,
            ICompanyRepository companyRepository,
            IWasteKindRepository kindRepository,
            IWasteTypeRepository typeRepository)
        {
            _storeRepository = storeRepository;
            _unitRepository = unitRepository;
            _companyRepository = companyRepository;
            _kindRepository = kindRepository;
            _typeRepository = typeRepository;
        }
        public async Task<BaseResponse<WastePageDropdown>> GetAllDropdown()
        {
            var stores = await _storeRepository.GetAllAsync();
            var units = await _unitRepository.GetAllAsync();
            var companies = await _companyRepository.GetAllAsync();
            var types = await _typeRepository.GetAllAsync();
            var kinds = await _kindRepository.GetAllAsync();


            var result = new WastePageDropdown
            {
                Companies = companies.Data.Select(s => new Dropdown { Text = s.Name, Value = s.Id }).ToList(),
                Kinds = kinds.Data.Select(s => new Dropdown { Text = s.Name, Value = s.Id }).ToList(),
                Stores = stores.Data.Select(s => new Dropdown { Text = s.Name, Value = s.Id }).ToList(),
                Units = units.Data.Select(s => new Dropdown { Text = s.Name, Value = s.Id }).ToList(),
                Types = types.Data.Select(s => new Dropdown { Text = s.Name, Value = s.Id }).ToList(),
            };

            return new BaseResponse<WastePageDropdown>().Success(result);
        }
    }
}
