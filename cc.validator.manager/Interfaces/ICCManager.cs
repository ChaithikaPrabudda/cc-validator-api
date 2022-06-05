using cc.validator.data.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.validator.manager.Interfaces
{
    public interface ICCManager
    {
        CreditCardResponseModel ValidateCreditCard(CreditCardRequestModel creditCardRequestModel);
    }
}
