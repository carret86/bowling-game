using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
  public class GameTest
  {
    private Game _sut;

    public GameTest()
    {
      _sut = new Game();
    }
    
    [Fact]
    public void Can_Create_Game()
    {
      var sut = new Game();
    }

    [Fact]
    public void Can_Roll_No_Pins_In_Game()
    {
      RollMany(0, 20);

      _sut.Score().Should().Be(0);
    }

    [Fact]
    public void Can_Roll_1_Pin_For_Each_Roll_In_Game()
    {
      RollMany(1, 20);

      _sut.Score().Should().Be(20);
    }

    private void RollMany(int pins, int rolls)
    {
      for (var i = 0; i < rolls; i++)
      {
        _sut.Roll(pins);
      }
    }
  }
}
