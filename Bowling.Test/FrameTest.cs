using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;
using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
  public class FrameTest
  {
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void CanCreateFrame(int index)
    {
      IFrame frame = new Frame(index);
      frame.Should().NotBeNull();
      frame.Index.Should().Be(index);
    }


    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void FrameTest_Roll_ReturnRightTotal(int pins)
    {
      var sut = new Frame(1);
      sut.Roll(pins);
      sut.Total.Should().Be(pins);
    }

    [Fact]
    public void Frame_Should_Have_Two_Rolls_Maximum()
    {
      var sut = new Frame(1);
      sut.Roll(2);
      sut.Roll(3);
      Assert.Throws<IndexOutOfRangeException>(() => sut.Roll(3));
    }

    [Fact]
    public void Frame_Should_Be_Strike()
    {
      var sut = new Frame(1);
      sut.Roll(10);
      sut.ScoreType.Should().Be(ScoreType.Strike);
    }

    [Fact]
    public void Frame_Should_Be_Spare()
    {
      var sut = new Frame(1);
      sut.Roll(9);
      sut.Roll(1);
      sut.ScoreType.Should().Be(ScoreType.Spare);
    }

    [Fact]
    public void Frame_Should_Be_Normal()
    {
      var sut = new Frame(1);
      sut.Roll(8);
      sut.Roll(1);
      sut.ScoreType.Should().Be(ScoreType.Normal);
    }
  }
}