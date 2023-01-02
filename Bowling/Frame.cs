using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;
using System.Linq;

namespace Bowling
{
  public class Frame : IFrame
  {
    public int Total => Rolls.Sum(x => x?.Score ?? 0);

    public int Index { get; }

    public Roll[] Rolls { get; } = new Roll[2];

    public ScoreType ScoreType => Rolls.LastOrDefault(x => x != null).Type;

    private byte _rollNumber = 0;

    public Frame(int index)
    {
      Index = index;
    }

    public void Roll(int pins)
    {
      var roll = new Roll() { Score = pins };

      Rolls[_rollNumber] = roll;

      if (_rollNumber == 0 && pins == 10)
      {
        roll.Type = ScoreType.Strike;
      }
      else if (_rollNumber == 1 && Rolls.Sum(x => x.Score) == 10)
      {
        roll.Type = ScoreType.Spare;
      }
      else
      {
        roll.Type = ScoreType.Normal;
      }

      _rollNumber++;
    }
  }
}
