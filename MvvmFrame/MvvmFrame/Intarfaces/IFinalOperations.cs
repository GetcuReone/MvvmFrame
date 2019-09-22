using System;

namespace MvvmFrame.Intarfaces
{
    /// <summary>
    /// Interface final operations
    /// </summary>
    public interface IFinalOperations
    {
        /// <summary>
        /// Add final operation
        /// </summary>
        /// <param name="operation">operation</param>
        void AddFinalOperation(Action operation);

        /// <summary>
        /// Run final operations
        /// </summary>
        void FinishOperations();
    }
}
