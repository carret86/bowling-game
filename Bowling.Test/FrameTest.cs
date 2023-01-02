using Bowling.Abstract.Contracts;
using Bowling.Abstract.Enums;
using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
  public class FrameTest
  {
    private readonly Frame _sut;

    public FrameTest()
    {
      _sut = new Frame(1);
    }

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
      _sut.Roll(pins);
      _sut.Total.Should().Be(pins);
    }

    [Fact]
    public void Frame_Should_Have_Two_Rolls_Maximum()
    {
      _sut.Roll(2);
      _sut.Roll(3);
      Assert.Throws<IndexOutOfRangeException>(() => _sut.Roll(3));
    }

    [Fact]
    public void Frame_Should_Be_Strike()
    {
      _sut.Roll(10);
      _sut.ScoreType.Should().Be(ScoreType.Strike);
    }

    [Fact]
    public void Frame_Should_Be_Spare()
    {
      _sut.Roll(9);
      _sut.Roll(1);
      _sut.ScoreType.Should().Be(ScoreType.Spare);
    }

    [Fact]
    public void Frame_Should_Be_Normal()
    {
      _sut.Roll(8);
      _sut.Roll(1);
      _sut.ScoreType.Should().Be(ScoreType.Normal);
    }
  }
}