using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
  public class GameTest
  {
    [Fact]
    public void Can_Create_Game()
    {
      var sut = new Game();
    }

    [Fact]
    public void Can_Roll_No_Pins_In_Game()
    {
      var sut = new Game();

      for (var i = 0; i < 20; i++)
      {
        sut.Roll(0);
      }

      sut.Score().Should().Be(0);
    }

    [Fact]
    public void Can_Roll_1_Pin_For_Each_Roll_In_Game()
    {
      var sut = new Game();

      for (var i = 0; i < 20; i++)
      {
        sut.Roll(1);
      }

      sut.Score().Should().Be(20);
    }
  }
}
