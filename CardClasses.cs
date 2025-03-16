using System;
using System.Text.Json.Serialization.Metadata;

namespace lab10Classes
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class BankCard : IInit
    {
        // Поля
        protected string cardNumber;
        protected string ownerName;
        protected DateTime validityPeriod;

        // Свойство номера карты
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                bool digitCheck = true;
                if (value.Length == 16)
                {
                    foreach (char letter in value)
                    {
                        if (!char.IsDigit(letter))
                        {
                            digitCheck = false;
                            break;
                        }
                    }
                }
                if (digitCheck)
                {
                    cardNumber = value;
                }
                else
                    throw new ArgumentException("Номер карты должен состоять из 16 цифр.");
            }
        }

        // Свойство имени владельца
        public string OwnerName
        {
            get { return ownerName; }
            set
            {
                if (value != null)
                {
                    ownerName = value;
                }
                else
                {
                    throw new ArgumentException("Имя владельца не может быть пустым.");
                }
            }
        }

        // Свойство даты действия
        public DateTime ValidityPeriod
        {
            get { return validityPeriod; }
            set
            {
                if (value > DateTime.Now)
                {
                    validityPeriod = value;
                }
                else
                {
                    throw new ArgumentException("Срок действия должен быть в будущем");
                }
            }
        }

        // Конструктор с параметрами
        public BankCard(string cardNumber, string ownerName, DateTime validityPeriod)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
        }

        // Конструктов без параметров
        public BankCard() { }

        // Конструктор копирования
        public BankCard(BankCard other)
        {
            cardNumber = other.cardNumber;
            ownerName = other.ownerName;
            validityPeriod = other.validityPeriod;
        }

        // Вывод
        public virtual void Show()
        {
            Console.WriteLine($"Номер карты: {cardNumber}");
            Console.WriteLine($"Владелец: {ownerName}");
            Console.WriteLine($"Срок действия: {validityPeriod.ToShortDateString()}\n");
        }

        public void NonVirtualShow()
        {
            Console.WriteLine($"Номер карты: {cardNumber}");
            Console.WriteLine($"Владелец: {ownerName}");
            Console.WriteLine($"Срок действия: {validityPeriod.ToShortDateString()}\n");
        }

        // Инициализация
        public virtual void Init()
        {
            Console.Write("Введите номер карты: ");
            CardNumber = Console.ReadLine();
            Console.Write("Введите имя владельца: ");
            OwnerName = Console.ReadLine();
            Console.Write("Введите срок действия (гггг-мм-дд): ");
            ValidityPeriod = DateTime.Parse(Console.ReadLine());
        }

        // Инициализация с ДСЧ
        public virtual void RandomInit()
        {
            string[] namesList = { "John", "Michael", "David", "James", "Robert", "William" };
            Random rnd = new Random();
            cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardNumber += rnd.Next(0, 10);
            }
            ownerName = namesList[rnd.Next(0, 6)];
            validityPeriod = DateTime.Now.AddYears(rnd.Next(1, 10));
        }

        // Операция сравнения
        new public virtual bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            BankCard other = (BankCard)obj;
            return (cardNumber == other.cardNumber && ownerName == other.ownerName && validityPeriod == other.validityPeriod);
        }

        public virtual object Clone()
        {
            return new BankCard
            (
                CardNumber = this.cardNumber,
                OwnerName = this.ownerName,
                ValidityPeriod = this.validityPeriod
            );
        }

        // Метод для поверхностного копирования
        public BankCard ShallowCopy()
        {
            return (BankCard)this.MemberwiseClone();
        }

    }

    public class DebitCard : BankCard
    {
        // Переменные
        protected int balance;

        // Свойство баланс
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public DebitCard(string cardNumber, string ownerName, DateTime validityPeriod, int balance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
            Balance = balance;
        }

        // Конструктов без параметров
        public DebitCard() { }

        // Конструктор копирования
        public DebitCard(DebitCard other)
        {
            cardNumber = other.cardNumber;
            ownerName = other.ownerName;
            validityPeriod = other.validityPeriod;
            balance = other.balance;
        }

        // Вывод
        public override void Show()
        {
            Console.WriteLine($"Номер карты: {cardNumber}");
            Console.WriteLine($"Владелец: {ownerName}");
            Console.WriteLine($"Срок действия: {validityPeriod.ToShortDateString()}");
            Console.WriteLine($"Баланс: {balance}");
        }

        public override void Init()
        {
            Console.WriteLine("Введите номер карты: ");
            CardNumber = Console.ReadLine();
            Console.WriteLine("Введите имя владельца: ");
            OwnerName = Console.ReadLine();
            Console.WriteLine("Введите срок действия (гггг-мм-дд): ");
            ValidityPeriod = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите текущий баланс: ");
            Balance = int.Parse(Console.ReadLine());
        }

        // Инициализация с ДСЧ
        public override void RandomInit()
        {
            string[] namesList = { "John", "Michael", "David", "James", "Robert", "William" };
            Random rnd = new Random();
            cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardNumber += rnd.Next(0, 10);
            }
            ownerName = namesList[rnd.Next(0, 6)];
            validityPeriod = DateTime.Now.AddYears(rnd.Next(1, 10));
            balance = rnd.Next(0, 100000);
        }

        // Операция сравнения
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            DebitCard other = (DebitCard)obj;
            return (cardNumber == other.cardNumber && ownerName == other.ownerName && validityPeriod == other.validityPeriod && balance == other.balance);
        }

        public override object Clone()
        {
            return new DebitCard
            (
                CardNumber = this.cardNumber,
                OwnerName = this.ownerName,
                ValidityPeriod = this.validityPeriod,
                Balance = this.balance
            );
        }
    }

    public class YouthCard : DebitCard
    {
        // Переменные
        protected double cashback;

        // Свойство кэшбек
        public double Cashback
        {
            get { return cashback; }
            set
            {
                if (value > 99.9)
                {
                    throw new ArgumentException("Кэшбек не может превышать 100%\n");
                }
                else
                {
                    cashback = value;
                }
            }
        }

        public YouthCard(string cardNumber, string ownerName, DateTime validityPeriod, int balance, double cashback)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
            Balance = balance;
            Cashback = cashback;
        }

        // Конструктов без параметров
        public YouthCard() { }

        // Конструктор копирования
        public YouthCard(YouthCard other)
        {
            cardNumber = other.cardNumber;
            ownerName = other.ownerName;
            validityPeriod = other.validityPeriod;
            balance = other.balance;
            cashback = other.cashback;
        }

        // Вывод
        public override void Show()
        {
            Console.WriteLine($"Номер карты: {cardNumber}");
            Console.WriteLine($"Владелец: {ownerName}");
            Console.WriteLine($"Срок действия: {validityPeriod.ToShortDateString()}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Кешбек: {cashback}");
        }

        public override void Init()
        {
            Console.Write("Введите номер карты: ");
            CardNumber = Console.ReadLine();
            Console.Write("Введите имя владельца: ");
            OwnerName = Console.ReadLine();
            Console.Write("Введите срок действия (гггг-мм-дд): ");
            ValidityPeriod = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите текущий баланс: ");
            Balance = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кешбек (в процентах): ");
            Cashback = float.Parse(Console.ReadLine());
        }

        // Инициализация с ДСЧ
        public override void RandomInit()
        {
            string[] namesList = { "John", "Michael", "David", "James", "Robert", "William" };
            Random rnd = new Random();
            cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardNumber += rnd.Next(0, 10);
            }
            ownerName = namesList[rnd.Next(0, 6)];
            validityPeriod = DateTime.Now.AddYears(rnd.Next(1, 10));
            balance = rnd.Next(0, 100000);
            cashback = rnd.NextDouble() + rnd.Next(0, 99);
        }

        // Операция сравнения
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            YouthCard other = (YouthCard)obj;
            return (cardNumber == other.cardNumber && ownerName == other.ownerName && validityPeriod == other.validityPeriod && balance == other.balance && cashback == other.cashback);
        }

        public override object Clone()
        {
            return new YouthCard
            (
                CardNumber = this.cardNumber,
                OwnerName = this.ownerName,
                ValidityPeriod = this.validityPeriod,
                Balance = this.balance,
                Cashback = this.cashback
            );
        }
    }

    public class CreditCard : YouthCard
    {
        // Переменные
        protected int limit;
        protected int maturityDate;

        // Свойство лимита
        public int Limit
        {
            get { return limit; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Лимит кредитной карты не может быть меньше 0");
                }
                else
                {
                    limit = value;
                }
            }
        }

        // Свойство срока погашения
        public int MaturityDate
        {
            get { return maturityDate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Дата погашения не может быть меньше 0");
                }
                else
                {
                    maturityDate = value;
                }
            }

        }

        public CreditCard(string cardNumber, string ownerName, DateTime validityPeriod, int balance,
            double cashback, int limit, int maturityDate)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
            Balance = balance;
            Cashback = cashback;
            Limit = limit;
            MaturityDate = maturityDate;
        }

        // Конструктов без параметров
        public CreditCard() { }

        // Конструктор копирования
        public CreditCard(CreditCard other)
        {
            cardNumber = other.cardNumber;
            ownerName = other.ownerName;
            validityPeriod = other.validityPeriod;
            balance = other.balance;
            cashback = other.cashback;
            limit = other.limit;
            maturityDate = other.maturityDate;
        }

        // Вывод
        public override void Show()
        {
            Console.WriteLine($"Номер карты: {cardNumber}");
            Console.WriteLine($"Владелец: {ownerName}");
            Console.WriteLine($"Срок действия: {validityPeriod.ToShortDateString()}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Кешбек: {cashback}");
            Console.WriteLine($"Лимит: {limit}");
            Console.WriteLine($"Срок погашения: {maturityDate}");
        }

        // Инициализация
        public override void Init()
        {
            Console.Write("Введите номер карты: ");
            CardNumber = Console.ReadLine();
            Console.Write("Введите имя владельца: ");
            OwnerName = Console.ReadLine();
            Console.Write("Введите срок действия (гггг-мм-дд): ");
            ValidityPeriod = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите текущий баланс: ");
            Balance = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кешбек (в процентах): ");
            Cashback = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите лимит по кредитной карте: ");
            Limit = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите лимит по кредитной карте: ");
            MaturityDate = int.Parse(Console.ReadLine());
        }

        // Инициализация с ДСЧ
        public override void RandomInit()
        {
            string[] namesList = { "John", "Michael", "David", "James", "Robert", "William" };
            Random rnd = new Random();
            cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardNumber += rnd.Next(0, 10);
            }
            ownerName = namesList[rnd.Next(0, 6)];
            validityPeriod = DateTime.Now.AddYears(rnd.Next(1, 10));
            balance = rnd.Next(0, 100000);
            cashback = rnd.NextDouble() + rnd.Next(0, 99);
            limit = rnd.Next(0, 100000);
            maturityDate = rnd.Next(6, 48);
        }

        // Операция сравнения
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            CreditCard other = (CreditCard)obj;
            return (cardNumber == other.cardNumber && ownerName == other.ownerName && validityPeriod == other.validityPeriod &&
                balance == other.balance && cashback == other.cashback && limit == other.limit && maturityDate == other.maturityDate);
        }

        public override object Clone()
        {
            return new CreditCard
            (
                CardNumber = this.cardNumber,
                OwnerName = this.ownerName,
                ValidityPeriod = this.validityPeriod,
                Balance = this.balance,
                Cashback = this.cashback,
                Limit = this.limit,
                MaturityDate = this.maturityDate
            );
        }
    }
}
