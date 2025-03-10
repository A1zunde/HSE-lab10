using System;
using System.ComponentModel.Design;
using lab10Classes;

namespace lab10
{
    class Program
    {
        static void Main()
        {
            DemoP1();

            DemoP2();
        }

        static void DemoP1()
        {
            Random rnd = new Random();
            BankCard[] cards = new BankCard[20];

            for (int i = 0; i < cards.Length; i++)
            {
                int cardType = rnd.Next(0, 4);

                switch (cardType)
                {
                    case 0:
                        cards[i] = new BankCard();
                        break;
                    case 1:
                        cards[i] = new DebitCard();
                        break;
                    case 2:
                        cards[i] = new YouthCard();
                        break;
                    case 3:
                        cards[i] = new CreditCard();
                        break;
                }

                cards[i].RandomInit();
            }


            Console.WriteLine("Просмотр массива с помощью виртуальных функций:");
            foreach (var card in cards)
            {
                card.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Просмотр массива с помощью обычных функций:");
            foreach (var card in cards)
            {
                card.NonVirtualShow();
                Console.WriteLine();
            }
        }

        static void DemoP2()
        {
            BankCard[] cards = new BankCard[20];
            Random rnd = new();
            for (int i = 0; i < cards.Length; i++)
            {
                int cardType = rnd.Next(0, 4);
                switch (cardType)
                {
                    case 0:
                        cards[i] = new BankCard();
                        break;
                    case 1:
                        cards[i] = new DebitCard();
                        break;
                    case 2:
                        cards[i] = new YouthCard();
                        break;
                    case 3:
                        cards[i] = new CreditCard();
                        break;
                }
                cards[i].RandomInit();
            }

            decimal totalCreditLimit = GetTotalCreditCardLimit(cards);
            Console.WriteLine($"1. Общий лимит по кредитным картам: {totalCreditLimit}\n");

            Console.WriteLine("\n2. Количество карт каждого типа:\n");
            CountCardsByType(cards);

            int averageRepaymentPeriod = GetAverageCreditCardRepaymentPeriod(cards);
            Console.WriteLine($"\n3. Средний срок погашения по кредитным картам: {averageRepaymentPeriod} месяцев");
        }

        public static int GetTotalCreditCardLimit(BankCard[] cards)
        {
            int totalLimit = 0;

            foreach (var card in cards)
            {
                if (card is CreditCard creditCard)
                {
                    totalLimit += creditCard.Limit;
                }
            }

            return totalLimit;
        }

        public static void CountCardsByType(BankCard[] cards)
        {
            int bankCardCount = 0;
            int debitCardCount = 0;
            int youthCardCount = 0;
            int creditCardCount = 0;

            foreach (var card in cards)
            {
                if (card is BankCard && !(card is DebitCard)) { bankCardCount++; }
                if (card is DebitCard) { debitCardCount++; }
                if (card is YouthCard) { youthCardCount++; }
                if (card is CreditCard) { creditCardCount++; }
            }

            Console.WriteLine($"Банковских карт: {bankCardCount}");
            Console.WriteLine($"Дебетовых карт: {debitCardCount}");
            Console.WriteLine($"Молодёжных карт: {youthCardCount}");
            Console.WriteLine($"Кредитных карт: {creditCardCount}");
        }

        public static int GetAverageCreditCardRepaymentPeriod(BankCard[] cards)
        {
            int totalPeriod = 0;
            int creditCardCount = 0;

            foreach (var card in cards)
            {
                if (card is CreditCard creditCard)
                {
                    totalPeriod += creditCard.MaturityDate;
                    creditCardCount++;
                }
            }

            return creditCardCount > 0 ? totalPeriod / creditCardCount : 0;
        }
    }
}