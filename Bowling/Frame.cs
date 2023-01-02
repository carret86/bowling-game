using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;
using System.Linq;
using Bowling.Abstract;

namespace Bowling
{
  public class Frame : IFrame
  {
    public int Total => _rolls.Sum(x => x?.Score ?? 0);

    public int Index { get; }

    private Roll[] _rolls { get; set; } = new Roll[2];

    public ScoreType ScoreType => _rolls.LastOrDefault(x => x != null).Type;

    private byte _rollNumber = 0;

    public Frame(int index)
    {
      Index = index;
    }

    public void Roll(int pins)
    {
      var roll = new Roll() { Score = pins };

      _rolls[_rollNumber] = roll;

      if (IsStrike(pins))
      {
        roll.Type = ScoreType.Strike;
      }
      else if (IsSpare())
      {
        roll.Type = ScoreType.Spare;
      }
      else
      {
        roll.Type = ScoreType.Normal;
      }

      _rollNumber++;
    }

    private bool IsSpare() => _rollNumber == 1 && IsMaxScoreReached(_rolls.Sum(x => x.Score));

    private bool IsStrike(int pins) => _rollNumber == 0 && IsMaxScoreReached(pins);

    private static bool IsMaxScoreReached(int score) => score == Constants.MaxRollScore;
  }
}
