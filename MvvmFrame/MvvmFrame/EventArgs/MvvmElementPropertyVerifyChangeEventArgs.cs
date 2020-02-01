using GetcuReone.MvvmFrame.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GetcuReone.MvvmFrame.EventArgs
{
    /// <summary>
    /// Parameters of the event of verification of a change in the model property
    /// </summary>
    public class MvvmElementPropertyVerifyChangeEventArgs : PropertyChangedEventArgs
    {
        private readonly List<MvvmFrameErrorDetail> _errors = new List<MvvmFrameErrorDetail>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">property name</param>
        public MvvmElementPropertyVerifyChangeEventArgs(string propertyName) : base(propertyName) { }

        /// <summary>
        /// True - event valid. It is not valid if there is at least one error
        /// </summary>
        public bool IsValid => _errors.Count == 0;

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="detail"></param>
        public void AddError(MvvmFrameErrorDetail detail) => _errors.Add(detail);
        /// <summary>
        /// Remove error
        /// </summary>
        /// <param name="detail"></param>
        public void RemoveError(MvvmFrameErrorDetail detail) => _errors.Remove(detail);

        /// <summary>
        /// Return list erors
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<MvvmFrameErrorDetail> GetErrors() => new ReadOnlyCollection<MvvmFrameErrorDetail>(_errors);
    }
}
