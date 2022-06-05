using cc.validator.data.core;
using cc.validator.data.core.Enum;
using cc.validator.data.core.Models;
using cc.validator.data.core.Settings;
using cc.validator.manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cc.validator.manager.Manager
{
    public class CCManager : ICCManager
    {
        private CCConfigsRegex _configs;
        public CCManager(CCConfigsRegex configs)
        {
            _configs = configs;
        }
        /// <summary>
        /// This method is used to validate and generate the response object based on the request
        /// </summary>
        /// <param name="creditCardRequestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreditCardResponseModel ValidateCreditCard(CreditCardRequestModel creditCardRequestModel)
        {
            if (creditCardRequestModel == null || string.IsNullOrWhiteSpace(creditCardRequestModel.CardNumber)) throw new Exception();

            CreditCardResponseModel response = ValidateCreditCardDigits(creditCardRequestModel.CardNumber);
            ValidateFormattedText(response);
            response.Type = FindCardType(response.NumberFormatted).ToString();
            return response;
        }

        /// <summary>
        /// This method is used to validate the number of digits in the cerdit card.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns>return credit card response object with formatted credit card number</returns>
        private CreditCardResponseModel ValidateCreditCardDigits(string creditCardNumber)
        {
            StringBuilder stringBuilder = new();

            foreach (char character in creditCardNumber)
            {
                if (Char.IsDigit(character))
                    stringBuilder.Append(character);
            }

            CreditCardResponseModel creditCardInfo = new()
            {
                NumberText = creditCardNumber,
                NumberFormatted = stringBuilder.ToString(),
                IsValid = stringBuilder != null
            };

            return creditCardInfo;
        }

        /// <summary>
        /// This method is used to check the validity of the formatted credit card number. use Luhn algorythm for validation check.
        /// </summary>
        /// <param name="creditCardResponseModel"></param>
        /// <returns> returns the validated credit card info</returns>
        private void ValidateFormattedText(CreditCardResponseModel creditCardResponseModel)
        {
            // revers the formatted credit card number
            string reversNumber = ReverseString(creditCardResponseModel.NumberFormatted);
            int total = 0;
            for (int i=0;i< reversNumber.Length;i++)
            {
                int tempValue = (int)(reversNumber[i] - '0');
                if (!(i== 0  || i % 2 == 0))                
                {
                    // If doubling of a number results in a two digits number, add up
                    // the digits to get a single digit number
                    tempValue = tempValue * 2;
                    if (tempValue > 9)
                    {
                        tempValue = tempValue % 10 + 1;
                    }
                }
                //Get the sum of the digits
                total += tempValue;
            }
           
            creditCardResponseModel.IsValid = total % 10 == 0;
        }

        /// <summary>
        /// this method is used to revers the given number
        /// </summary>
        /// <param name="number"> number which need to revers</param>
        /// <returns>revers the given number</returns>
        private string ReverseString(string number)
        {
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// this method is used to identify the card type.
        /// </summary>
        /// <param name="cardNumber">pass the formatted card number</param>
        /// <returns>card type</returns>
        /// <exception cref="Exception"></exception>
        private CardTypeEnum FindCardType(string cardNumber)
        {
            int cardNumberLength = cardNumber.Length;
            if (Regex.Match(cardNumber, _configs.Visa).Success && (cardNumberLength == Constant.VISA_1 || cardNumberLength == Constant.VISA_2))
            {
                return CardTypeEnum.Visa;
            }

            if (Regex.Match(cardNumber, _configs.Master).Success && cardNumberLength == Constant.MASTER)
            {
                return CardTypeEnum.MasterCard;
            }

            if (Regex.Match(cardNumber, _configs.Amex).Success && cardNumberLength == Constant.AMEX)
            {
                return CardTypeEnum.Amex;
            }

            if (Regex.Match(cardNumber, _configs.Discover).Success && cardNumberLength == Constant.DISCOVER)
            {
                return CardTypeEnum.Discover;
            }

            return CardTypeEnum.Unknown;
        }
    }

    
}
