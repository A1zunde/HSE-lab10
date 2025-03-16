using lab10Classes;

namespace lab10Test
{
    public class TestClass
    {
        [Fact]
        public void TestBankCardConstructor()
        {
            var card = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));

            Assert.Equal("1234567890123456", card.CardNumber);
            Assert.Equal("John Doe", card.OwnerName);
            Assert.True(card.ValidityPeriod > DateTime.Now);
        }

        [Fact]
        public void TestBankCardOwnerNameValidation()
        {
            var card = new BankCard();

            card.OwnerName = "John Doe";
            Assert.Equal("John Doe", card.OwnerName);

            Assert.Throws<ArgumentException>(() => card.OwnerName = null);
        }

        [Fact]
        public void TestBankCardValidityPeriodValidation()
        {
            var card = new BankCard();

            card.ValidityPeriod = DateTime.Now.AddYears(3);
            Assert.True(card.ValidityPeriod > DateTime.Now);

            Assert.Throws<ArgumentException>(() => card.ValidityPeriod = DateTime.Now.AddDays(-1));
        }

        [Fact]
        public void TestBankCardShow()
        {
            var card = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            card.Show();
        }

        [Fact]
        public void TestBankCardNonVirtualShow()
        {
            var card = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            card.NonVirtualShow();
        }

        [Fact]
        public void TestBankCardEquals()
        {
            var card1 = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            var card2 = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            var card3 = new BankCard("9876543210987654", "Jane Smith", DateTime.Now.AddYears(2));

            Assert.True(card1.Equals(card2));
            Assert.False(card1.Equals(card3));
        }

        [Fact]
        public void TestBankCardClone()
        {
            var card = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            var clonedCard = (BankCard)card.Clone();

            Assert.Equal(card.CardNumber, clonedCard.CardNumber);
            Assert.Equal(card.OwnerName, clonedCard.OwnerName);
            Assert.Equal(card.ValidityPeriod, clonedCard.ValidityPeriod);
        }

        [Fact]
        public void TestBankCardShallowCopy()
        {
            var card = new BankCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3));
            var shallowCard = card.ShallowCopy();

            Assert.Equal(card.CardNumber, shallowCard.CardNumber);
            Assert.Equal(card.OwnerName, shallowCard.OwnerName);
            Assert.Equal(card.ValidityPeriod, shallowCard.ValidityPeriod);
        }

        public void TestDebitCardConstructor()
        {
            var card = new DebitCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000);

            Assert.Equal("1234567890123456", card.CardNumber);
            Assert.Equal("John Doe", card.OwnerName);
            Assert.Equal(5000, card.Balance);
        }

        [Fact]
        public void TestDebitCardShow()
        {
            var card = new DebitCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000);
            card.Show();
        }

        [Fact]
        public void TestDebitCardEquals()
        {
            var card1 = new DebitCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000);
            var card2 = new DebitCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000);
            var card3 = new DebitCard("9876543210987654", "Jane Smith", DateTime.Now.AddYears(2), 1000);

            Assert.True(card1.Equals(card2));
            Assert.False(card1.Equals(card3));
        }

        [Fact]
        public void TestDebitCardClone()
        {
            var card = new DebitCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000);
            var clonedCard = (DebitCard)card.Clone();

            Assert.Equal(card.CardNumber, clonedCard.CardNumber);
            Assert.Equal(card.OwnerName, clonedCard.OwnerName);
            Assert.Equal(card.ValidityPeriod, clonedCard.ValidityPeriod);
            Assert.Equal(card.Balance, clonedCard.Balance);
        }

        [Fact]
        public void TestYouthCardConstructor()
        {
            var card = new YouthCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5);

            Assert.Equal("1234567890123456", card.CardNumber);
            Assert.Equal("John Doe", card.OwnerName);
            Assert.True(card.ValidityPeriod > DateTime.Now);
            Assert.Equal(5000, card.Balance);
            Assert.Equal(5, card.Cashback);
        }

        [Fact]
        public void TestYouthCardCashbackValidation()
        {
            var card = new YouthCard();

            card.Cashback = 10;
            Assert.Equal(10, card.Cashback);

            Assert.Throws<ArgumentException>(() => card.Cashback = 100);
        }

        [Fact]
        public void TestYouthCardShow()
        {
            var card = new YouthCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5);
            card.Show();
        }

        [Fact]
        public void TestYouthCardEquals()
        {
            var card1 = new YouthCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5);
            var card2 = new YouthCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5);
            var card3 = new YouthCard("9876543210987654", "Jane Smith", DateTime.Now.AddYears(2), 1000, 2);

            Assert.True(card1.Equals(card2));
            Assert.False(card1.Equals(card3));
        }

        [Fact]
        public void TestYouthCardClone()
        {
            var card = new YouthCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5);
            var clonedCard = (YouthCard)card.Clone();

            Assert.Equal(card.CardNumber, clonedCard.CardNumber);
            Assert.Equal(card.OwnerName, clonedCard.OwnerName);
            Assert.Equal(card.ValidityPeriod, clonedCard.ValidityPeriod);
            Assert.Equal(card.Balance, clonedCard.Balance);
            Assert.Equal(card.Cashback, clonedCard.Cashback);
        }

        [Fact]
        public void TestCreditCardConstructor()
        {
            var card = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5, 10000, 12);

            Assert.Equal("1234567890123456", card.CardNumber);
            Assert.Equal("John Doe", card.OwnerName);
            Assert.True(card.ValidityPeriod > DateTime.Now);
            Assert.Equal(5000, card.Balance);
            Assert.Equal(5, card.Cashback);
            Assert.Equal(10000, card.Limit);
            Assert.Equal(12, card.MaturityDate);
        }

        [Fact]
        public void TestCreditCardLimitValidation()
        {
            var card = new CreditCard();

            card.Limit = 10000;
            Assert.Equal(10000, card.Limit);

            Assert.Throws<ArgumentException>(() => card.Limit = -1000);
        }

        [Fact]
        public void TestCreditCardMaturityDateValidation()
        {
            var card = new CreditCard();

            card.MaturityDate = 12;
            Assert.Equal(12, card.MaturityDate);

            Assert.Throws<ArgumentException>(() => card.MaturityDate = -1);
        }

        [Fact]
        public void TestCreditCardShow()
        {
            var card = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5, 10000, 12);
            card.Show();
        }

        [Fact]
        public void TestCreditCardEquals()
        {
            var card1 = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5, 10000, 12);
            var card2 = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5, 10000, 12);
            var card3 = new CreditCard("9876543210987654", "Jane Smith", DateTime.Now.AddYears(2), 1000, 2, 5000, 6);

            Assert.True(card1.Equals(card2));
            Assert.False(card1.Equals(card3));
        }

        [Fact]
        public void TestCreditCardClone()
        {
            var card = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), 5000, 5, 10000, 12);
            var clonedCard = (CreditCard)card.Clone();

            Assert.Equal(card.CardNumber, clonedCard.CardNumber);
            Assert.Equal(card.OwnerName, clonedCard.OwnerName);
            Assert.Equal(card.ValidityPeriod, clonedCard.ValidityPeriod);
            Assert.Equal(card.Balance, clonedCard.Balance);
            Assert.Equal(card.Cashback, clonedCard.Cashback);
            Assert.Equal(card.Limit, clonedCard.Limit);
            Assert.Equal(card.MaturityDate, clonedCard.MaturityDate);
        }

    }
}