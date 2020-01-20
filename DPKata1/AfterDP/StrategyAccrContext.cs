namespace DPKata1
{
    public class StrategyAccrContext
    {
        public StrategyAccrContext(FeeData FeeData)
        {
            _FeeData = FeeData;
        }
        public void SetStrategy(StrategyTradeType TradeType)
        {
            switch (TradeType)
            {
                case StrategyTradeType.BOND:
                    Fee fee = _FeeData._feeList[_FeeData._index];
                    if (fee.Type == FEETYPE.PDF)
                    {
                        if (_FeeData._redmPrice == 1.0)
                        {
                            _strategy = new BondPDFRedemptionStrategy(_FeeData);
                        }
                        else
                        {
                            _strategy = new BondPDFStrategy(_FeeData);
                        }
                    }
                    else
                    {
                        _strategy = new BondNonPDFStrategy(_FeeData);
                    }
                    break;
                case StrategyTradeType.NONBOND:
                    _strategy = new NonBondStrategy(_FeeData);
                    break;
                default:
                    break;
            }
        }

        public void Execute(ref double  Accr, ref bool Reversing)
        {
            _strategy.Apply(ref Accr, ref Reversing);
        }

        private StrategyAccr _strategy;
	    private FeeData _FeeData;
    }
}