using System;

namespace MvvmFrame.Intarfaces
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
