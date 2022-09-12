using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Rest
{
    public interface IRestService
    {
        Task<BaseResponse<T>> Get<T>(string url);
        Task<BaseResponse<T>> Post<T>(string url, object data);
    }
}
