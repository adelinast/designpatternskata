using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategySort
{
  public abstract class SortStrategy
  {

    public abstract void Sort(int[] arr);
  }
}