using Core.Entity;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWasteService
    {
        Task<BaseResponse<List<Waste>>> GetAll();
        Task<BaseResponse<int>> Delete(WasteDeleteDto dto);
        Task<BaseResponse<WasteUpdateDto>> GetById(int id);
        Task<BaseResponse<int>> AddOrEdit(WasteUpdateDto update);
    }
}
