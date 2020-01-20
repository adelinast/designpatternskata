using NUnit.Framework;
using System.Collections.Generic;

namespace DPKata1
{
    public class AppTest
    {
        private TradeFeeAccrual _app;
        private List<Fee> _fees;

        [SetUp]
        public void Init()
        {
            _app = new TradeFeeAccrual();
            _fees = new List<Fee>();
        }

        [TearDown]
        public void Dispose()
        {
        }

        #region Sample_TestCode

        [TestCase()]
        public void BondPDFBuy()
        {
            bool flag = false;
            const double feeAmt = 10;
            double accr = 1.0;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            _app.BondSetFlag(feeAmt, _fees, 0, TradeSign.BUY, ref accr, out flag);
            
            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondPDFSell()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();
            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            _app.BondSetFlag(feeAmt, _fees, 0, TradeSign.SELL, ref accr, out flag);

            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondPDFRedemption()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            flag = _app.BondGetFlagPDFRedemption(feeAmt, _fees, 0, TradeSign.SELL, 1.0, ref accr);

            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void BondSetFlagNonPDF()
        {
            bool flag = false;
            const double feeAmt = 10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.NONE;

            _fees.Add(fee);

            _app.BondSetFlagNonPDF(feeAmt, _fees, 0, TradeSign.SELL, ref accr, out flag);

            Assert.IsTrue(flag);
        }

        [TestCase()]
        public void NonBondSetFlagPDF()
        {
            bool flag = false;
            const double feeAmt = -10;
            double accr = 1;
            _fees.Clear();

            Fee fee = new Fee();
            fee.Amount = feeAmt;
            fee.Type = FEETYPE.PDF;

            _fees.Add(fee);

            _app.NonBondSetFlag(feeAmt, _fees, 0, TradeSign.SELL, ref accr, out flag);

            Assert.IsTrue(flag);
        }

        #endregion
    }
}
