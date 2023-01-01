using Bowling.Abstract.Contracts;

namespace Bowling
{
  public class Game : IGame
  {
    public void Roll(int pins)
    {
      throw new NotImplementedException();
    }

    public int Score() => throw new NotImplementedException();
  }
}
