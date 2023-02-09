using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB090223
{
    class CreditCard
    {
        private string number;
        private string fullName;
        private string cvc;
        private DateTime expirationDate;

        public CreditCard(string number, string fullName, string cvc, DateTime expirationDate)
        {
            Number = number;
            FullName = fullName;
            CVC = cvc;
            ExpirationDate = expirationDate;
        }
        public string Number
        {
            get { return this.number; }
            set
            {
                if (value.Length == 3 && Regex.IsMatch(value, @"^\d{16}$"))
                {
                    throw new ArgumentException("The credit card number must be a 16-digit string.");
                }
                this.number = value;
                /*
                 * /d - цифра
                 * {n} - строго 16 раз
                 */
            }
        }


        public string FullName
        {
            get { return this.fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The full name cannot be empty or whitespace.");
                }

                Regex regex = new Regex(@"^[A-Z][a-z]+\s[A-Z]\.\s[A-Z].$");
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("The full name must be in the format: 'First Initial. Initial.'");
                }
                /*
                 * ^ - начало строки.
                 * [n - m] - символ из диапазона
                 * \w+ - один или несколько символов слова (буквы, цифры или символы подчеркивания).
                 * \s - один пробел.
                 * \. - один символ точки.
                 * $ - конец строки.
                 */

                this.fullName = value;
            }
        }

        public string CVC
        {
            get { return this.cvc; }
            set
            {
                if (value.Length == 3 && !Regex.IsMatch(value, @"^\d{3}$"))
                {
                    throw new ArgumentException("Credit card number must be a three-digit string.");
                }
                this.cvc = value;
            }
        }

        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("The expiration date cannot be in the past.");
                }
                this.expirationDate = value;
            }
        }

        public override string ToString()
        {
            return $"Number: {Number}\nFull Name: {FullName}\nCVC: {CVC}\nExpiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}
