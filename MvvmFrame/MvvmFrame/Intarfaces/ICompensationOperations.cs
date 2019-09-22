using System;

namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Interface describing the operation with compensatory operation
    /// </summary>
    public interface ICompensationOperations
    {
        /// <summary>
        /// Run compensation operations
        /// </summary>
        void Compensate();
        /// <summary>
        /// Add compensation
        /// </summary>
        /// <param name="compansation"></param>
        void AddCompensation(Action compansation);
        /// <summary>
        /// Clear compensation
        /// </summary>
        void ClearCompensation();
    }
}
