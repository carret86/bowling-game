using Bowling.EventArgs;

namespace Bowling
{
  internal static class Interop
  {
    internal delegate void RolledEventHandler(object sender, RolledEventArgs e);

    internal static event RolledEventHandler? OnRolled;

    internal static void Rolled(object sender, RolledEventArgs e)
    {
      OnRolled?.Invoke(sender, e);
    }
  }
}
