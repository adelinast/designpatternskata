using NUnit.Framework;
using System.Collections.Generic;

namespace DPKata1
{
    public class AppTest2
    {
        private List<Fee> _fees;

        [SetUp]
        public void Init()
        {
            _fees = new List<Fee>();

        }

        [TearDown]
        public void Dispose()
        {
        }

        #region Sample_TestCode

        [TestCase()]
        public void BondPDFBuy2()
        {
            bool flag = false;
            const double feeAmt = 10;
            double accr = 1.0;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            FeeData FeeData = new FeeData();
            FeeData._amount = feeAmt;
            FeeData._index = 0;
            FeeData._feeList = _fees;
            FeeData._redmPrice = 0.0;
            FeeData._sign = TradeSign.BUY;

            StrategyAccrContext context = new StrategyAccrContext(FeeData);

            context.SetStrategy(StrategyTradeType.BOND);

            context.Execute(ref accr, ref flag);
            
            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondPDFSell2()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();
            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            FeeData FeeData = new FeeData();
            FeeData._amount = feeAmt;
            FeeData._index = 0;
            FeeData._redmPrice = 0.0;
            FeeData._sign = TradeSign.SELL;
            FeeData._feeList = _fees;

            StrategyAccrContext context = new StrategyAccrContext(FeeData);

            context.SetStrategy(StrategyTradeType.BOND);

            context.Execute(ref accr, ref flag);

            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondPDFRedemption2()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            FeeData FeeData = new FeeData();
            FeeData._amount = feeAmt;
            FeeData._index = 0;
            FeeData._redmPrice = 1.0;
            FeeData._sign = TradeSign.SELL;
            FeeData._feeList = _fees;

            StrategyAccrContext context = new StrategyAccrContext(FeeData);

            context.SetStrategy(StrategyTradeType.BOND);

            context.Execute(ref accr, ref flag);
            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondSetFlagNonPDF2()
        {
            bool flag = false;
            const double feeAmt = 10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.NONE;

            _fees.Add(fee);

            FeeData FeeData = new FeeData();
            FeeData._amount = feeAmt;
            FeeData._index = 0;
            FeeData._redmPrice = 1.0;
            FeeData._sign = TradeSign.SELL;
            FeeData._feeList = _fees;

            StrategyAccrContext context = new StrategyAccrContext(FeeData);

            context.SetStrategy(StrategyTradeType.BOND);

            context.Execute(ref accr, ref flag);
            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void NonBondSetFlagPDF2()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            FeeData FeeData = new FeeData();
            FeeData._amount = feeAmt;
            FeeData._index = 0;
            FeeData._redmPrice = 0.0;
            FeeData._sign = TradeSign.SELL;
            FeeData._feeList = _fees;

            StrategyAccrContext context = new StrategyAccrContext(FeeData);

            context.SetStrategy(StrategyTradeType.NONBOND);
            context.Execute(ref accr, ref flag);

            Assert.IsTrue(flag);
        }

        #endregion
    }
}
