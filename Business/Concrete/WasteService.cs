using Business.Abstract;
using Core.Entity;
using Core.Model;
using DataAccess.Abstract;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WasteService : IWasteService
    {
        private readonly IWasteRepository _repository;
        public WasteService(IWasteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> AddOrEdit(WasteUpdateDto update)
        {
            var data = update.Adapt<Waste>();
            if (data.Id == 0)
                return await _repository.AddAsync(data);
            else
                return await _repository.UpdateAsync(data);
        }

        public async Task<BaseResponse<int>> Delete(WasteDeleteDto dto)
        {
            var data = await _repository.GetAsync(s => s.Id == dto.Id);

            if (!data.Status)
                return new BaseResponse<int>().Fail(data.ErrorMessage);

            data.Data.IsActive = false;

            return await _repository.UpdateAsync(data.Data);
        }

        public async Task<BaseResponse<List<Waste>>> GetAll()
        {
            return await _repository.GetAllAsync(s => s.IsActive == true,
                x => x.Unit, x => x.Company, x => x.Store, x => x.WasteKind, x => x.WasteType);
        }

        public async Task<BaseResponse<WasteUpdateDto>> GetById(int id)
        {
            var data = await _repository.GetAsync(s => s.Id == id);

            var result = data.Data.Adapt<WasteUpdateDto>();

            return new BaseResponse<WasteUpdateDto>().Success(result);
        }
    }
}
