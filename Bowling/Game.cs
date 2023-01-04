using Bowling.Abstract;
using Bowling.Abstract.Contracts;
using Bowling.EventArgs;

namespace Bowling
{
  public class Game : IGame
  {
    private readonly IFrame[] _frames = new Frame[Constants.FramesNumber];

    private IFrame _currentFrame => _frames[_frameIndex];

    private int _frameIndex = 0;

    public void Roll(int pins)
    {
      Interop.Rolled(this, new RolledEventArgs() { Pins = pins });
      if (_frameIndex == Constants.FramesNumber)
      {
        return;
      } 

      if (_currentFrame == null)
      {
        _frames[_frameIndex] = new Frame(_frameIndex);
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
