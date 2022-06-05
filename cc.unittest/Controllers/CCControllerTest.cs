using cc.host.validator.Controllers;
using cc.unittest.Mock;
using cc.validator.data.core.Models;
using cc.validator.manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace cc.unittest.Controllers
{
    public class CCControllerTest
    {
        private readonly Mock<ICCManager> _creditCardManagerMock = new();
        private CCController _creditCardController;

        public CCControllerTest()
        {
            //mock credit card manager ValidateCreditCards method
            _creditCardManagerMock.Setup(x => x.ValidateCreditCard(It.IsAny<CreditCardRequestModel>()))
                .Returns(MockData.GetTestCreditCardInfo());
        }

        [Fact()]
        public void Should_ReturnValidCreditCardInfo_When_ValidateCreditCard()
        {
            _creditCardController = new CCController(_creditCardManagerMock.Object);
            
            var actionResult = _creditCardController.ValidateCreditCard(MockData.SendTestCreditCard()) as OkObjectResult;
            var result = actionResult.Value as CreditCardResponseModel;

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }
    }
}
