using MvvmFrame.EventArgs;
using MvvmFrame.Interfaces;

namespace GetcuReone.MvvmFrame.EventHandlers
{
    /// <summary>
    /// Delegate for model change property verification events
    /// </summary>
    /// <param name="element">an element whose property has been changed</param>
    /// <param name="args">event args</param>
    public delegate void MvvmElementPropertyVerifyChangeEventHandler(IModel element, MvvmElementPropertyVerifyChangeEventArgs args);
}
