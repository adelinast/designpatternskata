using System.Collections.Generic;

namespace DPKata1
{
    public enum FEETYPE
    {
        NONE,
        PDF,
    }

    public enum TradeSign
    {
        NONE,
        BUY,
        SELL
    }

    public class Fee
    {
        public double Amount { get; set; }
        public FEETYPE Type { get; set; }

        public Fee()
        {
            Amount = 0.0;
            Type = FEETYPE.NONE;
        }
    }

    public class TradeFeeAccrual
    {

        public double _redemptionPrice { get; private set; }

        public TradeFeeAccrual()
        {
            _redemptionPrice = 0.0;
        }

        public void BondSetFlag(double FeeAmount, List<Fee> FeeList, int Index, TradeSign Sign, ref double Accrual, out bool Flag)
        {
            System.Console.WriteLine("Bond\n");

            Fee fee = FeeList[Index];
            if (fee.Type == FEETYPE.PDF)
            {
                if (_redemptionPrice == 1.0)
                {
                    Flag = BondGetFlagPDFRedemption(FeeAmount, FeeList, Index, Sign, _redemptionPrice, ref Accrual);
                }
                else
                {
                    BondSetFlagPDF(FeeAmount, FeeList, Index, Sign, ref Accrual, out Flag);
                }
            }
            else
            {
                BondSetFlagNonPDF(FeeAmount, FeeList, Index, Sign, ref Accrual, out Flag);
            }

        }
       
        public void BondSetFlagPDF(double FeeAmount, List<Fee> FeeList, int Index, TradeSign Sign, ref double Accrual, out bool Flag)
        {
            System.Console.WriteLine("Bond PDF\n");

            if ((Sign == TradeSign.BUY && FeeAmount > 0.0) ||
               Sign == TradeSign.SELL && FeeAmount < 0.0)
            {
                Accrual *= -1;
            }
            if (Accrual < 0.0)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
            }
        }

        public bool BondGetFlagPDFRedemption(double FeeAmount, List<Fee> FeeList, int Index, TradeSign Sign, double RedmPrice, ref double Accrual)
        {
            System.Console.WriteLine("Bond PDF Redemption\n");

            if ((Sign == TradeSign.BUY && FeeAmount> 0.0) ||
               Sign == TradeSign.SELL && FeeAmount < 0.0)
            {
                Accrual *= -1;
            }

            if (Accrual < 0.0)
            {
                return true;
            }

            return false;
        }

        public void BondSetFlagNonPDF(double FeeAmount, List<Fee> FeeList, int Index, TradeSign Sign, ref double Accrual, out bool Flag)
        {
            System.Console.WriteLine("Bond Non PDF\n");
            if (Sign == TradeSign.SELL)
            {
                Accrual *= -1;
            }

            if ((Sign == TradeSign.BUY && FeeAmount > 0.0) ||
              Sign == TradeSign.SELL && FeeAmount < 0.0)
            {
                Accrual *= -1;
            }

            if (Accrual < 0.0)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
            }
        }

        public void NonBondSetFlag(double FeeAmount, List<Fee> FeeList, int Index, TradeSign Sign, ref double Accrual, out bool Flag)
        {
            System.Console.WriteLine("Non Bond\n");
            Fee fee = FeeList[Index];
            if (Sign == TradeSign.SELL && fee.Type == FEETYPE.PDF)
            {
                Accrual *= -1;
            }

            if (Accrual < 0.0)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
            }
        }
        static void Main(string[] args)
        {
            
        }

    }
}
