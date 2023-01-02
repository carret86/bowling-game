using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;

namespace Bowling
{
  public class Game : IGame
  {
    private readonly Frame[] _frames = new Frame[10];
    private int _frameIndex = 0;
    private Frame _currentFrame => _frames[_frameIndex];

    public void Roll(int pins)
    {
      if (_currentFrame == null)
      {
        _frames[_frameIndex] = new Frame();
      }
      _currentFrame.Roll(pins);

      var previousScoreType = _frameIndex > 0 ? _frames[_frameIndex - 1].ScoreType : ScoreType.None;

      if (previousScoreType != ScoreType.None)
      {
        if (_frames[_frameIndex].RollNumber == 1 && previousScoreType is ScoreType.Spare)
        {
          _frames[_frameIndex - 1].Bonus = pins;
        }
        else if (previousScoreType is ScoreType.Strike)
        {
          _frames[_frameIndex - 1].Bonus += pins;

          if (_frameIndex - 1 > 0 && _frames[_frameIndex - 2].ScoreType == ScoreType.Strike)
          {
            _frames[_frameIndex - 2].Bonus += pins;
          }
        }
      }

      if (_currentFrame.IsCompleted || _currentFrame.ScoreType == ScoreType.Strike)
      {
        _frameIndex++;
      }
    }

    public int Score() => _frames.Sum(f => f.Total);
  }
}
