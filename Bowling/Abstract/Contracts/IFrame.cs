using Bowling.Abstract.Enums;

namespace Bowling.Abstract.Contracts
{
    public interface IFrame
    {
        public int Index { get; }

        int GetTotal();

        void Roll(int pins);
    }
}
