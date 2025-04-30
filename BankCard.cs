using System;
using System.Text.Json.Serialization.Metadata;

namespace lab10Classes
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class BankCard : IInit, IComparable<BankCard>, IComparable
    {
        protected string cardNumber;
        protected string ownerName;
        protected DateTime validityPeriod;

        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                if (value.Length == 16 && value.All(char.IsDigit))
                    cardNumber = value;
                else
                    throw new ArgumentException("Номер карты должен состоять из 16 цифр.");
            }
        }

        public string OwnerName
        {
            get { return ownerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    ownerName = value;
                else
                    throw new ArgumentException("Имя владельца не может быть пустым.");
            }
        }

        public DateTime ValidityPeriod
        {
            get { return validityPeriod; }
            set
            {
                if (value > DateTime.Now)
                    validityPeriod = value;
                else
                    throw new ArgumentException("Срок действия должен быть в будущем");
            }
        }

        public BankCard() { }

        public BankCard(string cardNumber, string ownerName, DateTime validityPeriod)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
        }

        public BankCard(BankCard other)
        {
            cardNumber = other.CardNumber;
            ownerName = other.OwnerName;
            validityPeriod = other.ValidityPeriod;
        }

        public virtual string GetCardInfo() // FIX
        {
            return $"\nНомер карты: {CardNumber}\nВладелец: {OwnerName}\nСрок действия: {ValidityPeriod.ToShortDateString()}";
        }

        public virtual void Show()
        {
            Console.WriteLine(GetCardInfo()); // FIX
        }

        public virtual void Init()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите номер карты: ");
                    CardNumber = Console.ReadLine();
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка!");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Введите имя владельца: ");
                    OwnerName = Console.ReadLine();
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Введите срок действия (гггг-мм-дд): ");
                    ValidityPeriod = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка формата даты! Используйте формат гггг-мм-дд");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }

        public virtual void RandomInit()
        {
            string[] namesList = { "John", "Michael", "David", "James", "Robert", "William" };
            Random rnd = new Random();
            cardNumber = string.Concat(Enumerable.Range(0, 16).Select(_ => rnd.Next(0, 10).ToString()));
            ownerName = namesList[rnd.Next(namesList.Length)];
            validityPeriod = DateTime.Now.AddYears(rnd.Next(1, 10));
        }

        public override bool Equals(object? obj)
        {
            return obj is BankCard other &&
                   cardNumber == other.cardNumber &&
                   ownerName == other.ownerName &&
                   validityPeriod == other.validityPeriod;
        }

        public virtual object Clone()
        {
            return new BankCard(CardNumber, OwnerName, ValidityPeriod); // FIX
        }

        public int CompareTo(BankCard? other)
        {
            return other == null ? 1 : string.Compare(cardNumber, other.cardNumber, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(object obj)
        {
            return obj is BankCard other ? CompareTo(other) : throw new ArgumentException("Object is not a BankCard");
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(cardNumber, ownerName, validityPeriod);
        }

        public override string ToString()
        {
            return $"BankCard: {CardNumber}, Owner: {OwnerName}, Validity: {ValidityPeriod}";
        }

        public BankCard ShallowCopy()
        {
            return (BankCard)this.MemberwiseClone();
        }
    } 
}
