using Interface4_Automatiseret_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface4_Automatiseret_Test.Classes
{
    // Single Responsibility Principle (S i SOLID) overholdes,    
    // da denne klasse kun har én funktionalitet:
    // at sende kvitteringer via E-mail.
    public class EMailService : INotifier
    {
        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender kvittering via E-mail: {message}... (klasse EMailService)");
        }
    }
}
