using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategySort
{
  public class QuickSortStrategy : SortStrategy
  {
    public QuickSortStrategy()
    {
    }

    public override void Sort(int[] arr)
    {
      Console.WriteLine("Quick");
    }
  }
}