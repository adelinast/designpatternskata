using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPKata1
{
    public class BondPDFStrategy : BondStrategy
    {
        public BondPDFStrategy(FeeData FeeData) : base(FeeData)
        {
        }
        public override void Apply(ref double Accrual, ref bool Reversing)
        {
            Console.WriteLine("Bond PDF\n");

            if ((_FeeData._sign == TradeSign.BUY && _FeeData._amount > 0.0) ||
               _FeeData._sign == TradeSign.SELL && _FeeData._amount < 0.0)
            {
                Accrual *= -1;
            }
            if (Accrual < 0.0)
            {
                Reversing = true;
            }
            else
            {
                Reversing = false;
            }
        }
    }
}