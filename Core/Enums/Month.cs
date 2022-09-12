using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum Month
    {
        [Description("Ocak")]
        Ocak = 1,
        [Description("Şubat")]
        Subat,
        [Description("Mart")]
        Mart,
        [Description("Nisan")]
        Nisan,
        [Description("Mayıs")]
        Mayis,
        [Description("Haziran")]
        Haziran,
        [Description("Temmuz")]
        Temmuz,
        [Description("Ağustos")]
        Agustos,
        [Description("Eylül")]
        Eylul,
        [Description("Ekim")]
        Ekim,
        [Description("Kasım")]
        Kasim,
        [Description("Aralık")]
        Aralik
    }
}
