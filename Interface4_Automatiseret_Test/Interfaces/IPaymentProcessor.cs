using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface4_Automatiseret_Test.Interfaces
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }
}
