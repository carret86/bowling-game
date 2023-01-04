using Bowling.Abstract;
using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;
using Bowling.EventArgs;

namespace Bowling
{
  public class Frame : IFrame
  {
    public int Total => _rolls.Sum(x => x?.Score ?? 0) + Bonus;

    public int Index { get; }

    public ScoreType ScoreType => _rolls.LastOrDefault(x => x != null)?.Type ?? ScoreType.None;

    public byte RollNumber { get; private set; } = 0;

    public bool IsCompleted => RollNumber == Constants.RollsNumber || ScoreType == ScoreType.Strike;

    public int Bonus { get; set; }

    private int _rollsBonus;

    private readonly Roll[] _rolls = new Roll[Constants.RollsNumber];

    public Frame(int index)
    {
      Index = index;
    }

    public void Roll(int pins)
    {
      bool IsSpare() => RollNumber == 2 && IsMaxScoreReached(Total);

      bool IsStrike() => RollNumber == 1 && IsMaxScoreReached(pins);

      RollNumber++;
      var roll = new Roll() { Score = pins };
      _rolls[RollNumber-1] = roll;
      roll.Type = IsStrike() ? ScoreType.Strike : IsSpare() ? ScoreType.Spare : ScoreType.Normal;

      if (ScoreType == ScoreType.Normal)
      {
        return;
      }

      _rollsBonus = EvaluateRollsBonus(ScoreType);
      Interop.OnRolled += OnRolled;
    }

    private byte EvaluateRollsBonus(ScoreType scoreType)
    {
      return scoreType switch
      {
        ScoreType.Strike => 2,
        ScoreType.Spare => 1,
        _ => 0
      };
    }

    private void OnRolled(object sender, RolledEventArgs e)
    {
      Bonus += e.Pins;
      _rollsBonus--; 
      if (_rollsBonus == 0)
      {
        Interop.OnRolled -= OnRolled;
      }
    }

    private static bool IsMaxScoreReached(int score) => score == Constants.MaxRollScore;
  }
}
