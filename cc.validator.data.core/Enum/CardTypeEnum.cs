using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.validator.data.core.Enum
{
    public enum CardTypeEnum
    {
        [Description("Amex")]
        Amex = 1,

        [Description("Discover")]
        Discover,

        [Description("Master Card")]
        MasterCard,

        [Description("Visa")]
        Visa,

        [Description("Unknown")]
        Unknown
    }
}
