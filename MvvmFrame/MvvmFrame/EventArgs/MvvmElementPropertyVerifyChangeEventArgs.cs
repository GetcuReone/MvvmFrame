using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvvmFrame.EventArgs
{
    /// <summary>
    /// Parameters of the event of verification of a change in the model property
    /// </summary>
    public class MvvmElementPropertyVerifyChangeEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">property name</param>
        public MvvmElementPropertyVerifyChangeEventArgs(string propertyName) : base(propertyName) { }

        /// <summary>
        /// True - event valid. It is not valid if there is at least one error
        /// </summary>
        public bool IsValid => _errorFuncs.Count == 0;

        /// <summary>
        /// For internal use
        /// </summary>
        public List<Func<string>> _errorFuncs { get; } = new List<Func<string>>();

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="getErrorMessage">func creation error message</param>
        public void AddError(Func<string> getErrorMessage) => _errorFuncs.Add(getErrorMessage);
        /// <summary>
        /// Remove error
        /// </summary>
        /// <param name="getErrorMessage">func creation error message</param>
        public void RemoveError(Func<string> getErrorMessage) => _errorFuncs.Remove(getErrorMessage);
    }
}
