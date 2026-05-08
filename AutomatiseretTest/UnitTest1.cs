

using Interface4_Automatiseret_Test.Classes;

namespace AutomatiseretTest
{
    public class UnitTest1
    {
        CreditCardProcessor creditCardProcessor_Object = new CreditCardProcessor();
        MobilePayProcessor mobilePayProcessor_Object = new MobilePayProcessor();
        EMailService eMailService_Object = new EMailService();

        [Fact]
        public void UsingCreditCardProcessorShouldPass()
        {
            // Arrange
            creditCardProcessor_Object.AmountSent = 0;

            //Act
            CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);

            checkoutManager_Object.CompleteOrder(500);

            // Assert
            Assert.Equal(510, creditCardProcessor_Object.AmountSent);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(1000)]
        [InlineData(1500)]
        [InlineData(2000)]
        public void MultipleUsingCreditCardProcessorShouldPass(decimal amount)
        {
            // Arrange
            creditCardProcessor_Object.AmountSent = 0;

            //Act
            CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);

            checkoutManager_Object.CompleteOrder(amount);

            // Assert
            Assert.Equal(amount + 10, creditCardProcessor_Object.AmountSent);
        }

        [Theory]
        [InlineData(250)]
        [InlineData(500)]
        [InlineData(1000)]
        public void MultipleUsingMultipleUsingCreditCardProcessorShouldPass2(decimal amount)
        {
            // Arrange
            decimal originalAmount = amount;
            decimal increaseAmount = 100;

            creditCardProcessor_Object.AmountSent = 0;

            //Act
            CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);
            checkoutManager_Object.CompleteOrder(amount);
            amount += increaseAmount;
            checkoutManager_Object.CompleteOrder(amount);
            amount += increaseAmount;
            checkoutManager_Object.CompleteOrder(amount);

            // Assert
            Assert.Equal((originalAmount + 10) +
                         (originalAmount + 10 + increaseAmount) +
                         (originalAmount + 10 + 2 * increaseAmount), creditCardProcessor_Object.AmountSent);
        }

        [Fact]
        public void UsingMobilePayProcessorShouldPass()
        {
            // Arrange
            mobilePayProcessor_Object.AmountSent = 0;

            //Act
            CheckoutManager checkoutManager_Object = new CheckoutManager(mobilePayProcessor_Object);
            checkoutManager_Object.CompleteOrder(250);

            // Assert
            Assert.Equal(255, mobilePayProcessor_Object.AmountSent);
        }

        [Fact]
        public void MethodSholdFailDueToContinousIntegrationDeliveryCallback()
        {
            // Arrange
            mobilePayProcessor_Object.AmountSent = 0;

            //Act
            CheckoutManager checkoutManager_Object = new CheckoutManager(mobilePayProcessor_Object);
            checkoutManager_Object.CompleteOrder(250);

            // Assert
            Assert.Equal(250, mobilePayProcessor_Object.AmountSent);
        }
    }
}
