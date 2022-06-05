using cc.unittest.Mock;
using cc.validator.data.core.Models;
using cc.validator.manager.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace cc.unittest.Manager
{
    public class CCManagerTest
    {
        private CCManager _creditCardManager;

        [Fact()]
        public void Should_ReturnValidCreditCardInfo_When_ValidateCreditCard()
        {
            _creditCardManager = new CCManager(MockData.ConfigData());

            var creditCardInfo = _creditCardManager.ValidateCreditCard(MockData.SendTestCreditCard()) as CreditCardResponseModel;

            Assert.NotNull(creditCardInfo);
            Assert.True(creditCardInfo.IsValid);
        }
    }
}
