using Bowling.Abstract.Enums;

namespace Bowling.Abstract.Contracts
{
  public interface IFrame
  {
    int Total { get; }

    int Index { get; }

    ScoreType ScoreType { get; }

    byte RollNumber { get; }

    bool IsCompleted { get; }

    int Bonus { get; set; }

    void Roll(int pins);
  }
}
