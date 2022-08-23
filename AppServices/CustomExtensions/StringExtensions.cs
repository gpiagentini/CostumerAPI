using System;
using System.Text.RegularExpressions;

namespace AppServices.CustomExtensions
{
    public static class StringExtensions
    {
        public static bool IsValidCPF(this string document)
        {
            var documentValidator = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$");
            if (document == null) return false;
            if (!documentValidator.IsMatch(document)) return false;
            else
            {
                document = Regex.Replace(document, @"[\.,\-]+","");
                var mainDigits = document.Substring(0, 9);
                var firstDigitChecker = 0;
                var secondDigitChecker = 0;
                for (var i = 0; i < mainDigits.Length; i++)
                {
                    firstDigitChecker += mainDigits.GetIntFromIndex(i) * (10 - i);
                }
                firstDigitChecker = firstDigitChecker % 11 < 2 ? 0 : 11 - (firstDigitChecker % 11);
                mainDigits = mainDigits + firstDigitChecker.ToString();
                for (var i = 0; i < mainDigits.Length; i++)
                {
                    secondDigitChecker += mainDigits.GetIntFromIndex(i) * (11 - i);
                }
                secondDigitChecker = secondDigitChecker % 11 < 2 ? 0 : 11 - (secondDigitChecker % 11);
                var digitCheckerValidation = document.GetIntFromIndex(9).Equals(firstDigitChecker) && document.GetIntFromIndex(10).Equals(secondDigitChecker);
                return digitCheckerValidation;
            }
        }

        public static bool IsValidCellphone(this string cellphone)
        {
            if (cellphone == null) return false;
            var cellphoneValidator = new Regex(@"^\(?\d{2}\)? ?\d?\d{4}\-?\d{4}$");
            return cellphoneValidator.IsMatch(cellphone);
        }

        public static bool IsValidPostalCode(this string postalCode)
        {
            if (postalCode == null) return false;
            var postalCodeValidator = new Regex(@"^\d{5}\-?\d{3}$");
            return postalCodeValidator.IsMatch(postalCode);
        }

        public static int GetIntFromIndex(this string text, int index)
        {
            try
            {
                return (int) Char.GetNumericValue(text[index]);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }
    }
}
