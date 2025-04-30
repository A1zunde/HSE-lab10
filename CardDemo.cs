using System;
using lab10Classes;
using System.Collections;

namespace lab10
{
    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            DemoP1();
            DemoP2();
            DemoP3();
        }

        static void DemoP1()
        {
            BankCard[] cards = new BankCard[20];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = GenerateRandomCard(rnd);
                cards[i].RandomInit();
            }

            Console.WriteLine("Просмотр массива:");
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Show();
                Console.WriteLine();
            }
        }

        static void DemoP2()
        {
            BankCard[] cards = new BankCard[20];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = GenerateRandomCard(rnd);
                cards[i].RandomInit();
            }

            decimal totalCreditLimit;
            bool hasCreditLimit = GetTotalCreditCardLimit(cards, out totalCreditLimit);
            if (hasCreditLimit)
                Console.WriteLine("1. Общий лимит по кредитным картам: " + totalCreditLimit);
            else
                Console.WriteLine("1. Нет кредитных карт для расчета лимита");

            Console.WriteLine("\n2. Общая сумма сбережений на дебетовых картах");
            decimal count;
            bool isBalance = GetTotalDebitCardBalance(cards, out count);
            Console.WriteLine(count);

            int averageRepaymentPeriod;
            bool hasAveragePeriod = GetAverageCreditCardRepaymentPeriod(cards, out averageRepaymentPeriod);
            if (hasAveragePeriod)
                Console.WriteLine("\n3. Средний срок погашения по кредитным картам: " + averageRepaymentPeriod + " месяцев");
            else
                Console.WriteLine("\n3. Нет кредитных карт для расчета срока погашения");

            CreditCard maxLimitCard = GetMaxLimitCreditCard(cards);
            if (maxLimitCard != null)
            {
                Console.WriteLine("\n4. Кредитная карта с максимальным лимитом:");
                maxLimitCard.Show();
            }
            else
            {
                Console.WriteLine("\n4. Нет кредитных карт для поиска максимального лимита");
            }
        }

        public static bool GetTotalCreditCardLimit(BankCard[] cards, out decimal totalLimit)
        {
            totalLimit = 0;
            int count = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                CreditCard creditCard = cards[i] as CreditCard;
                if (creditCard != null)
                {
                    totalLimit += creditCard.Limit;
                    count++;
                }
            }
            return count > 0;
        }

        public static bool GetTotalDebitCardBalance(BankCard[] cards, out decimal totalBalance)
        {
            totalBalance = 0;
            int count = 0;

            for (int i = 0; i < cards.Length; i++)
            {
                DebitCard debitCard = cards[i] as DebitCard;
                if (debitCard != null)
                {
                    totalBalance += debitCard.Balance;
                    count++;
                }
            }

            return count > 0;
        }


        public static bool GetAverageCreditCardRepaymentPeriod(BankCard[] cards, out int averagePeriod)
        {
            averagePeriod = 0;
            int totalPeriod = 0;
            int count = 0;

            for (int i = 0; i < cards.Length; i++)
            {
                CreditCard creditCard = cards[i] as CreditCard;
                if (creditCard != null)
                {
                    totalPeriod += creditCard.MaturityDate;
                    count++;
                }
            }

            if (count > 0)
            {
                averagePeriod = totalPeriod / count;
                return true;
            }
            return false;
        }

        public static CreditCard GetMaxLimitCreditCard(BankCard[] cards)
        {
            CreditCard maxCard = null;
            decimal maxLimit = -1;

            for (int i = 0; i < cards.Length; i++)
            {
                CreditCard creditCard = cards[i] as CreditCard;
                if (creditCard != null)
                {
                    if (creditCard.Limit > maxLimit)
                    {
                        maxLimit = creditCard.Limit;
                        maxCard = creditCard;
                    }
                }
            }

            return maxCard;
        }

        static void DemoP3()
        {
            lab9ElementsShowcase();
            CloningShowcase();
        }

        static void lab9ElementsShowcase()
        {
            IInit[] objects = new IInit[20];
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = GenerateRandomInitObject(rnd);
                objects[i].RandomInit();
            }

            int bankCardCount = 0;
            int debitCardCount = 0;
            int youthCardCount = 0;
            int creditCardCount = 0;
            int geoCoordinatesCount = 0;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is YouthCard)
                    youthCardCount++;
                else if (objects[i] is CreditCard)
                    creditCardCount++;
                else if (objects[i] is DebitCard)
                    debitCardCount++;
                else if (objects[i] is BankCard)
                    bankCardCount++;
                else if (objects[i] is GeoCoordinates)
                    geoCoordinatesCount++;
            }

            Console.WriteLine("\nПодсчет объектов каждого типа:");
            Console.WriteLine("Банковских карт: " + bankCardCount);
            Console.WriteLine("Дебетовых карт: " + debitCardCount);
            Console.WriteLine("Молодёжных карт: " + youthCardCount);
            Console.WriteLine("Кредитных карт: " + creditCardCount);
            Console.WriteLine("Геокоординат: " + geoCoordinatesCount);

            SortBinaryV1();
        }

        static void SortBinaryV1()
        {
            GeoCoordinates[] geoArray = new GeoCoordinates[10];
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i] = new GeoCoordinates();
                geoArray[i].RandomInit();
            }

            Array.Sort(geoArray);

            Console.WriteLine("Отсортированный массив GeoCoordinates:");
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i].PrintCoordinates();
            }

            Console.WriteLine();

            Random rand = new Random();
            GeoCoordinates searchGeo = geoArray[rand.Next(geoArray.Length)];
            int index = Array.BinarySearch(geoArray, searchGeo);
            if (index >= 0)
            {
                Console.WriteLine("Объект найден на позиции " + index + ":");
                geoArray[index].PrintCoordinates();
            }
            else
            {
                Console.WriteLine("Объект не найден.");
            }

            SortBinaryV2();
        }

        static void SortBinaryV2()
        {
            GeoCoordinates[] geoArray = new GeoCoordinates[10];
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i] = new GeoCoordinates();
                geoArray[i].RandomInit();
            }

            Array.Sort(geoArray, new LongitudeComparer());

            Console.WriteLine("Отсортированный массив GeoCoordinates по долготе:");
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i].PrintCoordinates();
            }

            Console.WriteLine();

            GeoCoordinates searchGeo = geoArray[rnd.Next(geoArray.Length)];
            int index = Array.BinarySearch(geoArray, searchGeo, new LongitudeComparer());
            if (index >= 0)
            {
                Console.WriteLine("Объект найден на позиции " + index + ":");
                geoArray[index].PrintCoordinates();
            }
            else
            {
                Console.WriteLine("Объект не найден.");
            }
        }

        static void CloningShowcase()
        {
            BankCard bankCard = new BankCard();
            bankCard.RandomInit();
            bankCard.OwnerName = "Alexei Alexandrovich";
            bankCard.CardNumber = "1234123412341234";

            DebitCard debitCard = new DebitCard();
            debitCard.RandomInit();
            debitCard.Balance = 0;

            YouthCard youthCard = new YouthCard();
            youthCard.RandomInit();
            youthCard.Cashback = 10;

            CreditCard creditCard = new CreditCard();
            creditCard.RandomInit();
            creditCard.Limit = 20000;

            BankCard clonedBankCard = (BankCard)bankCard.Clone();
            DebitCard clonedDebitCard = (DebitCard)debitCard.Clone();
            YouthCard clonedYouthCard = (YouthCard)youthCard.Clone();
            CreditCard clonedCreditCard = (CreditCard)creditCard.Clone();

            BankCard shallowBankCard = bankCard.ShallowCopy();
            DebitCard shallowDebitCard = (DebitCard)debitCard.ShallowCopy();
            YouthCard shallowYouthCard = (YouthCard)youthCard.ShallowCopy();
            CreditCard shallowCreditCard = (CreditCard)creditCard.ShallowCopy();

            Console.WriteLine("\nОригиналы:");
            bankCard.Show();
            debitCard.Show();
            youthCard.Show();
            creditCard.Show();

            Console.WriteLine("\nГлубокие копии:");
            clonedBankCard.Show();
            clonedDebitCard.Show();
            clonedYouthCard.Show();
            clonedCreditCard.Show();

            Console.WriteLine("\nПоверхностные копии:");
            shallowBankCard.Show();
            shallowDebitCard.Show();
            shallowYouthCard.Show();
            shallowCreditCard.Show();
        }

        static BankCard GenerateRandomCard(Random rnd)
        {
            int cardType = rnd.Next(0, 4);
            if (cardType == 0)
                return new BankCard();
            else if (cardType == 1)
                return new DebitCard();
            else if (cardType == 2)
                return new YouthCard();
            else
                return new CreditCard();
        }

        static IInit GenerateRandomInitObject(Random rnd)
        {
            int type = rnd.Next(0, 5);
            if (type == 0)
                return new BankCard();
            else if (type == 1)
                return new DebitCard();
            else if (type == 2)
                return new YouthCard();
            else if (type == 3)
                return new CreditCard();
            else
                return new GeoCoordinates();
        }
    }
}
