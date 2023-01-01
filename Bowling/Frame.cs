using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;

namespace Bowling
{
    public class Frame : IFrame
    {
      public int Index { get; private set; }

      public Frame(int index)
      {
        Index = index;
      }

      public int GetTotal() => throw new NotImplementedException();

      public void Roll(int pins)
      {
        throw new NotImplementedException();
      }
    }
}
