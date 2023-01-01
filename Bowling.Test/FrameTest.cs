using Bowling.Abstract.Contracts;
using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
    public class FrameTest
    {
      [Fact]
      public void CanCreateFrame()
      {
        IFrame frame = new Frame(1);
        frame.Should().NotBeNull();
        frame.Index.Should().Be(1);
      }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void FrameTest_Roll_ReturnRightTotal(int pins)
        {
          var sut = new Frame(1);
          sut.Roll(pins);
          sut.GetTotal().Should().Be(pins);

        }
    }
}