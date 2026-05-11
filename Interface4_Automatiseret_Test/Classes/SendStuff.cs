using Interface4_Automatiseret_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface4_Automatiseret_Test.Classes
{
    public class SendStuff : INotifier    
    {
        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender gå hjem besked til h1pd040126: {message}... (klasse SendStuff)");
        }
    }
}
