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
    public class UnitRepository:BaseRepository<Unit>,IUnitRepository
    {
        public UnitRepository(MetroContext context) : base(context)
        {

        }
    }
}
