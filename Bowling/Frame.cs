using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;

namespace Bowling
{
  public class Frame : IFrame
  {
    public int Total { get; private set; }
    public int Index { get; private set; }

    public Frame(int index)
    {
      Index = index;
    }

    public void Roll(int pins)
    {
      Total += pins;
    }
  }
}
