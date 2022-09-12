using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class WasteUpdateDto
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int StoreId { get; set; }
        public int WasteTypeId { get; set; }
        public int WasteKindId { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public int DeliveryCompanyId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime WasteDate { get; set; } = DateTime.Now;
        public string Content { get; set; }
    }
}
