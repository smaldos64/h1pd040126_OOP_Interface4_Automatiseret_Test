using Interface4_Automatiseret_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface4_Automatiseret_Test.Classes
{
    // Single Responsibility Principle (S i SOLID) overholdes ikke, 
    // da denne klasse har to funktionaliteter:
    // at behandle MobilePay-overførsler
    // og at sende kvitteringer via MobilePay.

    //public class MobilePayProcessor : IPaymentProcessor, INotifier
    public class MobilePayProcessor : IAdvancedPaymentProvider
    {
        private decimal _amountSent = 0; 

        public decimal AmountSent
        {
            get { return _amountSent; }
            set { _amountSent = value; }    
        }

        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Behandler MobilePay-overførsel på {amount} kr... (klasse MobilePayProcessor)");
            this._amountSent += amount + 5; // Opdaterer den ekstra funktionalitet, som ikke er relateret til betalingsbehandling
        }

        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender kvittering via MobilePay: {message}... (klasse MobilePayProcessor)");
        }
    }
}
