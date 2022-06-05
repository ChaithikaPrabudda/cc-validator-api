using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.validator.data.core.Models
{
    public class CreditCardResponseModel
    {
        public string NumberText { get; set; }
        public string NumberFormatted { get; set; }
        public bool IsValid { get; set; }
        public string Type { get; set; }
    }
}
