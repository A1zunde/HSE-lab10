using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10Classes
{

    public class CreditCard : BankCard, IComparable<CreditCard>
    {
        protected int limit;
        protected int maturityDate;

        public int Limit
        {
            get { return limit; }
            set
            {
                if (value < 0) throw new ArgumentException("Лимит не может быть меньше 0");
                limit = value;
            }
        }

        public int MaturityDate
        {
            get { return maturityDate; }
            set
            {
                if (value < 0) throw new ArgumentException("Срок погашения не может быть меньше 0");
                maturityDate = value;
            }
        }

        public CreditCard() { }

        public CreditCard(string cardNumber, string ownerName, DateTime validityPeriod, int limit, int maturityDate)
            : base(cardNumber, ownerName, validityPeriod)
        {
            Limit = limit;
            MaturityDate = maturityDate;
        }

        public CreditCard(CreditCard other) : base(other)
        {
            limit = other.Limit;
            maturityDate = other.MaturityDate;
        }

        public override string GetCardInfo() // FIX
        {
            return base.GetCardInfo() + $"\nЛимит: {Limit}\nСрок погашения: {MaturityDate}";
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
                    Console.Write("Введите лимит: ");
                    Limit = int.Parse(Console.ReadLine());
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

            while (true)
            {
                try
                {
                    Console.Write("Введите срок погашения (в месяцах): ");
                    MaturityDate = int.Parse(Console.ReadLine());
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
            limit = rnd.Next(10000, 100000);
            maturityDate = rnd.Next(6, 60);
        }

        public override bool Equals(object obj)
        {
            return obj is CreditCard other && base.Equals(other) &&
                   limit == other.limit && maturityDate == other.maturityDate;
        }

        public override object Clone()
        {
            return new CreditCard(CardNumber, OwnerName, ValidityPeriod, Limit, MaturityDate); // FIX
        }

        public int CompareTo(CreditCard? other)
        {
            if (other == null) return 1;
            int baseCmp = base.CompareTo(other);
            if (baseCmp != 0) return baseCmp;
            int limitCmp = limit.CompareTo(other.limit);
            return limitCmp != 0 ? limitCmp : maturityDate.CompareTo(other.maturityDate);
        }

        public new CreditCard ShallowCopy()
        {
            return (CreditCard)this.MemberwiseClone();
        }

        public BankCard GetBase()
        {
            return new BankCard(this.CardNumber, this.OwnerName, this.ValidityPeriod);
        }
    }
}
