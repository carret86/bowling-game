using Bowling.Abstract.Enums;

namespace Bowling.Abstract.Contracts
{
  public interface IFrame
  {
    int Index { get; }

    int Total { get; }

    ScoreType ScoreType { get; }

    void Roll(int pins);
  }
}
