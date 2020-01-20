
namespace DPKata1
{
    public class NonBondStrategy : StrategyAccr
    {
        public NonBondStrategy(FeeData FeeData):base(FeeData)
        {
        }

        public override void Apply(ref double Accrual, ref bool Reversing)
        {
            System.Console.WriteLine("Non Bond\n");
            Fee fee = _FeeData._feeList[_FeeData._index];

            if (_FeeData._sign == TradeSign.SELL && fee.Type == FEETYPE.PDF)
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