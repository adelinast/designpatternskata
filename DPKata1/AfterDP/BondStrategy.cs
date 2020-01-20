using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPKata1
{
    public class BondStrategy : StrategyAccr
    {
        public BondStrategy(FeeData FeeData) : base(FeeData)
        {
        }

        public override void Apply(ref double Accrual, ref bool Reversing)
        {
        }

    }
}