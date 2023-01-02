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

      if (_frameIndex > 0 && _frames[_frameIndex].RollNumber == 1 && _frames[_frameIndex - 1].ScoreType == ScoreType.Spare)
      {
        _frames[_frameIndex - 1].Bonus = pins;
      }

      if (_currentFrame.IsCompleted)
      {
        _frameIndex++;
      }
    }

    public int Score() => _frames.Sum(f => f.Total);
  }
}
