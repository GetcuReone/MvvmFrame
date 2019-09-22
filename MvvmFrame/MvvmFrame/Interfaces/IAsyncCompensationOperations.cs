using System;
using System.Threading.Tasks;

namespace MvvmFrame.Interfaces
{
    /// <summary>
    /// Interface describing the operation with compensatory operation
    /// </summary>
    public interface IAsyncCompensationOperations
    {
        /// <summary>
        /// Run compensation operations
        /// </summary>
        ValueTask Compensate();
        /// <summary>
        /// Add compensation
        /// </summary>
        /// <param name="compansation"></param>
        void AddCompensation(Func<ValueTask> compansation);
        /// <summary>
        /// Clear compensation
        /// </summary>
        void ClearCompensation();
    }
}
