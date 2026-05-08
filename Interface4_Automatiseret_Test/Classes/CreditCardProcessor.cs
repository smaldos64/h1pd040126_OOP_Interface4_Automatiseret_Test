using Interface4_Automatiseret_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface4_Automatiseret_Test.Classes
{
    // Single Responsibility Principle (S i SOLID) overholdes,
    // da denne klasse kun har én funktionalitet: at behandle kortbetalinger.
    public class CreditCardProcessor : IPaymentProcessor
    {
        private decimal _amountSent = 0;

        public decimal AmountSent
        {
            get { return _amountSent; }
            set { _amountSent = value; }
        }
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Behandler kortbetaling på {amount} kr. via Nets... (klasse CreditCardProcessor)");
            this._amountSent += amount + 10;
        }
    }
}
