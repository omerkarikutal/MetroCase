using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class WastePageDropdown
    {
        public List<Dropdown> Stores { get; set; }
        public List<Dropdown> Units { get; set; }
        public List<Dropdown> Companies { get; set; }
        public List<Dropdown> Types { get; set; }
        public List<Dropdown> Kinds { get; set; }

    }
    public class Dropdown
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
