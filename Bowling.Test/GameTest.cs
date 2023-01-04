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

    [Fact]
    public void Can_Roll_Spare()
    {
      _sut.Roll(4);
      _sut.Roll(6);
      _sut.Roll(2);
      RollMany(0, 17);
      _sut.Score().Should().Be(14);
    }

    [Fact]
    public void Can_Roll_Strike()
    {
      _sut.Roll(10);
      _sut.Roll(2);
      _sut.Roll(3);
      RollMany(0, 16);
      _sut.Score().Should().Be(20);
    }

    [Fact]
    public void Can_Roll_All_Strike()
    {
      RollMany(10, 10);
      _sut.Score().Should().Be(270);
    }

    [Fact]
    public void Can_Roll_13_Strike()
    {
      RollMany(10, 13);
      _sut.Score().Should().Be(300);
    }

    [Fact]
    public void Can_Roll_12_Strike()
    {
      RollMany(10, 12);
      _sut.Score().Should().Be(300);
    }

    [Fact]
    public void Can_Roll_10_Strike_And_Two_Normal_Rolls()
    {
      RollMany(10, 10);
      _sut.Roll(3);
      _sut.Roll(3);
      _sut.Score().Should().Be(279);
    }

    [Fact]
    public void Can_Roll_18_Normal_Frame_And_Spare_In_Last_Frame()
    {
      RollMany(1, 18);
      _sut.Roll(3);
      _sut.Roll(7);
      _sut.Roll(5);
      _sut.Score().Should().Be(33);
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
