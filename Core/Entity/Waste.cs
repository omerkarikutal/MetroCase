using Core.Enums;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Waste
    {
        public int Id { get; set; }
        public Month Month { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int WasteTypeId { get; set; }
        public virtual WasteType WasteType { get; set; }
        public int WasteKindId { get; set; }
        public virtual WasteKind WasteKind { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        [ForeignKey("Company")]
        public int DeliveryCompanyId { get; set; }
        public virtual Company Company { get; set; }
        public DateTime WasteDate { get; set; }
        public bool IsActive { get; set; }
        public string WasteDateString
        {
            get
            {

                return this.WasteDate.ToString("dd/MM/yyyy");
            }
        }
        public string MonthString
        {
            get
            {

                return this.Month.DescriptionAttr();
            }
        }
        public string Content { get; set; }
    }
}
