using Interface4_Automatiseret_Test.Classes;

namespace Interface4_Automatiseret_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCardProcessor creditCardProcessor_Object = new CreditCardProcessor();
            MobilePayProcessor mobilePayProcessor_Object = new MobilePayProcessor();
            EMailService eMailService_Object = new EMailService();

            /* Linjen herunder gør brug af den første Constructor i CheckoutManager, og den overholder 
             * derfor alle principperne i SOLID.
             * Vi sender en klasse der implementerer IPaymentProcessor (CreditCardProcessor) og
             * ingen klasse der implementerer INotifier, da denne parameter er optional. */
            CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);

            /* Linjen herunder gør brug af den anden Constructor i CheckoutManager, 
             * og den overholder derfor ikke alle principperne i SOLID.
             * Vi sender en klasse der implementerer IAdvancedPaymentProvider (MobilePayProcessor), 
             * som både implementerer IPaymentProcessor og INotifier. */
            CheckoutManager checkoutManager_Object1 = new CheckoutManager(mobilePayProcessor_Object);

            /* Linjen herunder gør brug af den første Constructor i CheckoutManager, 
             * og den overholder derfor alle principperne i SOLID.
             * Vi sender en klasse der implementerer IPaymentProcessor (MobilePayProcessor) 
             * og en klasse der implementerer INotifier (EMailService). */
            CheckoutManager checkoutManager_Object2 = new CheckoutManager(mobilePayProcessor_Object, eMailService_Object);

            // Linjen herunder giver compiler fejl, da CheckoutManager's constructor kræver en IPaymentProcessor,
            // og EMailService implementerer ikke dette interface.
            //CheckoutManager checkoutManager_Object3 = new CheckoutManager(eMailService_Object);

            Console.WriteLine();
            checkoutManager_Object.CompleteOrder(500);
            Console.WriteLine();
            checkoutManager_Object1.CompleteOrder(250);
            Console.WriteLine();
            checkoutManager_Object2.CompleteOrder(1000);

            Console.ReadKey();
        }
    }
}
