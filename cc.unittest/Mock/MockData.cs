using cc.validator.data.core.Enum;
using cc.validator.data.core.Models;
using cc.validator.data.core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.unittest.Mock
{
    public class MockData
    {
        public static CreditCardResponseModel GetTestCreditCardInfo()
        {
            return new CreditCardResponseModel()
            {
                NumberText = "4111111111111111",
                NumberFormatted = "4111111111111111",
                Type = CardTypeEnum.Visa.ToString(),
                IsValid = true
            };

        }

        public static CreditCardRequestModel SendTestCreditCard()
        {
            return new CreditCardRequestModel()
            {
                CardNumber = "4111111111111111"
            };
        }

        public static CCConfigsRegex ConfigData()
        {
            return new CCConfigsRegex()
            {
                Amex = "^(34|37)",
                Discover = "^(6011)",
                Master = "^(51|52|53|54|55)",
                Visa = "^(4)"
            };
        }
    }
}
