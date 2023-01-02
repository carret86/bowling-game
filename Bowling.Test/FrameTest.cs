using Bowling.Abstract.Contracts;
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
    public void Frame_ShouldHave_Two_Rolls_Maximum()
    {
      var sut = new Frame(1);
      sut.Roll(2);
      sut.Roll(3);
      Assert.Throws<IndexOutOfRangeException>(() => sut.Roll(3));
    }
  }
}