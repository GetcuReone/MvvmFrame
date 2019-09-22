using System;

namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Error handler
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Error handle
        /// </summary>
        /// <param name="ex"></param>
        void ErrorHandle(Exception ex);
    }
}
