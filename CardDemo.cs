using System;
using System.ComponentModel.Design;
using System.Reflection;
using lab10Classes;

namespace lab10
{
    class Program
    {
        static void Main()
        {
            DemoP1();

            DemoP2();

            DemoP3();
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

        static void DemoP3()
        {
            lab9ElementsShowcase();

            CloningShowcase();
        }
        static void lab9ElementsShowcase()
        {
            object[] objects = new object[20];
            Random rnd = new Random();
            for (int i = 0; i < objects.Length; i++)
            {
                int type = rnd.Next(0, 5);
                switch (type)
                {
                    case 0:
                        objects[i] = new BankCard();
                        break;
                    case 1:
                        objects[i] = new DebitCard();
                        break;
                    case 2:
                        objects[i] = new YouthCard();
                        break;
                    case 3:
                        objects[i] = new CreditCard();
                        break;
                    case 4:
                        objects[i] = new GeoCoordinates();
                        break;
                }

                // Инициализация у каждого из созданных элементов
                if (objects[i] is IInit initObject)
                {
                    initObject.RandomInit();
                }
            }

            // Подсчет объектов каждого типа
            int bankCardCount = 0;
            int debitCardCount = 0;
            int youthCardCount = 0;
            int creditCardCount = 0;
            int geoCoordinatesCount = 0;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is BankCard)
                {
                    bankCardCount++;
                }
                else if (objects[i] is DebitCard)
                {
                    debitCardCount++;
                }
                else if (objects[i] is YouthCard)
                {
                    youthCardCount++;
                }
                else if (objects[i] is CreditCard)
                {
                    creditCardCount++;
                }
                else if (objects[i] is GeoCoordinates)
                {
                    geoCoordinatesCount++;
                }
            }

            // Вывод результатов подсчета
            Console.WriteLine("\nПодсчет объектов каждого типа:");
            Console.WriteLine($"Банковских карт: {bankCardCount}");
            Console.WriteLine($"Дебетовых карт: {debitCardCount}");
            Console.WriteLine($"Молодёжных карт: {youthCardCount}");
            Console.WriteLine($"Кредитных карт: {creditCardCount}");
            Console.WriteLine($"Геокоординат: {geoCoordinatesCount}");

            SortBinatyV1();
        }

        static void SortBinatyV1()
        {
            // Создание массвива координат
            GeoCoordinates[] geoArray = new GeoCoordinates[10];
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i] = new GeoCoordinates();
                geoArray[i].RandomInit();
            }

            // Сортировка массива
            Array.Sort(geoArray);

            // Вывод отсортированного массива
            Console.WriteLine("Отсортированный массив GeoCoordinates:");
            foreach (var geo in geoArray)
            {
                geo.PrintCoordinates();
            }

            // Бинарный поиск
            GeoCoordinates searchGeo = new GeoCoordinates();
            searchGeo.RandomInit();
            int index = Array.BinarySearch(geoArray, searchGeo);
            if (index >= 0)
            {
                Console.WriteLine($"Объект найден на позиции {index}");
            }
            else
            {
                Console.WriteLine("Объект не найден.");
            }

            SortBinatyV2();
        }

        static void SortBinatyV2()
        {
            // Создание массвива координат
            GeoCoordinates[] geoArray = new GeoCoordinates[10];
            for (int i = 0; i < geoArray.Length; i++)
            {
                geoArray[i] = new GeoCoordinates();
                geoArray[i].RandomInit();
            }
            GeoCoordinates searchGeo = new GeoCoordinates();
            searchGeo.RandomInit();

            // Сортировка по долготе
            Array.Sort(geoArray, new LongitudeComparer());

            // Вывод отсортированного массива
            Console.WriteLine("Отсортированный массив GeoCoordinates по долготе:");
            foreach (var geo in geoArray)
            {
                geo.PrintCoordinates();
            }

            // Бинарный поиск
            int index = Array.BinarySearch(geoArray, searchGeo, new LongitudeComparer());
            if (index >= 0)
            {
                Console.WriteLine($"Объект найден на позиции {index}");
            }
            else
            {
                Console.WriteLine("Объект не найден.");
            }
        }

        static void CloningShowcase()
        {
            // Создаем объекты с использованием RandomInit
            BankCard bankCard = new BankCard();
            bankCard.RandomInit();

            DebitCard debitCard = new DebitCard();
            debitCard.RandomInit();

            YouthCard youthCard = new YouthCard();
            youthCard.RandomInit();

            CreditCard creditCard = new CreditCard();
            creditCard.RandomInit();

            // Глубокое копирование
            BankCard clonedBankCard = (BankCard)bankCard.Clone();
            DebitCard clonedDebitCard = (DebitCard)debitCard.Clone();
            YouthCard clonedYouthCard = (YouthCard)youthCard.Clone();
            CreditCard clonedCreditCard = (CreditCard)creditCard.Clone();

            // Поверхностное копирование
            BankCard shallowBankCard = bankCard.ShallowCopy();
            DebitCard shallowDebitCard = (DebitCard)debitCard.ShallowCopy();
            YouthCard shallowYouthCard = (YouthCard)youthCard.ShallowCopy();
            CreditCard shallowCreditCard = (CreditCard)creditCard.ShallowCopy();

            // Изменяем оригинальные объекты
            bankCard.OwnerName = "Alexei Alexandrovich";
            debitCard.Balance = 0;
            youthCard.Cashback = 10;
            creditCard.Limit = 20000;

            // Вывод результатов
            Console.WriteLine("\n\n\nКопирование");
            Console.WriteLine("\nОригиналы:\n\n");
            bankCard.Show();
            Console.WriteLine("\n");
            debitCard.Show();
            Console.WriteLine("\n");
            youthCard.Show();
            Console.WriteLine("\n");
            creditCard.Show();

            Console.WriteLine("\n\nГлубокие копии:\n\n");
            clonedBankCard.Show();
            Console.WriteLine("\n");
            clonedDebitCard.Show();
            Console.WriteLine("\n");
            clonedYouthCard.Show();
            Console.WriteLine("\n");
            clonedCreditCard.Show();

            Console.WriteLine("\n\nПоверхностные копии:\n\n");
            shallowBankCard.Show();
            Console.WriteLine("\n");
            shallowDebitCard.Show();
            Console.WriteLine("\n");
            shallowYouthCard.Show();
            Console.WriteLine("\n");
            shallowCreditCard.Show();
        }
    }
}