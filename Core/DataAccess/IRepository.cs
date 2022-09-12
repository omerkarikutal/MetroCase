using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<BaseResponse<List<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<int>> AddAsync(T entity);
        Task<BaseResponse<int>> UpdateAsync(T entity);
        Task<BaseResponse<T>> GetAsync(Expression<Func<T, bool>> filter = null, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);
    }
}
