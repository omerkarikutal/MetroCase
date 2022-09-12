using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class WasteAddDto
    {
        public int Month { get; set; }
        public int StoreId { get; set; }
        public int WasteTypeId { get; set; }
        public int WasteKingId { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public int DeliveryCompany { get; set; }
        public DateTime WasteDate { get; set; }
    }
}
