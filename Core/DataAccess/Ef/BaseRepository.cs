using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Ef
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
                where TEntity : class
    {
        protected readonly DbContext Context;
        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<BaseResponse<int>> AddAsync(TEntity entity)
        {
            try
            {
                var add = Context.Entry(entity);
                add.State = EntityState.Added;
                await Context.SaveChangesAsync();
                return new BaseResponse<int>().Success(1);
            }
            catch (Exception e)
            {
                return new BaseResponse<int>().Fail(e.Message);
            }
        }

        public async Task<BaseResponse<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking();

                if (filter != null)
                    query = query.Where(filter);

                if (includes.Length > 0)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
                var result = await query.ToListAsync();

                return new BaseResponse<List<TEntity>>().Success(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<List<TEntity>>().Fail(e.Message);
            }
        }

        public async Task<BaseResponse<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking();


                if (includes.Length > 0)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }

                var result = await query.FirstOrDefaultAsync(filter);
                if (result == null)
                    return new BaseResponse<TEntity>().Fail("Kayıt Bulunamadı");
                return new BaseResponse<TEntity>().Success(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>().Fail(e.Message);
            }
        }

        public async Task<BaseResponse<int>> UpdateAsync(TEntity entity)
        {
            try
            {
                var update = Context.Entry(entity);
                update.State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return new BaseResponse<int>().Success(1);

            }
            catch (Exception e)
            {
                return new BaseResponse<int>().Fail(e.Message);
            }
        }
    }
}
