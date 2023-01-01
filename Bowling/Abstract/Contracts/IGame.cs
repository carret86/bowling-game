namespace Bowling.Abstract.Contracts
{
  public interface IGame
  {
    void Roll(int pins);

    int Score();
  }
}
