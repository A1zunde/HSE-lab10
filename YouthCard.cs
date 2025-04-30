using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10Classes
{

    public class YouthCard : DebitCard, IComparable<YouthCard>
    {
        protected double cashback;

        public double Cashback
        {
            get { return cashback; }
            set
            {
                if (value > 100.0)
                    throw new ArgumentException("Кэшбек не может превышать 100%\n");
                cashback = value;
            }
        }

        public YouthCard() { }

        public YouthCard(string cardNumber, string ownerName, DateTime validityPeriod, int balance, double cashback)
            : base(cardNumber, ownerName, validityPeriod, balance)
        {
            Cashback = cashback;
        }

        public YouthCard(YouthCard other) : base(other)
        {
            cashback = other.Cashback; // FIX
        }

        public override string GetCardInfo() // FIX
        {
            return base.GetCardInfo() + $"\nКешбек: {Cashback}%";
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
                    Console.Write("Введите кешбек (в процентах): ");
                    Cashback = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите число!");
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
            cashback = Math.Round(rnd.NextDouble() * 100, 2);
        }

        public override bool Equals(object obj)
        {
            return obj is YouthCard other && base.Equals(other) && cashback == other.cashback;
        }

        public override object Clone()
        {
            return new YouthCard(CardNumber, OwnerName, ValidityPeriod, Balance, Cashback); // FIX
        }

        public int CompareTo(YouthCard? other)
        {
            if (other == null) return 1;
            int baseCmp = base.CompareTo(other);
            return baseCmp != 0 ? baseCmp : cashback.CompareTo(other.cashback);
        }

        public new YouthCard ShallowCopy()
        {
            return (YouthCard)this.MemberwiseClone();
        }
    }

}
