using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPKata1
{
    public abstract class StrategyAccr
    {
        protected FeeData _FeeData;
        
        public StrategyAccr(FeeData FeeData)
        {
            _FeeData = FeeData;
        }

        public abstract void Apply(ref double Accr, ref bool Reversing);

    }
}