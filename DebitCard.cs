using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10Classes
{

    public class DebitCard : BankCard, IComparable<DebitCard>
    {
        protected int balance;

        public int Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException("Баланс не может быть отрицательным");
                }
            }
        }

        public DebitCard() { }

        public DebitCard(string cardNumber, string ownerName, DateTime validityPeriod, int balance)
            : base(cardNumber, ownerName, validityPeriod)
        {
            Balance = balance;
        }

        public DebitCard(DebitCard other) : base(other)
        {
            balance = other.Balance; // FIX
        }

        public override string GetCardInfo() // FIX
        {
            return base.GetCardInfo() + $"\nБаланс: {Balance}";
        }

        public override void Show()
        {
            Console.WriteLine(GetCardInfo()); // FIX
        }

        public override void Init()
        {
            base.Init();

            while (true)
            {
                try
                {
                    Console.Write("Введите текущий баланс: ");
                    Balance = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите целое число!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            balance = rnd.Next(0, 100000);
        }

        public override bool Equals(object obj)
        {
            return obj is DebitCard other && base.Equals(other) && balance == other.Balance;
        }

        public override object Clone()
        {
            return new DebitCard(CardNumber, OwnerName, ValidityPeriod, Balance); // FIX
        }

        public int CompareTo(DebitCard? other)
        {
            if (other == null) return 1;
            int baseCmp = base.CompareTo(other);
            return baseCmp != 0 ? baseCmp : balance.CompareTo(other.balance);
        }

        public new DebitCard ShallowCopy()
        {
            return (DebitCard)this.MemberwiseClone();
        }

        public BankCard GetBase()
        {
            return new BankCard(this.CardNumber, this.OwnerName, this.ValidityPeriod);
        }
    }

}
