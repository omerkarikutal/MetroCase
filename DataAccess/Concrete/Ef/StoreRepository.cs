using Core.DataAccess.Ef;
using Core.Entity;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Ef
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(MetroContext context) : base(context)
        {

        }
    }
}
