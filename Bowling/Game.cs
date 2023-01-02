using Bowling.Abstract.Contracts;

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

      if (_currentFrame.IsCompleted)
      {
        _frameIndex++;
      }
    }

    public int Score() => _frames.Sum(f => f.Total);
  }
}
